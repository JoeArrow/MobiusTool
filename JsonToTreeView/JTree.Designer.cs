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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView trvJSON;
        private System.Windows.Forms.CheckBox cbExpand;
        private System.Windows.Forms.Label lblNodesFound;
        private System.Windows.Forms.SplitContainer sptContainer;

        private ScintillaNET.Scintilla rtxJSON;

        private const int FOLDING_MARGIN = 3;
        private const int LINENUMBER_MARGIN = 0;
        private const bool CODEFOLDING_CIRCULAR = false;

        // -----------
        // Tree Events

        private event EventHandler SearchEvent;
        private event EventHandler ListTokensEvent;
        private event EventHandler CopyNodePathEvent;
        private event EventHandler CopyArrayPathEvent;
        private event EventHandler DecomposeNodeEvent;
        private event EventHandler CopyNodeValueEvent;
        private event EventHandler ToggleExpansionEvent;

        // -----------
        // Text Events

        private event EventHandler NewJSONEvent;
        private event EventHandler BuildTreeEvent;
        private event EventHandler FixupJsonEvent;
        private event EventHandler SearchTreeEvent;
        private event EventHandler FormatJSONEvent;
        private event EventHandler CopySelectedEvent;
        private event EventHandler ReplaceValueEvent;

        // -----------------
        // Set by the client

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
            this.sptContainer = new System.Windows.Forms.SplitContainer();
            this.rtxJSON = new ScintillaNET.Scintilla();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNodesFound = new System.Windows.Forms.Label();
            this.cbExpand = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trvJSON = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.sptContainer)).BeginInit();
            this.sptContainer.Panel1.SuspendLayout();
            this.sptContainer.Panel2.SuspendLayout();
            this.sptContainer.SuspendLayout();
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
            this.sptContainer.Panel1.Controls.Add(this.rtxJSON);
            this.sptContainer.Panel1.Controls.Add(this.label2);
            // 
            // sptContainer.Panel2
            // 
            this.sptContainer.Panel2.Controls.Add(this.lblNodesFound);
            this.sptContainer.Panel2.Controls.Add(this.cbExpand);
            this.sptContainer.Panel2.Controls.Add(this.label1);
            this.sptContainer.Panel2.Controls.Add(this.trvJSON);
            this.sptContainer.Size = new System.Drawing.Size(654, 180);
            this.sptContainer.SplitterDistance = 303;
            this.sptContainer.TabIndex = 0;
            this.sptContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SyncTargets);
            // 
            // rtxJSON
            // 
            this.rtxJSON.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxJSON.Location = new System.Drawing.Point(3, 21);
            this.rtxJSON.Name = "rtxJSON";
            this.rtxJSON.Size = new System.Drawing.Size(298, 156);
            this.rtxJSON.TabIndex = 2;
            this.rtxJSON.TextChanged += new System.EventHandler(this.OnJSONTextChange);
            this.rtxJSON.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnTextKeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "String Representation";
            // 
            // lblNodesFound
            // 
            this.lblNodesFound.AutoSize = true;
            this.lblNodesFound.Location = new System.Drawing.Point(124, 5);
            this.lblNodesFound.Name = "lblNodesFound";
            this.lblNodesFound.Size = new System.Drawing.Size(0, 13);
            this.lblNodesFound.TabIndex = 3;
            // 
            // cbExpand
            // 
            this.cbExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbExpand.AutoSize = true;
            this.cbExpand.Location = new System.Drawing.Point(246, 4);
            this.cbExpand.Name = "cbExpand";
            this.cbExpand.Size = new System.Drawing.Size(101, 17);
            this.cbExpand.TabIndex = 2;
            this.cbExpand.Text = "Load Expanded";
            this.cbExpand.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tree Representation";
            // 
            // trvJSON
            // 
            this.trvJSON.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvJSON.Location = new System.Drawing.Point(0, 21);
            this.trvJSON.Name = "trvJSON";
            this.trvJSON.Size = new System.Drawing.Size(347, 156);
            this.trvJSON.TabIndex = 0;
            this.trvJSON.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTreeKeyDown);
            this.trvJSON.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnTreeKeyUp);
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
            this.ResumeLayout(false);

        }

        #endregion

        // ------------------------------------------------

        private void JSONStyle()
        {
            rtxJSON.Styles[Style.Json.Number].ForeColor = EnumToColor(eColorConstant.Number);
            rtxJSON.Styles[Style.Json.Default].ForeColor = EnumToColor(eColorConstant.Default);
            rtxJSON.Styles[Style.Json.String].ForeColor = EnumToColor(eColorConstant.StringFore);
            rtxJSON.Styles[Style.Json.StringEol].BackColor = EnumToColor(eColorConstant.StringEol);
            rtxJSON.Styles[Style.Json.LineComment].ForeColor = EnumToColor(eColorConstant.Comment);
            rtxJSON.Styles[Style.Json.BlockComment].ForeColor = EnumToColor(eColorConstant.Comment);
            rtxJSON.Styles[Style.Json.Operator].ForeColor = EnumToColor(eColorConstant.OperatorFore);
            rtxJSON.Styles[Style.Json.PropertyName].ForeColor = EnumToColor(eColorConstant.PropertyName);

            rtxJSON.Lexer = Lexer.Json;
        }

        // ------------------------------------------------

        private void LineNumberStyle()
        {
            rtxJSON.Styles[Style.LineNumber].ForeColor = EnumToColor(eColorConstant.Fore_Color);
            rtxJSON.Styles[Style.LineNumber].BackColor = EnumToColor(eColorConstant.Back_Color);
        }

        // ------------------------------------------------

        private void CodeFoldingStyle()
        {
            rtxJSON.SetFoldMarginColor(true, EnumToColor(eColorConstant.Back_Color));
            rtxJSON.SetFoldMarginHighlightColor(true, EnumToColor(eColorConstant.Back_Color));

            // -------------------
            // Enable code folding

            rtxJSON.SetProperty("fold", "1");
            rtxJSON.SetProperty("fold.compact", "1");

            // ---------------------------------------------
            // Configure a margin to display folding symbols

            rtxJSON.Margins[FOLDING_MARGIN].Width = 20;
            rtxJSON.Margins[FOLDING_MARGIN].Sensitive = true;
            rtxJSON.Margins[FOLDING_MARGIN].Type = MarginType.Symbol;
            rtxJSON.Margins[FOLDING_MARGIN].Mask = Marker.MaskFolders;

            // ----------------------------------
            // Set colors for all folding markers

            for(int i = 25; i <= 31; i++)
            {
                rtxJSON.Markers[i].SetForeColor(EnumToColor(eColorConstant.Back_Color));
                rtxJSON.Markers[i].SetBackColor(EnumToColor(eColorConstant.Fore_Color));
            }

            // -------------------------------------------------
            // Configure folding markers with respective symbols

            rtxJSON.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            rtxJSON.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;
            rtxJSON.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;

            rtxJSON.Markers[Marker.Folder].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlus : MarkerSymbol.BoxPlus;
            rtxJSON.Markers[Marker.FolderOpen].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinus : MarkerSymbol.BoxMinus;
            rtxJSON.Markers[Marker.FolderEnd].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlusConnected : MarkerSymbol.BoxPlusConnected;
            rtxJSON.Markers[Marker.FolderOpenMid].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinusConnected : MarkerSymbol.BoxMinusConnected;

            // ------------------------
            // Enable automatic folding

            rtxJSON.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
        }
    }
}
