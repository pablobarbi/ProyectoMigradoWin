using System;
using System.Windows.Forms;
using Minotti.Models;

namespace Minotti.Controls
{
    // Extensión parcial de uo_tab para agregar los métodos que invoca uo_tp
    public partial class uo_tab : UserControl
    {
        // Equivalente al dynamic event ue_dw_cambio_fila(uo_dw arg_objeto)
        public void ue_dw_cambio_fila(uo_dw arg_objeto)
        {
            // En el SRU original este evento se disparaba dinámicamente desde uo_tp hacia el padre.
            // Si no hay lógica específica, se puede dejar vacío.
        }

        // Equivalente al dynamic event integer ue_dw_itemchanged(uo_dw arg_objeto, long row, dwobject dwo, string data)
        public int ue_dw_itemchanged(uo_dw arg_objeto, long row, object dwo, string data)
        {
            // En PowerBuilder devolvía lo que devolviera el evento del padre.
            // Si acá no tenés validación extra, devolver 0 (OK) es lo más neutro.
            return 0;
        }
    }
}
