using System;
using System.Data;
using System.Windows.Forms;
using Minotti.Models;

namespace Minotti.Controls
{
    // Migración de PowerBuilder: uo_tp_dw.sru
    // En PB: "global type uo_tp_dw from uo_tp", aquí heredamos de uo_tp (TabPage).
    public partial class uo_tp_dw : uo_tp
    {
        // Control interno (PB: "type dw_1 from uo_dw within uo_tp_dw")
        public uo_dw dw_1;

        public uo_tp_dw()
        {
            InitializeComponent();
        }

        // ===== Funciones públicas (mismos nombres) =====

        // public function integer uof_ancho (); Return(dw_1.uof_ancho() + s_esp.borde * 2)
        public int uof_ancho()
        {
            return (dw_1?.uof_Ancho() ?? 0) + (s_esp?.borde ?? 0) * 2;
        }

        // public function integer uof_largo (); Return(dw_1.uof_largo() + s_esp.borde * 2)
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
            // PB: If dw_1.AcceptText() = -1 or dw_1.ModifiedCount() > 0 Then Return True
            return (dw_1.AcceptText() == -1) || (dw_1.ModifiedCount() > 0);
        }

        // public subroutine uof_setclaves (string parametros[])
        public void uof_setclaves(string[] parametros)
        {
            if (dw_1?.grid?.DataSource is DataTable dt && parametros != null && parametros.Length > 0)
            {
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    for (int c = 0; c < parametros.Length && c < dt.Columns.Count; c++)
                    {
                        // PB usa índices 1-based; aquí 0-based
                        dw_1.uof_setitem(r + 1, c + 1, parametros[c]);
                    }
                }
            }
            // Si no hay DataTable, no realizamos acción (compatibilidad)
        }

        // ===== Eventos PB transformados a métodos con el mismo nombre =====

        // event ue_seleccionado ()
        public void ue_seleccionado()
        {
            // Placeholder: en PB podría enfocarse dw_1 o similar
            dw_1?.Focus();
        }

        // event ue_leer_parametros; call super::ue_leer_parametros; dw_1.uof_SetDataObject( ... )
        public void ue_leer_parametros(ref st_pagina_carpeta arg_s_pag)
        {
            // Llamada al "super" ya existe como método en uo_tp (stub)
            base.ue_leer_parametros(ref arg_s_pag);

            // En PB se lee el DataObject desde los parámetros. Aquí, si viene algo en arg_s_pag.parametros lo usamos tal cual.
            if (dw_1 != null && arg_s_pag != null)
            {
                // Si el string trae múltiples parámetros separados (como en PB), tu función wf_ProxParam los partirá.
                // Aquí aplicamos directamente 'parametros' completo por falta de formato específico.
                var dataObj = arg_s_pag.parametros ?? string.Empty;
                dw_1.uof_SetDataObject(dataObj);
            }
        }
    }
}
