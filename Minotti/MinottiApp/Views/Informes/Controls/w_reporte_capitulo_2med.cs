using Minotti.Data;
using Minotti.Repositories;
using Minotti.Views.Basicos.Models;
using Minotti.Views.Reportes.Controls;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Informes.Controls
{
    // Migrado desde PowerBuilder Window: w_reporte_capitulo_2med.srw
    // Se conserva el nombre exacto y se adjunta el contenido original como comentario.
    public partial class w_reporte_capitulo_2med : w_reporte
    {
        // PB: uo_ds ds_reporte
        private uo_ds? ds_reporte;

        public w_reporte_capitulo_2med()
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
            // Long ll_capitulo
            // String ls_medicamento, ls_medicamento2
            uo_capitulos? ls_capitulos = null;
            long ll_capitulo;
            string? ls_medicamento;
            string? ls_medicamento2;

            // PB: SetPointer(HourGlass!)
            var oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // If dw_param.AcceptText() <> 1 Then ...
                if (dw_param.AcceptText() != 1)
                {
                    dw_param.SetFocus();
                    return;
                }

                // ds_reporte = create uo_ds
                ds_reporte = new uo_ds();
                ds_reporte.SetTransObject(SQLCA.Instance);
                ds_reporte.uof_setdataobject("dr_capitulo_completo");

                ll_capitulo = (long)dw_param.GetItemNumber(1, "capitulo");
                ls_medicamento = dw_param.GetItemString(1, "medicamento");
                ls_medicamento2 = dw_param.GetItemString(1, "medicamento2");

                // IF IsNull(ll_capitulo) OR IsNull(ls_medicamento) OR IsNull(ls_medicamento2) THEN ...
                if (dw_param.IsNull(1, "capitulo") || ls_medicamento == null || ls_medicamento2 == null)
                {
                    MessageBox.Show(
                        "Es necesario completar todos los valores antes de procesar.",
                        "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                // IF ls_medicamento = ls_medicamento2 THEN ...
                if (ls_medicamento == ls_medicamento2)
                {
                    MessageBox.Show(
                        "Es necesario que los medicamentos sean distintos.",
                        "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                // ls_capitulos = CREATE uo_capitulos
                ls_capitulos = new uo_capitulos();
                ls_capitulos.capitulo_id = ll_capitulo;
                ls_capitulos.uo_cargar_info();
                ls_capitulos.uo_devolver_un_med(ds_reporte, ls_medicamento);
                ls_capitulos.uo_devolver_un_med(ds_reporte, ls_medicamento2);

                // comparto el buffer.
                ds_reporte.share_data(dw_reporte);

                // If dw_reporte.RowCount() < 1 Then ...
                if (dw_reporte.RowCount() < 1)
                {
                    MessageBox.Show(
                        "No hay registros",
                        "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    if (IsValid(dw_param)) dw_param.SetFocus();
                }
                else
                {
                    dw_reporte.SetFocus();
                }
            }
            finally
            {
                Cursor.Current = oldCursor;
            }
        }

        private static bool IsValid(object? o) => o != null;
    }
}