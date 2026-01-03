using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    public partial class w_sheet
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            // 
            // w_sheet
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1024, 768);
            this.Name = "w_sheet";
            this.Text = "w_sheet";
            this.StartPosition = FormStartPosition.CenterScreen; // PB: x=0,y=0
            this.Location = new Point(0, 0);

            // Es un "sheet": normalmente MDI child
            this.FormBorderStyle = FormBorderStyle.Sizable;

            this.ResumeLayout(false);
        }

        protected  override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }
    }
}
