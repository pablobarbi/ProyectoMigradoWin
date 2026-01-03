using System;
using System.Data;
using System.Windows.Forms;
using Minotti.Models;

namespace Minotti.Controls
{
    // Migración de PowerBuilder: uo_tp_multilinea.sru
    // En PB: "global type uo_tp_multilinea from uo_tp"
    public partial class uo_tp_multilinea : uo_tp
    {
        // Controles internos (mismos nombres PB)
        public uo_dw dw_1;
        public Button pb_insertar;
        public Button pb_borrar;

        public uo_tp_multilinea()
        {
            InitializeComponent();
        }

        // ===== Funciones (mismos nombres/firmas) =====

        // public function integer uof_ancho ()
        public int uof_ancho()
        {
            return (dw_1?.uof_Ancho() ?? 0) + (s_esp?.borde ?? 0) * 2;
        }

        // public function integer uof_largo ()
        public int uof_largo()
        {
            return (dw_1?.uof_Largo() ?? 0) + (s_esp?.borde ?? 0) * 2;
        }

        // public function boolean uof_getclaves (ref string parametros[], integer fila)
        public bool uof_getclaves(ref string[] parametros, int fila)
        {
            if (dw_1 == null) { parametros = Array.Empty<string>(); return false; }
            return dw_1.uof_getclaves(ref parametros, fila);
        }

        // public function boolean uof_cambios_pendientes ()
        public bool uof_cambios_pendientes()
        {
            if (dw_1 == null) return false;
            return (dw_1.AcceptText() == -1) || (dw_1.ModifiedCount() > 0);
        }

        // ===== Subrutinas (mismos nombres/firmas) =====

        // public subroutine uof_setclaves (string parametros[])
        public void uof_setclaves(string[] parametros)
        {
            if (dw_1?.grid?.DataSource is DataTable dt && parametros != null && parametros.Length > 0)
            {
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    for (int c = 0; c < parametros.Length && c < dt.Columns.Count; c++)
                    {
                        dw_1.uof_setitem(r + 1, c + 1, parametros[c]);
                    }
                }
            }
        }

        // ===== Evento PB convertido a método =====

        public void ue_seleccionado()
        {
            dw_1?.Focus();
        }
    }
}
