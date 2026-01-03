using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dl_operaciones_por_usuario
    {

        public string usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string modulo { get; set; }
        public string nombre_modulo { get; set; }
        public string bitmap_modulo { get; set; }
        public string operacion { get; set; }
        public string nombre_operacion { get; set; }
        public string bitmap_operacion { get; set; }
        public string alta { get; set; }
        public string baja { get; set; }
        public string modificacion { get; set; }


        private const string Sql = @"
SELECT dba.acc_usuarios.usuario,
       dba.acc_usuarios.nombre nombre_usuario,
       dba.acc_operaciones_x_modulo.modulo,
       dba.acc_modulos.nombre,
       dba.acc_modulos.bitmap,
       dba.acc_operaciones_x_modulo.operacion,
       dba.acc_operaciones.nombre,
       dba.acc_operaciones.bitmap,
       upper(dba.acc_operaciones_x_modulo.alta) alta,
       upper(dba.acc_operaciones_x_modulo.baja) baja,
       upper(dba.acc_operaciones_x_modulo.modificacion) modificacion
  FROM dba.acc_modulos,
       dba.acc_operaciones,
       dba.acc_operaciones_x_modulo,
       dba.acc_modulos_x_perfil,
       dba.acc_usuarios
 WHERE dba.acc_modulos.modulo = dba.acc_operaciones_x_modulo.modulo
   AND dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion
   AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
   AND dba.acc_modulos_x_perfil.perfil = dba.acc_usuarios.perfil
   AND dba.acc_usuarios.usuario = ?
 ORDER BY dba.acc_modulos.nombre,
          dba.acc_operaciones.nombre";



        /// <summary>
        /// Equivalente al retrieve del DataWindow dl_operaciones_por_usuario.
        /// Argumento: usuario (string), como en arguments=(("usuario", string))
        /// </summary>

        public static List<dl_operaciones_por_usuario> Retrieve(string usuario)
        {
            return SQLCA.ExecuteList(
                Sql,
                r => new dl_operaciones_por_usuario
                {
                    // nombres iguales a los del datawindow:
                    usuario = r["usuario"] as string,
                    nombre_usuario = r["nombre_usuario"] as string,
                    modulo = r["modulo"] as string,
                    nombre_modulo = r["nombre_modulo"] as string,   // acc_modulos.nombre
                    bitmap_modulo = r["bitmap_modulo"] as string,   // acc_modulos.bitmap
                    operacion = r["operacion"] as string,
                    nombre_operacion = r["nombre_operacion"] as string,   // acc_operaciones.nombre
                    bitmap_operacion = r["bitmap_operacion"] as string,   // acc_operaciones.bitmap
                    alta = r["alta"] as string,
                    baja = r["baja"] as string,
                    modificacion = r["modificacion"] as string
                },
                cmd =>
                {
                    // parámetro :usuario → ?
                    var p = cmd.CreateParameter();
                    p.Value = string.IsNullOrEmpty(usuario)
                              ? (object)DBNull.Value
                              : usuario;
                    cmd.Parameters.Add(p);
                });
        }
    }







    //        public static List<dl_operaciones_por_usuario> Retrieve(string usuario)
    //        {
    //            const string sql = @"
    //SELECT dba.acc_usuarios.usuario,
    //       dba.acc_usuarios.nombre nombre_usuario,
    //       dba.acc_operaciones_x_modulo.modulo,
    //       dba.acc_modulos.nombre,
    //       dba.acc_modulos.bitmap,
    //       dba.acc_operaciones_x_modulo.operacion,
    //       dba.acc_operaciones.nombre,
    //       dba.acc_operaciones.bitmap,
    //       upper(dba.acc_operaciones_x_modulo.alta) alta,
    //       upper(dba.acc_operaciones_x_modulo.baja) baja,
    //       upper(dba.acc_operaciones_x_modulo.modificacion) modificacion
    //  FROM dba.acc_modulos,
    //       dba.acc_operaciones,
    //       dba.acc_operaciones_x_modulo,
    //       dba.acc_modulos_x_perfil,
    //       dba.acc_usuarios
    // WHERE dba.acc_modulos.modulo = dba.acc_operaciones_x_modulo.modulo
    //   AND dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion
    //   AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
    //   AND dba.acc_modulos_x_perfil.perfil = dba.acc_usuarios.perfil
    //   AND dba.acc_usuarios.usuario = @usuario
    // ORDER BY dba.acc_modulos.nombre,
    //          dba.acc_operaciones.nombre";

    //            var lista = new List<dl_operaciones_por_usuario_row>();

    //            using (var connection = new OdbcConnection(sqlca_connection_string))
    //            using (var command = new OdbcCommand(sql, connection))
    //            {
    //                command.Parameters.Add(
    //                    new OdbcParameter("@usuario", OdbcType.VarChar) { Value = usuario }
    //                );

    //                connection.Open();

    //                using (var reader = command.ExecuteReader())
    //                {
    //                    while (reader.Read())
    //                    {
    //                        var row = new dl_operaciones_por_usuario_row
    //                        {
    //                            // orden de columnas según el SELECT
    //                            usuario = reader["usuario"] as string,
    //                            nombre_usuario = reader["nombre_usuario"] as string,
    //                            modulo = reader["modulo"] as string,
    //                            nombre_modulo = reader.GetString(3), // dba.acc_modulos.nombre
    //                            bitmap_modulo = reader["bitmap"] as string, // acc_modulos.bitmap
    //                            operacion = reader["operacion"] as string,
    //                            nombre_operacion = reader.GetString(6), // dba.acc_operaciones.nombre
    //                            bitmap_operacion = reader["bitmap1"] as string, // acc_operaciones.bitmap
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

 