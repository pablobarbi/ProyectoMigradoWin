using Minotti.Data;
using Minotti.Views.Basicos.Models;
using System.Data;
using System.Reflection;

namespace Minotti.Funciones
{
    public static class f_cargar_datos_usuario
    {
        // === SQL EXACTO PB ===
        private const string SQL = @"
SELECT dba.acc_usuarios.usuario,
       dba.acc_usuarios.nombre,
       dba.acc_usuarios.clave,
       dba.acc_usuarios.perfil,
       GETDATE()
  FROM dba.acc_usuarios
 WHERE dba.acc_usuarios.usuario = ?";

        /// <summary>
        /// PB: f_cargar_datos_usuario (SRF)
        /// return: 1 OK | -2 usuario/clave inválido | -1 error SQL
        /// </summary>
        public static int fcargar_datos_usuario(cat_usuario at_usuario, bool controla_clave)
        {
            if (at_usuario == null)
            {
                SQLCA.SqlCode = -1;
                SQLCA.SqlErrText = "cat_usuario es null.";
                return -1;
            }

            if (string.IsNullOrWhiteSpace(SQLCA.UserID))
            {
                SQLCA.SqlCode = -1;
                SQLCA.SqlErrText = "SQLCA.UserID no está configurado.";
                return -1;
            }

            try
            {
                using var cmd = SQLCA.CreateCommand(SQL);
                SQLCA.AddParam(cmd, SQLCA.UserID); // param posicional PB

                using var rd = SQLCA.ExecuteReader(cmd);

                if (!rd.Read())
                {
                    // PB: sqlcode = 100
                    SQLCA.SqlCode = 100;

                    if (controla_clave)
                    {
                        MessageBox.Show(
                            "Usuario o clave inexistente.",
                            "Error en Conexion",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Stop
                        );
                    }

                    return -2;
                }

                // === Lectura columnas (PB 1:1) ===
                string usuario = rd.IsDBNull(0) ? "" : rd.GetString(0);
                string nombre = rd.IsDBNull(1) ? "" : rd.GetString(1);
                string clave = rd.IsDBNull(2) ? "" : Convert.ToString(rd.GetValue(2)) ?? "";
                string perfil = rd.IsDBNull(3) ? "" : Convert.ToString(rd.GetValue(3)) ?? "";
                DateTime fecha = rd.IsDBNull(4) ? DateTime.Now : Convert.ToDateTime(rd.GetValue(4));

                // === Asignación estilo PB ===
                SetProp(at_usuario, "Usuario", usuario);
                SetProp(at_usuario, "Nombre", nombre);
                SetProp(at_usuario, "Perfil", perfil);
                SetProp(at_usuario, "Fecha_Coneccion", fecha);


                guo_app.uof_SetUsuario(at_usuario);

                // === Validación de clave ===
                if (controla_clave)
                {
                    if (!string.Equals(clave, SQLCA.DBPass ?? "", StringComparison.Ordinal))
                    {
                        MessageBox.Show(
                            "Usuario o clave inexistente.",
                            "Error en Conexion",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Stop
                        );
                        return -2;
                    }
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

        // === Helper PB-like: asigna Property o Field por nombre ===
        private static void SetProp(object obj, string name, object? value)
        {
            var t = obj.GetType();

            var pi = t.GetProperty(
                name,
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase
            );
            if (pi != null)
            {
                pi.SetValue(obj, value);
                return;
            }

            var fi = t.GetField(
                name,
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase
            );
            if (fi != null)
            {
                fi.SetValue(obj, value);
            }
        }
    }
}
