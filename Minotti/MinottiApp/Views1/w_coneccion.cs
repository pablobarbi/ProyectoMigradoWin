using System;
using System.Data.Odbc;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Minotti.Models;

namespace Minotti.Views
{
    // Migración de PowerBuilder: w_coneccion.srw (window) desde w_response
    // Mantiene el nombre del tipo: w_coneccion
    public partial class w_coneccion : Form
    {
        // ===== Variables PB (mismos nombres) =====
        protected int Retorno = -1;
        protected int Intentos = 3;
        protected bool conectado = false;
        protected cat_usuario at_usuario;
        protected int fallidos = 0;

        // Emulación simple de SQLCA (mismos nombres de propiedades usadas en PB)
        public class TSQLCA
        {
            public string DBMS { get; set; } = string.Empty;
            public string Database { get; set; } = string.Empty; // Aquí se usa como DSN
            public string ServerName { get; set; } = string.Empty;
            public string DbParm { get; set; } = string.Empty;
            public bool AutoCommit { get; set; } = true;

            public string UserID { get; set; } = string.Empty;  // Usuario de la aplicación
            public string DBPass { get; set; } = string.Empty;  // Clave de la aplicación
            public string LogID { get; set; } = string.Empty;   // Usuario de la base (ODBC)
            public string LogPass { get; set; } = string.Empty; // Clave de la base (ODBC)

            public int SqlCode { get; set; } = 0;
            public string SqlErrText { get; set; } = string.Empty;
        }
        public TSQLCA SQLCA = new TSQLCA();

        public w_coneccion()
        {
            InitializeComponent();
            at_usuario = new cat_usuario();
        }

        // ===== Evento PB: open =====
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // /* Carga los valores del archivo .INI */
            string arch_ini = GetArchivoInicio();
            // Equivalente ProfileString(...)
            SQLCA.DBMS       = ReadIni(arch_ini, "Base de Datos", "DBMS", SQLCA.DBMS);
            SQLCA.Database   = ReadIni(arch_ini, "Base de Datos", "DataBase", SQLCA.Database);
            SQLCA.ServerName = ReadIni(arch_ini, "Base de Datos", "ServerName", SQLCA.ServerName);
            SQLCA.DbParm     = ReadIni(arch_ini, "Base de Datos", "DbParm", SQLCA.DbParm);

            SQLCA.AutoCommit = true;

            if (sle_usuario_base.Visible)
                sle_usuario_base.Focus();
            else if (sle_usuario_aplicacion.Visible)
                sle_usuario_aplicacion.Focus();
        }

        // ===== Evento PB: ue_leer =====
        public void ue_leer()
        {
            SQLCA.UserID  = sle_usuario_aplicacion.Text;
            SQLCA.DBPass  = sle_clave_aplicacion.Text;
            SQLCA.LogID   = sle_usuario_base.Text;
            SQLCA.LogPass = sle_clave_base.Text;
        }

        // ===== Evento PB: ue_conectar =====
        public void ue_conectar()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor; // SetPointer(HourGlass!)
                // This.TriggerEvent("ue_leer")
                ue_leer();

                // /* Se conecta a la base de datos */
                // Emular "Connect using SQLCA" con ODBC por DSN (SQL Anywhere 9)
                string dsn = SQLCA.Database; // en PB se usa Database como DSN en DbParm
                string connStr = $"DSN={dsn};UID={SQLCA.LogID};PWD={SQLCA.LogPass};";
                using (var conn = new OdbcConnection(connStr))
                {
                    try
                    {
                        conn.Open();
                        SQLCA.SqlCode = 0;
                        SQLCA.SqlErrText = string.Empty;
                        conectado = true;
                    }
                    catch (Exception ex)
                    {
                        SQLCA.SqlCode = -1;
                        SQLCA.SqlErrText = ex.Message;
                        conectado = false;
                    }
                }

                if (SQLCA.SqlCode == -1)
                {
                    MessageBox.Show(
                        "Problemas al intentar conectarse a la base de datos\r\n" + SQLCA.SqlErrText,
                        "Error en Conexion",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop
                    );
                    // /* Cuenta los intentos fallidos y, después de la cantidad definida, cierra la ventana */
                    fallidos += 1;
                    if (fallidos == Intentos) Application.Exit();
                    at_usuario.usuario = null;
                    sle_usuario_base.Focus();
                    return;
                }

                // ... PB hace más cosas aquí (setea usuario en superficies, etc.)

                // This.TriggerEvent("ue_cargar_usuario")
                ue_cargar_usuario();
                if (Retorno != 1)
                {
                    // falló carga de usuario
                    fallidos += 1;
                    if (fallidos == Intentos) Application.Exit();
                    sle_usuario_base.Focus();
                    // Emular "Disconnect using SQLCA" no persistimos conexión aquí
                    return;
                }

                // This.PostEvent("Close") -> cerramos con OK
                this.Close();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        // ===== Evento PB: ue_cargar_usuario =====
        public void ue_cargar_usuario()
        {
            bool bAux = false;
            if (sle_usuario_aplicacion.Visible) bAux = true;
            Retorno = f_cargar_datos_usuario(at_usuario, bAux);
        }

        // ===== Evento PB: close =====
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (Retorno != 1) at_usuario.usuario = null;
            // Emular CloseWithReturn(This, at_usuario):
            // Dejamos el resultado accesible vía propiedad pública y DialogResult
            this.DialogResult = (Retorno == 1) ? DialogResult.OK : DialogResult.Cancel;
        }

        // ===== Stub equivalente a función PB f_cargar_datos_usuario(at_usuario, bAux) =====
        // Mantengo el nombre para compatibilidad con el SRW
        private int f_cargar_datos_usuario(cat_usuario a_usuario, bool bAux)
        {
            // TODO: Implementar carga real de usuario (consultar DB con SQLCA.UserID/DBPass)
            // Por ahora, si hay UserID, devolvemos OK.
            if (!string.IsNullOrWhiteSpace(SQLCA.UserID))
            {
                a_usuario.usuario = SQLCA.UserID;
                return 1;
            }
            return 0;
        }

        // ===== Helpers INI (reemplazo de ProfileString/guo_app.uof_GetArchivoInicio) =====
        private static string GetArchivoInicio()
        {
            // Buscar "Minotti.ini" en el directorio de la app; si no, devolver vacío
            var exeDir = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(exeDir, "Minotti.ini");
            return File.Exists(path) ? path : path; // devolvemos path aunque no exista (ProfileString maneja por defecto)
        }

        // Lectura básica INI (compatible con ProfileString)
        private static string ReadIni(string file, string section, string key, string defaultValue)
        {
            if (string.IsNullOrEmpty(file) || !File.Exists(file)) return defaultValue ?? string.Empty;
            var sb = new StringBuilder(1024);
            GetPrivateProfileString(section, key, defaultValue, sb, (uint)sb.Capacity, file);
            return sb.ToString();
        }

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern uint GetPrivateProfileString(string section, string key, string defaultValue,
                                                           StringBuilder retVal, uint size, string filePath);
    }
}
