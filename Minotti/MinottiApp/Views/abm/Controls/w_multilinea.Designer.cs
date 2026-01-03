using System.ComponentModel;
using System.Windows.Forms;

namespace Minotti.Views.Abm.Controls
{
    partial class w_multilinea
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Name = "w_multilinea";
            this.Text = "w_multilinea";
        }
    }
}
