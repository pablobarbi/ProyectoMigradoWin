using Minotti.Views.Basicos.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Minotti.Views.Basicos
{
    // PB: global type w_ver_datos from w_response
   

    public partial class w_ver_datos
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dw_1 = new uo_dw();

            this.SuspendLayout();

            // 
            // w_ver_datos
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 600);
            this.Name = "w_ver_datos";
            this.Text = "w_ver_datos";
            this.StartPosition = FormStartPosition.CenterParent;

            // pb_continuar / pb_cancelar vienen de w_response
            // Ajustamos sus posiciones según PB:
            // pb_continuar: X=151, Y=777
            // pb_cancelar : X=1427, Y=777
            // (en WinForms inicial el tamaño de la ventana es menor,
            //  luego ue_acomodar_objetos recalcula todo)
            this.pb_continuar.Left = 151;
            this.pb_continuar.Top = 450; // valor inicial, luego se recalcula
            this.pb_continuar.BringToFront();

            this.pb_cancelar.Left = 500; // valor inicial
            this.pb_cancelar.Top = 450;
            this.pb_cancelar.BringToFront();

            // Eventos click → disparan ue_continuar / ue_cancelar
            this.pb_continuar.Click += (s, e) => ue_continuar();
            this.pb_cancelar.Click += (s, e) => ue_cancelar();

            // 
            // dw_1
            // 
            this.dw_1.Name = "dw_1";
            this.dw_1.Left = 20;
            this.dw_1.Top = 20;
            this.dw_1.Width = 740;
            this.dw_1.Height = 380;
            this.dw_1.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // 
            // Controls
            // 
            this.Controls.Add(this.dw_1);

            this.ResumeLayout(false);
        }

        protected  override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
