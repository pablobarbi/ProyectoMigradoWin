using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

using Minotti.utils;
namespace Minotti.Repositories
{
 
    // Migrado desde PowerBuilder DataWindow: dk_medicamentos_de_la_subrubrica_ph.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dk_medicamentos_de_la_subrubrica_ph : datastore
    {
        // Consulta original detectada desde el SRD
        public const string SQL = @"SELECT subrubricacion_med.medicamento, 
                                           medicamentos.descripcion,
                                           subrubricacion_med.valor,
                                           'S' seleccionado   
                                    FROM subrubricacion_med, medicamentos  
                                    WHERE subrubricacion_med.medicamento = medicamentos.medicamento AND 
                                          subrubricacion_med.subrubrica_padre = :subrubrica_padre AND 
                                          subrubricacion_med.subrubrica_hija  = :subrubrica_hija  
                                   UNION SELECT medicamentos.medicamento,        
                                                medicamentos.descripcion,
                                                ' ' valor,        
                                                'N' seleccionado   
                                        FROM medicamentos  WHERE medicamentos.medicamento NOT IN ( SELECT subrubricacion_med.medicamento FROM subrubricacion_med                                           WHERE subrubricacion_med.subrubrica_padre = :subrubrica_padre AND subrubricacion_med.subrubrica_hija = :subrubrica_hija ) ORDER BY 3 DESC , 1 ASC";





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