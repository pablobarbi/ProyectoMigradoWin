using Minotti.Views.Basicos.Controls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Minotti.Views.Basicos
{
    partial class w_ayuda
    {
        // dw_1 dw_1
        private uo_dw dw_1;

        private void InitializeComponent()
        {
            // IMPORTANTE: pb_continuar y pb_cancelar vienen de w_response (base)
            // Acá solo configuramos lo de w_ayuda y agregamos dw_1.

            this.dw_1 = new uo_dw();

            // dw_1 from uo_dw within w_ayuda
            this.dw_1.Name = "dw_1";
            this.dw_1.Left = 238; // PB: X=238
            this.dw_1.Top = 145;  // PB: Y=145
            this.dw_1.Border = true; // si tu uo_dw tiene esta prop
            this.dw_1.BorderStyle = BorderStyle.Fixed3D; // PB: StyleLowered!
            this.dw_1.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // Agrego al formulario
            this.Controls.Add(this.dw_1);

            // type pb_continuar ... Width=590 BringToTop=true
            this.pb_continuar.Width = 590;
            this.pb_continuar.BringToFront();
            this.pb_continuar.Click -= pb_continuar_Clicked;
            this.pb_continuar.Click += pb_continuar_Clicked;

            // type pb_cancelar ... Visible=false BringToTop=true
            this.pb_cancelar.Visible = false;
            this.pb_cancelar.BringToFront();

            // Window basics
            this.Name = "w_ayuda";
        }
    }
}
