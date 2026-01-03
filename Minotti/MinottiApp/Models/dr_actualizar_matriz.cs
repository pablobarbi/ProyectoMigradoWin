using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: dr_actualizar_matriz.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dr_actualizar_matriz
    {
        // Consulta original detectada desde el SRD (puede estar vacía si el objeto es sólo de update)
        public const string Sql = @"";

        /// <summary>
        /// Carga los datos usando ODBC (SQL Anywhere 9 via DSN).
        /// Respeta nombres y estructura. Ajustá el DSN en Config.AppConfig.
        /// </summary>
        public static DataTable RetrieveToDataTable(params object[] parametros)
        {
            return SQLCA.ExecuteDataTable(Sql, cmd =>
            {

            });
        }

        // ====== PowerBuilder UPDATE definition (conservado tal cual) ======
        /*
(No se detectó bloque UPDATE en el SRD)
        */
    }
}