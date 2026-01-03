using Minotti.Views.Reportes.Controls;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Informes.Controls
{
    // Migrado desde PowerBuilder Window: w_reporte_matriz.srw
    // Se conserva el nombre exacto y se adjunta el contenido original como comentario.

    public partial class w_reporte_matriz : w_reporte
    {
        public w_reporte_matriz()
        {
            InitializeComponent();
        }

        // =====================================================
        // PB: event ue_procesar (ANCESTOR SCRIPT OVERRIDE)
        // =====================================================
        public override void ue_procesar()
        {
            // PB: string parametros[], string filtro, long rtn
            string[] parametros = Array.Empty<string>();
            string? filtro;
            int rtn;

            // PB: SetPointer(HourGlass!)
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
                rtn = (int)MessageBox.Show(
                    "Si actualizó capítulo, rúbrica o subrúbrica, invoque y procese primero Actualizar Matriz de Capítulos para que se incluyan en esta búsqueda esos cambios.",
                    "Atención",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2);

                if (rtn == (int)DialogResult.OK)
                {
                    // PB: filtro = parametros[1]
                    filtro = (parametros.Length > 1) ? parametros[1] : null;

                    // PB: if (len(filtro) < 3) OR isnull(filtro) then
                    if (filtro == null || filtro.Length < 3)
                    {
                        MessageBox.Show(
                            "Debe ingresar al menos 3 letras como filtro.",
                            "Atención",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        dw_param.SetFocus();
                    }
                    else
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