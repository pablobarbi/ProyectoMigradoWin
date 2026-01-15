using Minotti.Data;
using Minotti.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace Minotti.Repositories
{



    public class dk_submodulos : datastore
    {
        public string Submodulo { get; set; }
        public string Nombre { get; set; }
        public string Bitmap { get; set; }


        private const string SQL = @"
SELECT dba.acc_submodulos.submodulo,
       dba.acc_submodulos.nombre,
       dba.acc_submodulos.bitmap
  FROM dba.acc_submodulos
 ORDER BY dba.acc_submodulos.nombre";

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