using System;
using System.Windows.Forms;

namespace Minotti.Views
{
    // Migración de PowerBuilder: w_response_string.srw (window) desde w_response
    // Mantiene el nombre del tipo: w_response_string
    public partial class w_response_string : w_response
    {
        public w_response_string()
        {
            InitializeComponent();
        }

        // En el SRW: pb_cancelar::clicked llama a ue_cancelar (el base ya lo hace).
        // Si necesitás lógica adicional, podés agregarla acá sin cambiar los nombres.
    }
}
