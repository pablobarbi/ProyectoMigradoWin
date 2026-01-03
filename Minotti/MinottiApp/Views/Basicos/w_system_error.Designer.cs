using Minotti.Views.Basicos.Controls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
 

namespace Minotti.Views.Basicos
{
    public partial class w_system_error
    {
        private System.ComponentModel.IContainer components = null;

        // Controles equivalentes a PB
        private uo_dw dw_error;
        private Button cb_imprimir;
        private Button cb_salir;
        private Button cb_continuar;

        private void InitializeComponent()
        {
            this.dw_error = new uo_dw();
            this.cb_imprimir = new Button();
            this.cb_salir = new Button();
            this.cb_continuar = new Button();
            this.SuspendLayout();

            // 
            // w_system_error
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 450);
            this.Name = "w_system_error";
            this.Text = "w_system_error";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Ocultar pb_continuar / pb_cancelar heredados de w_response (como en PB)
            this.pb_continuar.Visible = false;
            this.pb_cancelar.Visible = false;

            // 
            // dw_error
            // 
            this.dw_error.Name = "dw_error";
            this.dw_error.Left = 20;
            this.dw_error.Top = 20;
            this.dw_error.Width = 1150;
            this.dw_error.Height = 300;
            // En PB: Border = true; StyleLowered
            // Si tu uo_dw tiene propiedades equivalentes, las seteás acá.

            // 
            // cb_salir
            // 
            this.cb_salir.Name = "cb_salir";
            this.cb_salir.Text = "&Salir del Sistema";
            this.cb_salir.Left = 20;
            this.cb_salir.Top = 340;
            this.cb_salir.Width = 180;
            this.cb_salir.Height = 40;
            this.cb_salir.TabIndex = 0;
            this.cb_salir.Click += cb_salir_Click;

            // 
            // cb_continuar
            // 
            this.cb_continuar.Name = "cb_continuar";
            this.cb_continuar.Text = "&Continuar";
            this.cb_continuar.Left = 500;
            this.cb_continuar.Top = 340;
            this.cb_continuar.Width = 180;
            this.cb_continuar.Height = 40;
            this.cb_continuar.TabIndex = 1;
            this.cb_continuar.Click += cb_continuar_Click;

            // 
            // cb_imprimir
            // 
            this.cb_imprimir.Name = "cb_imprimir";
            this.cb_imprimir.Text = "&Imprimir";
            this.cb_imprimir.Left = 950;
            this.cb_imprimir.Top = 340;
            this.cb_imprimir.Width = 180;
            this.cb_imprimir.Height = 40;
            this.cb_imprimir.TabIndex = 2;
            this.cb_imprimir.Click += cb_imprimir_Click;

            // 
            // Controles en la ventana
            // 
            this.Controls.Add(this.dw_error);
            this.Controls.Add(this.cb_imprimir);
            this.Controls.Add(this.cb_salir);
            this.Controls.Add(this.cb_continuar);

            this.ResumeLayout(false);
        }

        protected  override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }
    }
}
