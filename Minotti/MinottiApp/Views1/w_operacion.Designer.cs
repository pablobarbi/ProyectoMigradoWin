using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views1
{
    partial class w_operacion
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
            this.components = new Container();
            this.Name = "w_operacion";
            this.Text = "w_operacion";
            this.ClientSize = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.KeyPreview = true;
        }
    }
}
