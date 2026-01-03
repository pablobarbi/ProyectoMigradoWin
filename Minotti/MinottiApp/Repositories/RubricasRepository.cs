using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti
{
    /// <summary>
    /// Lógica para cargar mig_rubricas a partir de las tablas c4..c39.
    /// Migración del PIPELINE original.
    /// </summary>
    public static class RubricasRepository
    {
        // SQL original del PIPELINE (RETRIEVE)
        private const string SelectSql = @"
SELECT  4 AS capitulo, codigo, descripcio FROM c4
UNION  SELECT  5 AS capitulo, codigo, descripcio FROM c5
UNION  SELECT  7 AS capitulo, codigo, descripcio FROM c7
UNION  SELECT  8 AS capitulo, codigo, descripcio FROM c8
UNION  SELECT  9 AS capitulo, codigo, descripcio FROM c9
UNION  SELECT 10 AS capitulo, codigo, descripcio FROM c10
UNION  SELECT 11 AS capitulo, codigo, descripcio FROM c11
UNION  SELECT 12 AS capitulo, codigo, descripcio FROM c12
UNION  SELECT 13 AS capitulo, codigo, descripcio FROM c13
UNION  SELECT 14 AS capitulo, codigo, descripcio FROM c14
UNION  SELECT 15 AS capitulo, codigo, descripcio FROM c15
UNION  SELECT 16 AS capitulo, codigo, descripcio FROM c16
UNION  SELECT 17 AS capitulo, codigo, descripcio FROM c17
UNION  SELECT 18 AS capitulo, codigo, descripcio FROM c18
UNION  SELECT 19 AS capitulo, codigo, descripcio FROM c19
UNION  SELECT 20 AS capitulo, codigo, descripcio FROM c20
UNION  SELECT 21 AS capitulo, codigo, descripcio FROM c21
UNION  SELECT 22 AS capitulo, codigo, descripcio FROM c22
UNION  SELECT 23 AS capitulo, codigo, descripcio FROM c23
UNION  SELECT 24 AS capitulo, codigo, descripcio FROM c24
UNION  SELECT 25 AS capitulo, codigo, descripcio FROM c25
UNION  SELECT 26 AS capitulo, codigo, descripcio FROM c26
UNION  SELECT 27 AS capitulo, codigo, descripcio FROM c27
UNION  SELECT 28 AS capitulo, codigo, descripcio FROM c28
UNION  SELECT 29 AS capitulo, codigo, descripcio FROM c29
UNION  SELECT 30 AS capitulo, codigo, descripcio FROM c30
UNION  SELECT 31 AS capitulo, codigo, descripcio FROM c31
UNION  SELECT 32 AS capitulo, codigo, descripcio FROM c32
UNION  SELECT 33 AS capitulo, codigo, descripcio FROM c33
UNION  SELECT 34 AS capitulo, codigo, descripcio FROM c34
UNION  SELECT 35 AS capitulo, codigo, descripcio FROM c35
UNION  SELECT 36 AS capitulo, codigo, descripcio FROM c36
UNION  SELECT 37 AS capitulo, codigo, descripcio FROM c37
UNION  SELECT 38 AS capitulo, codigo, descripcio FROM c38
UNION  SELECT 39 AS capitulo, codigo, descripcio FROM c39";

        /// <summary>
        /// Ejecuta el pipeline:
        ///  - Lee capitulo, codigo, descripcio desde c4..c39 (SelectSql)
        ///  - Borra el contenido de mig_rubricas
        ///  - Inserta todas las filas en mig_rubricas(capitulo, codigo, descripcio)
        ///
        /// Devuelve la cantidad de filas insertadas.
        /// </summary>
        public static int EjecutarMigRubricas()
        {
            if (SQLCA.Connection is null)
            {
                SQLCA.SqlCode = -1;
                SQLCA.SqlErrText = "SQLCA.Connection no está configurada.";
                return -1;
            }

            if (string.IsNullOrEmpty(SQLCA.UserID))
            {
                SQLCA.SqlCode = -1;
                SQLCA.SqlErrText = "SQLCA.UserID no está configurado.";
                return -1;
            }

            // 1) Obtener las filas origen usando SQLCA.ExecuteList
            var filas = SQLCA.ExecuteList(
                SelectSql,
                reader => new
                {
                    capitulo = reader.IsDBNull(0) ? (double?)null : Convert.ToDouble(reader.GetValue(0)),
                    codigo = reader.IsDBNull(1) ? (double?)null : Convert.ToDouble(reader.GetValue(1)),
                    descripcio = reader.IsDBNull(2) ? string.Empty : reader.GetString(2)
                },
                cmd =>
                {
                    // Sin parámetros en este SELECT
                });

            using var tran = SQLCA.Connection.BeginTransaction();

            try
            {
                // 2) Limpiar tabla destino (equivalente a type=create del pipeline)
                using (var cmdDelete = SQLCA.Connection.CreateCommand())
                {
                    cmdDelete.Transaction = tran;
                    cmdDelete.CommandText = "DELETE FROM mig_rubricas";
                    cmdDelete.ExecuteNonQuery();
                }

                // 3) Insertar en mig_rubricas(capitulo, codigo, descripcio)
                using (var cmdInsert = SQLCA.Connection.CreateCommand())
                {
                    cmdInsert.Transaction = tran;
                    cmdInsert.CommandText = @"
INSERT INTO mig_rubricas (capitulo, codigo, descripcio)
VALUES (?, ?, ?)";

                    var pCapitulo = cmdInsert.Parameters.Add("capitulo", OdbcType.Double);
                    var pCodigo = cmdInsert.Parameters.Add("codigo", OdbcType.Double);
                    var pDescripcio = cmdInsert.Parameters.Add("descripcio", OdbcType.VarChar, 255);

                    int inserted = 0;

                    foreach (var fila in filas)
                    {
                        pCapitulo.Value = (object?)fila.capitulo ?? DBNull.Value;
                        pCodigo.Value = (object?)fila.codigo ?? DBNull.Value;
                        pDescripcio.Value = (object?)fila.descripcio ?? DBNull.Value;

                        cmdInsert.ExecuteNonQuery();
                        inserted++;
                    }

                    tran.Commit();

                    SQLCA.SqlCode = 0;
                    SQLCA.SqlErrText = null;

                    return inserted;
                }
            }
            catch (OdbcException ex)
            {
                tran.Rollback();
                SQLCA.SqlCode = ex.ErrorCode;
                SQLCA.SqlErrText = ex.Message;
                throw;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                SQLCA.SqlCode = -1;
                SQLCA.SqlErrText = ex.Message;
                throw;
            }
        }
    }
}
