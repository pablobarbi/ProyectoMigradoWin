using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinottiApp.Repositories
{
    public class d_reperto_total
    {
        // SELECT del DataWindow (adaptado a ODBC: ? en lugar de :rep_total)
        public const string SqlRetrieve = @"
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
        public static DataTable RetrieveByRepertoTotal(object rep_total)
        {
            return SQLCA.ExecuteDataTable(SqlRetrieve, cmd =>
            {
                var prm = cmd.CreateParameter();
                prm.Value = rep_total ?? DBNull.Value;
                cmd.Parameters.Add(prm);
            });
        }

        /// <summary>
        /// Inserta un nuevo registro en reperto_total.
        /// Devuelve filas afectadas.
        /// </summary>
        public static int Insert(object reperto_total, object reperto_sintoma, object orden)
        {
            return SQLCA.Insert(SqlInsert, cmd =>
            {
                var p1 = cmd.CreateParameter();
                p1.Value = reperto_total ?? DBNull.Value;
                cmd.Parameters.Add(p1);

                var p2 = cmd.CreateParameter();
                p2.Value = reperto_sintoma ?? DBNull.Value;
                cmd.Parameters.Add(p2);

                var p3 = cmd.CreateParameter();
                p3.Value = orden ?? DBNull.Value;
                cmd.Parameters.Add(p3);
            });
        }

        /// <summary>
        /// Actualiza 'orden' para el par (reperto_total, reperto_sintoma).
        /// Devuelve filas afectadas.
        /// </summary>
        public static int Update(object reperto_total, object reperto_sintoma, object orden)
        {
            return SQLCA.Update(SqlUpdate, cmd =>
            {
                // SET orden = ?
                var pOrden = cmd.CreateParameter();
                pOrden.Value = orden ?? DBNull.Value;
                cmd.Parameters.Add(pOrden);

                // WHERE reperto_total = ?
                var pRepTotal = cmd.CreateParameter();
                pRepTotal.Value = reperto_total ?? DBNull.Value;
                cmd.Parameters.Add(pRepTotal);

                //   AND reperto_sintoma = ?
                var pRepSintoma = cmd.CreateParameter();
                pRepSintoma.Value = reperto_sintoma ?? DBNull.Value;
                cmd.Parameters.Add(pRepSintoma);
            });
        }

        /// <summary>
        /// Borra el registro de reperto_total para el par (reperto_total, reperto_sintoma).
        /// Devuelve filas afectadas.
        /// </summary>
        public static int Delete(object reperto_total, object reperto_sintoma)
        {
            return SQLCA.Delete(SqlDelete, cmd =>
            {
                var p1 = cmd.CreateParameter();
                p1.Value = reperto_total ?? DBNull.Value;
                cmd.Parameters.Add(p1);

                var p2 = cmd.CreateParameter();
                p2.Value = reperto_sintoma ?? DBNull.Value;
                cmd.Parameters.Add(p2);
            });
        }
    }
}
 
