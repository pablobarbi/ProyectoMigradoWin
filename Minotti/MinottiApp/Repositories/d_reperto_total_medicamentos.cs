using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinottiApp.Repositories
{
    public class d_reperto_total_medicamentos
    {
        // SELECT del DataWindow (adaptado a ODBC: ? en lugar de :reperto_total, :reperto_sintoma)
        public const string SqlRetrieve = @"
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
        public static DataTable RetrieveByReperto(object reperto_total, object reperto_sintoma)
        {
            return SQLCA.ExecuteDataTable(SqlRetrieve, cmd =>
            {
                var p1 = cmd.CreateParameter();
                p1.Value = reperto_total ?? DBNull.Value;
                cmd.Parameters.Add(p1);

                var p2 = cmd.CreateParameter();
                p2.Value = reperto_sintoma ?? DBNull.Value;
                cmd.Parameters.Add(p2);
            });
        }

        /// <summary>
        /// Inserta un nuevo registro en reperto_total_med.
        /// Devuelve filas afectadas.
        /// </summary>
        public static int Insert(
            object reperto_total,
            object reperto_sintoma,
            object medicamento,
            object orden,
            object puntuacion)
        {
            return SQLCA.Insert(SqlInsert, cmd =>
            {
                var p1 = cmd.CreateParameter(); p1.Value = reperto_total ?? DBNull.Value; cmd.Parameters.Add(p1);
                var p2 = cmd.CreateParameter(); p2.Value = reperto_sintoma ?? DBNull.Value; cmd.Parameters.Add(p2);
                var p3 = cmd.CreateParameter(); p3.Value = medicamento ?? DBNull.Value; cmd.Parameters.Add(p3);
                var p4 = cmd.CreateParameter(); p4.Value = orden ?? DBNull.Value; cmd.Parameters.Add(p4);
                var p5 = cmd.CreateParameter(); p5.Value = puntuacion ?? DBNull.Value; cmd.Parameters.Add(p5);
            });
        }

        /// <summary>
        /// Actualiza orden y puntuacion para un registro identificado por
        /// (reperto_total, reperto_sintoma, medicamento).
        /// Devuelve filas afectadas.
        /// </summary>
        public static int Update(
            object reperto_total,
            object reperto_sintoma,
            object medicamento,
            object orden,
            object puntuacion)
        {
            return SQLCA.Update(SqlUpdate, cmd =>
            {
                // SET orden = ?, puntuacion = ?
                var pOrden = cmd.CreateParameter(); pOrden.Value = orden ?? DBNull.Value; cmd.Parameters.Add(pOrden);
                var pPunt = cmd.CreateParameter(); pPunt.Value = puntuacion ?? DBNull.Value; cmd.Parameters.Add(pPunt);

                // WHERE reperto_total = ?
                var pRepTotal = cmd.CreateParameter(); pRepTotal.Value = reperto_total ?? DBNull.Value; cmd.Parameters.Add(pRepTotal);

                //   AND reperto_sintoma = ?
                var pRepSint = cmd.CreateParameter(); pRepSint.Value = reperto_sintoma ?? DBNull.Value; cmd.Parameters.Add(pRepSint);

                //   AND medicamento = ?
                var pMed = cmd.CreateParameter(); pMed.Value = medicamento ?? DBNull.Value; cmd.Parameters.Add(pMed);
            });
        }

        /// <summary>
        /// Borra un registro por claves (reperto_total, reperto_sintoma, medicamento).
        /// Devuelve filas afectadas.
        /// </summary>
        public static int Delete(object reperto_total, object reperto_sintoma, object medicamento)
        {
            return SQLCA.Delete(SqlDelete, cmd =>
            {
                var p1 = cmd.CreateParameter(); p1.Value = reperto_total ?? DBNull.Value; cmd.Parameters.Add(p1);
                var p2 = cmd.CreateParameter(); p2.Value = reperto_sintoma ?? DBNull.Value; cmd.Parameters.Add(p2);
                var p3 = cmd.CreateParameter(); p3.Value = medicamento ?? DBNull.Value; cmd.Parameters.Add(p3);
            });
        }

        /// <summary>
        /// Verifica si existe un registro para las claves indicadas.
        /// </summary>
        public static bool Exists(object reperto_total, object reperto_sintoma, object medicamento)
        {
            const string sql = @"
SELECT COUNT(*)
  FROM reperto_total_med
 WHERE reperto_total   = ?
   AND reperto_sintoma = ?
   AND medicamento     = ?";

            int? count = SQLCA.ExecuteScalar<int>(sql, cmd =>
            {
                var p1 = cmd.CreateParameter(); p1.Value = reperto_total ?? DBNull.Value; cmd.Parameters.Add(p1);
                var p2 = cmd.CreateParameter(); p2.Value = reperto_sintoma ?? DBNull.Value; cmd.Parameters.Add(p2);
                var p3 = cmd.CreateParameter(); p3.Value = medicamento ?? DBNull.Value; cmd.Parameters.Add(p3);
            });

            return (count ?? 0) > 0;
        }

        /// <summary>
        /// Guardar estilo DataWindow:
        /// - Si existe (reperto_total, reperto_sintoma, medicamento) → UPDATE
        /// - Si no → INSERT
        /// </summary>
        public static int Save(
            object reperto_total,
            object reperto_sintoma,
            object medicamento,
            object orden,
            object puntuacion)
        {
            if (Exists(reperto_total, reperto_sintoma, medicamento))
            {
                return Update(reperto_total, reperto_sintoma, medicamento, orden, puntuacion);
            }
            else
            {
                return Insert(reperto_total, reperto_sintoma, medicamento, orden, puntuacion);
            }
        }
    }
}