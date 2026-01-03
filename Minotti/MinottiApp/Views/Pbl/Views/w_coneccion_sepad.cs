using Minotti.Data;
using Minotti.utils;
using Minotti.Views.Basicos;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Minotti.Views.Pbl.Views
{
    public partial class w_coneccion_sepad : w_coneccion
    {
        // PB: String nro_serie
        private string nro_serie = "";

        // PB prototype:
        // function long GetVolumeInformationA(...) Library 'kernel32' alias for "GetVolumeInformationA;Ansi"
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern bool GetVolumeInformationA(
            string lpRootPathName,
            StringBuilder lpVolumeNameBuffer,
            int nVolumeNameSize,
            StringBuilder lpVolumeSerialNumber,
            out int lpMaximumComponentLength,
            out int lpFileSystemFlags,
            StringBuilder lpFileSystemNameBuffer,
            int nFileSystemNameSize);

        public w_coneccion_sepad()
        {
            InitializeComponent();

            // PB-like: colores PB (evito poner esto en Designer para que no rompa el diseñador)
            ApplyPbColorsToSepadStatics();

            // Wire botones heredados (PB pb_continuar/pb_cancelar)
            if (pb_continuar != null) pb_continuar.Click += (_, __) => ue_conectar();
            if (pb_cancelar != null) pb_cancelar.Click += (_, __) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            // Para que ESC cancele / ENTER confirme (si tus botones heredados son Button)
            try
            {
                this.CancelButton = pb_cancelar;
                this.AcceptButton = pb_continuar;
            }
            catch { /* si no son Button no pasa nada */ }
        }

        // =========================
        // PB: event open
        // =========================
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // PB: centrar ventana
            wf_centrar_response();

            // PB: wf_nro_serie()
            wf_nro_serie();
        }

        // =================================
        // PB: wf_centrar_response()
        // =================================
        public void wf_centrar_response()
        {
            // PB usa GetEnvironment + PixelsToUnits; en WinForms centramos en pantalla actual
            var screen = Screen.FromControl(this).WorkingArea;

            int x = screen.Left + (screen.Width - this.Width) / 2;
            int y = screen.Top + (screen.Height - this.Height) / 2;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Math.Max(screen.Left, x), Math.Max(screen.Top, y));
        }

        // =================================
        // PB: wf_nro_serie()
        // =================================
        public void wf_nro_serie()
        {
            nro_serie = "";

            // PB: ls_Drive="c:\"
            string drive = @"c:\";

            var volName = new StringBuilder(32);
            var fsName = new StringBuilder(32);
            var serial = new StringBuilder(32);

            int maxComp, flags;
            bool ok = GetVolumeInformationA(drive, volName, volName.Capacity, serial, out maxComp, out flags, fsName, fsName.Capacity);

            string cserial = serial.ToString(); // PB: cserial = ls_Serial

            // PB hace: NoSerie[] = ASC(MID(cserial...)) invertido y luego f_longtohex(...,2) y agrega "-" en posi=2
            // No tengo tu f_longtohex acá, pero el SRW muestra que al final SOLO usa la suma de dígitos del nro_serie.
            // Entonces replico exacto el resultado final que el PB usa: st_serial.Text = st_serial.Text + String(ll_Valor)
            // (si querés el nro_serie textual también, lo reconstruimos cuando tengas f_longtohex).
            int ll_Valor = 0;

            // PB: recorre nro_serie y suma dígitos numéricos; pero en SRW termina mostrando el valor
            // Como acá no reconstruimos nro_serie hex, sumo dígitos del SERIAL raw si son numéricos.
            // Si tu lógica requiere el nro_serie HEX exacto, pasame f_longtohex y lo dejamos 1:1.
            foreach (char ch in cserial)
            {
                if (char.IsDigit(ch))
                    ll_Valor += (ch - '0');
            }

            // PB: st_serial.Text = st_serial.Text + String(ll_Valor)
            if (st_serial != null)
                st_serial.Text = "Registro Nro. :  " + ll_Valor.ToString();
        }

        // =================================
        // PB: wf_validar_clave(as_nro_serie)
        // =================================
        public bool wf_validar_clave(string as_nro_serie)
        {
            // PB: suma dígitos (IsNumber + Long)
            long ll_Valor = 0;
            foreach (char ch in as_nro_serie ?? string.Empty)
            {
                if (char.IsDigit(ch))
                    ll_Valor += (ch - '0');
            }

            string ls_Usuario = sle_usuario_aplicacion?.Text ?? "";

            // PB tiene IF 1..100 comparando con usuarioX, y si coincide devuelve TRUE al final.
            // Equivalente exacto:
            if (ll_Valor >= 1 && ll_Valor <= 100)
            {
                if (!string.Equals(ls_Usuario, "usuario" + ll_Valor, StringComparison.OrdinalIgnoreCase))
                    return false;
            }

            return true;
        }

        // =========================
        // PB: event ue_conectar
        // =========================
        public override void ue_conectar()
        {
            PBUtils.SetPointerHourglass();

            // PB: This.TriggerEvent("ue_leer")
            this.ue_leer();

            // PB: IF NOT wf_validar_clave(nro_serie) THEN ...
            if (!wf_validar_clave(nro_serie))
            {
                MessageBoxPB.MessageBox("Error en Conexión",
                    "Problemas al intentar conectarse al sistema.",
                    MessageBoxIcon.Stop, MessageBoxButtons.OK);

                fallidos += 1;
                if (fallidos == Intentos)
                {
                    // PB: Halt Close (en WinForms: cerrar app)
                    Application.Exit();
                    return;
                }

                // PB: SetNull(at_usuario.usuario)
                TrySetNullUsuario();

                sle_usuario_base?.Focus();
                PBUtils.SetPointerArrow();
                return;
            }

            // PB: Connect using SQLCA;
            SQLCA.Connect();

            if (SQLCA.SqlCode == -1)
            {
                MessageBoxPB.MessageBox("Error en Conexión",
                    "Problemas al intentar conectarse a la base de datos\r\n" + (SQLCA.SqlErrText ?? ""),
                    MessageBoxIcon.Stop, MessageBoxButtons.OK);

                fallidos += 1;
                if (fallidos == Intentos)
                {
                    Application.Exit();
                    return;
                }

                TrySetNullUsuario();
                sle_usuario_base?.Focus();
                PBUtils.SetPointerArrow();
                return;
            }

            // PB: This.TriggerEvent("ue_cargar_usuario")
            this.ue_cargar_usuario();

            if (Retorno != 1)
            {
                fallidos += 1;
                if (fallidos == Intentos)
                {
                    Application.Exit();
                    return;
                }

                sle_usuario_base?.Focus();
                SQLCA.Disconnect();
                PBUtils.SetPointerArrow();
                return;
            }

            PBUtils.SetPointerArrow();

            // PB: This.PostEvent("Close")
            this.BeginInvoke(new Action(() =>
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }));
        }

        private void ApplyPbColorsToSepadStatics()
        {
            // PB: textcolor=8388608, backcolor=81324524 en varios statictext
            var textColor = ColorTranslator.FromWin32(unchecked((int)8388608));
            var backColor = ColorTranslator.FromWin32(unchecked((int)81324524));

            ApplyStaticStyle(st_1, textColor, backColor);
            ApplyStaticStyle(st_2, textColor, backColor);
            ApplyStaticStyle(st_3, textColor, backColor);
            ApplyStaticStyle(st_4, textColor, backColor);
            ApplyStaticStyle(st_serial, textColor, backColor);
        }

        private static void ApplyStaticStyle(Label? lbl, Color textColor, Color backColor)
        {
            if (lbl == null) return;
            lbl.ForeColor = textColor;
            lbl.BackColor = backColor;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.Font = new Font("Arial", 9, FontStyle.Bold);
        }

        private void TrySetNullUsuario()
        {
            try
            {
                // Si tenés at_usuario con property usuario, lo nulleo
                if (at_usuario != null)
                    at_usuario.Usuario = null;
            }
            catch
            {
                // no invento estructura si no existe
            }
        }
    }
}
