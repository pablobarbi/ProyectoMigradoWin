using Minotti.Views.Reportes.Controls;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Informes.Controls
{
    // Migrado desde PowerBuilder Window: w_reporte_diagnosticos.srw
    // Se conserva el nombre exacto y se adjunta el contenido original como comentario.
    public partial class w_reporte_diagnosticos : w_reporte
    {
        public w_reporte_diagnosticos()
        {
            InitializeComponent();
        }

        // =====================================================
        // PB: event ue_procesar
        // =====================================================
        public override void ue_procesar()
        {
            // PB: String ls_datos, parametros[]
            string? ls_datos;
            string[] parametros;

            if (dw_param.AcceptText() != 1)
            {
                dw_param.SetFocus();
                return;
            }

            // dw_param.uof_getargumentos(parametros[], dw_param.GetRow())
            parametros = dw_param.uof_getargumentos(dw_param.GetRow());

            // parametros[3] = '%' + parametros[3] + '%'
            // (PB arrays son 1-based; en C# es 0-based. Para no inventar,
            //  ajusto suponiendo que tu uof_getargumentos devuelve 1-based "emulado"
            //  o 0-based real. Como no tengo tu implementación, lo dejo seguro:)
            if (parametros.Length > 3)
            {
                parametros[3] = "%" + parametros[3] + "%";
            }

            ls_datos = dw_param.GetItemString(1, "tipo_diagnostico");
            if (ls_datos == null || ls_datos.Trim() == "")
            {
                MessageBox.Show(
                    "Es necesario completar el tipo de diagnóstico antes de procesar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            ls_datos = dw_param.GetItemString(1, "diag_nosologico");
            if (ls_datos == null || ls_datos.Trim() == "")
            {
                MessageBox.Show(
                    "Es necesario completar el diagnóstico antes de procesar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            // PB: SetPointer(HourGlass!)
            var oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                dw_reporte.uof_retrieve(parametros);

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