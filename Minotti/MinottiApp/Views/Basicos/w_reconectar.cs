using Minotti.Data;
using Minotti.Views.Basicos.Models;
using System;
using System.Net;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    // Migración de PowerBuilder: w_reconectar.srw (window) desde w_response
    // Mantiene el nombre del tipo: w_reconectar
    // PB: global type w_reconectar from w_response
    public partial class w_reconectar : w_response
    {
        // === variables PB ===
        // Integer cnt_conecciones = 1
        private int cnt_conecciones = 1;

        // Cat_usuario at_usuario
        private cat_usuario at_usuario = new cat_usuario();

        /// <summary>
        /// Código de retorno PB:
        ///  1  = validó usuario/password
        /// -1  = cancelado / falló validación
        /// </summary>
        public int ReturnCode { get; private set; } = -1;

        public w_reconectar()
        {
            InitializeComponent();

            // Equivalente a eventos open / ue_continuar / ue_cancelar / pb_*
            this.Load += w_reconectar_Load;

            pb_continuar.Click += pb_continuar_clicked;
            pb_cancelar.Click += pb_cancelar_clicked;
        }

        // === OPEN ===
        private void w_reconectar_Load(object? sender, EventArgs e)
        {
            // PB: sle_usuario.SetFocus()
            sle_usuario.Focus();

            // PB: at_usuario = guo_app.uof_GetUsuario()
            at_usuario = guo_app.Instance.uof_getusuario();
        }

        // === ue_continuar ===
        private void ue_continuar()
        {
            // PB:
            // if cnt_conecciones > 3 then
            //   CloseWithReturn(This,-1)
            //   return
            // else
            //   cnt_conecciones += 1
            //   ...
            if (cnt_conecciones > 3)
            {
                ReturnCode = -1;
                this.Close();
                return;
            }

            cnt_conecciones += 1;

            // Usuario inválido
            if (!string.Equals(
                    sle_usuario.Text?.Trim(),
                    at_usuario.Usuario?.Trim(),
                    StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Usuario inválido!",
                    "Atencion!!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                sle_usuario.Focus();
                return;
            }

            // Password inválido
            if (!string.Equals(
                    sle_password.Text?.Trim(),
                    SQLCA.DBPass?.Trim(),
                    StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Password inválido!",
                    "Atencion!!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                sle_password.Focus();
                return;
            }

            // OK
            ReturnCode = 1;
            this.Close();
        }

        // === ue_cancelar ===
        private void ue_cancelar()
        {
            // PB: CloseWithReturn(This,-1)
            ReturnCode = -1;
            this.Close();
        }

        // === pb_continuar.clicked: parent.TriggerEvent("ue_continuar") ===
        private void pb_continuar_clicked(object? sender, EventArgs e)
        {
            ue_continuar();
        }

        // === pb_cancelar.clicked: halt Close ===
        private void pb_cancelar_clicked(object? sender, EventArgs e)
        {
            // PB hace halt Close -> cerrar la aplicación
            Application.Exit();
        }

        // Equivalente a CLOSE (si quisieras leer ReturnCode luego de ShowDialog)
        protected  override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            // PB: CloseWithReturn(This, <valor>)
            // En C# el llamador usará dlg.ReturnCode después de ShowDialog()
        }
    }
}
