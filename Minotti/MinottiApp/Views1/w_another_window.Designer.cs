namespace Minotti
{
    partial class w_another_window
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label st_1;
        private System.Windows.Forms.Button cb_1;

        /// <summary>Clean up any resources being used.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.st_1 = new System.Windows.Forms.Label();
            this.cb_1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // st_1 (StaticText)
            // 
            this.st_1.Name = "st_1";
            this.st_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.st_1.AutoSize = false;
            this.st_1.Location = new System.Drawing.Point(12, 88);
            this.st_1.Size = new System.Drawing.Size(660, 40);
            this.st_1.Text = ""; // PB no mostraba texto en el XAML fragmentado
            // 
            // cb_1 (CommandButton)
            // 
            this.cb_1.Name = "cb_1";
            this.cb_1.Text = "Close";
            this.cb_1.Location = new System.Drawing.Point(535, 236);
            this.cb_1.Size = new System.Drawing.Size(90, 28);
            this.cb_1.TabIndex = 0;
            this.cb_1.UseVisualStyleBackColor = true;
            this.cb_1.Click += new System.EventHandler(this.cb_1_Click);
            // 
            // w_another_window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 300);
            this.Controls.Add(this.cb_1);
            this.Controls.Add(this.st_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "w_another_window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "w_another_window";
            // PB: Default="true" y Cancel="true" en cb_1
            this.AcceptButton = this.cb_1;
            this.CancelButton = this.cb_1;
            this.ResumeLayout(false);
        }

        #endregion
    }
}
