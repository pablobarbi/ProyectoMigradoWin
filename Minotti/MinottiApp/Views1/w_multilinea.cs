using System;
using System.Windows.Forms;

namespace Minotti.Views
{
    public partial class w_multilinea : w_abm_detalle
    {
        private dynamic dw_2;

        public w_multilinea()
        {
            InitializeComponent();
        }

        public bool wf_datos_completos()
        {
            // Implementar validación de datos aquí si aplica
            return true;
        }

        public void ue_borrar_item()
        {
            // base.ue_borrar_item();
            if (dw_2.RowCount() <= 0)
                return;

            dw_2.DeleteRow(0);
        }

        public void ue_insertar_item()
        {
            // base.ue_insertar_item();
            int li_fila;

            // Inserta una fila en el detalle
            li_fila = dw_2.InsertRow(0);

            // Posicionarse en la fila nueva
            dw_2.ScrollToRow(li_fila);
            dw_2.SetRow(li_fila);
            dw_2.SetFocus();
        }
    }
}
