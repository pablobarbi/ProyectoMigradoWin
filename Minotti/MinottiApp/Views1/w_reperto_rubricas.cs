using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// Migrado desde PB Window 'w_reperto_rubricas' (deriva de w_abm_lista_seleccion).
    /// Se preservan nombres y se integra la lógica visible (sin inventar).
    /// </summary>
    public partial class w_reperto_rubricas : Form
    {
        /// <summary>DSN ODBC (SQL Anywhere 9) para emular USING SQLCA</summary>
        public string Dsn { get; set; } = string.Empty;

        /// <summary>Flag PB para commit/rollback</summary>
        public bool ib_grabar { get; set; } = true;

        public w_reperto_rubricas()
        {
            InitializeComponent();

            // Hooks con los mismos nombres si luego querés pegar la lógica PB exacta.
            this.cb_reperto_parcial.Click += (s, e) => cb_reperto_parcial_clicked();
            this.cb_reperto_total.Click += (s, e) => cb_reperto_total_clicked();
        }

        // Hooks con los mismos nombres para portar lógica PB si la compartís.
        public void cb_reperto_parcial_clicked() { /* lógica PB no visible en SRW */ }
        public void cb_reperto_total_clicked() { /* lógica PB no visible en SRW */ }

        /// <summary>
        /// Fragmento visible en SRW:
        /// If Not(ib_grabar) Then
        ///     RollBack;
        ///     /* Manejo de guo_app.at_error_db... */
        /// End If
        /// Dejamos helper para reflejar el rollback transaccional si hubo error.
        /// </summary>
        public void uo_rollback_si_error()
        {
            if (!this.ib_grabar)
            {
                // En PB: RollBack; además registra SqlDbCode/SqlErrText en guo_app.at_error_db.
                // Aquí documentamos la intención; el rollback real depende de dónde abras la transacción ODBC.
            }
        }
    }
}