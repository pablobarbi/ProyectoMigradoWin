using Minotti.Views.Basicos.Controls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Minotti.Views.Basicos
{
    public partial class w_seleccionar
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dw_1 = new uo_dw();

            this.SuspendLayout();

            // 
            // w_seleccionar
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1800, 950);
            this.Name = "w_seleccionar";
            this.Text = "w_seleccionar";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // Posiciones PB:
            // pb_continuar: x = 151,  y = 776
            // pb_cancelar : x = 1426, y = 776
            this.pb_continuar.Location = new Point(151, 776);
            this.pb_continuar.Size = new Size(398, 105);
            this.pb_continuar.Text = "C&ontinuar";

            this.pb_cancelar.Location = new Point(1426, 776);
            this.pb_cancelar.Size = new Size(380, 105);
            this.pb_cancelar.Text = "&Cancelar";

            // 
            // dw_1
            // 
            this.dw_1.Name = "dw_1";
            this.dw_1.Location = new Point(40, 40);
            this.dw_1.Size = new Size(1500, 700);
            this.dw_1.TabIndex = 0;

            // 
            // Controls
            // 
            this.Controls.Add(this.dw_1);

            this.ResumeLayout(false);
        }

        protected  override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }
    }
}
