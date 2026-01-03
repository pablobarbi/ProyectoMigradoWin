using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: dsto_actualiza_subrubricas.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dsto_actualiza_subrubricas
    {
        // Consulta original detectada desde el SRD
        public const string Sql = @"SELECT subrubricas.subrubrica,        subrubricas.nombre   FROM subrubricas";

        // Carga los datos usando ODBC (SQL Anywhere 9 via DSN).
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
    }
}