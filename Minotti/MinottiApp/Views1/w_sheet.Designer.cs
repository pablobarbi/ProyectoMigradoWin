using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views
{
    partial class w_sheet
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
            this.Name = "w_sheet";
            this.Text = "w_sheet";
            this.ClientSize = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;
        }
    }
}
