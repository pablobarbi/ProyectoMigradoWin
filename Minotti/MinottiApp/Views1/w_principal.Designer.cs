using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views
{
    partial class w_principal
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
            this.Name = "w_principal";
            this.Text = "w_principal";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(800, 600);
        }
    }
}
