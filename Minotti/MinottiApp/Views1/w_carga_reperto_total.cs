using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// Migrado desde PowerBuilder Window 'w_carga_reperto_total' (deriva de w_carga).
    /// Se preservan nombres y se integra la lógica visible del SRW sin inventar.
    /// </summary>
    public partial class w_carga_reperto_total : Form
    {
        /// <summary>Emula flags PB</summary>
        public bool ib_grabar { get; set; } = true;
        public bool ib_AutoCommit { get; set; } = true;

        /// <summary>DSN ODBC (SQL Anywhere 9) para emular USING SQLCA</summary>
        public string Dsn { get; set; } = string.Empty;

        public w_carga_reperto_total()
        {
            InitializeComponent();

            // Port del 'clicked' que muestra confirmación y borra el síntoma seleccionado.
            this.cb_borrar.Click += (s, e) => cb_borrar_clicked();
        }

        /// <summary>
        /// Extraído del SRW: evento de borrar elemento seleccionado en dw_1 y sus detalles.
        /// </summary>
        public void cb_borrar_clicked()
        {
            // Variables PB: Long ll_Orden, ll_Rtn, ll_RepertoParcial
            long ll_Orden, ll_Rtn, ll_RepertoParcial;

            // ll_Orden = dw_1.GetRow()
            // ll_RepertoParcial = dw_1.GetItemNumber(ll_Orden, 'reperto_parcial')
            if (dw_1.DataSource is not DataTable dt1 || dt1.Rows.Count == 0)
                return;

            ll_Orden = dw_1.CurrentRow >= 0 ? dw_1.CurrentRow + 1 : 0;
            if (ll_Orden <= 0) return;

            var idx = (int)ll_Orden - 1;
            if (!dt1.Columns.Contains("reperto_parcial")) return;
            ll_RepertoParcial = Convert.ToInt64(Convert.ToDecimal(dt1.Rows[idx]["reperto_parcial"]));

            // Confirmación
            var msg = $"Esta seguro que desea borrar el síntoma de orden: {ll_Orden}";
            var dr = MessageBox.Show(msg, "Borrar Síntoma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            ll_Rtn = (dr == DialogResult.Yes) ? 1 : 0;

            if (ll_Rtn == 1)
            {
                // DELETE FROM reperto_parcial_med WHERE reperto_parcial = :ll_RepertoParcial USING SQLCA;
                // DELETE FROM reperto_parcial WHERE reperto_parcial = :ll_RepertoParcial USING SQLCA;
                try
                {
                    if (string.IsNullOrWhiteSpace(this.Dsn))
                        throw new InvalidOperationException("Debe asignar DSN para ejecutar SQL (USING SQLCA).");

                    using var cn = new OdbcConnection($"DSN={this.Dsn};");
                    cn.Open();
                    using (var tx = cn.BeginTransaction())
                    {
                        using (var cmd = cn.CreateCommand())
                        {
                            cmd.Transaction = tx;
                            cmd.CommandText = "DELETE FROM reperto_parcial_med WHERE reperto_parcial = ?";
                            var p = cmd.Parameters.Add("p1", OdbcType.BigInt);
                            p.Value = ll_RepertoParcial;
                            cmd.ExecuteNonQuery();
                        }
                        using (var cmd = cn.CreateCommand())
                        {
                            cmd.Transaction = tx;
                            cmd.CommandText = "DELETE FROM reperto_parcial WHERE reperto_parcial = ?";
                            var p = cmd.Parameters.Add("p1", OdbcType.BigInt);
                            p.Value = ll_RepertoParcial;
                            cmd.ExecuteNonQuery();
                        }
                        tx.Commit();
                    }
                }
                catch
                {
                    this.ib_grabar = false;
                }
            }

            // Si no se grabaron los datos ... RollBack;
            if (!this.ib_grabar)
            {
                // Rollback ya se realizó en catch si hubo error en SQL; aquí reflejamos la intención PB.
                // f_error_base_de_datos() -> no implementado aquí.
            }

            // SQLCA.AutoCommit = This.ib_AutoCommit  -> no aplica directo en ODBC .NET; se documenta la intención.
        }
    }
}