using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: duo_rubricaciones.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class duo_rubricaciones
    {
        // Consulta original detectada desde el SRD
        public const string Sql = @"SELECT rubricaciones.rubrica,        rubricaciones.subrubrica,        rubricaciones.posicion,        subrubricas.nombre   FROM rubricaciones,        subrubricas  WHERE rubricaciones.subrubrica = subrubricas.subrubrica    AND rubricaciones.rubrica = :rubrica  ORDER BY rubricaciones.posicion";

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