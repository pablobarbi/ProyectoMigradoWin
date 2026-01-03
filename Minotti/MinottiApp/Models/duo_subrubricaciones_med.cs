using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: duo_subrubricaciones_med.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class duo_subrubricaciones_med
    {
        // Consulta original detectada desde el SRD
        public const string Sql = @"SELECT subrubricacion_med.subrubrica_padre,        subrubricacion_med.subrubrica_hija,        subrubricacion_med.medicamento,        subrubricacion_med.valor   FROM subrubricacion_med  WHERE subrubricacion_med.subrubrica_padre = :subrubrica_padre    AND subrubricacion_med.subrubrica_hija = :subrubrica_hija";

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