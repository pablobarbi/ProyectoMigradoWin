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
//SELECT reperto_total.reperto_total,
//       reperto_total.reperto_sintoma,
//       reperto_total.orden
//  FROM reperto_total
// WHERE reperto_total.reperto_total = ?";

    public class d_reperto_total : datastore{
        // SELECT del DataWindow (adaptado a ODBC: ? en lugar de :rep_total)
        public const string SQL = @"
SELECT reperto_total.reperto_total,
       reperto_total.reperto_sintoma,
       reperto_total.orden
  FROM reperto_total
 WHERE reperto_total.reperto_total = ?";

        // INSERT de un registro (todas las columnas)
        public const string SqlInsert = @"
INSERT INTO reperto_total (reperto_total, reperto_sintoma, orden)
VALUES (?, ?, ?)";

        // UPDATE usando las columnas key del DW (reperto_total + reperto_sintoma)
        // Solo actualizamos 'orden' como hace típicamente el DW.
        public const string SqlUpdate = @"
UPDATE reperto_total
   SET orden = ?
 WHERE reperto_total     = ?
   AND reperto_sintoma   = ?";

        // DELETE por keys
        public const string SqlDelete = @"
DELETE FROM reperto_total
 WHERE reperto_total   = ?
   AND reperto_sintoma = ?";

        /// <summary>
        /// Equivalente al retrieve del DataWindow:
        /// argumentos=(("rep_total", string))
        /// Devuelve un DataTable con columnas:
        ///   reperto_total, reperto_sintoma, orden
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