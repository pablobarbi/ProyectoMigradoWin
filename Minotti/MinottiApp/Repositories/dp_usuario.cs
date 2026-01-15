using Minotti.Data;
using System.Data.Odbc;
using Minotti.utils;
using System.Data;


namespace Minotti.Repositories
{


    public class dp_usuario : datastore
    {
        public string Usuario { get; set; }

        private const string SQL = @"SELECT usuario FROM dba.acc_usuarios ORDER BY usuario";

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