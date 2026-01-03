using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: dl_medicamentos_desde_hasta.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dl_medicamentos_desde_hasta
    {
        // Consulta original detectada desde el SRD
        public const string Sql = @"SELECT medicamentos.medicamento,       
                                                   medicamentos.descripcion  
                                            FROM medicamentos  
                                            WHERE medicamentos.medicamento >= ?   
                                              AND medicamentos.medicamento <= ?";

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