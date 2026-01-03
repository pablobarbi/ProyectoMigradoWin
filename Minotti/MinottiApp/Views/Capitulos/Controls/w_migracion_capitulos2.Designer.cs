
namespace Minotti.Views.Capitulos.Controls
{
 partial class w_migracion_capitulos2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tv_1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tv_1
            // 
            this.tv_1.Location = new System.Drawing.Point(78, 52);
            this.tv_1.Name = "tv_1";
            this.tv_1.Size = new System.Drawing.Size(1733, 1248);
            this.tv_1.TabIndex = 10;
            this.tv_1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.Tv_1_AfterExpand);
            // 
            // w_migracion_capitulos2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2199, 1516);
            this.Controls.Add(this.tv_1);
            this.Name = "w_migracion_capitulos2";
            this.Text = "w_migracion_capitulos2";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TreeView tv_1;
    }
}
