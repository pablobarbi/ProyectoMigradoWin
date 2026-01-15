using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

using Minotti.utils;
namespace Minotti.Repositories
{
     

    // Migrado desde PowerBuilder DataWindow: dk_medicamentos_de_la_subrubrica.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dk_medicamentos_de_la_subrubrica : datastore
    {
        // Consulta original detectada desde el SRD
        public const string SQL = @"SELECT rubricacion_med.medicamento,        
                                                   medicamentos.descripcion,
                                                   rubricacion_med.valor,
                                                   'S' seleccionado   
                                            FROM rubricacion_med,medicamentos
                                            WHERE rubricacion_med.medicamento = medicamentos.medicamento    AND 
                                                  rubricacion_med.rubrica = :rubrica    AND 
                                                  rubricacion_med.subrubrica = :subrubrica  
                                            UNION 
                                            SELECT medicamentos.medicamento,
                                                   medicamentos.descripcion,
                                                   ' ' valor,        
                                                   'N' seleccionado   
                                            FROM medicamentos  
                                            WHERE medicamentos.medicamento NOT IN ( 
                                                                                SELECT rubricacion_med.medicamento 
                                                                                FROM rubricacion_med
                                                                                WHERE rubricacion_med.rubrica = :rubrica AND 
                                                                                rubricacion_med.subrubrica = :subrubrica ) 
                                                                                ORDER BY 3 DESC , 1 ASC";






        public override int Retrieve(params object?[] args)
        {
            if (SQLCA.Connection == null)
                throw new InvalidOperationException("SQLCA.Connection es null");

            try
            {
                using var cmd = SQLCA.Connection.CreateCommand();
                cmd.CommandText = SQL;

                using var da = new OdbcDataAdapter((OdbcCommand)cmd);
                var dt = new DataTable();
                da.Fill(dt);

                this.SetData(dt);
                return this.RowCount();
            }
            catch (Exception ex)
            {
                SQLCA.SqlCode = -1;
                SQLCA.SqlErrText = ex.Message;
                throw;
            }
        }

    }
}