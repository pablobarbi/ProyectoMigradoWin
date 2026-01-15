using Minotti.Data;
using System;

using Minotti.utils;
using System.Data.Odbc;
using System.Data;
namespace Minotti.Repositories
{
    public class r_header : datastore
    {
        // SQL exacto del SRD
        private const string SQL =
@"SELECT count(*)
   FROM dba.acc_usuarios";




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