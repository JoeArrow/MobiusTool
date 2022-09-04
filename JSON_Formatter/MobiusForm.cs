#region © 2019 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Configuration;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Web.Script.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using JsonToTreeView;
using AboutJoeWare_Lib;
using JsonToTreeView.Exporters;

namespace JSON_Formatter
{
    public partial class MobiusForm : Form
    {
        public MobiusForm()
        {
            InitializeComponent();

            Size = Properties.Settings.Default.Size;
            Location = Properties.Settings.Default.Location;
            SetPathFinder(Properties.Settings.Default.PathFinder);
            jTree.SplitDist = Properties.Settings.Default.SplitDist;
            tbFileName.Text = Properties.Settings.Default.InitialPath;
            jTree.Orientation = Properties.Settings.Default.Orientation;
            jTree.LoadExpanded = Properties.Settings.Default.LoadExpanded;

            if(!Directory.Exists(tbFileName.Text)) { tbFileName.Text = Properties.Settings.Default.DefaultPath; }

            tcTabs.TabAddedEvent += OnTabAdded;

            jTree.NodeClickedEvent += OnNodeClicked;
            jTree.DecompositionExportedEvent += OnDataDecomposition;
            jTree.EvenSplit();
        }

        // ------------------------------------------------

        public MobiusForm(string fileName)
            : this()
        {
            LoadFile(fileName);
        }

        // ------------------------------------------------
        public void NewInstance(string fileName = null)
        {
            WindowState = FormWindowState.Normal;

            if(!string.IsNullOrEmpty(fileName))
            {
                LoadFile(fileName);
            }

            Focus();
        }

        // ------------------------------------------------

        public void LoadFile(string fileName)
        {
            Cursor = Cursors.WaitCursor;
            TabPage page = null;

            LoadConstants(fileName);

            if(string.IsNullOrEmpty(tcTabs.SelectedTab.JTree().JSON))
            {
                page = tcTabs.SelectedTab;
                page.Text = Path.GetFileName(fileName);

                using(var streamReader = File.OpenText(fileName))
                {
                    page.JTree().ProcessJSON(streamReader.ReadToEnd(), "json");
                }
            }
            else
            {
                page = tcTabs.AddTab("", Path.GetFileNameWithoutExtension(fileName));
            }

            page.JTree().EvenSplit();
            page.Tag = Path.GetFileName(fileName);

            tbFileName.Text = fileName;

            // ----------------------------------
            // Load the JSON, and then format it.

            using(var streamReader = File.OpenText(fileName))
            {
                (page.JTree()).ProcessJSON(streamReader.ReadToEnd(), "json");
            }

            Cursor = Cursors.Default;
        }

        // ------------------------------------------------

        private void SetPathFinder(string pathFinder)
        {
            // ------------------------------------------
            // Handle which item should be checked now...

            foreach(ToolStripMenuItem item in PathFinderMenuItem.DropDownItems)
            {
                item.Checked = pathFinder.Equals(item.Text);
            }

            // ----------------------------------------
            // Set the PathFinder algorithm accordingly

            jTree.SetPathFinder(pathFinder);
            Properties.Settings.Default.PathFinder = pathFinder;
            Properties.Settings.Default.Save();
        }

        // ------------------------------------------------

        private void SetExporter(string name)
        {
            // ------------------------------------------
            // Handle which item should be checked now...

            foreach(ToolStripMenuItem item in ExporterMenuItem.DropDownItems)
            {
                item.Checked = name.Equals(item.Text, StringComparison.CurrentCultureIgnoreCase);
            }

            jTree.Exporter = ExporterFactory.GetExporter(name);
            Properties.Settings.Default.Exporter = name;
            Properties.Settings.Default.Save();
        }

        // ------------------------------------------------

        private void LoadConstants(string fullName)
        {
            var ser = new JavaScriptSerializer();
            var path = Path.GetDirectoryName(fullName);
            var ext = Properties.Settings.Default.ConstExtension;
            var name = Path.GetFileNameWithoutExtension(fullName);

            var constFile = Path.Combine(path, $"{name}.{ext}");
            Properties.Settings.Default.ConstantsPath = path;
            Properties.Settings.Default.Save();

            if(File.Exists(constFile))
            {
                // --------------------------------------------------
                // Load the constants to the currently selected jTree

                var content = File.ReadAllText(constFile);
                ((JTree)tcTabs.SelectedTab.Controls[0]).Constants = ser.Deserialize<string[]>(content);
            }
        }

