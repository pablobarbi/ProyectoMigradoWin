using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Minotti.Views.Informes.Controls
{
    partial class w_reporte_capitulo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            //
            // w_reporte_capitulo
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "w_reporte_capitulo";
            this.Text = "w_reporte_capitulo";
            this.ResumeLayout(false);
        }
    }
}