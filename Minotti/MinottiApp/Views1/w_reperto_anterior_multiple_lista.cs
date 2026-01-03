using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// Migrado desde PB Window 'w_reperto_anterior_multiple_lista' (deriva de w_reporte).
    /// Se preservan nombres y se integra la lógica visible (sin inventar).
    /// </summary>
    public partial class w_reperto_anterior_multiple_lista : Form
    {
        /// <summary>DSN ODBC (SQL Anywhere 9) para emular USING SQLCA</summary>
        public string Dsn { get; set; } = string.Empty;

        public w_reperto_anterior_multiple_lista()
        {
            InitializeComponent();

            // Hooks de click con los mismos nombres si luego querés portar las rutinas PB exactas.
            this.pb_total.Click += (s, e) => pb_total_clicked();
            this.pb_parcial.Click += (s, e) => pb_parcial_clicked();
            this.pb_ver.Click += (s, e) => pb_ver_clicked();
        }

        // Hooks con los MISMOS nombres para integrar la lógica PB si la compartís.
        public void pb_total_clicked() { /* lógica PB específica no visible en el SRW */ }
        public void pb_parcial_clicked() { /* lógica PB específica no visible en el SRW */ }
        public void pb_ver_clicked() { /* lógica PB específica no visible en el SRW */ }

        /// <summary>
        /// Bloque INSERT visible en el SRW (literal):
        /// INSERT INTO reperto_parcial_med (reperto_parcial, medicamento, orden, valor)
        ///         VALUES (:ll_Sintoma, :ls_medicamento, :ll_Fila2, :ll_Valor) USING SQLCA;
        /// </summary>
        public void uo_insert_reperto_parcial_med(long ll_Sintoma, string ls_medicamento, long ll_Fila2, decimal ll_Valor)
        {
            if (string.IsNullOrWhiteSpace(this.Dsn))
                throw new InvalidOperationException("Debe asignar DSN para ejecutar SQL (USING SQLCA).");

            using var cn = new OdbcConnection($"DSN={this.Dsn};");
            cn.Open();
            using var cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO reperto_parcial_med (reperto_parcial, medicamento, orden, valor) VALUES (?,?,?,?)";
            cmd.Parameters.Add("p1", OdbcType.BigInt).Value = ll_Sintoma;
            cmd.Parameters.Add("p2", OdbcType.VarChar).Value = ls_medicamento ?? (object)DBNull.Value;
            cmd.Parameters.Add("p3", OdbcType.BigInt).Value = ll_Fila2;
            cmd.Parameters.Add("p4", OdbcType.Decimal).Value = ll_Valor;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// INSERT con SELECT referenciado en el SRW (comentado allí). No inventamos el SELECT completo.
        /// </summary>
        public void uo_insert_reperto_parcial_med_desde_total(long il_reperto)
        {
            // El SRW muestra el patrón pero tiene el SELECT comentado. Cuando compartas el bloque activo, lo porto literal.
        }
    }
}