using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Minotti.Controls;

namespace Minotti.Views
{
    partial class w_ver_datos
    {
        private IContainer components = null;

        // Controles con los mismos nombres que en PB
        public uo_dw dw_1;
        public uo_dw dw_lista; // detectado en referencias del SRW

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
            this.dw_lista = new uo_dw();

            this.SuspendLayout();

            // dw_1
            this.dw_1.Name = "dw_1";
            this.dw_1.Location = new Point(12, 12);
            this.dw_1.Size = new Size(560, 220);
            this.dw_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // dw_lista
            this.dw_lista.Name = "dw_lista";
            this.dw_lista.Location = new Point(12, 244);
            this.dw_lista.Size = new Size(560, 180);
            this.dw_lista.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // w_ver_datos
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(584, 441);
            this.Controls.Add(this.dw_1);
            this.Controls.Add(this.dw_lista);
            this.Name = "w_ver_datos";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "w_ver_datos";

            this.ResumeLayout(false);
        }
    }
}
