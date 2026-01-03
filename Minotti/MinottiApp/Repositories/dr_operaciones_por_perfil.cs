using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dr_operaciones_por_perfil
    {


        public string perfil { get; set; }
        public string nombre_perfil { get; set; }
        public string modulo { get; set; }
        public string nombre_modulo { get; set; }
        public string bitmap_modulo { get; set; }
        public string operacion { get; set; }
        public string nombre_operacion { get; set; }
        public string bitmap_operacion { get; set; }
        public string alta { get; set; }
        public string baja { get; set; }
        public string modificacion { get; set; }



        /// <summary>
        /// Equivalente al retrieve del DataWindow dr_operaciones_por_perfil.
        /// Argumento: perfil (string), como en arguments=(("perfil", string))
        ///
        /// En el SRD:
        ///   AND (dba.acc_modulos_x_perfil.perfil = :perfil or :perfil is Null)
        /// </summary>


        public static List<dr_operaciones_por_perfil> Retrieve(string perfil)
        {
            const string sql = @"
SELECT dba.acc_perfiles.perfil                               AS perfil,
       dba.acc_perfiles.nombre                               AS nombre_perfil,
       dba.acc_operaciones_x_modulo.modulo                   AS modulo,
       dba.acc_modulos.nombre                                AS nombre_modulo,
       dba.acc_modulos.bitmap                                AS bitmap_modulo,
       dba.acc_operaciones_x_modulo.operacion                AS operacion,
       dba.acc_operaciones.nombre                            AS nombre_operacion,
       dba.acc_operaciones.bitmap                            AS bitmap_operacion,
       UPPER(dba.acc_operaciones_x_modulo.alta)              AS alta,
       UPPER(dba.acc_operaciones_x_modulo.baja)              AS baja,
       UPPER(dba.acc_operaciones_x_modulo.modificacion)      AS modificacion
  FROM dba.acc_modulos,
       dba.acc_operaciones,
       dba.acc_operaciones_x_modulo,
       dba.acc_modulos_x_perfil,
       dba.acc_perfiles
 WHERE dba.acc_modulos.modulo = dba.acc_operaciones_x_modulo.modulo
   AND dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion
   AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
   AND dba.acc_modulos_x_perfil.perfil = dba.acc_perfiles.perfil
   AND (dba.acc_modulos_x_perfil.perfil = ? OR ? IS NULL)
 ORDER BY dba.acc_perfiles.nombre,
          dba.acc_modulos.nombre,
          dba.acc_operaciones.nombre";

            return SQLCA.ExecuteList(
                sql,
                r => new dr_operaciones_por_perfil
                {
                    perfil = r["perfil"] as string ?? string.Empty,
                    nombre_perfil = r["nombre_perfil"] as string ?? string.Empty,
                    modulo = r["modulo"] as string ?? string.Empty,
                    nombre_modulo = r["nombre_modulo"] as string ?? string.Empty,
                    bitmap_modulo = r["bitmap_modulo"] as string ?? string.Empty,
                    operacion = r["operacion"] as string ?? string.Empty,
                    nombre_operacion = r["nombre_operacion"] as string ?? string.Empty,
                    bitmap_operacion = r["bitmap_operacion"] as string ?? string.Empty,
                    alta = r["alta"] as string ?? string.Empty,
                    baja = r["baja"] as string ?? string.Empty,
                    modificacion = r["modificacion"] as string ?? string.Empty
                },
                cmd =>
                {
                    // ODBC usa parámetros posicionales "?"
                    object value = (object?)perfil ?? DBNull.Value;

                    var p1 = cmd.CreateParameter();
                    p1.Value = value;
                    cmd.Parameters.Add(p1); // para "= ?"

                    var p2 = cmd.CreateParameter();
                    p2.Value = value;
                    cmd.Parameters.Add(p2); // para "OR ? IS NULL"
                });
        }
//        public static List<dr_operaciones_por_perfil> Retrieve(string perfil)
//        {
//            const string sql = @"
//SELECT dba.acc_perfiles.perfil                               AS perfil,
//       dba.acc_perfiles.nombre                               AS nombre_perfil,
//       dba.acc_operaciones_x_modulo.modulo                   AS modulo,
//       dba.acc_modulos.nombre                                AS nombre_modulo,
//       dba.acc_modulos.bitmap                                AS bitmap_modulo,
//       dba.acc_operaciones_x_modulo.operacion                AS operacion,
//       dba.acc_operaciones.nombre                            AS nombre_operacion,
//       dba.acc_operaciones.bitmap                            AS bitmap_operacion,
//       UPPER(dba.acc_operaciones_x_modulo.alta)              AS alta,
//       UPPER(dba.acc_operaciones_x_modulo.baja)              AS baja,
//       UPPER(dba.acc_operaciones_x_modulo.modificacion)      AS modificacion
//  FROM dba.acc_modulos,
//       dba.acc_operaciones,
//       dba.acc_operaciones_x_modulo,
//       dba.acc_modulos_x_perfil,
//       dba.acc_perfiles
// WHERE dba.acc_modulos.modulo = dba.acc_operaciones_x_modulo.modulo
//   AND dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion
//   AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
//   AND dba.acc_modulos_x_perfil.perfil = dba.acc_perfiles.perfil
//   AND (dba.acc_modulos_x_perfil.perfil = ? OR ? IS NULL)
// ORDER BY dba.acc_perfiles.nombre,
//          dba.acc_modulos.nombre,
//          dba.acc_operaciones.nombre";

//            var lista = new List<dr_operaciones_por_perfil>();

//            using (var connection = new OdbcConnection(sqlca_connection_string))
//            using (var command = new OdbcCommand(sql, connection))
//            {
//                // ODBC usa "?" y son POSICIONALES.
//                // El SRD usa :perfil dos veces → acá agregamos 2 parámetros en el mismo orden.
//                object value = (object)perfil ?? DBNull.Value;

//                command.Parameters.Add(new OdbcParameter { Value = value }); // para "= ?"
//                command.Parameters.Add(new OdbcParameter { Value = value }); // para "OR ? IS NULL"

//                connection.Open();

//                using (var reader = command.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        var row = new dr_operaciones_por_perfil_row
//                        {
//                            perfil = reader["perfil"] as string,
//                            nombre_perfil = reader["nombre_perfil"] as string,
//                            modulo = reader["modulo"] as string,
//                            nombre_modulo = reader["nombre_modulo"] as string,
//                            bitmap_modulo = reader["bitmap_modulo"] as string,
//                            operacion = reader["operacion"] as string,
//                            nombre_operacion = reader["nombre_operacion"] as string,
//                            bitmap_operacion = reader["bitmap_operacion"] as string,
//                            alta = reader["alta"] as string,
//                            baja = reader["baja"] as string,
//                            modificacion = reader["modificacion"] as string
//                        };

//                        lista.Add(row);
//                    }
//                }
//            }

//            return lista;
//        }
    }


   
}
