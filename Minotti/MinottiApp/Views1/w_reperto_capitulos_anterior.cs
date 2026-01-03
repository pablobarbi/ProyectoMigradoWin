using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// Migrado desde PB Window 'w_reperto_capitulos_anterior' (deriva de w_abm_lista_seleccion).
    /// Se preservan nombres y se integra la lógica visible (sin inventar).
    /// </summary>
    public partial class w_reperto_capitulos_anterior : Form
    {
        /// <summary>DSN ODBC (SQL Anywhere 9) para emular USING SQLCA</summary>
        public string Dsn { get; set; } = string.Empty;

        /// <summary>Flag de grabación como en PB</summary>
        public bool ib_grabar { get; set; } = true;

        public w_reperto_capitulos_anterior()
        {
            InitializeComponent();

            // Hooks de click con los mismos nombres si luego querés portar las rutinas PB exactas.
            this.cb_reperto_parcial.Click += (s, e) => cb_reperto_parcial_clicked();
            this.cb_reperto_total.Click += (s, e) => cb_reperto_total_clicked();
        }

        // Hooks con los mismos nombres para portar lógica PB si la compartís.
        public void cb_reperto_parcial_clicked() { /* lógica PB específica no visible en el SRW */ }
        public void cb_reperto_total_clicked() { /* lógica PB específica no visible en el SRW */ }

        /// <summary>
        /// Fragmento visible en SRW relativo a rollback si ib_grabar = FALSE.
        /// No hay SQL explícito previo en el bloque visible, pero dejamos helper para ejecutar un rollback transaccional.
        /// </summary>
        public void uo_rollback_si_error()
        {
            if (string.IsNullOrWhiteSpace(this.Dsn))
                return;

            using var cn = new OdbcConnection($"DSN={this.Dsn};");
            cn.Open();
            using var tx = cn.BeginTransaction();
            try
            {
                // No se ejecuta nada; se documenta la intención de RollBack;
                tx.Rollback();
            }
            catch
            {
                // silencioso: la intención es sólo reflejar el patrón PB
            }
        }
    }
}