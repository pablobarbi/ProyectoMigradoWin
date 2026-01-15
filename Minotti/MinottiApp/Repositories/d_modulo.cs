using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using Minotti.Data;

using Minotti.utils;
namespace Minotti.Repositories
{



    public class d_modulo : datastore
    {
        private readonly string _connectionString = "DSN=tu_dsn_aqui";
        public string ModuloId { get; set; }
        public string Nombre { get; set; }
        public string Bitmap { get; set; }

        private const string SQL = @"
SELECT dba.acc_modulos.modulo,
       dba.acc_modulos.nombre,
       dba.acc_modulos.bitmap
  FROM dba.acc_modulos
 WHERE dba.acc_modulos.modulo = ?";

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