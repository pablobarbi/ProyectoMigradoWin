using Minotti.Data;
using System;

namespace Minotti.Repositories
{
    public class r_header
    {
        // SQL exacto del SRD
        private const string SQL_RETRIEVE =
@"SELECT count(*)
   FROM dba.acc_usuarios";

        public static long GetCantidadUsuarios()
        {
            if (SQLCA.Connection == null)
                throw new InvalidOperationException("SQLCA.Connection es null (no inicializada).");

            try
            {
                using var cmd = SQLCA.Connection.CreateCommand();
                cmd.CommandText = SQL_RETRIEVE;

                object? val = cmd.ExecuteScalar();
                long result = (val == null || val is DBNull) ? 0L : Convert.ToInt64(val);

                SQLCA.SqlCode = 0;
                SQLCA.SqlErrText = null;
                return result;
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
 