        // ------------------------------------------------

        private void OnLoadJson(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog()
            {
                InitialDirectory = tbFileName.Text,
                Filter = ConfigurationManager.AppSettings["SearchFilter"]
            };

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                LoadFile(dlg.FileName);

                Properties.Settings.Default.InitialPath = Path.GetDirectoryName(dlg.FileName);
                Properties.Settings.Default.Save();
            }
        }

        // ------------------------------------------------

        private void OnSave(object sender, EventArgs e)
        {
            var jtree = tcTabs.SelectedTab.Controls[0] as JTree;

            if(jtree != null && !string.IsNullOrEmpty(jtree.JSON))
            {
                var fileName = jtree.SaveJSON(tbFileName.Text);

                if(!string.IsNullOrEmpty(fileName))
                {
                    tcTabs.SelectedTab.Text = Path.GetFileNameWithoutExtension(fileName);
                    tbFileName.Text = fileName;
                }
            }
        }

        // ------------------------------------------------

        private void OnAbout(object sender, EventArgs e)
        {
            using(var dlg = new AboutJoeWareDlg())
            {
                dlg.ShowDialog();
            }
        }

        // ------------------------------------------------

        private void OnDataDecomposition(object sender, EventArgs e)
        {
            var args = e as DecompositionEventArgs;

            if(args != null && !string.IsNullOrEmpty(args.DecomposedData))
            {
                jTree = tcTabs.AddTab(args.DecomposedData, "Decomposed Node").JTree();
                jTree.ProcessJSON(args.DecomposedData, "json");
            }
        }

        // ------------------------------------------------

        private void OnNodeClicked(object sender, EventArgs e)
        {
            var args = e as NodeClickedEventArgs;

            if(args != null && !string.IsNullOrEmpty(args.NodePath))
            {
                lblNodePath.Text = args.NodePath;
            }
        }

        // ------------------------------------------------

        private void OnTabAdded(object sender, EventArgs e)
        {
            var jtree = sender as JTree;

            if(jtree != null)
            {
                jtree.AllowDrop = true;
                jtree.NodeClickedEvent += OnNodeClicked;
                jtree.DragDrop += new DragEventHandler(OnFileDrop);
                jtree.DragEnter += new DragEventHandler(OnDragEnter);
                jtree.DecompositionExportedEvent += OnDataDecomposition;
            }
        }

        // ------------------------------------------------

        private void OnPathFinderSelection(object sender, EventArgs e)
        {
            var selection = sender as ToolStripMenuItem;

            if(selection != null)
            {
                SetPathFinder(selection.Text);
            }
        }

        // ------------------------------------------------

        private void OnExporterSelection(object sender, EventArgs e)
        {
            var selection = sender as ToolStripMenuItem;

            if(selection != null)
            {
                SetExporter(selection.Text);
            }
        }

        // ------------------------------------------------

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        // ------------------------------------------------

        private void OnFileDrop(object sender, DragEventArgs e)
        {
            var fileNames = (string[]) e.Data.GetData(DataFormats.FileDrop, false);

            if(fileNames.Length > 0)
            {
                tbFileName.Text = fileNames[0];
                tcTabs.SelectedTab.Text = Path.GetFileNameWithoutExtension(tbFileName.Text);

                Cursor = Cursors.WaitCursor;

                // ----------------------------------
                // Load the JSON, and then format it.

                using(var streamReader = File.OpenText(tbFileName.Text))
                {
                    ((JTree)tcTabs.SelectedTab.Controls[0]).ProcessJSON(streamReader.ReadToEnd(), "json");
                }

                Cursor = Cursors.Default;
            }
        }

        // ------------------------------------------------

