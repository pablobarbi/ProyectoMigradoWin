using System;
using System.Windows.Forms;
using Minotti.Controls;
using Minotti.Models;

namespace Minotti.Views
{
    // Migración de PowerBuilder: w_seleccion.srw (window) desde w_response
    // Mantiene el nombre del tipo: w_seleccion
    public partial class w_seleccion : w_response
    {
        // Variables PB con los mismos nombres
        public uo_dw dw_1;                 // control de listado/selección
        public str_w_seleccion s_w_sel;    // estructura asociada
        
        public w_seleccion()
        {
            InitializeComponent();
        }

        // Si en el SRW hay más eventos (ue_continuar, ue_cancelar), pueden definirse aquí.
        // En w_response ya están declarados y pb_* mapean sus clicks.
        public override void ue_acomodar_objetos()
        {
            base.ue_acomodar_objetos();
            // Con Anchor y Dock ya se acomoda; si necesitás la lógica exacta de PB, la agrego acá.
        }
    }
}
