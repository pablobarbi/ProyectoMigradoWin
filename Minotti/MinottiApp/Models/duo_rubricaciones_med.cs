using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: duo_rubricaciones_med.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class duo_rubricaciones_med
    {
        // Consulta original detectada desde el SRD
        public const string Sql = @"SELECT rubricacion_med.rubrica,        rubricacion_med.subrubrica,        rubricacion_med.medicamento,        rubricacion_med.valor   FROM rubricacion_med  WHERE rubricacion_med.rubrica = :rubrica    AND rubricacion_med.subrubrica = :subrubrica";

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