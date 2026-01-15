
using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;
using Minotti.utils;


namespace Minotti.Repositories
{ 
    public class d_agregar_subrubricas : datastore
    {
        public const string SQL = @"SELECT subrubricas.nombre FROM subrubricas "; 


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