        private void OnTokenizeJSON(object sender, EventArgs e)
        {
            jTree = (JTree)tcTabs.SelectedTab.Controls[0];

            if(string.IsNullOrEmpty(jTree.JSON))
            {
                MessageBox.Show("There seems to be no JSON available to Tokenize!", "Hmmmm!");
            }
            else
            {
                Cursor = Cursors.WaitCursor;

                try
                {
                    var tokenized = jTree.Tokenize();

                    jTree = tcTabs.AddTab(tokenized, "Tokenized").JTree();
                    jTree.ProcessJSON(tokenized, "json");
                }
                catch(Exception exp)
                {
                    var cr = Environment.NewLine;
                    MessageBox.Show($"{exp.Message}{cr}{cr}Please make sure that there are no Tokens already in the JSON text.",
                                     "Failed to Parse JSON");
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        // ------------------------------------------------

        private void OnLoadConstants(object sender, EventArgs e)
        {
            var ext = Properties.Settings.Default.ConstExtension;
            var path = Properties.Settings.Default.ConstantsPath;

            var dlg = new OpenFileDialog()
            {
                InitialDirectory = path,
                Filter = $"Token Constants (*.{ext})|*.{ext}|All Files (*.*)|*.*"
            };

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                LoadConstants(dlg.FileName);
            }
        }

        // ------------------------------------------------

        private void OnCreateTokenConstants(object sender, EventArgs e)
        {
            var tokens = new List<string>();
            var json = ((JTree)tcTabs.SelectedTab.Controls[0]).JSON;

            if(!string.IsNullOrEmpty(json))
            {
                try
                {
                    var obj = JToken.Parse(json) as JObject;

                    if(obj != null)
                    {
                        // -----------------------------
                        // I Need some recursion here...

                        foreach(var token in GetProperties(obj))
                        {
                            if(!tokens.Contains(token))
                            {
                                tokens.Add(token);
                            }
                        }

                        tokens.Sort();
                    }
                }
                catch
                {
                    MessageBox.Show("Failed to create Constants for the input text!", "Failure!");
                }

                if(tokens.Count > 0)
                {
                    var allTokens = JsonConvert.SerializeObject(tokens);

                    jTree = tcTabs.AddTab(allTokens, "Token Constants").JTree();
                    jTree.ProcessJSON(allTokens, "json");
                }
            }
        }

        // ------------------------------------------------

        private void OnFormClose(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Size = Size;
            Properties.Settings.Default.Location = Location;
            Properties.Settings.Default.SplitDist = jTree.SplitDist;
            Properties.Settings.Default.Orientation = jTree.Orientation;
            Properties.Settings.Default.LoadExpanded = jTree.LoadExpanded;

            if(!string.IsNullOrEmpty(tbFileName.Text))
            {
                Properties.Settings.Default.InitialPath = Path.GetDirectoryName(tbFileName.Text);
            }

            Properties.Settings.Default.Save();
        }

        // ------------------------------------------------

        private void OnClickFileName(object sender, EventArgs e)
        {
            tbFileName.SelectAll();
        }

        // ------------------------------------------------

        private void OnNewJSON(object sender, EventArgs e)
        {
            tcTabs.AddTab("{ }", "JSON Tab");
        }

        // ------------------------------------------------

        private void OnNodePathLabelClick(object sender, MouseEventArgs e)
        {
            var label = sender as Label;

            if(label != null)
            {
                Clipboard.SetText(label.Text);
            }
        }

        // ------------------------------------------------

        private void OnTabSelect(object sender, TabControlEventArgs e)
        {
            var tab = sender as TabControl;

            if(tab != null)
            {
                var fileName = tab.SelectedTab.Text;

                if(!(fileName.StartsWith("JSON Tab") || fileName.StartsWith("New Tab")))
                {
                    tbFileName.Text = fileName;
                }
            }
        }

        // ------------------------------------------------

        private List<string> GetProperties(JToken token)
        {
            var obj = token as JObject;
            var array = token as JArray;
            var prop = token as JProperty;
            var retVal = new List<string>();

            if(obj != null)
            {
                // ----------------------------------------
                // With a JObject, we need to handle all of
                // the properties...

                foreach(var property in obj.Properties())
                {
                    if(!retVal.Contains(property.Name))
                    {
                        retVal.Add(property.Name);
                    }

                    retVal.AddRange(GetProperties(property));
                }
            }
            else if(prop != null)
            {
                retVal.AddRange(GetProperties(prop.Value));
            }
            else if(array != null)
            {
                foreach(var element in array)
                {
                    retVal.AddRange(GetProperties(element));
                }
            }

            return retVal;
        }
    }
}