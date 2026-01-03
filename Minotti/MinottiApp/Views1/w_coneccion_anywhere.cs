using System;
using System.Windows.Forms;
using Minotti.Data;

namespace Minotti.Views
{
    // Migración de PowerBuilder: w_coneccion_anywhere.srw
    // Herencia: from w_coneccion
    public partial class w_coneccion_anywhere : w_coneccion
    {
        public w_coneccion_anywhere()
        {
            InitializeComponent();
        }

        // === Eventos PB migrados a handlers WinForms con los mismos nombres de controles ===
        private void cb_probar_Click(object? sender, EventArgs e)
        {
            // Probar conexión usando conec_anywhere + SQLCA
            try
            {
                using var cnn = Minotti.Data.conec_anywhere.Abrir(sle_dsn.Text, sle_usuario.Text, sle_clave.Text);
                MessageBox.Show("Conexión OK.", "Prueba", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cb_aceptar_Click(object? sender, EventArgs e)
        {
            try
            {
                SQLCA.Connection = Minotti.Data.conec_anywhere.Abrir(sle_dsn.Text, sle_usuario.Text, sle_clave.Text);
                SQLCA.UserID = sle_usuario.Text;
                SQLCA.DBPass = sle_clave.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cb_cancelar_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
