using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Repositories
{
    public static class SubrubricasData
    {
        /// <summary>
        /// PB: DELETE FROM subrubricas WHERE subrubrica = :ll_SubRubrica
        /// </summary>
        public static bool DeleteSubrubrica(long subrubrica)
        {
            const string sql = @"
DELETE FROM subrubricas
WHERE subrubrica = ?
";

            int rows = SQLCA.ExecuteNonQuery(
                sql,
                subrubrica
            );

            return rows > 0;
        }

        /// <summary>
        /// PB:
        /// UPDATE subrubricas
        ///    SET nombre = :ls_Nombre
        ///  WHERE subrubrica = :ll_subrubrica
        /// </summary>
        public static bool UpdateNombreSubrubrica(long subrubrica, string nombre)
        {
            const string sql = @"
UPDATE subrubricas
   SET nombre = ?
 WHERE subrubrica = ?
";

            int rows = SQLCA.ExecuteNonQuery(sql, cmd =>
            {
                cmd.Parameters.AddWithValue("@p1", nombre);
                cmd.Parameters.AddWithValue("@p2", subrubrica);
            });


            return rows > 0;
        }

        /// <summary>
        /// PB: INSERT vía dsto_actualiza_subrubricas
        /// (equivalente explícito)
        /// </summary>
        public static long InsertSubrubrica(string nombre)
        {
            const string sql = @"
INSERT INTO subrubricas (nombre)
VALUES (?)
";

            SQLCA.ExecuteNonQuery(sql, nombre);

            // PB luego hace:
            // GetItemNumber(ll_Fila, 'subrubrica')
            // → asumimos identity / autoincrement
            return SQLCA.GetLastIdentity();
        }
    }
}
