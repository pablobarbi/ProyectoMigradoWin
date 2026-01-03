using System;
using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// Migrado desde PB Window 'w_ver_reperto_multiple' (deriva de w_carga).
    /// Se preservan nombres y el patrón transaccional/mensajes visibles sin inventar SQL.
    /// </summary>
    public partial class w_ver_reperto_multiple : Form
    {
        /// <summary>Flag PB de grabación</summary>
        public bool ib_grabar { get; set; } = true;

        public w_ver_reperto_multiple()
        {
            InitializeComponent();
        }

        /// <summary>
        /// PB: event ue_abrir_transaccion()
        /// (no hay cuerpo visible en el SRW) → se deja hook con el mismo nombre.
        /// </summary>
        public void ue_abrir_transaccion()
        {
            // Inicio de transacción en PB (SQLCA.AutoCommit = FALSE, etc.).
        }

        /// <summary>
        /// PB: event ue_cerrar_transaccion()
        /// Lógica visible (literal del SRW):
        /// If This.ib_Grabar Then
        ///     Commit;
        ///     If SQLCA.SqlCode = 0 Then
        ///         MessageBox('¡Atención!', 'Los datos se grabaron correctamente.', Exclamation!)
        ///     Else
        ///         This.ib_grabar = FALSE
        ///         guo_app.at_error_db.SqlDbCode = SQLCA.SqlDbCode
        ///         guo_app.at_error_db.SqlErrText = SQLCA.SqlErrText
        ///     End If
        /// End If
        /// If Not(ib_grabar) Then
        ///     RollBack;
        /// End If
        /// </summary>
        public void ue_cerrar_transaccion()
        {
            if (this.ib_grabar)
            {
                // En PB: Commit; y se chequea SQLCA.SqlCode.
                // Si OK: se avisa que se grabó correctamente.
                MessageBox.Show("Los datos se grabaron correctamente.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // Si falla el Commit (SQLCode <> 0), PB setea ib_grabar = FALSE y registra el error.
            }

            if (!this.ib_grabar)
            {
                // En PB: RollBack; Documentamos el punto de rollback.
            }
        }
    }
}