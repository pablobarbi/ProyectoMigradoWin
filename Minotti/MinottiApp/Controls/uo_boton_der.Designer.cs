using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Minotti.Controls
{
    partial class uo_boton_der
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();

            // uo_boton_der (Button con imagen al centro, sin texto por defecto)
            this.Name = "uo_boton_der";
            this.Size = new Size(32, 32);
            this.Text = string.Empty;
            this.ImageAlign = ContentAlignment.MiddleCenter;
            this.TextImageRelation = TextImageRelation.Overlay;
            this.UseVisualStyleBackColor = true;
            this.TabStop = true;
            this.FlatStyle = FlatStyle.Standard;
        }
    }
}
