using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Repositories
{
    public static class w_carga_reperto_parcial_dal
    {
        // PB:
        // INSERT INTO reperto_parcial (...)
        // USING SQLCA;
        public static int InsertRepertoParcial(
            long ll_capitulo,
            long ll_rubrica,
            long ll_subrubrica,
            string ls_medicamento,
            long ll_valor)
        {
            const string sql = @"
INSERT INTO reperto_parcial (
    capitulo,
    rubrica,
    subrubrica,
    medicamento,
    valor
)
VALUES (?, ?, ?, ?, ?)";

            using var cmd = new OdbcCommand(sql, SQLCA.Connection);

            SQLCA.AddParam(cmd, ll_capitulo);
            SQLCA.AddParam(cmd, ll_rubrica);
            SQLCA.AddParam(cmd, ll_subrubrica);
            SQLCA.AddParam(cmd, ls_medicamento);
            SQLCA.AddParam(cmd, ll_valor);

            return SQLCA.ExecuteNonQuery(cmd);
        }
    }
}
