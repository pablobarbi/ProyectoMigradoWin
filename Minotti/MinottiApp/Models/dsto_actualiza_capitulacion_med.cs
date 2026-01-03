using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: dsto_actualiza_capitulacion_med.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dsto_actualiza_capitulacion_med
    {
        // Consulta original detectada desde el SRD
        public const string Sql = @"SELECT capitulacion_med.capitulo,        capitulacion_med.rubrica,        capitulacion_med.medicamento,        capitulacion_med.valor   FROM capitulacion_med WHERE  capitulacion_med.capitulo = :capitulo AND   capitulacion_med.rubrica = :rubrica";

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