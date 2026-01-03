using System;
using System.Windows.Forms;
using Minotti.Controls;
using Minotti.Models;
namespace Minotti.Views
{
    // Migración de PowerBuilder: w_seleccion_share.srw
    // Herencia: from w_response (ajustable si me pasás la base exacta)
    public partial class w_seleccion_share : w_response
    {
        public w_seleccion_share()
        {
            InitializeComponent();
        }

        // Si el SRW original tenía eventos (ue_continuar/ue_cancelar), ya están en w_response.
        // Agregamos aquí cualquier lógica adicional si me compartís esos cuerpos.
    }
}
