namespace JsonToTreeView
{
    partial class SearchDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchDialog));
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbTerm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUseRegex = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(71, 68);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.OnSearch);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(153, 68);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // tbTerm
            // 
            this.tbTerm.Location = new System.Drawing.Point(12, 32);
            this.tbTerm.Name = "tbTerm";
            this.tbTerm.Size = new System.Drawing.Size(275, 20);
            this.tbTerm.TabIndex = 0;
            this.tbTerm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.tbTerm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search Term:";
            // 
            // cbUseRegex
            // 
            this.cbUseRegex.AutoSize = true;
            this.cbUseRegex.Location = new System.Drawing.Point(211, 15);
            this.cbUseRegex.Name = "cbUseRegex";
            this.cbUseRegex.Size = new System.Drawing.Size(80, 17);
            this.cbUseRegex.TabIndex = 4;
            this.cbUseRegex.Text = "Use RegEx";
            this.cbUseRegex.UseVisualStyleBackColor = true;
            this.cbUseRegex.Visible = false;
            // 
            // SearchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 103);
            this.Controls.Add(this.cbUseRegex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTerm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(315, 142);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(315, 142);
            this.Name = "SearchDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbTerm;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox cbUseRegex;
    }
}