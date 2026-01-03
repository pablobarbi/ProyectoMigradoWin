using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Repositories
{
    public static class w_borrar_reperto_dal
    {
        // PB:
        // DELETE FROM reperto_parcial
        // WHERE reperto_parcial = :ll_reperto
        // USING SQLCA;
        public static int DeleteRepertoParcial(decimal ll_reperto)
        {
            const string sql = @"
DELETE
  FROM reperto_parcial
 WHERE reperto_parcial = ?";

            using var cmd = new OdbcCommand(sql, SQLCA.Connection);
            SQLCA.AddParam(cmd, ll_reperto);

            return SQLCA.ExecuteNonQuery(cmd);
        }
    }
}
