#region © 2019 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics.CodeAnalysis;

using Newtonsoft.Json.Linq;

namespace JsonToTreeView
{
    public class Json2Tree
    {
        private readonly TreeView treeView;
        private readonly SearchTool treeSearch = new SearchTool();

        // ------------------------------------------------

        public Json2Tree(ref TreeView tv)
        {
            treeView = tv;
        }

        // ------------------------------------------------

        public void BuildTree(string json, string name)
        {
            BuildTree(JToken.Parse(json), name);
        }

        // ------------------------------------------------

        public void BuildTree(JToken root, string name)
        {
            treeView.BeginUpdate();
            treeView.Nodes.Clear();

            var node = new TreeNode(name);
            var tNode = treeView.Nodes[treeView.Nodes.Add(node)];
            tNode.ContextMenu = BuildNodeMenu(node);

            AddNode(root, tNode);
            treeView.EndUpdate();
        }

        // ------------------------------------------------
        /// <summary>
        ///     Recursive Method...
        /// </summary>
        /// <param name="token"></param>
        /// <param name="inTreeNode"></param>

        private void AddNode(JToken token, TreeNode inTreeNode)
        {
            if(token != null)
            {
                if(token is JValue)
                {
                    var val = token.ToString();
                    var node = new TreeNode(string.IsNullOrEmpty(val) ? "<Not Set>" : val);

                    var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(node)];

                    if(string.IsNullOrEmpty(val))
                    {
                        node.ForeColor = Color.Red;
                        inTreeNode.ForeColor = Color.Red;
                    }
                    else if(val.StartsWith("{{"))
                    {
                        node.ForeColor = Color.Blue;
                        inTreeNode.ForeColor = Color.Blue;
                    }

                    childNode.ContextMenu = BuildNodeMenu(node);
                }
                else if(token is JObject)
                {
                    var obj = token as JObject;

                    foreach(var property in obj.Properties())
                    {
                        var node = new TreeNode(property.Name);
                        var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(node)];

                        childNode.ContextMenu = BuildNodeMenu(node);
                        AddNode(property.Value, childNode);
                    }
                }
                else if(token is JArray)
                {
                    var array = token as JArray;

                    for(int index = 0; index < array.Count; index++)
                    {
                        var node = new TreeNode($"[{index.ToString()}]");
                        var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(node)];

                        childNode.ContextMenu = BuildNodeMenu(node);
                        AddNode(array[index], childNode);
                    }
                }
            }
        }

        // ------------------------------------------------

        private ContextMenu BuildNodeMenu(TreeNode node)
        {
            var copyNodeValue = new MenuItem("Copy");
            copyNodeValue.Click += OnCopyNodeValue;
            copyNodeValue.Tag = node;

            var copyNodeItem = new MenuItem("Copy Node Path");
            copyNodeItem.Click += OnCopyNodePath;
            copyNodeItem.Tag = node;

            var toggleExpNodeItem = new MenuItem("Toggle Node Expansion");
            toggleExpNodeItem.Tag = node;
            toggleExpNodeItem.Click += OnToggleExpansion;

            var findNode = new MenuItem("Search");
            findNode.Tag = node;
            findNode.Click += OnSearch;

            var retVal = new ContextMenu(new MenuItem[] { copyNodeValue, findNode, toggleExpNodeItem, copyNodeItem });

            return retVal;
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

            if(node != null)
            {
                var val = node.FullPath.Substring(node.FullPath.LastIndexOf('\\') + 1);
                var path = node.FullPath.Substring(0, node.FullPath.LastIndexOf('\\')).Replace('\\', '.').Replace(".[", "[");

                Clipboard.SetText($"pm.expect({path}).to.eql(\"{val}\")");
            }
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnToggleExpansion(object sender, EventArgs e)
        {
            var item = sender as MenuItem;

            if(item != null)
            {
                var node = item.Tag as TreeNode;

                if(node != null)
                {
                    if(node.IsExpanded)
                    {
                        node.Collapse();
                    }
                    else
                    {
                        node.ExpandAll();
                    }

                    treeView.SelectedNode = node;
                    treeView.SelectedNode.FirstNode.EnsureVisible();
                }
            }
        }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        private void OnSearch(object sender, EventArgs e)
        {
            using(var dlg = new SearchDialog())
            {
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    var item = sender as MenuItem;

                    if(item != null)
                    {
                        var node = item.Tag as TreeNode;

                        if(node != null)
                        {
                            treeSearch.Search(node, dlg.SearchTerm);
                        }
                    }
                }
            }
        }
    }
}
