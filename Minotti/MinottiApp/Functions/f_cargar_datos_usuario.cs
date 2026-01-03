using Minotti.Data;
using Minotti.Views.Basicos.Models;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Minotti.Functions
{
    public static class f_cargar_datos_usuario
    {
        // SQL equivalente a la del SRF (usa SQLCA.UserID como parámetro)
        private const string SQL = @"
SELECT dba.acc_usuarios.usuario,
       dba.acc_usuarios.nombre,
       dba.acc_usuarios.clave,
       dba.acc_usuarios.perfil,
       GETDATE()
  FROM dba.acc_usuarios
 WHERE dba.acc_usuarios.usuario = ?";

        public static int fcargar_datos_usuario(cat_usuario at_usuario, bool controla_clave)
        {
            if (SQLCA.Connection is null)
            {
                SQLCA.SqlCode = -1;
                SQLCA.SqlErrText = "SQLCA.Connection no está configurada.";
                return -1;
            }

            if (string.IsNullOrEmpty(SQLCA.UserID))
            {
                SQLCA.SqlCode = -1;
                SQLCA.SqlErrText = "SQLCA.UserID no está configurado.";
                return -1;
            }

            var cnn = SQLCA.Connection;
            if (cnn.State != System.Data.ConnectionState.Open)
                cnn.Open();

            try
            {
                using var cmd = cnn.CreateCommand();
                cmd.CommandText = SQL;
                var p1 = cmd.CreateParameter();
                p1.Value = SQLCA.UserID!;
                cmd.Parameters.Add(p1);

                using var rd = cmd.ExecuteReader();
                if (!rd.Read())
                {
                    SQLCA.SqlCode = 100; // no encontrado
                    if (controla_clave)
                        MessageBox.Show("Usuario o clave inexistente.", "Error en Conexion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return -2;
                }

                // Leer columnas
                string usuario = rd.IsDBNull(0) ? "" : rd.GetString(0);
                string nombre = rd.IsDBNull(1) ? "" : rd.GetString(1);
                string clave = rd.IsDBNull(2) ? "" : rd.GetValue(2)?.ToString() ?? "";
                string perfil = rd.IsDBNull(3) ? "" : rd.GetValue(3)?.ToString() ?? "";
                DateTime fechaSrv = rd.IsDBNull(4) ? DateTime.Now : Convert.ToDateTime(rd.GetValue(4));

                // Asignar a 'at_usuario' manteniendo nombres PB (Usuario, Nombre, Perfil, Fecha_Coneccion)
                SetProp(at_usuario, "Usuario", usuario);
                SetProp(at_usuario, "Nombre", nombre);
                SetProp(at_usuario, "Perfil", perfil);
                SetProp(at_usuario, "Fecha_Coneccion", fechaSrv);

                // Validación de clave si corresponde
                if (controla_clave && !string.IsNullOrEmpty(SQLCA.DBPass) && !string.Equals(clave, SQLCA.DBPass, StringComparison.Ordinal))
                {
                    // En PB: MessageBox(...) y Return(-2)
                    MessageBox.Show("Usuario o clave inexistente.", "Error en Conexion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return -2;
                }

                SQLCA.SqlCode = 0;
                SQLCA.SqlErrText = null;
                return 1;
            }
            catch (Exception ex)
            {
                SQLCA.SqlCode = -1;
                SQLCA.SqlErrText = ex.Message;
                return -1;
            }
        }

        // Helper para asignar propiedades/fields con nombre exacto (ignorando mayúsculas/minúsculas)
        private static void SetProp(object obj, string name, object? value)
        {
            var type = obj.GetType();
            var pi = type.GetProperty(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (pi != null)
            {
                pi.SetValue(obj, value);
                return;
            }
            var fi = type.GetField(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (fi != null)
            {
                fi.SetValue(obj, value);
            }
        }
    }
}
