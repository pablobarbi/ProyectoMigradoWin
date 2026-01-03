using System;
using System.Windows.Forms;
using Minotti.Models;

namespace Minotti.Views
{
    // Migración de PowerBuilder: w_carga_observaciones.srw (window) desde w_principal
    // Mantiene el nombre del tipo: w_carga_observaciones
    public partial class w_carga_observaciones : Form
    {
        // Variable de respuesta (mismo nombre usado en PB)
        public cat_response_string at_string = new cat_response_string();

        public w_carga_observaciones()
        {
            InitializeComponent();
        }

        // ===== Evento PB: cb_aceptar::clicked =====
        private void cb_aceptar_Click(object? sender, EventArgs e)
        {
            // Valida y devuelve el string
            int ok = ue_validar_string();
            if (ok == 1)
            {
                at_string.retorno = 1;
                at_string.valor = mle_campo.Text ?? string.Empty;
                // Equivalente a CloseWithReturn(parent, at_string)
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Mantener el foco para editar
                mle_campo.Focus();
            }
        }

        // ===== Evento PB: cb_cancelar::clicked =====
        private void cb_cancelar_Click(object? sender, EventArgs e)
        {
            // Cierra sin devolver el string (retorno = -1)
            at_string.retorno = -1;
            // Equivalente a CloseWithReturn(parent, at_string)
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ===== Evento/función PB: ue_validar_string() : integer =====
        public int ue_validar_string()
        {
            // En PB se suele validar que no esté vacío / que cumpla longitud, etc.
            // Mínimo: que tenga contenido no vacío.
            return string.IsNullOrWhiteSpace(mle_campo.Text) ? 0 : 1;
        }
    }
}
