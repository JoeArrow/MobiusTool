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
using System.Collections.Generic;
using System.Text.RegularExpressions;

using ScintillaNET;

namespace JsonToTreeView
{
    // ----------------------------------------------------
    /// <summary>
    ///     TreeSearch Description
    /// </summary>

    public class SearchTool
    {
        const int HIGHLIGHT = 8;

        private JTree m_jTree;
        private int currentIndex = 0;
        private string SearchTerm { set; get; }
        private List<int> WordLines = new List<int>();
        private List<TreeNode> Nodes = new List<TreeNode>();

        // ------------------------------------------------

        public SearchTool() { }

        // ------------------------------------------------

        public SearchTool(JTree jTree)
        {
            m_jTree = jTree;
        }

        // ------------------------------------------------

        public string RemoveHex(string fullText)
        {
            var retVal = fullText;
            var regEx = new Regex(@"(0[xX]\w{2})|(\\[xX]\w{2})");

            var matches = regEx.Matches(fullText);

            foreach(Match match in matches)
            {
                retVal = retVal.Replace(match.Value, string.Empty);
            }

            return retVal;
        }

        // ------------------------------------------------

        public int Search(string fullText, string val)
        {
            var retVal = -1;
            var regEx = GetRegex(val);

            var match = regEx.Match(fullText);

            if(match.Success) { retVal = match.Index; }

            return retVal;
        }

        // ------------------------------------------------

        public int Search(TreeNode node, string val, bool useRegex)
        {
            Nodes.Clear();
            SearchTerm = val;

            if(!string.IsNullOrEmpty(SearchTerm))
            {
                currentIndex = 0;
                RecursiveSearch(node, useRegex);

                if(Nodes.Count > 0)
                {
                    m_jTree.tvJSON.SelectedNode = Nodes[currentIndex];
                    m_jTree.tvJSON.SelectedNode.Expand();
                    m_jTree.tvJSON.Select();

                    m_jTree.tvJSON.SelectedNode.EnsureVisible();
                }
            }

            HighlightSearchTerm();

            SetTextPosition(currentIndex);

            return Nodes.Count;
        }

        // ------------------------------------------------

        private void RecursiveSearch(TreeNode node, bool useRegex = false)
        {
            foreach(TreeNode testNode in node.Nodes)
            {
                // ---------------------------------------------
                // Check both the Name and the Value for a match

                if(useRegex)
                {
                    var regex = GetRegex(SearchTerm.Trim());

                    if(regex.Match(testNode.Text.ToLower()).Success || 
                       regex.Match(testNode.Name.ToLower()).Success)
                    {
                        Nodes.Add(testNode);
                    }
                }
                else
                {
                    if(testNode.Text.ToLower().Contains(SearchTerm.ToLower().Trim()) ||
                       testNode.Name.ToLower().Contains(SearchTerm.ToLower().Trim()))
                    {
                        Nodes.Add(testNode);
                    }
                }

                // --------------------
                // Look out! Recursion!

                if(node.Nodes != null && node.Nodes.Count > 0)
                {
                    RecursiveSearch(testNode, useRegex);
                }
            }
        }

        // ------------------------------------------------

        public int Next()
        {
            if(currentIndex < Nodes.Count -1)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }

            if(Nodes.Count > 0 && currentIndex < Nodes.Count)
            {
                m_jTree.tvJSON.SelectedNode = Nodes[currentIndex];
                m_jTree.tvJSON.SelectedNode.Expand();
                m_jTree.tvJSON.Select();

                m_jTree.tvJSON.SelectedNode.EnsureVisible();

                SetTextPosition(currentIndex);
            }

            return currentIndex;
        }

        // ------------------------------------------------

        public int Previous()
        {
            if(currentIndex > 0)
            {
                currentIndex--;
            }
            else
            {
                currentIndex = Nodes.Count - 1;
            }

            if(Nodes.Count > 0 && currentIndex >= 0)
            {
                m_jTree.tvJSON.SelectedNode = Nodes[currentIndex];
                m_jTree.tvJSON.SelectedNode.Expand();
                m_jTree.tvJSON.Select();

                m_jTree.tvJSON.SelectedNode.EnsureVisible();

                SetTextPosition(currentIndex);
            }

            return currentIndex;
        }

        // ------------------------------------------------

        private void SetTextPosition(int currentIndex)
        {
            if(WordLines.Count >= currentIndex)
            {
                try
                {
                    m_jTree.tbJSON.Lines[WordLines[currentIndex]].Goto();
                }
                catch(Exception)
                {
                    // Just eat this exception
                }
            }
        }

        // ------------------------------------------------

        private void HighlightSearchTerm()
        {
            if(!string.IsNullOrEmpty(SearchTerm))
            {
                WordLines.Clear();

                // --------------------------------
                // Remove all uses of our indicator

                m_jTree.tbJSON.IndicatorCurrent = HIGHLIGHT;
                m_jTree.tbJSON.IndicatorClearRange(0, m_jTree.tbJSON.TextLength);

                // ---------------------------
                // Update indicator appearance

                m_jTree.tbJSON.Indicators[HIGHLIGHT].Alpha = 1000;
                m_jTree.tbJSON.Indicators[HIGHLIGHT].Under = true;
                m_jTree.tbJSON.Indicators[HIGHLIGHT].OutlineAlpha = 50;
                m_jTree.tbJSON.Indicators[HIGHLIGHT].ForeColor = Color.SpringGreen;
                m_jTree.tbJSON.Indicators[HIGHLIGHT].Style = IndicatorStyle.StraightBox;

                // -------------------
                // Search the document

                m_jTree.tbJSON.TargetStart = 0;
                m_jTree.tbJSON.TargetEnd = m_jTree.tbJSON.TextLength;
                m_jTree.tbJSON.SearchFlags = SearchFlags.None;

                while(m_jTree.tbJSON.SearchInTarget(SearchTerm) != -1)
                {
                    // --------------------------------------------------
                    // Mark the search results with the current indicator

                    m_jTree.tbJSON.IndicatorFillRange(m_jTree.tbJSON.TargetStart, m_jTree.tbJSON.TargetEnd - m_jTree.tbJSON.TargetStart);
                    WordLines.Add(m_jTree.tbJSON.LineFromPosition(m_jTree.tbJSON.TargetStart));

                    // ------------------------------------
                    // Search the remainder of the document

                    m_jTree.tbJSON.TargetStart = m_jTree.tbJSON.TargetEnd;
                    m_jTree.tbJSON.TargetEnd = m_jTree.tbJSON.TextLength;
                }

                m_jTree.tbJSON.TargetStart = 0;
            }
        }

        // ------------------------------------------------

        private Regex GetRegex(string searchTerm)
        {
            Regex retVal = new Regex("~_~");

            if(!string.IsNullOrWhiteSpace(searchTerm))
            {
                var options = RegexOptions.Multiline | RegexOptions.IgnoreCase;

                // ------------------------------------
                // Allows us to write Windows eol RegEx
                // that still works in this app

                try
                {
                    retVal = new Regex(searchTerm.Replace(@"\r\n", @"\n"), options);
                }
                catch(Exception /*ex*/)
                {
                    retVal = new Regex("~_~");
                }
            }

            return retVal;
        }
    }
}
