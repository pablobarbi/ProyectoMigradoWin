using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: dr_pacientes_estadisticas.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dr_pacientes_estadisticas
    {
        // Consulta original detectada desde el SRD (puede estar vacía si el objeto es sólo de update)
        public const string Sql = @"SELECT diagnosticos.paciente,        diagnosticos.primera   FROM diagnosticos  WHERE diagnosticos.fecha_visita >= YMD(SUBSTR(:fecha_desde, 7, 4), SUBSTR(:fecha_desde, 4, 2), SUBSTR(:fecha_desde, 1, 2))    AND diagnosticos.fecha_visita <= YMD(SUBSTR(:fecha_hasta, 7, 4), SUBSTR(:fecha_hasta, 4, 2), SUBSTR(:fecha_hasta, 1, 2))  ORDER BY diagnosticos.paciente";

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
(No se detectó bloque UPDATE en el SRD)
        */
    }
}