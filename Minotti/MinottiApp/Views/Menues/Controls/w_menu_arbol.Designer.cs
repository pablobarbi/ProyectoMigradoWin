namespace Minotti.Views.Menues.Controls
{
    partial class w_menu_arbol
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TreeView tv_1;

        protected  override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tv_1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tv_1
            // 
            this.tv_1.Name = "tv_1";
            this.tv_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_1.HideSelection = false;
            this.tv_1.TabIndex = 0;
            // 
            // w_menu_arbol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tv_1);
            this.Name = "w_menu_arbol";
            this.Text = "w_menu_arbol";
            this.ResumeLayout(false);
        }
    }
}
