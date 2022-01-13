#region © 2019 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Configuration;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ScintillaNET;
using JWSortable;
using TreePathFinder;
using JSON.String.Extensions;
using JsonToTreeView.Exporters;

namespace JsonToTreeView
{
    public partial class JTree : UserControl
    {
        private readonly string cr = Environment.NewLine;

        // -----------------------------------------
        // Indicators 0-7 could be in use by a lexer
        // so we'll use indicator 8 to highlight words.

        const int HIGHLIGHT = 8;

        [ExcludeFromCodeCoverage]
        public string FileName { set; get; }

        [ExcludeFromCodeCoverage]
        public string[] Constants { set; get; }

        [ExcludeFromCodeCoverage]
        public IExporter Exporter { set; get; }

        public int CurrentLine { get; set; }
        public int CurrentColumn { get; set; }

        [ExcludeFromCodeCoverage]
        private IPathFinder PathFinder { set; get; } = new NodePathFinder();

        private List<JTree> SplitSyncTargets = new List<JTree>();
        public TreeNode RootNode { get { return tvJSON.Nodes.Count > 0 ? tvJSON.Nodes[0] : null; } }

        internal TreeView tvJSON { get { return trvJSON; } }
        internal Scintilla tbJSON { get { return sciJSON; } }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        public string JSON
        {
            set { sciJSON.Text = value; }
            get { return FixupJSON(sciJSON.Text, false); }
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        public int SplitDistance
        {
            set { sptContainer.SplitterDistance = value; }
            get { return sptContainer.SplitterDistance; }
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        public bool LoadExpanded
        {
            set { cbExpand.Checked = value; }
            get { return cbExpand.Checked; }
        }

        // ------------------------------------------------

        public string[] AvailablePathFinders
        {
            get
            {
                return Enum.GetNames(typeof(eAvailablePathFinders));
            }
        }

        // ------------------------------------------------
        /// <summary>
        ///     Default Constructor
        /// </summary>

        public JTree()
        {
            InitializeComponent();

            JSONStyle();
            LineNumberStyle();
            CodeFoldingStyle();

            Constants = new string[0];
            searchTool = new SearchTool(this);
            lblNodesFound.Text = string.Empty;
            sciJSON.ContextMenu = BuildJSONContextMenu();
            Exporter = ExporterFactory.GetExporter("Default");
        }

        // ------------------------------------------------
        /// <summary>
        ///     Overloaded Constructor allowing a command
        ///     line argument or two
        /// </summary>
        /// <param name="json"></param>
        /// <param name="rootName"></param>

        public JTree(string json, string rootName = "json")
            : this()
        {
            ProcessJSON(json, rootName);
        }

        // ------------------------------------------------
        /// <summary>
        ///     Use the name of a PathFinder to set the object
        /// </summary>
        /// <param name="pathFinder"></param>

        [ExcludeFromCodeCoverage]
        public void SetPathFinder(string pathFinder)
        {
            PathFinder = PathFinderFactory.GetPathFinder(pathFinder);
        }

        // ------------------------------------------------

        public void ProcessJSON(string json, string rootName)
        {
            sciJSON.Text = json;
            sciJSON.Tag = false;
            lblNodesFound.Text = string.Empty;

            if(FormatJSON(true))
            {
                try
                {
                    BuildTree(JToken.Parse(sciJSON.Text), rootName);
                }
                catch(Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        // ------------------------------------------------

        public string Tokenize()
        {
            return JSON.Tokenize(Constants);
        }

        // ------------------------------------------------

        public string Tokenize(string[] constants)
        {
            Constants = constants;
            return JSON.Tokenize(Constants);
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        public string SaveJSON(string fileName = "")
        {
            var retVal = string.Empty;

            if(!string.IsNullOrWhiteSpace(fileName))
            {
                fileName = Path.GetFileName(fileName);
            }

            var dlg = new SaveFileDialog()
            {
                FileName = fileName,
                OverwritePrompt = false,
                Filter = ConfigurationManager.AppSettings["SearchFilter"]
            };

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                retVal = Path.GetFileNameWithoutExtension(dlg.FileName);
                File.WriteAllText(dlg.FileName, JSON);
                FileName = dlg.FileName;
            }

            return retVal;
        }

        // ------------------------------------------------

        private Color EnumToColor(eColorConstant colorConst)
        {
            var rgb = (int)colorConst;
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        // ------------------------------------------------

        private void BuildTree(JToken root, string rootName)
        {
            trvJSON.BeginUpdate();
            trvJSON.Nodes.Clear();

            Cursor = Cursors.WaitCursor;

            // -------------------------------------
            // Create a root node to anchor the tree

            var node = new TreeNode(rootName);
            var tNode = trvJSON.Nodes[trvJSON.Nodes.Add(node)];
            tNode.ContextMenu = BuildNodeContextMenu(node);

            // ---------------------------------------------
            // AddNode() is recursive, and will traverse the 
            // entire JSON adding nodes.

            AddNode(root, tNode);

            // --------------------------------------------
            // Determine whether or not to expand the nodes

            if(cbExpand.Checked)
            {
                tNode.ExpandAll();
            }
            else
            {
                tNode.Expand();
            }

            trvJSON.EndUpdate();
            Cursor = Cursors.Default;
        }

        // ------------------------------------------------
        /// <summary>
        ///     Recursive Method...
        /// </summary>
        /// <param name="token"></param>
        /// <param name="parentNode"></param>

        private void AddNode(JToken token, TreeNode parentNode)
        {
            if(token != null)
            {
                if(token is JValue)
                {
                    // --------------------------------
                    // With a JValue, we are at a leaf.
                    // No recursion necessary

                    var val = token.ToString();
                    var node = new TreeNode(string.IsNullOrEmpty(val) ? "<Not Set>" : val) { Tag = token as JValue };

                    var childNode = parentNode.Nodes[parentNode.Nodes.Add(node)];

                    // ----------------------
                    // Simple color coding...

                    if(string.IsNullOrEmpty(val))
                    {
                        node.ForeColor = Color.Red;
                        parentNode.ForeColor = Color.Red;
                    }
                    else if(val.StartsWith("{{"))
                    {
                        node.ForeColor = Color.Blue;
                        parentNode.ForeColor = Color.Blue;
                    }

                    childNode.ContextMenu = BuildNodeContextMenu(node);
                }
                else if(token is JObject)
                {
                    // ----------------------------------------
                    // With a JObject, we need to handle all of
                    // the properties...

                    var obj = token as JObject;

                    foreach(var property in obj.Properties())
                    {
                        var node = new TreeNode(property.Name) { Tag = obj };

                        var childNode = parentNode.Nodes[parentNode.Nodes.Add(node)];

                        childNode.ContextMenu = BuildNodeContextMenu(node);

                        // ---------
                        // Recursion

                        AddNode(property.Value, childNode);
                    }
                }
                else if(token is JArray)
                {
                    // -------------------------------------
                    // With a JArray, we need to handle each
                    // of the elements.

                    var array = token as JArray;

                    for(int index = 0; index < array.Count; index++)
                    {
                        var node = new TreeNode($"[{index.ToString()}]")
                        {
                            Tag = array
                        };

                        var childNode = parentNode.Nodes[parentNode.Nodes.Add(node)];

                        node.ForeColor = Color.Green;
                        parentNode.ForeColor = Color.Green;

                        childNode.ContextMenu = BuildNodeContextMenu(node);

                        // ---------
                        // Recursion

                        AddNode(array[index], childNode);
                    }
                }
            }
        }

        // ------------------------------------------------
        /// <summary>
        ///     Context Menu for the Treeview
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>

        private ContextMenu BuildNodeContextMenu(TreeNode node)
        {
            var copyNodeValue = new MenuItem("Copy");
            copyNodeValue.Click += OnCopyNodeValue;
            copyNodeValue.Tag = node;

            var findNodeItem = new MenuItem("Search");
            findNodeItem.Tag = node;
            findNodeItem.Click += OnSearch;

            var toggleExpNodeItem = new MenuItem("Toggle Node Expansion");
            toggleExpNodeItem.Tag = node;
            toggleExpNodeItem.Click += OnToggleExpansion;

            var copyNodeItem = new MenuItem("Copy Node Path");
            copyNodeItem.Click += OnCopyNodePath;
            copyNodeItem.Tag = node;

            var copyArrayItem = new MenuItem("Copy Array Path");
            copyArrayItem.Click += OnCopyArrayPath;
            copyArrayItem.Tag = node;

            var CopyPathMenuItem = new MenuItem("Copy Path");
            CopyPathMenuItem.MenuItems.Add(copyNodeItem);
            CopyPathMenuItem.MenuItems.Add(copyArrayItem);

            var decomposeNodeItem = new MenuItem("Decompose Node");
            decomposeNodeItem.Tag = node;
            decomposeNodeItem.Click += OnDecomposeNode;

            var listTokensNode = new MenuItem("List Tokens");
            listTokensNode.Click += OnListTokens;

            return new ContextMenu(new MenuItem[]
            {
                copyNodeValue,
                findNodeItem,
                toggleExpNodeItem,
                CopyPathMenuItem,
                decomposeNodeItem,
                listTokensNode
            });
        }

        // ------------------------------------------------
        /// <summary>
        ///     Build the Context Menu for the JSON String
        /// </summary>
        /// <returns></returns>

        private ContextMenu BuildJSONContextMenu()
        {
            var newJsonItem = new MenuItem("New JSON");
            newJsonItem.Click += OnNewJSON;

            var buildItem = new MenuItem("Build The Tree");
            buildItem.Click += OnBuildTree;

            var fixupJSONItem = new MenuItem("Fixup JSON");
            fixupJSONItem.Click += OnFixupJSON;

            var searchFromJSONItem = new MenuItem("Search");
            searchFromJSONItem.Click += OnJSONSearch;

            var listTokensNode = new MenuItem("List Tokens");
            listTokensNode.Click += OnListTokens;

            var copyItem = new MenuItem("Copy Selected Text");
            copyItem.Click += OnCopySelected;

            var replaceValueItem = new MenuItem("Replace Value");
            replaceValueItem.Click += OnReplaceValue;

            var formatJsonItem = new MenuItem("Toggle JSON Format");
            formatJsonItem.Click += OnFormatJSON;

            var retVal = new ContextMenu(new MenuItem[]
            {
                searchFromJSONItem,
                copyItem,
                formatJsonItem,
                newJsonItem,
                buildItem,
                replaceValueItem,
                fixupJSONItem,
                listTokensNode
            });

            return retVal;
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void CopyNodePath(TreeNode node)
        {
            if(node != null && PathFinder != null)
            {
                // --------------------------------------------------
                // If node.Nodes.Count == 0, then this is a leaf node
                // It has no children...

                Clipboard.SetText(PathFinder.GetPath(node.FullPath, node.Nodes.Count == 0));
            }
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void CopyArrayPath(TreeNode node)
        {
            if(node != null && PathFinder != null)
            {
                Clipboard.SetText(PathFinder.GetArrayPath("json", node.FullPath));
            }
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void Search(TreeNode node)
        {
            if(node != null && tvJSON.Nodes.Count > 0)
            {
                using(var dlg = new SearchDialog())
                {
                    if(dlg.ShowDialog() == DialogResult.OK)
                    {
                        Clipboard.SetText(dlg.SearchTerm);
                        lblNodesFound.Text = $"Found: {searchTool.Search(node, dlg.SearchTerm)}";
                    }
                }
            }
        }

        // ------------------------------------------------

        private void CopyText()
        {
            var json = string.Empty;

            // ---------------------------------------
            // If text is selected, use the selection,
            // otherwise use the full text

            if(string.IsNullOrEmpty(sciJSON.SelectedText))
            {
                json = sciJSON.Text;
            }
            else
            {
                json = sciJSON.SelectedText;
            }

            if(!string.IsNullOrEmpty(json))
            {
                var regEx = new Regex("\"{{\\w+}}\"");
                var matches = regEx.Matches(json);
                var processed = new StringCollection();

                foreach(var cap in matches)
                {
                    if(!processed.Contains(cap.ToString()))
                    {
                        json = Regex.Replace(json, cap.ToString(), cap.ToString().Replace("\"{{", "{{").Replace("}}\"", "}}"));
                        processed.Add(cap.ToString());
                    }
                }

                Clipboard.SetText(json);
            }
        }

        // ------------------------------------------------

        public void NewJSON()
        {
            OnNewJSON(null, null);
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void PasteText()
        {
            trvJSON.Nodes.Clear();
            sciJSON.Tag = false;
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnCopyNodeValue(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            var node = item.Tag as TreeNode;

            if(node != null)
            {
                Clipboard.SetText(node.Text);
            }
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnCopyNodePath(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            var node = item.Tag as TreeNode;

            CopyNodePath(node);
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnCopyArrayPath(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            var node = item.Tag as TreeNode;

            CopyArrayPath(node);
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnToggleExpansion(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            TreeNode node = tvJSON.SelectedNode ?? tvJSON.Nodes[0];

            if(item != null)
            {
                node = item.Tag as TreeNode;
            }

            Cursor = Cursors.WaitCursor;

            if(node != null)
            {
                if(node.IsExpanded)
                {
                    node.Collapse();
                }
                else
                {
                    trvJSON.BeginUpdate();
                    node.ExpandAll();
                    trvJSON.EndUpdate();
                }

                trvJSON.SelectedNode = node;

                if(trvJSON.SelectedNode.FirstNode != null)
                {
                    trvJSON.SelectedNode.EnsureVisible();
                }
            }

            Cursor = Cursors.Default;
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnJSONSearch(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(sciJSON.SelectedText))
            {
                lblNodesFound.Text = $"Found: {searchTool.Search(trvJSON.Nodes[0], sciJSON.SelectedText)}";
            }
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnFullTreeSearch(object sender, EventArgs e)
        {
            if(tvJSON.Nodes.Count > 0)
            {
                using(var dlg = new SearchDialog())
                {
                    if(dlg.ShowDialog() == DialogResult.OK)
                    {
                        Clipboard.SetText(dlg.SearchTerm);
                        lblNodesFound.Text = $"Found: {searchTool.Search(tvJSON.Nodes[0], dlg.SearchTerm)}";
                    }
                }
            }
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnDecomposeNode(object sender, EventArgs e)
        {
            var output = new StringBuilder();
            var item = sender as MenuItem;

            if(item != null)
            {
                var node = item.Tag as TreeNode;
                var items = new SortableBindingList<DecomposedItem>();

                if(node != null)
                {
                    if(node.Nodes.Count > 0)
                    {
                        foreach(TreeNode child in node.Nodes)
                        {
                            if(child.Nodes.Count > 0)
                            {
                                items.Add(new DecomposedItem()
                                {
                                    Id = child.Nodes.Count > 0 && child.Nodes[0].Nodes.Count > 0 ? child.Nodes[0].Nodes[0].Text : string.Empty,
                                    Key = child.Nodes.Count > 1 && child.Nodes[1].Nodes.Count > 0 ? child.Nodes[1].Nodes[0].Text : string.Empty,
                                    Value = child.Nodes.Count > 2 && child.Nodes[2].Nodes.Count > 0 ? child.Nodes[2].Nodes[0].Text : string.Empty,
                                    DataType = child.Nodes.Count > 3 && child.Nodes[3].Nodes.Count > 0 ? child.Nodes[3].Nodes[0].Text : string.Empty
                                });
                            }
                        }
                    }
                    else
                    {
                        output.Append(node.Text);
                    }

                    using(var dlg = new DecompositionDialog(node.Text, Exporter, items))
                    {
                        if(dlg.ShowDialog() == DialogResult.Yes)
                        {
                            DecompositionExportedEvent?.Invoke(this, new DecompositionEventArgs(dlg.DecomposedData));
                        }
                    }
                }
            }
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnNodeClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            NodeClickedEvent?.Invoke(this, new NodeClickedEventArgs(e.Node.FullPath));
        }

        // ------------------------------------------------

        private void OnNodeDoubleClick(object sender, MouseEventArgs e)
        {
            //var tree = sender as TreeView;
            //var node = tree.SelectedNode;

            //searchTool.Search(node, node.Text);
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnSearch(object sender, EventArgs e)
        {
            var item = sender as MenuItem;

            if(item != null)
            {
                Search(item.Tag as TreeNode);
            }
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnListTokens(object sender, EventArgs e)
        {
            var r = new Regex("{{\\w+}}");

            var matches = r.Matches(sciJSON.Text);
            var tokens = new List<string>();

            foreach(var match in matches)
            {
                var current = match.ToString().Substring(2, match.ToString().Length - 4);

                if(!tokens.Contains(current))
                {
                    tokens.Add(current);
                }
            }

            tokens.Sort();

            var items = new SortableBindingList<TokenDTO>();

            foreach(var token in tokens)
            {
                items.Add(new TokenDTO() { Token = token });
            }

            using(var dlg = new TokenDialog(items))
            {
                dlg.Text = "Unique Tokens Found";
                dlg.ShowDialog();
            }
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnCopySelected(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(sciJSON.SelectedText))
            {
                Clipboard.SetText(sciJSON.SelectedText);
            }
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnBuildTree(object sender, EventArgs e)
        {
            ProcessJSON(sciJSON.Text, "json");
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnFormatJSON(object sender, EventArgs e)
        {
            if(sciJSON.Tag != null)
            {
                FormatJSON(!(bool)sciJSON.Tag);
            }
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnReplaceValue(object sender, EventArgs e)
        {
            var searchTerm = sciJSON.SelectedText;

            using(var dlg = new ReplaceValueDialog(searchTerm))
            {
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    // -----------------------------------------
                    // The user MAY have changed the search term

                    searchTerm = dlg.SearchValue;
                    var replacementTerm = dlg.NewValue;

                    sciJSON.Text = sciJSON.Text.Replace(searchTerm, replacementTerm);

                    ProcessJSON(sciJSON.Text, "json");
                }
            }
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnNewJSON(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(sciJSON.Text))
            {
                trvJSON.Nodes.Clear();
                sciJSON.Text = "{  }";
            }
            else
            {
                var result = MessageBox.Show("Save Existing JSON?", "Save Your Work?", MessageBoxButtons.YesNoCancel);

                switch(result)
                {
                    case DialogResult.Yes:

                        SaveJSON();

                        trvJSON.Nodes.Clear();
                        sciJSON.Text = "{  }";
                        break;

                    case DialogResult.No:

                        trvJSON.Nodes.Clear();
                        sciJSON.Text = "{  }";
                        break;

                    default:
                        // Do Nothing !!
                        break;
                }
            }
        }

        // ------------------------------------------------

        private void OnCaretPositionChange(object sender, UpdateUIEventArgs e)
        {
            var scintilla = sender as Scintilla;

            lblLine.Text = (scintilla.CurrentLine + 1).ToString();
            lblColumn.Text = scintilla.GetColumn(scintilla.CurrentPosition).ToString();
        }

        // ------------------------------------------------

        private bool FormatJSON(bool pretty)
        {
            bool retVal;
            sciJSON.Tag = pretty;
            var token = null as JToken;

            sciJSON.ScrollWidth = 1;
            sciJSON.ScrollWidthTracking = true;

            try
            {
                token = JToken.Parse(sciJSON.Text);
                retVal = true;
            }
            catch(Exception exp)
            {
                retVal = false;
                trvJSON.Nodes.Clear();

                MessageBox.Show(exp.Message);
            }

            if(retVal)
            {
                var json = token.ToString(pretty ? Formatting.Indented : Formatting.None);

                if(pretty)
                {
                    sciJSON.Text = json;
                    BuildTree(JToken.Parse(json), "json");
                }
                else
                {
                    sciJSON.Text = json.Replace("\"'", "'")
                                       .Replace("'\"", "'")
                                       .Replace("\"", "'");
                }
            }

            return retVal;
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void SyncTargets(object sender, SplitterEventArgs e)
        {
            foreach(var target in SplitSyncTargets)
            {
                target.SplitDistance = sptContainer.SplitterDistance;
            }
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        public void OnFixupJSON(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tbJSON.Text))
            {
                tbJSON.Text = FixupJSON(tbJSON.Text, true);
                OnBuildTree(null, null);
            }
        }

        // ------------------------------------------------
        /// <summary>
        ///     Fixup JSON which may contain Postman Variables
        /// </summary>
        /// <param name="json"></param>

        private string FixupJSON(string json, bool protectVars)
        {
            Regex r;

            if(protectVars)
            {
                r = new Regex("{{\\w+}}");
            }
            else
            {
                r = new Regex("\"{{\\w+}}\"");
            }

            var matches = r.Matches(json);
            var processed = new StringCollection();

            foreach(var match in matches)
            {
                // ------------------------------------------------------------------------------
                // Since we are using RegexReplace, we are fixing up all of a given token at once
                // We store that token so that we know not to process it again

                if(!processed.Contains(match.ToString()))
                {
                    json = Regex.Replace(json, match.ToString(), protectVars ? $"\"{match.ToString()}\"" : match.ToString().Replace("\"", ""));
                    processed.Add(match.ToString());
                }
            }

            return json;
        }

        // ------------------------------------------------
        /// <summary>
        ///     F3 for Next
        ///     Shift + F3 for Previous
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        [ExcludeFromCodeCoverage]
        private void OnTreeKeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case (Keys.Control | Keys.F3):
                case (Keys.Control | Keys.F):
                    Search(trvJSON.Nodes[0]);
                    break;

                case (Keys.None | Keys.F3):
                    searchTool.Next();
                    break;

                case (Keys.Shift | Keys.F3):
                    searchTool.Previous();
                    break;

                case (Keys.Control | Keys.C):
                    Clipboard.SetText(trvJSON.SelectedNode.Text);
                    break;
            }
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnTreeKeyUp(object sender, KeyEventArgs e)
        {
            if(e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                // ----
                // Copy 

                var tree = sender as TreeView;
                var node = tree.SelectedNode;

                if(node != null)
                {
                    Clipboard.SetText(node.Text);
                }
            }
            else if(e.Modifiers == Keys.Control && e.KeyCode == Keys.P)
            {
                // -----
                // Paste

                var tree = sender as TreeView;
                var node = tree.SelectedNode;

                if(node != null)
                {
                    CopyNodePath(node);
                }
            }
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnTextKeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case Keys.Escape:
                    sciJSON.IndicatorCurrent = HIGHLIGHT;
                    sciJSON.IndicatorClearRange(0, sciJSON.TextLength);
                    break;

                case (Keys.Control | Keys.C):
                    CopyText();
                    break;

                case (Keys.Control | Keys.V):
                    PasteText();
                    break;

                case (Keys.Control | Keys.S):
                    SaveJSON();
                    break;
            }
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnJSONTextChange(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(sciJSON.Text))
            {
                trvJSON.Nodes.Clear();
            }

            // ---------------------------------------------------------------
            // Did the number of characters in the line number display change?
            // i.e. nnn VS nn, or nnnn VS nn, etc...

            var columnWidth = sciJSON.Lines.Count.ToString().Length;

            if(columnWidth != maxLineNumberwidth)
            {
                maxLineNumberwidth = columnWidth;

                // ------------------------------------------------------------
                // Calculate the width required to display the last line number
                // and include some padding for good measure.

                const int paddingLeft = 2;

                sciJSON.Margins[LINENUMBER_MARGIN].Width = sciJSON.TextWidth(Style.LineNumber, new string('9', maxLineNumberwidth + paddingLeft));
            }
        }

        // ------------------------------------------------

        private void OnClearJSON(object sender, EventArgs e)
        {
            // ------------------------------------------------------
            // If the JSON Textbox is empty, we have nothing to fear.

            if(string.IsNullOrEmpty(tbJSON.Text) || MessageBox.Show($"All JSON in this tab will be lost!{cr}Are You Sure?", "Are You Sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tbJSON.Text = "{'':''}";
                tbJSON.Tag = false;
            }
        }

        // ------------------------------------------------

        private void OnLoadExpandedToggle(object sender, EventArgs e)
        {
            sciJSON.Tag = false;
        }
    }
}
