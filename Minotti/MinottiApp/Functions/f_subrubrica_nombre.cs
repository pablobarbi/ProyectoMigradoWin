using System;

namespace Minotti.Functions
{
     

    public static class f_subrubrica_nombre
    {
        // Equivalente a: global function string f_subrubrica_nombre (long ai_subrubrica)
        public static string fsubrubrica_nombre(long ai_subrubrica)
        {
            string ls_nombre = string.Empty;

            const string sql = @"
select nombre
  from subrubricas
 where subrubrica = ?";

            var dt = Minotti.Data.SQLCA.ExecuteDataTable(sql, cmd =>
            {
                // parámetro posicional ODBC
                var p = cmd.CreateParameter();
                p.Value = ai_subrubrica;
                cmd.Parameters.Add(p);
            });

            if (Minotti.Data.SQLCA.SqlCode != 0)
                return string.Empty;

            if (dt.Rows.Count > 0 && dt.Rows[0] != null && dt.Columns.Count > 0)
            {
                var val = dt.Rows[0][0];
                if (val != DBNull.Value && val != null)
                    ls_nombre = Convert.ToString(val) ?? string.Empty;
            }

            return ls_nombre;
        }
    }

}
