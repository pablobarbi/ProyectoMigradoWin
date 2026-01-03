using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Minotti.Controls
{
    partial class uo_tab
    {
        private IContainer components = null;
        public TabControl tab;

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
            tab = new TabControl();

            SuspendLayout();
            // tab
            tab.Name = "tab";
            tab.Dock = DockStyle.Fill;

            // uo_tab
            this.Name = "uo_tab";
            this.Size = new Size(800, 500);
            this.Controls.Add(tab);
            ResumeLayout(false);
        }
    }
}
