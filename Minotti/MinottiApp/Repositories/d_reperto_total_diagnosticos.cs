using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinottiApp.Repositories
{
    public class d_reperto_total_diagnosticos
    {/// <summary>
     /// Lógica de datos para el DataWindow de reperto_total_diag.
     /// Tabla: reperto_total_diag (reperto_total, fecha, comentario, paciente, marca).
     /// </summary>
        public static class RepertoTotalDiagRepository
        {
            // SELECT del DataWindow (adaptado a ODBC: ? en lugar de :reperto_total)
            public const string SqlRetrieve = @"
SELECT reperto_total_diag.reperto_total,
       reperto_total_diag.fecha,
       reperto_total_diag.comentario,
       reperto_total_diag.paciente,
       reperto_total_diag.marca
  FROM reperto_total_diag
 WHERE reperto_total_diag.reperto_total = ?";

            // INSERT de un registro completo
            public const string SqlInsert = @"
INSERT INTO reperto_total_diag (reperto_total, fecha, comentario, paciente, marca)
VALUES (?, ?, ?, ?, ?)";

            // UPDATE: en el DW todas las columnas tienen updatewhereclause=yes,
            // pero la clave principal funcional suele ser reperto_total (y eventualmente paciente).
            // Para simplificar, usamos reperto_total como condición, y actualizamos todo lo demás.
            public const string SqlUpdate = @"
UPDATE reperto_total_diag
   SET fecha      = ?,
       comentario = ?,
       paciente   = ?,
       marca      = ?
 WHERE reperto_total = ?";

            // DELETE por reperto_total
            public const string SqlDelete = @"
DELETE FROM reperto_total_diag
 WHERE reperto_total = ?";

            /// <summary>
            /// Equivalente al retrieve del DataWindow:
            /// argumentos=(("reperto_total", string))
            /// Devuelve un DataTable con columnas:
            ///   reperto_total, fecha, comentario, paciente, marca
            /// </summary>
            public static DataTable RetrieveByRepertoTotal(object reperto_total)
            {
                return SQLCA.ExecuteDataTable(SqlRetrieve, cmd =>
                {
                    var prm = cmd.CreateParameter();
                    prm.Value = reperto_total ?? DBNull.Value;
                    cmd.Parameters.Add(prm);
                });
            }

            /// <summary>
            /// Inserta un nuevo registro en reperto_total_diag.
            /// Devuelve filas afectadas.
            /// </summary>
            public static int Insert(object reperto_total, object fecha, object comentario, object paciente, object marca)
            {
                return SQLCA.Insert(SqlInsert, cmd =>
                {
                    var p1 = cmd.CreateParameter(); p1.Value = reperto_total ?? DBNull.Value; cmd.Parameters.Add(p1);
                    var p2 = cmd.CreateParameter(); p2.Value = fecha ?? DBNull.Value; cmd.Parameters.Add(p2);
                    var p3 = cmd.CreateParameter(); p3.Value = comentario ?? DBNull.Value; cmd.Parameters.Add(p3);
                    var p4 = cmd.CreateParameter(); p4.Value = paciente ?? DBNull.Value; cmd.Parameters.Add(p4);
                    var p5 = cmd.CreateParameter(); p5.Value = marca ?? DBNull.Value; cmd.Parameters.Add(p5);
                });
            }

            /// <summary>
            /// Actualiza fecha, comentario, paciente y marca para un reperto_total.
            /// Devuelve filas afectadas.
            /// </summary>
            public static int Update(object reperto_total, object fecha, object comentario, object paciente, object marca)
            {
                return SQLCA.Update(SqlUpdate, cmd =>
                {
                    // SET fecha = ?, comentario = ?, paciente = ?, marca = ?
                    var pFecha = cmd.CreateParameter(); pFecha.Value = fecha ?? DBNull.Value; cmd.Parameters.Add(pFecha);
                    var pComent = cmd.CreateParameter(); pComent.Value = comentario ?? DBNull.Value; cmd.Parameters.Add(pComent);
                    var pPac = cmd.CreateParameter(); pPac.Value = paciente ?? DBNull.Value; cmd.Parameters.Add(pPac);
                    var pMarca = cmd.CreateParameter(); pMarca.Value = marca ?? DBNull.Value; cmd.Parameters.Add(pMarca);

                    // WHERE reperto_total = ?
                    var pRep = cmd.CreateParameter(); pRep.Value = reperto_total ?? DBNull.Value; cmd.Parameters.Add(pRep);
                });
            }

            /// <summary>
            /// Borra el registro de reperto_total_diag para el reperto_total indicado.
            /// Devuelve filas afectadas.
            /// </summary>
            public static int Delete(object reperto_total)
            {
                return SQLCA.Delete(SqlDelete, cmd =>
                {
                    var prm = cmd.CreateParameter();
                    prm.Value = reperto_total ?? DBNull.Value;
                    cmd.Parameters.Add(prm);
                });
            }

            /// <summary>
            /// Guarda estilo DataWindow:
            /// si existe reperto_total → UPDATE
            /// si no → INSERT
            /// </summary>
            public static int Save(object reperto_total, object fecha, object comentario, object paciente, object marca)
            {
                if (Exists(reperto_total))
                    return Update(reperto_total, fecha, comentario, paciente, marca);
                else
                    return Insert(reperto_total, fecha, comentario, paciente, marca);
            }

            /// <summary>
            /// Verifica si existe un registro en reperto_total_diag para ese reperto_total.
            /// </summary>
            public static bool Exists(object reperto_total)
            {
                const string sql = @"
SELECT COUNT(*)
  FROM reperto_total_diag
 WHERE reperto_total = ?";

                int? count = SQLCA.ExecuteScalar<int>(sql, cmd =>
                {
                    var prm = cmd.CreateParameter();
                    prm.Value = reperto_total ?? DBNull.Value;
                    cmd.Parameters.Add(prm);
                });

                return (count ?? 0) > 0;
            }
        }
    }
}