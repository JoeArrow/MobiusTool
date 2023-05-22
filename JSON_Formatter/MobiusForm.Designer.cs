namespace JSON_Formatter
{
    partial class MobiusForm
    {
        // ------------------------------------------------
        /// <summary>
        ///     Required designer variable.
        /// </summary>

        private System.ComponentModel.IContainer components = null;

        // ------------------------------------------------
        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        ///     true if managed resources should be disposed; otherwise, false.
        /// </param>

        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        // ------------------------------------------------
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MobiusForm));
            JsonToTreeView.Exporters.MobiusExporter mobiusExporter1 = new JsonToTreeView.Exporters.MobiusExporter();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tokenizeJSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PathFinderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postmanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExporterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notepadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConstantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTokenConstantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNodePath = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tcTabs = new JSON_Formatter.TabControlEx();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.jTree = new JsonToTreeView.JTree();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.removeHexValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tcTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbFileName
            // 
            this.tbFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFileName.Location = new System.Drawing.Point(13, 82);
            this.tbFileName.Margin = new System.Windows.Forms.Padding(4);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(1149, 24);
            this.tbFileName.TabIndex = 0;
            this.tbFileName.Text = "C:\\Usage\\JSON";
            this.tbFileName.Click += new System.EventHandler(this.OnClickFileName);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Input JSON File:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1178, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.tokenizeJSONToolStripMenuItem,
            this.removeHexValuesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "&Open";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.OnLoadJson);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.OnSave);
            // 
            // tokenizeJSONToolStripMenuItem
            // 
            this.tokenizeJSONToolStripMenuItem.Name = "tokenizeJSONToolStripMenuItem";
            this.tokenizeJSONToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tokenizeJSONToolStripMenuItem.Text = "&Tokenize JSON";
            this.tokenizeJSONToolStripMenuItem.Click += new System.EventHandler(this.OnTokenizeJSON);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "A&bout";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OnAbout);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PathFinderMenuItem,
            this.ExporterMenuItem,
            this.loadConstantsToolStripMenuItem,
            this.createTokenConstantsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // PathFinderMenuItem
            // 
            this.PathFinderMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.postmanToolStripMenuItem,
            this.treeNodeToolStripMenuItem,
            this.cToolStripMenuItem});
            this.PathFinderMenuItem.Name = "PathFinderMenuItem";
            this.PathFinderMenuItem.Size = new System.Drawing.Size(198, 22);
            this.PathFinderMenuItem.Text = "&Path Finder Option";
            // 
            // postmanToolStripMenuItem
            // 
            this.postmanToolStripMenuItem.Name = "postmanToolStripMenuItem";
            this.postmanToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.postmanToolStripMenuItem.Text = "Postman";
            this.postmanToolStripMenuItem.Click += new System.EventHandler(this.OnPathFinderSelection);
            // 
            // treeNodeToolStripMenuItem
            // 
            this.treeNodeToolStripMenuItem.Checked = true;
            this.treeNodeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.treeNodeToolStripMenuItem.Name = "treeNodeToolStripMenuItem";
            this.treeNodeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.treeNodeToolStripMenuItem.Text = "TreeNode";
            this.treeNodeToolStripMenuItem.Click += new System.EventHandler(this.OnPathFinderSelection);
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            this.cToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.cToolStripMenuItem.Text = "CSharp";
            this.cToolStripMenuItem.Click += new System.EventHandler(this.OnPathFinderSelection);
            // 
            // ExporterMenuItem
            // 
            this.ExporterMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notepadToolStripMenuItem,
            this.notepadToolStripMenuItem1});
            this.ExporterMenuItem.Name = "ExporterMenuItem";
            this.ExporterMenuItem.Size = new System.Drawing.Size(198, 22);
            this.ExporterMenuItem.Text = "E&xporter";
            this.ExporterMenuItem.Visible = false;
            // 
            // notepadToolStripMenuItem
            // 
            this.notepadToolStripMenuItem.Checked = true;
            this.notepadToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.notepadToolStripMenuItem.Name = "notepadToolStripMenuItem";
            this.notepadToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.notepadToolStripMenuItem.Text = "Notepad";
            this.notepadToolStripMenuItem.Click += new System.EventHandler(this.OnExporterSelection);
            // 
            // notepadToolStripMenuItem1
            // 
            this.notepadToolStripMenuItem1.Name = "notepadToolStripMenuItem1";
            this.notepadToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.notepadToolStripMenuItem1.Text = "Notepad++";
            this.notepadToolStripMenuItem1.Click += new System.EventHandler(this.OnExporterSelection);
            // 
            // loadConstantsToolStripMenuItem
            // 
            this.loadConstantsToolStripMenuItem.Name = "loadConstantsToolStripMenuItem";
            this.loadConstantsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.loadConstantsToolStripMenuItem.Text = "Load Token &Constants";
            this.loadConstantsToolStripMenuItem.Click += new System.EventHandler(this.OnLoadConstants);
            // 
            // createTokenConstantsToolStripMenuItem
            // 
            this.createTokenConstantsToolStripMenuItem.Name = "createTokenConstantsToolStripMenuItem";
            this.createTokenConstantsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.createTokenConstantsToolStripMenuItem.Text = "Create To&ken Constants";
            this.createTokenConstantsToolStripMenuItem.Click += new System.EventHandler(this.OnCreateTokenConstants);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Close.png");
            // 
            // tabPage2
            // 
            this.tabPage2.ImageIndex = 0;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(977, 848);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "JSON Tab 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1178, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New Tab";
            this.newToolStripButton.Click += new System.EventHandler(this.OnNewJSON);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open JSON File";
            this.openToolStripButton.Click += new System.EventHandler(this.OnLoadJson);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save As";
            this.saveToolStripButton.Click += new System.EventHandler(this.OnSave);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "A&bout";
            this.helpToolStripButton.Click += new System.EventHandler(this.OnAbout);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 515);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Node Path: ";
            // 
            // lblNodePath
            // 
            this.lblNodePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNodePath.AutoSize = true;
            this.lblNodePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNodePath.Location = new System.Drawing.Point(101, 515);
            this.lblNodePath.Name = "lblNodePath";
            this.lblNodePath.Size = new System.Drawing.Size(0, 16);
            this.lblNodePath.TabIndex = 18;
            this.lblNodePath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnNodePathLabelClick);
            // 
            // tabPage3
            // 
            this.tabPage3.ImageIndex = 0;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1145, 616);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "JSON Tab 2";
            this.tabPage3.Visible = false;
            // 
            // tcTabs
            // 
            this.tcTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcTabs.Controls.Add(this.tabPage1);
            this.tcTabs.Controls.Add(this.tabPage4);
            this.tcTabs.ImageList = this.imageList;
            this.tcTabs.Location = new System.Drawing.Point(13, 113);
            this.tcTabs.Name = "tcTabs";
            this.tcTabs.SelectedIndex = 0;
            this.tcTabs.Size = new System.Drawing.Size(1153, 395);
            this.tcTabs.TabIndex = 15;
            this.tcTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.OnTabSelect);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.jTree);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1145, 369);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "JSON Tab";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // jTree
            // 
            this.jTree.AllowDrop = true;
            this.jTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jTree.Constants = new string[0];
            this.jTree.CurrentColumn = 0;
            this.jTree.CurrentLine = 0;
            this.jTree.Exporter = mobiusExporter1;
            this.jTree.FileName = null;
            this.jTree.JSON = "";
            this.jTree.LoadExpanded = false;
            this.jTree.Location = new System.Drawing.Point(0, 0);
            this.jTree.Name = "jTree";
            this.jTree.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.jTree.Size = new System.Drawing.Size(1145, 366);
            this.jTree.SplitDist = 644;
            this.jTree.SplitDistance = 644;
            this.jTree.TabIndex = 2;
            this.jTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnFileDrop);
            this.jTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1145, 369);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "New Tab";
            this.tabPage4.Visible = false;
            // 
            // removeHexValuesToolStripMenuItem
            // 
            this.removeHexValuesToolStripMenuItem.Name = "removeHexValuesToolStripMenuItem";
            this.removeHexValuesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeHexValuesToolStripMenuItem.Text = "&Remove Hex values";
            this.removeHexValuesToolStripMenuItem.Click += new System.EventHandler(this.OnRemoveHex);
            // 
            // MobiusForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 539);
            this.Controls.Add(this.lblNodePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tcTabs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(200, 100);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(772, 448);
            this.Name = "MobiusForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "The Mobius Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClose);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tcTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // ------------------------------------------------

        private TabControlEx tcTabs;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private JsonToTreeView.JTree jTree;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PathFinderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postmanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treeNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExporterMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notepadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tokenizeJSONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadConstantsToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripMenuItem notepadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createTokenConstantsToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNodePath;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ToolStripMenuItem removeHexValuesToolStripMenuItem;
    }
}

