using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: dk_rubricas_del_capitulo.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dk_rubricas_del_capitulo
    {
        // Consulta original detectada desde el SRD
        public const string Sql = @"SELECT capitulaciones.capitulo,        
                                                    capitulaciones.rubrica,
                                                    rubricas.nombre  
                                            FROM capitulaciones, rubricas  
                                            WHERE capitulaciones.rubrica = rubricas.rubrica    AND 
                                                  capitulaciones.capitulo = ?      
                                            ORDER BY rubricas.nombre";

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