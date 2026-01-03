using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Minotti.Controls;

namespace Minotti.Views
{
    partial class w_tab
    {
        private IContainer components = null;

        // Control con el mismo nombre que en PB
        public uo_tab tab_1;

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
            this.tab_1 = new uo_tab();

            this.SuspendLayout();

            // tab_1
            this.tab_1.Name = "tab_1";
            this.tab_1.Location = new Point(12, 12);
            this.tab_1.Size = new Size(760, 536);
            this.tab_1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // w_tab
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(784, 561);
            this.Controls.Add(this.tab_1);
            this.Name = "w_tab";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "w_tab";

            this.ResumeLayout(false);
        }
    }
}
