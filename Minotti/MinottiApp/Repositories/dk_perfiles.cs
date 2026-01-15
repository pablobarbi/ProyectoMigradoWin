using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

using Minotti.utils;
using System.Data;
namespace Minotti.Repositories
{

   

    public class dk_perfiles : datastore
    {
        public string Perfil { get; set; }
        public string Nombre { get; set; }
        public string Bitmap { get; set; }


        private const string SQL = @"
SELECT dba.acc_perfiles.perfil,
       dba.acc_perfiles.nombre,
       dba.acc_perfiles.bitmap
  FROM dba.acc_perfiles
 ORDER BY dba.acc_perfiles.nombre";


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