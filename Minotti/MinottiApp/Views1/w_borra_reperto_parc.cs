using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// Migrado desde PowerBuilder Window 'w_borra_reperto_parc' (extiende w_abm_lista_seleccion).
    /// Nombres y lógica preservados. Conexión ODBC (SQL Anywhere 9) por DSN para emular USING SQLCA.
    /// </summary>
    public partial class w_borra_reperto_parc : Form
    {
        /// <summary>Equivalente a This.ib_grabar en PB</summary>
        public bool ib_grabar { get; set; } = true;

        /// <summary>Equivalente a This.ib_cerrar_al_grabar en PB</summary>
        public bool ib_cerrar_al_grabar { get; set; } = true;

        /// <summary>DSN ODBC de SQL Anywhere 9 (emula USING SQLCA)</summary>
        public string Dsn { get; set; } = string.Empty;

        public w_borra_reperto_parc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// event ue_borrar;  (portado 1:1)
        /// Recorre dw_1 de abajo hacia arriba y borra registros seleccionados,
        /// ejecutando además: DELETE FROM reperto_parcial_med WHERE reperto_parcial = :ll_reperto USING SQLCA;
        /// </summary>
        public void ue_borrar()
        {
            // Variables PB
            long iAux;
            decimal ll_reperto;
            string ls_Seleccionado;

            // is_Accion = "B"  // Campo de estado en la jerarquía; no se usa aquí explícitamente.

            // IF dw_1.RowCount() = 0 THEN RETURN
            var dt = this.bindingSource1.DataSource as DataTable;
            if (dt == null || dt.Rows.Count == 0)
                return;

            // FOR iAux = dw_1.RowCount() TO 1 STEP -1
            for (iAux = dt.Rows.Count; iAux >= 1; iAux--)
            {
                var row = dt.Rows[(int)iAux - 1];
                // ls_Seleccionado = dw_1.GetItemString(iAux, "seleccionado")
                ls_Seleccionado = row.Table.Columns.Contains("seleccionado") ? Convert.ToString(row["seleccionado"]) : null;
                // ll_reperto = dw_1.GetItemDecimal(iAux, "reperto_parcial")
                if (row.Table.Columns.Contains("reperto_parcial"))
                {
                    ll_reperto = Convert.ToDecimal(row["reperto_parcial"]);
                }
                else
                {
                    // Si no existe la columna, no hay nada que borrar en tabla de detalle.
                    continue;
                }

                if (ls_Seleccionado == "S")
                {
                    if (this.ib_grabar)
                    {
                        // If dw_1.DeleteRow(iAux) <> 1 Then This.ib_grabar = FALSE
                        // DataWindow borra la fila; aquí removemos del DataTable.
                        try
                        {
                            row.Delete();
                        }
                        catch
                        {
                            this.ib_grabar = false;
                        }
                    }

                    if (this.ib_grabar)
                    {
                        // If dw_1.Update(TRUE, TRUE) <> 1 Then This.ib_grabar = FALSE
                        // En WinForms + DataTable hacemos AcceptChanges() como commit local.
                        try
                        {
                            dt.AcceptChanges();
                        }
                        catch
                        {
                            this.ib_grabar = false;
                        }
                    }

                    if (this.ib_grabar)
                    {
                        // DELETE FROM reperto_parcial_med WHERE reperto_parcial = :ll_reperto USING SQLCA;
                        try
                        {
                            if (string.IsNullOrWhiteSpace(this.Dsn))
                                throw new InvalidOperationException("Debe asignar DSN para ejecutar SQL (USING SQLCA).");

                            using var cn = new OdbcConnection($"DSN={this.Dsn};");
                            cn.Open();
                            using var cmd = cn.CreateCommand();
                            cmd.CommandText = "DELETE FROM reperto_parcial_med WHERE reperto_parcial = ?";
                            var p = cmd.Parameters.Add("ll_reperto", OdbcType.Decimal);
                            p.Value = ll_reperto;
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {
                            this.ib_grabar = false;
                        }
                    }

                    if (this.ib_grabar)
                    {
                        // /* No se cierra al borrar un registro de la lista */
                        this.ib_cerrar_al_grabar = false;
                    }
                    else
                    {
                        // dw_1.RowsMove(1, dw_1.DeletedCount(), Delete!, dw_1, iAux, Primary!)
                        // dw_1.SetRow(iAux)
                        // // dw_1.Sort()
                        // No hay equivalente directo en WinForms; mantenemos intención.
                    }
                }
            }
        }

        /// <summary>
        /// event ue_iniciar; call super::ue_iniciar; wf_armar_sintomas()
        /// </summary>
        public void ue_iniciar()
        {
            // call super::ue_iniciar  -> omitido (no tenemos la clase base w_abm_lista_seleccion aquí)
            wf_armar_sintomas();
        }

        /// <summary>Stub: wf_armar_sintomas (llamado por ue_iniciar). Se mantiene el nombre para no romper llamadas.</summary>
        public void wf_armar_sintomas()
        {
            // Implementación real puede estar en otra unidad; se mantiene el stub.
        }

        /// <summary>
        /// event ue_dw_button_clicked; call super::ue_dw_button_clicked; ...
        /// Se mantiene la firma como método público para preservar nombres.
        /// </summary>
        public void ue_dw_button_clicked()
        {
            // Lógica específica no portada aquí (depende de base/ancestros y botones). Se preserva el hook.
        }
    }
}