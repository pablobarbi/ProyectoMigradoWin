using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    // Migrado desde PowerBuilder DataWindow: dk_medicamentos_ejemplos.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dk_medicamentos_ejemplos
    {
        // Consulta original detectada desde el SRD
        public const string Sql = @"SELECT medicamentos.medicamento,        
                                                   medicamentos.descripcion,        
                                                   ' ' seleccionado   
                                            FROM medicamentos";

        // Carga los datos usando ODBC (SQL Anywhere 9 via DSN).
        public static DataTable RetrieveToDataTable(params object[] parametros)
        {
            return SQLCA.ExecuteDataTable(Sql, cmd =>
            {
                
            });
        }
    }
}