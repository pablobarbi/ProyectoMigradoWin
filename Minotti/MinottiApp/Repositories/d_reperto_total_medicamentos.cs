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

//    private const string SQL = @"
//SELECT reperto_total_med.reperto_total,
//       reperto_total_med.reperto_sintoma,
//       reperto_total_med.medicamento,
//       reperto_total_med.orden,
//       reperto_total_med.puntuacion
//  FROM reperto_total_med
// WHERE reperto_total_med.reperto_total   = ?
//   AND reperto_total_med.reperto_sintoma = ?";

    public class d_reperto_total_medicamentos : datastore{
        // SELECT del DataWindow (adaptado a ODBC: ? en lugar de :reperto_total, :reperto_sintoma)
        public const string SQL = @"
SELECT reperto_total_med.reperto_total,
       reperto_total_med.reperto_sintoma,
       reperto_total_med.medicamento,
       reperto_total_med.orden,
       reperto_total_med.puntuacion
  FROM reperto_total_med
 WHERE reperto_total_med.reperto_total   = ?
   AND reperto_total_med.reperto_sintoma = ?";

        // INSERT completo
        public const string SqlInsert = @"
INSERT INTO reperto_total_med
    (reperto_total, reperto_sintoma, medicamento, orden, puntuacion)
VALUES
    (?, ?, ?, ?, ?)";

        // UPDATE por keys (reperto_total, reperto_sintoma, medicamento)
        public const string SqlUpdate = @"
UPDATE reperto_total_med
   SET orden      = ?,
       puntuacion = ?
 WHERE reperto_total   = ?
   AND reperto_sintoma = ?
   AND medicamento     = ?";

        // DELETE por keys
        public const string SqlDelete = @"
DELETE FROM reperto_total_med
 WHERE reperto_total   = ?
   AND reperto_sintoma = ?
   AND medicamento     = ?";

        /// <summary>
        /// Equivalente al retrieve del DataWindow:
        /// argumentos=(("reperto_total", string),("reperto_sintoma", string))
        /// Devuelve todas las filas para ese par (reperto_total, reperto_sintoma).
        /// </summary>
        


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

var prm1 = cmd.CreateParameter();
prm1.Value = args[1];
cmd.Parameters.Add(prm1);

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