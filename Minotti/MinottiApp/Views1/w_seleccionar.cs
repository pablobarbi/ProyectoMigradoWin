using System;
using System.Windows.Forms;
using Minotti.Controls;
using Minotti.Models;

namespace Minotti.Views
{
    // Migración de PowerBuilder: w_seleccionar.srw
    // Hereda de w_response; ajusto si me pasás la base exacta.
    public partial class w_seleccionar : w_response
    {
        public w_seleccionar()
        {
            InitializeComponent();
        }

        // Si en PB había eventos ue_continuar/ue_cancelar, ya están en w_response y quedan mapeados por los pb_*.
        // Agrego cualquier otra lógica si me das los cuerpos del SRW.
    }
}
