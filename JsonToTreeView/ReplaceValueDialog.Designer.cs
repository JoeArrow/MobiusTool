namespace JsonToTreeView
{
    partial class ReplaceValueDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplaceValueDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearchValue = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReplace = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNewValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Search Value:";
            // 
            // tbSearchValue
            // 
            this.tbSearchValue.Location = new System.Drawing.Point(83, 9);
            this.tbSearchValue.Name = "tbSearchValue";
            this.tbSearchValue.Size = new System.Drawing.Size(204, 20);
            this.tbSearchValue.TabIndex = 0;
            this.tbSearchValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(154, 67);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(72, 67);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(75, 23);
            this.btnReplace.TabIndex = 2;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.OnReplace);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "New Value:";
            // 
            // tbNewValue
            // 
            this.tbNewValue.Location = new System.Drawing.Point(83, 34);
            this.tbNewValue.Name = "tbNewValue";
            this.tbNewValue.Size = new System.Drawing.Size(204, 20);
            this.tbNewValue.TabIndex = 1;
            this.tbNewValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            // 
            // ReplaceValueDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 103);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNewValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearchValue);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReplace);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReplaceValueDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replace All Values";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSearchValue;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNewValue;
    }
}