using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Minotti.utils;
using System.Data.Odbc;
namespace MinottiApp.Repositories
{

  

    public class d_reperto_total_diagnosticos : datastore{/// <summary>
                                                          /// Lógica de datos para el DataWindow de reperto_total_diag.
                                                          /// Tabla: reperto_total_diag (reperto_total, fecha, comentario, paciente, marca).
                                                          /// </summary>

        private const string SQL = @"
SELECT reperto_total_diag.reperto_total,
       reperto_total_diag.fecha,
       reperto_total_diag.comentario,
       reperto_total_diag.paciente,
       reperto_total_diag.marca
  FROM reperto_total_diag
 WHERE reperto_total_diag.reperto_total = ?";

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