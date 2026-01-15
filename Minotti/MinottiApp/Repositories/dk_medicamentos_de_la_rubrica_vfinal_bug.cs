using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

using Minotti.utils;
namespace Minotti.Repositories
{

   

    // Migrado desde PowerBuilder DataWindow: dk_medicamentos_de_la_rubrica_vfinal_bug.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dk_medicamentos_de_la_rubrica_vfinal_bug : datastore
    {
        // Consulta original detectada desde el SRD
        public const string SQL = @"SELECT capitulacion_med.medicamento,        
                                                   medicamentos.descripcion,
                                                   capitulacion_med.valor,    
                                                   'S' seleccionado   
                                            FROM capitulacion_med,medicamentos  
                                            WHERE capitulacion_med.medicamento = medicamentos.medicamento AND 
                                                  capitulacion_med.capitulo = ?    AND 
                                                  capitulacion_med.rubrica = ?  
                                            UNION 
                                            SELECT medicamentos.medicamento,        
                                                   medicamentos.descripcion,        
                                                   ' ' valor,        
                                                   'N' seleccionado   
                                            FROM medicamentos  
                                            WHERE medicamentos.medicamento NOT IN ( 
                                                                            SELECT capitulacion_med.medicamento 
                                                                            FROM capitulacion_med
                                                                            WHERE capitulacion_med.capitulo = ? AND 
                                                                                  capitulacion_med.rubrica = ?)";





        public override int Retrieve(params object?[] args)
        {
            if (SQLCA.Connection == null)
                throw new InvalidOperationException("SQLCA.Connection es null");

            try
            {
                using var cmd = SQLCA.Connection.CreateCommand();
                cmd.CommandText = SQL;

                var prm0 = cmd.CreateParameter();
                prm0.Value = args[0];
                cmd.Parameters.Add(prm0);

                var prm1 = cmd.CreateParameter();
                prm1.Value = args[1];
                cmd.Parameters.Add(prm1);

                var prm2 = cmd.CreateParameter();
                prm2.Value = args[2];
                cmd.Parameters.Add(prm2);

                var prm3 = cmd.CreateParameter();
                prm3.Value = args[3];
                cmd.Parameters.Add(prm3);

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