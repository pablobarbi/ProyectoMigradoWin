using Minotti.Data;
using Minotti.Functions;
using Minotti.utils;
using Minotti.Views.Basicos.Models;
using MinottiApp.utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    // Importante: si w_response es internal, y esta clase es public => te va a dar "Inconsistent accessibility".
    // En ese caso, poné w_response como public o bajá la visibilidad de w_coneccion.
    public partial class w_coneccion : w_response
    {
        // ===== PB: variables (public ) =====
        public  int Retorno = -1;
        public  int Intentos = 3;
        public  bool conectado = false;
        public  cat_usuario at_usuario = new cat_usuario();
        public  int fallidos = 0;

        public w_coneccion()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 550);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Wire events como PB
            this.Load += w_coneccion_Load; // PB event open
            this.FormClosed += w_coneccion_FormClosed; // PB event close
        }

        // =======================
        // PB event open
        // =======================
        private void w_coneccion_Load(object? sender, EventArgs e)
        {
            // call super::open
            base.open();

            // /* Carga los valores del archivo .INI */
            string arch_ini = string.Empty;

            // PB: arch_ini = guo_app.uof_GetArchivoInicio()
            // Mantengo el nombre; asumo que existe el global "guo_app".
            arch_ini = guo_app.Instance.uof_getarchivoinicio();

            // PB:
            // SQLCA.DBMS       = ProfileString(arch_ini, "Base de Datos", "DBMS",       SQLCA.DBMS)
            // SQLCA.Database   = ProfileString(arch_ini, "Base de Datos", "DataBase",   SQLCA.Database)
            // SQLCA.ServerName = ProfileString(arch_ini, "Base de Datos", "ServerName", SQLCA.ServerName)
            // SQLCA.DbParm     = ProfileString(arch_ini, "Base de Datos", "DbParm",     SQLCA.DbParm)
            SQLCA.DBMS = ProfileString(arch_ini, "Base de Datos", "DBMS", SQLCA.DBMS);
            SQLCA.Database = (string)ProfileString(arch_ini, "Base de Datos", "DataBase", SQLCA.Database);
            SQLCA.ServerName = ProfileString(arch_ini, "Base de Datos", "ServerName", SQLCA.ServerName);
            SQLCA.DBParm = ProfileString(arch_ini, "Base de Datos", "DbParm", SQLCA.DBParm);

            // PB: SQLCA.AutoCommit = TRUE
            SQLCA.AutoCommit = true;

            // PB focus:
            if (sle_usuario_base.Visible)
                sle_usuario_base.Focus();
            else if (sle_usuario_aplicacion.Visible)
                sle_usuario_aplicacion.Focus();
        }

        // =======================
        // PB event close
        // =======================
        public void w_coneccion_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // call super::close
            base.close();//.close();

            // PB: If retorno <> 1 Then SetNull(at_usuario.usuario)
            if (Retorno != 1)
            {
                // SetNull(at_usuario.usuario)
                at_usuario.Usuario = null;
            }

            // PB: CloseWithReturn(This, at_usuario)
            // En tu migración esto suele ir por Message.PowerObjectParm o similar.
            // Mantengo el nombre: si tenés Message.PowerObjectParm, dejalo.
            utils.Message.PowerObjectParm = at_usuario;
        }

        // =======================
        // PB event ue_conectar
        // =======================
        public virtual void ue_conectar()
        {
            // call super::ue_conectar
            base.ue_conectar();

            // SetPointer(HourGlass!)
            SetPointerHourGlass(true);

            // This.TriggerEvent("ue_leer")
            TriggerEvent("ue_leer");

            // Connect using SQLCA;
            ConnectUsingSQLCA();

            if (SQLCA.SqlCode == -1)
            {
                MessageBoxPB.MessageBox(
                    "Error en Conexion",
                    "Problemas al intentar conectarse a la base de datos\r\n" + (SQLCA.SqlErrText ?? string.Empty),
                    MessageBoxIcon.Stop,
                    MessageBoxButtons.OK);

                // fallidos += 1
                fallidos += 1;

                // If fallidos = Intentos Then Halt Close
                if (fallidos == Intentos)
                {
                    // Halt Close: cierro la ventana inmediatamente
                    this.Close();
                    return;
                }

                // SetNull(at_usuario.usuario)
                at_usuario.Usuario = null;

                // sle_usuario_base.SetFocus()
                sle_usuario_base.Focus();
                return;
            }

            // This.TriggerEvent("ue_cargar_usuario")
            TriggerEvent("ue_cargar_usuario");

            if (Retorno != 1)
            {
                fallidos += 1;

                if (fallidos == Intentos)
                {
                    this.Close();
                    return;
                }

                sle_usuario_base.Focus();

                // Disconnect using SQLCA;
                DisconnectUsingSQLCA();

                return;
            }

            // This.PostEvent("Close")
            PostEvent("Close");
        }

        // =======================
        // PB event ue_cargar_usuario
        // =======================
        public virtual void ue_cargar_usuario()
        {
            // call super::ue_cargar_usuario
            base.ue_cargar_usuario();

            bool bAux = false;
            if (sle_usuario_aplicacion.Visible) bAux = true;

            // Retorno = f_cargar_datos_usuario(at_usuario, bAux)
            // NO invento implementación real: dejo virtual para que lo conectes a tu lib.
            Retorno = f_cargar_datos_usuario.fcargar_datos_usuario(at_usuario, bAux);
        }

        // =======================
        // PB event ue_leer
        // =======================
        public virtual void ue_leer()
        {
            // call super::ue_leer
            base.ue_leer();

            // SQLCA.UserID  = sle_usuario_aplicacion.text
            // SQLCA.DBPass  = sle_clave_aplicacion.text
            // SQLCA.LogID   = sle_usuario_base.text
            // SQLCA.LogPass = sle_clave_base.text
            SQLCA.UserID = sle_usuario_aplicacion.Text;
            SQLCA.DBPass = sle_clave_aplicacion.Text;
            SQLCA.LogID = sle_usuario_base.Text;
            SQLCA.LogPass = sle_clave_base.Text;
        }

        // =======================
        // PB: pb_continuar::clicked => Parent.TriggerEvent("ue_conectar")
        // =======================
        private void pb_continuar_Click(object? sender, EventArgs e)
        {
            TriggerEvent("ue_conectar");
        }

        // =======================
        // PB: pb_cancelar::clicked => Parent.PostEvent("Close")
        // =======================
        private void pb_cancelar_Click(object? sender, EventArgs e)
        {
            PostEvent("Close");
        }

        // =========================================================
        // Helpers PB-like (TriggerEvent / PostEvent / Pointer)
        // =========================================================
        public  virtual void TriggerEvent(string eventName)
        {
            // Mantengo nombres PB exactos.
            switch (eventName)
            {
                case "ue_leer":
                    ue_leer();
                    break;
                case "ue_cargar_usuario":
                    ue_cargar_usuario();
                    break;
                case "ue_conectar":
                    ue_conectar();
                    break;
                default:
                    // Si querés, acá podés lanzar o ignorar.
                    break;
            }
        }

        public  virtual void PostEvent(string eventName)
        {
            // PB PostEvent: diferido.
            if (string.Equals(eventName, "Close", StringComparison.OrdinalIgnoreCase))
            {
                this.BeginInvoke(new Action(() => this.Close()));
                return;
            }

            // Si aparece otro evento, lo podés mapear acá.
        }

        public  virtual void SetPointerHourGlass(bool on)
        {
            Cursor.Current = on ? Cursors.WaitCursor : Cursors.Default;
        }

        // =========================================================
        // Connect/Disconnect using SQLCA (sin inventar DBMS/DbParm)
        // =========================================================
        public  virtual void ConnectUsingSQLCA()
        {
            try
            {
                if (SQLCA.Connection == null)
                {
                    SQLCA.SqlCode = -1;
                    SQLCA.SqlErrText = "SQLCA.Connection no está configurada.";
                    return;
                }

                if (SQLCA.Connection.State != System.Data.ConnectionState.Open)
                    SQLCA.Connection.Open();

                SQLCA.SqlCode = 0;
                SQLCA.SqlErrText = null;
            }
            catch (Exception ex)
            {
                SQLCA.SqlCode = -1;
                SQLCA.SqlErrText = ex.Message;
            }
        }

        public  virtual void DisconnectUsingSQLCA()
        {
            try
            {
                if (SQLCA.Connection != null && SQLCA.Connection.State != System.Data.ConnectionState.Closed)
                    SQLCA.Connection.Close();

                SQLCA.SqlCode = 0;
                SQLCA.SqlErrText = null;
            }
            catch (Exception ex)
            {
                SQLCA.SqlCode = -1;
                SQLCA.SqlErrText = ex.Message;
            }
        }

        // =========================================================
        // Hooks NO inventados: solo firma PB.
        // =========================================================
        //public  virtual int f_cargar_datos_usuario(cat_usuario atUsuario, bool bAux)
        //{
        //    // En PB esto es una función externa.
        //    // Acá NO la implemento: retorná 1 si OK, distinto si error.
        //    return -1;
        //}

        public  virtual object ProfileString(string archIni, string section, string key, object defaultValue)
        {
            // PB ProfileString: lee INI.
            // No invento lectura: dejo el hook para que lo conectes a tu helper real.
            return defaultValue;
        }

        // =========================================================
        // “Global” como en PB: placeholder para compilar si no lo tenés.
        // Si ya tenés guo_app en otro lado, BORRÁ este bloque.
        // =========================================================
        //public static uo_app guo_app { get; set; } = new uo_app();
    }
}
