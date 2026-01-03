using Minotti.Views.Basicos.Controls;
using System.ComponentModel;
using System.Windows.Forms;

namespace Minotti.Views.Repertorizaciones.Controls
{
    partial class w_carga_reperto_total
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
            // w_carga_reperto_total
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Name = "w_carga_reperto_total";
            this.Text = "w_carga_reperto_total";

            // 
            // dw_1
            // 
            this.dw_1.Left = 24;
            this.dw_1.Top = 24;
            this.dw_1.Width = 1500;
            this.dw_1.Height = 650;
            this.dw_1.TabIndex = 10;

            // 
            // Controls
            // 
            this.Controls.Add(this.dw_1);

            this.ResumeLayout(false);
        }
    }
}