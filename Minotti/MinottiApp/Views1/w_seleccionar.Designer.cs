using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Minotti.Controls;

namespace Minotti.Views
{
    partial class w_seleccionar
    {
        private IContainer components = null;

        // Controles con los mismos nombres que en PB
        public uo_dw dw_1;

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
            this.components = new Container();
            this.dw_1 = new uo_dw();
            this.dw_1.Name = "dw_1";
            this.dw_1.Location = new System.Drawing.Point(12, 12);
            this.dw_1.Size = new System.Drawing.Size(560, 320);
            this.dw_1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            this.SuspendLayout();

            this.Controls.Add(this.dw_1);

            // w_seleccionar
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(584, 361);
            this.Name = "w_seleccionar";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "w_seleccionar";

            this.ResumeLayout(false);
        }
    }
}
