using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: dp_pacientes_mas_todos.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dp_pacientes_mas_todos
    {
        // Consulta original detectada desde el SRD (puede estar vacía si el objeto es sólo de update)
        public const string Sql = @"SELECT pacientes.paciente   FROM pacientes";

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
pacientes
        */
    }
}