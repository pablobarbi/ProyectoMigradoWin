using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: dw_pacientes_mas_todos.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dw_pacientes_mas_todos
    {
        // Consulta original detectada desde el SRD (puede estar vacía si el objeto es sólo de update)
        public const string Sql = @"SELECT pacientes.paciente,        pacientes.nombre   FROM pacientes  UNION SELECT 0, ' Todos los pacientes'  ORDER BY 2";

        /// <summary>
        /// Carga los datos usando ODBC (SQL Anywhere 9 via DSN).
        /// Respeta nombres y estructura. Ajustá el DSN en Config.AppConfig.
        /// </summary>
        public static DataTable RetrieveToDataTable(params object[] parametros)
        {
            return SQLCA.ExecuteDataTable(Sql, cmd =>
            {
                foreach (var p in parametros)
                {
                    var prm = cmd.CreateParameter();
                    prm.Value = p ?? DBNull.Value;
                    cmd.Parameters.Add(prm);
                }
            });
        }

        // ====== PowerBuilder UPDATE definition (conservado tal cual) ======
        /*
pacientes
        */
    }
}