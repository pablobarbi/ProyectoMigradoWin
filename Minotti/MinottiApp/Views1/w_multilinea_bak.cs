using System;
using System.Windows.Forms;

namespace Minotti.Views
{
    public partial class w_multilinea_bak : w_operacion
    {
        private dynamic dw_1;
        private dynamic dw_2;

        public w_multilinea_bak()
        {
            InitializeComponent();
        }

        public bool wf_cambios_pendientes()
        {
            // Implementar lógica real si es necesario
            return true;
        }

        public void ue_deshabilitar_clave()
        {
            // base.ue_deshabilitar_clave();
            int cant_claves = dw_2.ii_claves.Length;

            for (int iAux = 1; iAux <= cant_claves; iAux++)
            {
                string clave = dw_2.ii_claves[iAux];
                string visible = dw_2.Describe("#" + clave + ".Visible");
                if (visible == "1")
                {
                    dw_2.Modify("#" + clave + ".Protect='0\t If(IsRowNew(),0,1)'");
                }
            }
        }

        public void ue_insertar_item()
        {
            // base.ue_insertar_item();
            int li_fila = dw_2.InsertRow(0);
            dw_2.ScrollToRow(li_fila);
            dw_2.SetRow(li_fila);
            dw_2.SetFocus();
        }

        public void ue_borrar_item()
        {
            // base.ue_borrar_item();
            if (dw_2.RowCount() <= 0)
                return;

            dw_2.DeleteRow(0);
        }
    }
}
