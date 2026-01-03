using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// Migrado desde PB Window 'w_reperto_capitulos' (deriva de w_abm_lista_seleccion).
    /// Se preservan nombres y se integra la lógica visible (sin inventar).
    /// </summary>
    public partial class w_reperto_capitulos : Form
    {
        /// <summary>DSN ODBC (SQL Anywhere 9) para emular USING SQLCA</summary>
        public string Dsn { get; set; } = string.Empty;

        public w_reperto_capitulos()
        {
            InitializeComponent();

            // El SRW no trae cuerpo de eventos; sólo se detectan los botones.
            // Cableamos hooks vacíos con los mismos nombres que en PB si luego querés pegar la lógica.
            this.cb_reperto_parcial.Click += (s, e) => cb_reperto_parcial_clicked();
            this.cb_reperto_total.Click += (s, e) => cb_reperto_total_clicked();
        }

        // Hooks con los mismos nombres para portar lógica PB si la compartís
        public void cb_reperto_parcial_clicked() { /* lógica PB específica no visible en el SRW */ }
        public void cb_reperto_total_clicked() { /* lógica PB específica no visible en el SRW */ }

        /// <summary>
        /// Bloques SQL visibles en el SRW (literal):
        /// RollBack;
        /// DELETE FROM reperto_parcial USING SQLCA;
        /// DELETE FROM reperto_parcial_med USING SQLCA;
        /// </summary>
        public void uo_borrar_todo_reperto_parcial()
        {
            if (string.IsNullOrWhiteSpace(this.Dsn))
                throw new InvalidOperationException("Debe asignar DSN para ejecutar SQL (USING SQLCA).");

            using var cn = new OdbcConnection($"DSN={this.Dsn};");
            cn.Open();
            using var tx = cn.BeginTransaction();
            try
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.Transaction = tx;
                    cmd.CommandText = "DELETE FROM reperto_parcial_med";
                    cmd.ExecuteNonQuery();
                }
                using (var cmd = cn.CreateCommand())
                {
                    cmd.Transaction = tx;
                    cmd.CommandText = "DELETE FROM reperto_parcial";
                    cmd.ExecuteNonQuery();
                }
                tx.Commit();
            }
            catch
            {
                try { tx.Rollback(); } catch {}
                throw;
            }
        }
    }
}