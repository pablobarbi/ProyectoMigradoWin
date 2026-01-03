using System.ComponentModel;
using System.Windows.Forms;

namespace Minotti.Views.Abm.Controls
{
    partial class w_abm_lista
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
            this.SuspendLayout();

            // 
            // w_abm_lista
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Name = "w_abm_lista";
            this.Text = "w_abm_lista";
            this.ResumeLayout(false);
        }
    }
}
