using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

using Minotti.utils;
using System.Data;
namespace Minotti.Repositories
{


    public class d_ayuda : datastore
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Ayuda { get; set; }

        //        
        private const string SQL = @"
SELECT ayuda,
       titulo,
       descripcion
  FROM dba.acc_ayuda
 ORDER BY ayuda";


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