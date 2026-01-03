using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Minotti.Views.Basicos.Controls;

namespace Minotti.Views.Basicos
{
    public partial class w_seleccion_n_filas
    {
        private System.ComponentModel.IContainer components = null;

        // PB: uo_dw dw_1
        private uo_dw dw_1;

        protected  override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dw_1 = new uo_dw();

            this.SuspendLayout();

            // 
            // w_seleccion_n_filas
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1780, 900);
            this.Name = "w_seleccion_n_filas";
            this.Text = "w_seleccion_n_filas";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // pb_continuar / pb_cancelar vienen de w_response.
            // Ajustamos su posición similar al PB:
            // PB: pb_continuar X=151, Y=777; pb_cancelar X=1427, Y=777

            this.pb_continuar.Location = new Point(151, 777);
            this.pb_continuar.Size = new Size(398, 105);
            this.pb_continuar.Text = "Continuar";

            this.pb_cancelar.Location = new Point(1427, 777);
            this.pb_cancelar.Size = new Size(380, 105);
            this.pb_cancelar.Text = "Cancelar";

            // 
            // dw_1  (PB: se calcula en ue_acomodar_objetos, acá sólo lo creamos básico)
            // 
            this.dw_1.Name = "dw_1";
            this.dw_1.Location = new Point(40, 40);
            this.dw_1.Size = new Size(1500, 600);
            this.dw_1.TabIndex = 0;

            // 
            // Controls
            // 
            this.Controls.Add(this.dw_1);

            this.ResumeLayout(false);
        }
    }
}
