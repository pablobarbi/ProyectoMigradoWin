using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

using Minotti.utils;
namespace Minotti.Repositories
{

 

    // Migrado desde PowerBuilder DataWindow: dk_medicamentos_ejemplos.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dk_medicamentos_ejemplos : datastore
    {
        // Consulta original detectada desde el SRD
        public const string SQL = @"SELECT medicamentos.medicamento,        
                                                   medicamentos.descripcion,        
                                                   ' ' seleccionado   
                                            FROM medicamentos";

        // Carga los datos usando ODBC (SQL Anywhere 9 via DSN).



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