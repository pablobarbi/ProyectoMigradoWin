using Minotti.Data;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public static class w_borra_reperto_parc_dal
    {
        // PB:
        // DELETE FROM reperto_parcial_med WHERE reperto_parcial = :ll_reperto
        // USING SQLCA;
        public static int DeleteRepertoParcialMed(decimal ll_reperto)
        {
            const string sql = @"DELETE FROM reperto_parcial_med WHERE reperto_parcial = ?";

            using var cmd = new OdbcCommand(sql, SQLCA.Connection);
            SQLCA.AddParam(cmd, ll_reperto);

            return SQLCA.ExecuteNonQuery(cmd);
        }
    }
}
