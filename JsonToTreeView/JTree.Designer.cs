#region © 2019 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;

using ScintillaNET;

namespace JsonToTreeView
{
    partial class JTree
    {
        // ------------------------------------------------
        /// <summary> 
        ///     Required designer variable.
        /// </summary>

        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView trvJSON;
        private System.Windows.Forms.CheckBox cbExpand;
        private System.Windows.Forms.Label lblNodesFound;
        private System.Windows.Forms.SplitContainer sptContainer;

        private ScintillaNET.Scintilla sciJSON;

        private const int FOLDING_MARGIN = 3;
        private const int LINENUMBER_MARGIN = 0;
        private const bool CODEFOLDING_CIRCULAR = false;

        // -----------------
        // Set by the client

        public event EventHandler NodeClickedEvent;
        public event EventHandler DecompositionExportedEvent;

        private int maxLineNumberwidth;
        private SearchTool searchTool;

        /// <summary> 
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JTree));
            this.sptContainer = new System.Windows.Forms.SplitContainer();
            this.textToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.lblColumn = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.sciJSON = new ScintillaNET.Scintilla();
            this.label2 = new System.Windows.Forms.Label();
            this.treeToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.lblNodesFound = new System.Windows.Forms.Label();
            this.cbExpand = new System.Windows.Forms.CheckBox();
            this.trvJSON = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.sptContainer)).BeginInit();
            this.sptContainer.Panel1.SuspendLayout();
            this.sptContainer.Panel2.SuspendLayout();
            this.sptContainer.SuspendLayout();
            this.textToolStrip.SuspendLayout();
            this.treeToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sptContainer
            // 
            this.sptContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sptContainer.Location = new System.Drawing.Point(0, 3);
            this.sptContainer.Name = "sptContainer";
            // 
            // sptContainer.Panel1
            // 
            this.sptContainer.Panel1.Controls.Add(this.textToolStrip);
            this.sptContainer.Panel1.Controls.Add(this.lblColumn);
            this.sptContainer.Panel1.Controls.Add(this.label4);
            this.sptContainer.Panel1.Controls.Add(this.label3);
            this.sptContainer.Panel1.Controls.Add(this.lblLine);
            this.sptContainer.Panel1.Controls.Add(this.sciJSON);
            this.sptContainer.Panel1.Controls.Add(this.label2);
            // 
            // sptContainer.Panel2
            // 
            this.sptContainer.Panel2.Controls.Add(this.treeToolStrip);
            this.sptContainer.Panel2.Controls.Add(this.lblNodesFound);
            this.sptContainer.Panel2.Controls.Add(this.cbExpand);
            this.sptContainer.Panel2.Controls.Add(this.trvJSON);
            this.sptContainer.Size = new System.Drawing.Size(654, 183);
            this.sptContainer.SplitterDistance = 303;
            this.sptContainer.TabIndex = 0;
            this.sptContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SyncTargets);
            // 
            // textToolStrip
            // 
            this.textToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.textToolStrip.Location = new System.Drawing.Point(0, 0);
            this.textToolStrip.Name = "textToolStrip";
            this.textToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.textToolStrip.Size = new System.Drawing.Size(303, 25);
            this.textToolStrip.TabIndex = 7;
            this.textToolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(117, 22);
            this.toolStripLabel1.Text = "JSON Representation";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Toggle the Tree";
            this.toolStripButton1.Click += new System.EventHandler(this.OnFormatJSON);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.toolStripButton2.Size = new System.Drawing.Size(25, 22);
            this.toolStripButton2.Text = "Clear JSON";
            this.toolStripButton2.Click += new System.EventHandler(this.OnClearJSON);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "Search";
            this.toolStripButton3.Click += new System.EventHandler(this.OnJSONSearch);
            // 
            // lblColumn
            // 
            this.lblColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblColumn.AutoSize = true;
            this.lblColumn.Location = new System.Drawing.Point(263, 168);
            this.lblColumn.Name = "lblColumn";
            this.lblColumn.Size = new System.Drawing.Size(13, 13);
            this.lblColumn.TabIndex = 6;
            this.lblColumn.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Column:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Line:";
            // 
            // lblLine
            // 
            this.lblLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLine.AutoSize = true;
            this.lblLine.Location = new System.Drawing.Point(180, 167);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(13, 13);
            this.lblLine.TabIndex = 3;
            this.lblLine.Text = "0";
            // 
            // sciJSON
            // 
            this.sciJSON.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sciJSON.Location = new System.Drawing.Point(3, 30);
            this.sciJSON.Name = "sciJSON";
            this.sciJSON.Size = new System.Drawing.Size(298, 128);
            this.sciJSON.TabIndex = 2;
            this.sciJSON.UpdateUI += new System.EventHandler<ScintillaNET.UpdateUIEventArgs>(this.OnCaretPositionChange);
            this.sciJSON.TextChanged += new System.EventHandler(this.OnJSONTextChange);
            this.sciJSON.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnTextKeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "String Representation";
            // 
            // treeToolStrip
            // 
            this.treeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripButton5,
            this.toolStripButton4});
            this.treeToolStrip.Location = new System.Drawing.Point(0, 0);
            this.treeToolStrip.Name = "treeToolStrip";
            this.treeToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.treeToolStrip.Size = new System.Drawing.Size(347, 25);
            this.treeToolStrip.TabIndex = 8;
            this.treeToolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(110, 22);
            this.toolStripLabel2.Text = "Tree Representation";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Expand Tree";
            this.toolStripButton5.Click += new System.EventHandler(this.OnToggleExpansion);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "Search";
            this.toolStripButton4.Click += new System.EventHandler(this.OnFullTreeSearch);
            // 
            // lblNodesFound
            // 
            this.lblNodesFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNodesFound.AutoSize = true;
            this.lblNodesFound.Location = new System.Drawing.Point(2, 167);
            this.lblNodesFound.Name = "lblNodesFound";
            this.lblNodesFound.Size = new System.Drawing.Size(0, 13);
            this.lblNodesFound.TabIndex = 3;
            // 
            // cbExpand
            // 
            this.cbExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbExpand.AutoSize = true;
            this.cbExpand.Location = new System.Drawing.Point(243, 164);
            this.cbExpand.Name = "cbExpand";
            this.cbExpand.Size = new System.Drawing.Size(101, 17);
            this.cbExpand.TabIndex = 2;
            this.cbExpand.Text = "Load Expanded";
            this.cbExpand.UseVisualStyleBackColor = true;
            this.cbExpand.CheckedChanged += new System.EventHandler(this.OnLoadExpandedToggle);
            // 
            // trvJSON
            // 
            this.trvJSON.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvJSON.Location = new System.Drawing.Point(0, 30);
            this.trvJSON.Name = "trvJSON";
            this.trvJSON.Size = new System.Drawing.Size(347, 128);
            this.trvJSON.TabIndex = 0;
            this.trvJSON.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnNodeClick);
            this.trvJSON.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTreeKeyDown);
            this.trvJSON.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnTreeKeyUp);
            this.trvJSON.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnNodeDoubleClick);
            // 
            // JTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sptContainer);
            this.Name = "JTree";
            this.Size = new System.Drawing.Size(657, 186);
            this.sptContainer.Panel1.ResumeLayout(false);
            this.sptContainer.Panel1.PerformLayout();
            this.sptContainer.Panel2.ResumeLayout(false);
            this.sptContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptContainer)).EndInit();
            this.sptContainer.ResumeLayout(false);
            this.textToolStrip.ResumeLayout(false);
            this.textToolStrip.PerformLayout();
            this.treeToolStrip.ResumeLayout(false);
            this.treeToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // ------------------------------------------------

        private void JSONStyle()
        {
            sciJSON.Styles[Style.Json.Number].ForeColor = EnumToColor(eColorConstant.Number);
            sciJSON.Styles[Style.Json.Default].ForeColor = EnumToColor(eColorConstant.Default);
            sciJSON.Styles[Style.Json.String].ForeColor = EnumToColor(eColorConstant.StringFore);
            sciJSON.Styles[Style.Json.StringEol].BackColor = EnumToColor(eColorConstant.StringEol);
            sciJSON.Styles[Style.Json.LineComment].ForeColor = EnumToColor(eColorConstant.Comment);
            sciJSON.Styles[Style.Json.BlockComment].ForeColor = EnumToColor(eColorConstant.Comment);
            sciJSON.Styles[Style.Json.Operator].ForeColor = EnumToColor(eColorConstant.OperatorFore);
            sciJSON.Styles[Style.Json.PropertyName].ForeColor = EnumToColor(eColorConstant.PropertyName);

            sciJSON.Lexer = Lexer.Json;
        }

        // ------------------------------------------------

        private void LineNumberStyle()
        {
            sciJSON.Styles[Style.LineNumber].ForeColor = EnumToColor(eColorConstant.Fore_Color);
            sciJSON.Styles[Style.LineNumber].BackColor = EnumToColor(eColorConstant.Back_Color);
        }

        // ------------------------------------------------

        private void CodeFoldingStyle()
        {
            sciJSON.SetFoldMarginColor(true, EnumToColor(eColorConstant.Back_Color));
            sciJSON.SetFoldMarginHighlightColor(true, EnumToColor(eColorConstant.Back_Color));

            // -------------------
            // Enable code folding

            sciJSON.SetProperty("fold", "1");
            sciJSON.SetProperty("fold.compact", "1");

            // ---------------------------------------------
            // Configure a margin to display folding symbols

            sciJSON.Margins[FOLDING_MARGIN].Width = 20;
            sciJSON.Margins[FOLDING_MARGIN].Sensitive = true;
            sciJSON.Margins[FOLDING_MARGIN].Type = MarginType.Symbol;
            sciJSON.Margins[FOLDING_MARGIN].Mask = Marker.MaskFolders;

            // ----------------------------------
            // Set colors for all folding markers

            for(int i = 25; i <= 31; i++)
            {
                sciJSON.Markers[i].SetForeColor(EnumToColor(eColorConstant.Back_Color));
                sciJSON.Markers[i].SetBackColor(EnumToColor(eColorConstant.Fore_Color));
            }

            // -------------------------------------------------
            // Configure folding markers with respective symbols

            sciJSON.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            sciJSON.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;
            sciJSON.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;

            sciJSON.Markers[Marker.Folder].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlus : MarkerSymbol.BoxPlus;
            sciJSON.Markers[Marker.FolderOpen].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinus : MarkerSymbol.BoxMinus;
            sciJSON.Markers[Marker.FolderEnd].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlusConnected : MarkerSymbol.BoxPlusConnected;
            sciJSON.Markers[Marker.FolderOpenMid].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinusConnected : MarkerSymbol.BoxMinusConnected;

            // ------------------------
            // Enable automatic folding

            sciJSON.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
        }

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblColumn;
        private System.Windows.Forms.ToolStrip textToolStrip;
        private System.Windows.Forms.ToolStrip treeToolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
    }
}
