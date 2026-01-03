using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Minotti.Controls;

namespace Minotti.Views
{
    partial class w_seleccion
    {
        private IContainer components = null;

        // Control con el mismo nombre que en PB
        // (los botones pb_continuar / pb_cancelar vienen del base w_response)
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

            this.SuspendLayout();

            // dw_1
            this.dw_1.Name = "dw_1";
            this.dw_1.Location = new Point(12, 12);
            this.dw_1.Size = new Size(560, 300);
            this.dw_1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // w_seleccion
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(584, 361);
            this.Controls.Add(this.dw_1);
            this.Name = "w_seleccion";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "w_seleccion";

            this.ResumeLayout(false);
        }
    }
}
