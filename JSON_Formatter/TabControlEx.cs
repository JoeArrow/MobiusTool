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

using JsonToTreeView;

namespace JSON_Formatter
{
    // ----------------------------------------------------
    /// <summary>
    ///     We are extending the TabControl in order to gain
    ///     full control over some of its inner workings.
    /// </summary>

    public class TabControlEx : TabControl
    {
        private const int MIN_PAGES = 2;

        private bool MovingATab = false;
        private event EventHandler TabRenameEvent;
        private event EventHandler TabDeleteEvent;

        public delegate bool PreRemoveTab(int index);

        private TabPage SourceTab { set; get; }
        private TabPage CurrentTab { set; get; }
        private PreRemoveTab PreRemoveTabPage { set; get; }

        // ------------------------------------------------

        public TabControlEx()
            : base()
        {
            PreRemoveTabPage = null;
            ContextMenu = BuildTabContextMenu();

            MouseUp += OnMouseUp;
            MouseDown += OnMouseDown;
            MouseMove += OnMouseMove;
        }

        // ------------------------------------------------

        private ContextMenu BuildTabContextMenu()
        {
            var renameTab = new MenuItem("Rename Tab");
            TabRenameEvent = OnRenameTab;
            renameTab.Click += TabRenameEvent;

            var deleteTab = new MenuItem("Delete Tab");
            TabDeleteEvent = OnDeleteTab;
            deleteTab.Click += TabDeleteEvent;

            return new ContextMenu(new MenuItem[] { renameTab, deleteTab });
        }

        // ------------------------------------------------

        public void AddTab()
        {
            if(SelectedTab != null && SelectedTab.Text.Equals("New Tab"))
            {
                AddTab("", $"{Properties.Settings.Default.DefaultTabText} {TabCount.ToString()}");
            }
        }

        // ------------------------------------------------

        public JTree AddTab(string json, string tabText)
        {
            SelectedTab = Controls[Controls.Count - 1] as TabPage;

            SelectedTab.ImageIndex = 0;
            SelectedTab.Text = tabText;

            Controls.Add(new TabPage() { Text = "New Tab" });

            SelectedTab.Controls.Add(new JTree()
            {
                Size = SelectedTab.ClientSize,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            });

            var retVal = SelectedTab.Controls[0] as JTree;
            retVal.JSON = json;

            return SelectedTab.Controls[0] as JTree;
        }

        // ------------------------------------------------

        private void OnDeleteTab(object sender, EventArgs e)
        {
            if(SelectedTab != null && TabPages.Count > 2)
            {
                TabPages.Remove(SelectedTab);
            }
        }

        // ------------------------------------------------

        private void OnRenameTab(object sender, EventArgs e)
        {
            if(SourceTab != null)
            {
                using(var dlg = new TabRenameDialog(SourceTab.Text))
                {
                    if(dlg.ShowDialog() == DialogResult.OK)
                    {
                        SourceTab.Text = dlg.tbNewName.Text;
                    }
                }
            }
        }

        // ------------------------------------------------

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            SetCurrentTab(e);
            var clickPoint = e.Location;

            if(CurrentTab.Text.Equals("New Tab", StringComparison.CurrentCultureIgnoreCase))
            {
                AddTab();
            }
            else
            {
                var currentIndex = TabPages.IndexOf(CurrentTab);
                var rectangle = GetTabRect(currentIndex);

                rectangle.Width = 16;
                rectangle.Height = 16;
                rectangle.Offset(2, 2);

                var clickedTheX = rectangle.Contains(clickPoint);

                if(clickedTheX)
                {
                    if(TabCount > MIN_PAGES)
                    {
                        TabPages.RemoveAt(currentIndex);

                        if(currentIndex > 0 && (TabPages.Count - 1) >= currentIndex)
                        {
                            TabPages[--currentIndex].Select();
                        }
                    }
                }
                else
                {
                    MovingATab = true;
                    SourceTab = CurrentTab;
                }
            }
        }

        // ------------------------------------------------

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if(MovingATab)
            {
                // ---------------------------------------
                // Always keep up with the tab we are over
                // while moving a tab.

                SetCurrentTab(e);

                if(SourceTab != null && CurrentTab != null)
                {
                    var sourceIndex = TabPages.IndexOf(SourceTab);
                    var currentIndex = TabPages.IndexOf(CurrentTab);

                    if(currentIndex < sourceIndex) { Cursor = Cursors.PanWest; }
                    else if(currentIndex > sourceIndex) { Cursor = Cursors.PanEast; }
                    else { Cursor = Cursors.Default; }
                }
            }
        }

        // ------------------------------------------------

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if(MovingATab)
            {
                MovingATab = false;
                Cursor = Cursors.Default;

                if(SourceTab != null && CurrentTab != null)
                {
                    var sourceIndex = TabPages.IndexOf(SourceTab);
                    var currentIndex = TabPages.IndexOf(CurrentTab);

                    if(sourceIndex != currentIndex && 
                       currentIndex < TabPages.Count - 1)
                    {
                        TabPages.Remove(SourceTab);
                        TabPages.Insert(currentIndex, SourceTab);
                    }
                }
            }
        }

        // ------------------------------------------------

        private void SetCurrentTab(MouseEventArgs e)
        {
            for(int i = 0; i < TabCount; i++)
            {
                // ----------------------------
                // Get their rectangle area and 
                // see if it contains the mouse cursor

                if(GetTabRect(i).Contains(new Point(e.X, e.Y)))
                {
                    CurrentTab = TabPages[i];
                }
            }
        }
    }
}
