using System;
using System.Data;
using System.Windows.Forms;
using Minotti.Data;

namespace Minotti.Functions
{
    // Equivalente a: global function integer f_error_db_anywhere ( )
    public static class f_error_db_anywhere
    {
        public static int ferror_db_anywhere()
        {
            // IF NOT IsValid(SQLCA) THEN ...
            if (SQLCA.Connection == null)
            {
                MessageBox.Show(
                    "Error en transacción.",
                    "Error Base de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return -1;
            }

            // Carga básica de datos en la estructura de error
            guo_app.at_error_db.sqlname = "SQL Anywhere";
            guo_app.at_error_db.coderror = SQLCA.SqlCode;
            guo_app.at_error_db.sqlerrtext = SQLCA.SqlErrText ?? string.Empty;
            guo_app.at_error_db.sqlerror =
                "Código error Sql: " + guo_app.at_error_db.coderror.ToString();

            // Intento de obtener info extendida del motor (errorLine, errorMsgRow, etc.)
            try
            {
                string sql = $@"
SELECT CAST(errorLine({SQLCA.SqlCode}) AS integer)    AS nro_linea,
       errorMsgRow({SQLCA.SqlCode})                   AS nro_renglon,
       errorPos({SQLCA.SqlCode})                      AS pos_error,
       errorMsg({SQLCA.SqlCode})                      AS mensaje,
       '{SQLCA.DBMS} {SQLCA.DBParm}'                  AS dbservidor
  FROM dummy";

                DataTable dt = SQLCA.ExecuteDataTable(sql, cmd => { });

                if (dt.Rows.Count > 0)
                {
                    var r = dt.Rows[0];

                    if (r["nro_linea"] != DBNull.Value)
                        guo_app.at_error_db.linea = Convert.ToInt32(r["nro_linea"]);
                    if (r["nro_renglon"] != DBNull.Value)
                        guo_app.at_error_db.renglon = Convert.ToInt32(r["nro_renglon"]);
                    if (r["pos_error"] != DBNull.Value)
                        guo_app.at_error_db.posicion = Convert.ToInt32(r["pos_error"]);

                    guo_app.at_error_db.mensaje = r["mensaje"] as string ?? string.Empty;
                    guo_app.at_error_db.servidor = r["dbservidor"] as string ?? string.Empty;
                }
            }
            catch
            {
                // Si falla el SELECT a dummy, seguimos solo con SqlCode / SqlErrText
            }

            const string ls_sal = "\r\n";
            string lv_mensaje_mas_info;
            long ll_SqlCode = guo_app.at_error_db.coderror;

            // CHOOSE CASE ll_SqlCode
            switch (ll_SqlCode)
            {
                case -141:
                    lv_mensaje_mas_info =
                        "Consulte con el administrador de la base de datos." + ls_sal +
                        ls_sal +
                        "El nombre del objeto referenciado en el script no existe." + ls_sal +
                        "Puede deberse a un fallo de sintaxis, falta de permisos " + ls_sal +
                        "en las tablas o por problemas en la configuración del sistema.";
                    break;

                case -193:
                    lv_mensaje_mas_info =
                        "Contacte con su administrador." + ls_sal +
                        ls_sal +
                        "No se pudo abrir o acceder al archivo solicitado." + ls_sal +
                        "Esto puede estar asociado a problemas con permisos " + ls_sal +
                        "de lectura/escritura o archivos bloqueados.";
                    break;

                case -195:
                    lv_mensaje_mas_info =
                        "Revise el filtro o criterio utilizado en la consulta." + ls_sal +
                        ls_sal +
                        "No es posible realizar una conversión con el tipo de dato utilizado." + ls_sal +
                        "Ejemplo: intento de convertir texto no numérico a número.";
                    break;

                case 42000:
                    lv_mensaje_mas_info =
                        "Error de sintaxis en la instrucción SQL." + ls_sal +
                        ls_sal +
                        "Verifique la estructura de la consulta, nombres de tablas," + ls_sal +
                        "campos y parámetros utilizados.";
                    break;

                default:
                    lv_mensaje_mas_info =
                        "Ocurrió un error en la base de datos (SQL Anywhere)." + ls_sal +
                        ls_sal +
                        "Código de error: " + ll_SqlCode + ls_sal +
                        "Mensaje: " + (guo_app.at_error_db.sqlerrtext ?? string.Empty);
                    break;
            }

            guo_app.at_error_db.sqlerrtext =
                (guo_app.at_error_db.sqlerrtext ?? string.Empty) +
                ls_sal + ls_sal +
                lv_mensaje_mas_info;

            // IF guo_app.gi_app_modo_debug = True THEN MessageBox(...)
            if (guo_app.Instance.gi_app_modo_debug)
            {
                MessageBox.Show(
                    "Código error Sql: " + guo_app.at_error_db.coderror + ls_sal +
                    ls_sal +
                    "Mensaje: " + guo_app.at_error_db.sqlerrtext,
                    "Error Base de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return 1;
        }
    }
}
