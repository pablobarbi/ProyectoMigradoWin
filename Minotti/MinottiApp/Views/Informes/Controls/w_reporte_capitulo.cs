using Minotti.Repositories;
using Minotti.utils;
using Minotti.Views.Basicos.Models;
using Minotti.Views.Reportes.Controls;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Informes.Controls
{
    // Migrado desde PowerBuilder Window: w_reporte_capitulo.srw
    // Se conserva el nombre exacto y se adjunta el contenido original como comentario.
    public partial class w_reporte_capitulo : w_reporte
    {
        // PB: uo_ds ds_reporte
        private uo_ds? ds_reporte;

        public w_reporte_capitulo()
        {
            InitializeComponent();
        }

        // =====================================================
        // PB: event ue_procesar (ANCESTOR SCRIPT OVERRIDE)
        // =====================================================
        public override void ue_procesar()
        {
            // PB:
            // uo_capitulos ls_capitulos
            // string parametros[]
            // Long ll_capitulo, rtn
            uo_capitulos? ls_capitulos = null; // declarada pero no usada (igual que PB)
            string[] parametros = Array.Empty<string>();
            long ll_capitulo;
            int rtn;

            // PB: SetPointer(HourGlass!)
            // (si tenés helper, usalo; si no, dejo cursor)
            var oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (IsValid(dw_param))
                {
                    if (dw_param.AcceptText() != 1)
                    {
                        dw_param.SetFocus();
                        return;
                    }

                    // dw_param.uof_getargumentos(parametros[], dw_param.GetRow())
                    parametros = dw_param.uof_getargumentos(dw_param.GetRow());
                }

                // PB: rtn = MessageBox(..., Exclamation!, OKCancel!, 2)
                // PB: if rtn = 1 then  (OK)
                rtn =(int)MessageBoxPB.MessageBox(
                    "Si actualizó capítulo, rúbrica o subrúbrica, invoque y procese primero Actualizar Matriz de Capítulos para que se incluyan en esta búsqueda esos cambios.",
                    "Atención",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2);

                if (rtn == (int)DialogResult.OK)
                {
                    // ll_capitulo = dw_param.GetItemNumber(1,'capitulo')
                    ll_capitulo = (long)dw_param.GetItemNumber(1, "capitulo");

                    // If IsNull(ll_capitulo) Then ...
                    // En C# asumimos que GetItemNumber devuelve nullable si tu uo_dw lo soporta;
                    // si no lo soporta, dejá la versión long? abajo.
                    //
                    // ✅ Versión segura si GetItemNumber retorna long?
                    // long? llCap = dw_param.GetItemNumberNullable(1, "capitulo");
                    // if (llCap == null) { ... }
                    //
                    // Como no quiero inventar métodos, hago:
                    if (ll_capitulo == 0 && dw_param.IsNull(1, "capitulo"))
                    {
                        MessageBox.Show("Es obligatorio seleccionar un capitulo.", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (IsValid(dw_param)) dw_param.SetFocus();
                        return;
                    }

                    // dw_reporte.uof_retrieve(parametros[])
                    dw_reporte.uof_retrieve(parametros);

                    // If dw_reporte.RowCount() < 1 Then ...
                    if (dw_reporte.RowCount() < 1)
                    {
                        MessageBox.Show("No hay registros", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (IsValid(dw_param)) dw_param.SetFocus();
                    }
                    else
                    {
                        dw_reporte.SetFocus();
                    }
                }
            }
            finally
            {
                Cursor.Current = oldCursor;
            }
        }

        // PB: IsValid()
        private static bool IsValid(object? o) => o != null;
    }
}