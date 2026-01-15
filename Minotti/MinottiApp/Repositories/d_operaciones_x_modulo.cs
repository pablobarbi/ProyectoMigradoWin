using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

using Minotti.utils;
using System.Data;
namespace Minotti.Repositories
{



    public class d_operaciones_x_modulo : datastore{
        public string Modulo { get; set; }
        public string Operacion { get; set; }
        public string Submodulo { get; set; }
        public string Alta { get; set; }
        public string Baja { get; set; }
        public string Modificacion { get; set; }


        private const string SQL = @"
SELECT dba.acc_operaciones_x_modulo.modulo,
       dba.acc_operaciones_x_modulo.operacion,
       dba.acc_operaciones_x_modulo.submodulo,
       dba.acc_operaciones_x_modulo.alta,
       dba.acc_operaciones_x_modulo.baja,
       dba.acc_operaciones_x_modulo.modificacion
  FROM dba.acc_operaciones_x_modulo
 WHERE dba.acc_operaciones_x_modulo.modulo = ?";



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