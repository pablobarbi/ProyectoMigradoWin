using Minotti.Data;
using Minotti.Repositories;
using Minotti.Views.Basicos.Models;
using Minotti.Views.Reportes.Controls;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Informes.Controls
{
    // Migrado desde PowerBuilder Window: w_reporte_capitulo_filtro_todo.srw
    // Se conserva el nombre exacto y se adjunta el contenido original como comentario.
    public partial class w_reporte_capitulo_filtro_todo : w_reporte
    {
        // PB: uo_ds ds_reporte
        private uo_ds? ds_reporte;

        public w_reporte_capitulo_filtro_todo()
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
            // String ls_filtro, ls_filtrar
            uo_capitulos? ls_capitulos = null;
            long ll_capitulo;
            string? ls_filtro;
            string ls_filtrar;

            // PB: SetPointer(HourGlass!)
            var oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (dw_param.AcceptText() != 1)
                {
                    dw_param.SetFocus();
                    return;
                }

                ds_reporte = new uo_ds();
                ds_reporte.SetTransObject(SQLCA.Instance);
                ds_reporte.uof_setdataobject("dr_capitulo_completo");

                ll_capitulo = 0;
                ls_filtro = dw_param.GetItemString(1, "nombre");

                if (ls_filtro == null)
                {
                    MessageBox.Show("No hay registros", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (IsValid(dw_param)) dw_param.SetFocus();
                    return;
                }

                ls_capitulos = new uo_capitulos();
                ls_capitulos.capitulo_id = ll_capitulo;
                ls_capitulos.uo_cargar_info();
                ls_capitulos.uo_devolver_capitulo(ds_reporte);

                // comparto el buffer.
                ds_reporte.share_data(dw_reporte);

                // Si no encontró datos, envía un mensaje
                if (dw_reporte.RowCount() < 1)
                {
                    MessageBox.Show("No hay registros", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (IsValid(dw_param)) dw_param.SetFocus();
                    return;
                }
                else
                {
                    dw_reporte.SetFocus();
                }

                // HAGO LOS FILTROS POR CADA UNO DE LOS NIVELES
                // PB: "(upper(capitulo_nombre) like '%" + upper(ls_filtro) + "%')" + " OR ..."
                // En C#: replico concatenación literal.
                string filtroUpper = ls_filtro.ToUpperInvariant();

                ls_filtrar =
                    "(upper(capitulo_nombre) like '%" + filtroUpper + "%')" +
                    " OR (upper(rubrica_nombre) like '%" + filtroUpper + "%')" +
                    " OR (upper(subrubrica01_nombre) like '%" + filtroUpper + "%')" +
                    " OR (upper(subrubrica02_nombre) like '%" + filtroUpper + "%')" +
                    " OR (upper(subrubrica03_nombre) like '%" + filtroUpper + "%')" +
                    " OR (upper(subrubrica04_nombre) like '%" + filtroUpper + "%')" +
                    " OR (upper(subrubrica05_nombre) like '%" + filtroUpper + "%')" +
                    " OR (upper(subrubrica06_nombre) like '%" + filtroUpper + "%')" +
                    " OR (upper(subrubrica07_nombre) like '%" + filtroUpper + "%')" +
                    " OR (upper(subrubrica08_nombre) like '%" + filtroUpper + "%')" +
                    " OR (upper(subrubrica09_nombre) like '%" + filtroUpper + "%')" +
                    " OR (upper(subrubrica10_nombre) like '%" + filtroUpper + "%')";

                dw_reporte.SetFilter(ls_filtrar);
                dw_reporte.Filter();

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
            finally
            {
                Cursor.Current = oldCursor;
            }
        }

        private static bool IsValid(object? o) => o != null;
    }



}



