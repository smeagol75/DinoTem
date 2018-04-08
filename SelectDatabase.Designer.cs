namespace DinoTem
{
    partial class SelectDatabase
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
            if (disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectDatabase));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.applyTeam = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(4, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(275, 134);
            this.listBox1.TabIndex = 31;
            // 
            // applyTeam
            // 
            this.applyTeam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(177)))), ((int)(((byte)(68)))));
            this.applyTeam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.applyTeam.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.applyTeam.FlatAppearance.BorderSize = 0;
            this.applyTeam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(177)))), ((int)(((byte)(68)))));
            this.applyTeam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(147)))), ((int)(((byte)(68)))));
            this.applyTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.applyTeam.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.applyTeam.Location = new System.Drawing.Point(193, 154);
            this.applyTeam.Margin = new System.Windows.Forms.Padding(0);
            this.applyTeam.Name = "applyTeam";
            this.applyTeam.Size = new System.Drawing.Size(86, 29);
            this.applyTeam.TabIndex = 135;
            this.applyTeam.Text = "Select";
            this.applyTeam.UseVisualStyleBackColor = false;
            this.applyTeam.Click += new System.EventHandler(this.applyTeam_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(177)))), ((int)(((byte)(68)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(177)))), ((int)(((byte)(68)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(147)))), ((int)(((byte)(68)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(97, 154);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 29);
            this.button1.TabIndex = 136;
            this.button1.Text = "Deselect";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 188);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.applyTeam);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SelectDatabase";
            this.Text = "SelectDatabase";
            this.Load += new System.EventHandler(this.SelectDatabase_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button applyTeam;
        private System.Windows.Forms.Button button1;
    }
}