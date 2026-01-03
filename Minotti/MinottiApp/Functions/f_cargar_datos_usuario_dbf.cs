using Minotti.Data;
using Minotti.Views.Basicos.Models;
using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti.Functions
{
    public static class f_cargar_datos_usuario_dbf
    {
        // PB: global function integer f_cargar_datos_usuario_dbf (ref cat_usuario at_usuario, boolean controla_clave)
        public static int fcargar_datos_usuario_dbf(ref cat_usuario at_usuario, bool controla_clave)
        {
            string clave = "";

            string sql =
                "SELECT usuarios.usuario, " +
                "       usuarios.nombre, " +
                "       usuarios.clave, " +
                "       usuarios.perfil " +
                "  FROM usuarios " +
                " WHERE usuarios.usuario = ?";

            try
            {
                var p1 = new OdbcParameter { OdbcType = OdbcType.VarChar, Value = SQLCA.UserID ?? (object)DBNull.Value };

                DataTable dt = SQLCA.ExecuteDataTable(sql, p1);

                // En PB: If SQLCA.SqlCode < 0 Then Return(-1)
                if (SQLCA.SqlCode < 0)
                    return -1;

                // En PB: SqlCode = 100 equivale a "no data found"
                // En tu SQLCA puede venir como 100, o puede venir como 0 con dt vacío.
                bool noData = (SQLCA.SqlCode == 100) || (dt == null) || (dt.Rows.Count == 0);

                if (noData)
                {
                    MessageBox.Show("Usuario o clave inexistente.", "Error en Conexion",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return -2;
                }

                DataRow r = dt.Rows[0];

                at_usuario.Usuario = r["usuario"] == DBNull.Value ? null : Convert.ToString(r["usuario"]);
                at_usuario.Nombre = r["nombre"] == DBNull.Value ? null : Convert.ToString(r["nombre"]);
                clave = r["clave"] == DBNull.Value ? "" : Convert.ToString(r["clave"]);
                at_usuario.Perfil = r["perfil"] == DBNull.Value ? null : Convert.ToString(r["perfil"]);

                // PB: at_usuario.Fecha_Coneccion = DateTime(String(Today(), "dd/mm/yyyy hh:mm"))
                // En .NET guardamos "ahora" (equivalente práctico).
                at_usuario.Fecha_Coneccion = DateTime.Now;

                // PB: ElseIf ... (clave <> SQLCA.DBPass and controla_clave) Then Return(-2)
                if (controla_clave)
                {
                    string dbPass = SQLCA.DBPass ?? "";
                    if (!string.Equals(clave ?? "", dbPass, StringComparison.Ordinal))
                    {
                        MessageBox.Show("Usuario o clave inexistente.", "Error en Conexion",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return -2;
                    }
                }

                return 1;
            }
            catch (Exception ex)
            {
                SQLCA.SqlCode = -1;
                SQLCA.SqlErrText = ex.Message;
                return -1;
            }
        }
    }
}
