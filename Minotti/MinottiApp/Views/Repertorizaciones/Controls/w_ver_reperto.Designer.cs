using Minotti.Views.Basicos.Controls;
using System.ComponentModel;
using System.Windows.Forms;

namespace Minotti.Views.Repertorizaciones.Controls
{
    partial class w_ver_reperto
    {
        private IContainer? components = null;

        private uo_dw dw_1 = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dw_1 = new uo_dw();
            this.SuspendLayout();

            // 
            // dw_1
            // 
            this.dw_1.Left = 24;
            this.dw_1.Top = 24;
            this.dw_1.Width = 1600;
            this.dw_1.Height = 850;
            this.dw_1.TabIndex = 10;

            // 
            // w_ver_reperto
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1700, 920);
            this.Name = "w_ver_reperto";
            this.Text = "w_ver_reperto";

            this.Controls.Add(this.dw_1);
            this.ResumeLayout(false);
        }
    }
}