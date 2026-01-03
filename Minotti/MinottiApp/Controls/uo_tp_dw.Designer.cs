using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Minotti.Controls
{
    partial class uo_tp_dw
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
            this.dw_1 = new uo_dw();

            // dw_1
            this.dw_1.Name = "dw_1";
            this.dw_1.Dock = DockStyle.Fill;

            // uo_tp_dw (TabPage heredado)
            this.Name = "uo_tp_dw";
            this.Padding = new Padding(6);
            this.Controls.Add(this.dw_1);
        }
    }
}
