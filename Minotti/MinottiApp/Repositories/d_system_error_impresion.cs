using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

using Minotti.utils;
using System.Data;
namespace Minotti.Repositories
{


    public class d_system_error_impresion : datastore
    {
        public string nro_error { get; set; }
        public string fecha_hora { get; set; }
        public string lugar { get; set; }
        public string evento { get; set; }
        public string objeto { get; set; }
        public string linea_script { get; set; }
        public string mensaje_error { get; set; }


        private const string SQL = @"
SELECT dba.errores_sistema.nro_error,
       dba.errores_sistema.fecha_hora,
       dba.errores_sistema.lugar,
       dba.errores_sistema.evento,
       dba.errores_sistema.objeto,
       dba.errores_sistema.linea_script,
       dba.errores_sistema.mensaje_error
  FROM dba.errores_sistema";



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