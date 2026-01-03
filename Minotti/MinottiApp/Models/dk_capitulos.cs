using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: dk_capitulos.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dk_capitulos
    {
        // Consulta original detectada desde el SRD
        public const string Sql = @"SELECT capitulos.capitulo,
       capitulos.nombre
FROM capitulos
ORDER BY capitulos.nombre";

        // Carga los datos usando ODBC (SQL Anywhere 9 via DSN).
        public static DataTable RetrieveToDataTable(params object[] parametros)
        {
            

            return SQLCA.ExecuteDataTable(Sql, cmd =>
            {
                
            });
        }
    }
}