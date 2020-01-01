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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.tcTabs = new JSON_Formatter.TabControlEx();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.jTree = new JsonToTreeView.JTree();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.tcTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(901, 48);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(95, 24);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.OnBrowse);
            // 
            // tbFileName
            // 
            this.tbFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFileName.Location = new System.Drawing.Point(13, 48);
            this.tbFileName.Margin = new System.Windows.Forms.Padding(4);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(880, 24);
            this.tbFileName.TabIndex = 0;
            this.tbFileName.Text = "C:\\";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Input JSON File:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Location = new System.Drawing.Point(468, 959);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.OnSave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1010, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.tokenizeJSONToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.loadToolStripMenuItem.Text = "&Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.OnBrowse);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.OnSave);
            // 
            // tokenizeJSONToolStripMenuItem
            // 
            this.tokenizeJSONToolStripMenuItem.Name = "tokenizeJSONToolStripMenuItem";
            this.tokenizeJSONToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tokenizeJSONToolStripMenuItem.Text = "&Tokenize JSON";
            this.tokenizeJSONToolStripMenuItem.Click += new System.EventHandler(this.OnTokenizeJSON);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
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
            this.PathFinderMenuItem.Size = new System.Drawing.Size(199, 22);
            this.PathFinderMenuItem.Text = "&Path Finder Option";
            // 
            // postmanToolStripMenuItem
            // 
            this.postmanToolStripMenuItem.Name = "postmanToolStripMenuItem";
            this.postmanToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.postmanToolStripMenuItem.Text = "Postman";
            // 
            // treeNodeToolStripMenuItem
            // 
            this.treeNodeToolStripMenuItem.Checked = true;
            this.treeNodeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.treeNodeToolStripMenuItem.Name = "treeNodeToolStripMenuItem";
            this.treeNodeToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.treeNodeToolStripMenuItem.Text = "TreeNode";
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            this.cToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.cToolStripMenuItem.Text = "CSharp";
            // 
            // ExporterMenuItem
            // 
            this.ExporterMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notepadToolStripMenuItem,
            this.notepadToolStripMenuItem1});
            this.ExporterMenuItem.Name = "ExporterMenuItem";
            this.ExporterMenuItem.Size = new System.Drawing.Size(199, 22);
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
            this.loadConstantsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.loadConstantsToolStripMenuItem.Text = "Load Token &Constants";
            this.loadConstantsToolStripMenuItem.Click += new System.EventHandler(this.OnLoadConstants);
            // 
            // createTokenConstantsToolStripMenuItem
            // 
            this.createTokenConstantsToolStripMenuItem.Name = "createTokenConstantsToolStripMenuItem";
            this.createTokenConstantsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
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
            // tcTabs
            // 
            this.tcTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcTabs.Controls.Add(this.tabPage1);
            this.tcTabs.Controls.Add(this.tabPage3);
            this.tcTabs.ImageList = this.imageList;
            this.tcTabs.Location = new System.Drawing.Point(13, 79);
            this.tcTabs.Name = "tcTabs";
            this.tcTabs.SelectedIndex = 0;
            this.tcTabs.Size = new System.Drawing.Size(985, 874);
            this.tcTabs.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.jTree);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(977, 848);
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
            this.jTree.Exporter = mobiusExporter1;
            this.jTree.JSON = "";
            this.jTree.LoadExpanded = false;
            this.jTree.Location = new System.Drawing.Point(0, 0);
            this.jTree.Name = "jTree";
            this.jTree.Size = new System.Drawing.Size(977, 849);
            this.jTree.SplitDistance = 550;
            this.jTree.TabIndex = 2;
            this.jTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.jTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(977, 848);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "New Tab";
            this.tabPage3.Visible = false;
            // 
            // MobiusForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 987);
            this.Controls.Add(this.tcTabs);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowse);
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
            this.tcTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // ------------------------------------------------

        private TabControlEx tcTabs;

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
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
    }
}

