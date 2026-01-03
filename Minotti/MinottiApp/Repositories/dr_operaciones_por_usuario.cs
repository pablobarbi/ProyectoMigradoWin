using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dr_operaciones_por_usuario
    {
        public string? usuario { get; set; }
        public string? nombre_usuario { get; set; }
        public string? modulo { get; set; }
        public string? nombre_modulo { get; set; }
        public string? bitmap_modulo { get; set; }
        public string? operacion { get; set; }
        public string? nombre_operacion { get; set; }
        public string? bitmap_operacion { get; set; }
        public string? alta { get; set; }
        public string? baja { get; set; }
        public string? modificacion { get; set; }


        private const string Sql = @"
SELECT dba.acc_usuarios.usuario                               AS usuario,
       dba.acc_usuarios.nombre                                AS nombre_usuario,
       dba.acc_operaciones_x_modulo.modulo                    AS modulo,
       dba.acc_modulos.nombre                                 AS nombre_modulo,
       dba.acc_modulos.bitmap                                 AS bitmap_modulo,
       dba.acc_operaciones_x_modulo.operacion                 AS operacion,
       dba.acc_operaciones.nombre                             AS nombre_operacion,
       dba.acc_operaciones.bitmap                             AS bitmap_operacion,
       UPPER(dba.acc_operaciones_x_modulo.alta)               AS alta,
       UPPER(dba.acc_operaciones_x_modulo.baja)               AS baja,
       UPPER(dba.acc_operaciones_x_modulo.modificacion)       AS modificacion
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


        public static List<dr_operaciones_por_usuario> Retrieve(string usuario)
        {
            if (SQLCA.Connection is null)
                throw new InvalidOperationException("SQLCA.Connection no inicializada. Llamar a SQLCA.Initialize(...)");

            return SQLCA.ExecuteReaderList(
                Sql,
                r => new dr_operaciones_por_usuario
                {
                    usuario = r.IsDBNull(0) ? null : r.GetString(0),
                    nombre_usuario = r.IsDBNull(1) ? null : r.GetString(1),
                    modulo = r.IsDBNull(2) ? null : r.GetString(2),
                    nombre_modulo = r.IsDBNull(3) ? null : r.GetString(3),
                    bitmap_modulo = r.IsDBNull(4) ? null : r.GetString(4),
                    operacion = r.IsDBNull(5) ? null : r.GetString(5),
                    nombre_operacion = r.IsDBNull(6) ? null : r.GetString(6),
                    bitmap_operacion = r.IsDBNull(7) ? null : r.GetString(7),
                    alta = r.IsDBNull(8) ? null : r.GetString(8),
                    baja = r.IsDBNull(9) ? null : r.GetString(9),
                    modificacion = r.IsDBNull(10) ? null : r.GetString(10)
                },
                cmd =>
                {
                    // único parámetro: usuario (ODBC usa ? posicional)
                    SQLCA.AddParam(cmd, usuario);
                });
        }
    }

    //        public static List<dr_operaciones_por_usuario> GetByUsuario(string usuario)
    //        {
    //            var lista = new List<dr_operaciones_por_usuario>();
    //            string connectionString = "DSN=tu_dsn_aqui";

    //            using (var connection = new OdbcConnection(connectionString))
    //            {
    //                connection.Open();
    //                var command = new OdbcCommand(@"
    //SELECT dba.acc_usuarios.usuario,        dba.acc_usuarios.nombre nombre_usuario,        dba.acc_operaciones_x_modulo.modulo,        dba.acc_modulos.nombre,        dba.acc_modulos.bitmap,        dba.acc_operaciones_x_modulo.operacion,        dba.acc_operaciones.nombre,        dba.acc_operaciones.bitmap,        upper(dba.acc_operaciones_x_modulo.alta) alta,        upper(dba.acc_operaciones_x_modulo.baja) baja,        upper(dba.acc_operaciones_x_modulo.modificacion) modificacion   FROM dba.acc_modulos,        dba.acc_operaciones,        dba.acc_operaciones_x_modulo,        dba.acc_modulos_x_perfil,        dba.acc_usuarios  WHERE dba.acc_modulos.modulo = dba.acc_operaciones_x_modulo.modulo    AND dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion    AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo    AND dba.acc_modulos_x_perfil.perfil = dba.acc_usuarios.perfil    AND dba.acc_usuarios.usuario = :usuario  ORDER BY dba.acc_modulos.nombre,           dba.acc_operaciones.nombre
    //                ", connection);
    //                command.Parameters.AddWithValue("@usuario", usuario);

    //                using (var reader = command.ExecuteReader())
    //                {
    //                    while (reader.Read())
    //                    {
    //                        lista.Add(new dr_operaciones_por_usuario
    //                        {
    //                            Name = reader["name"]?.ToString(),
    //                            Name = reader["name"]?.ToString(),
    //                            Name = reader["name"]?.ToString(),
    //                            Name = reader["name"]?.ToString(),
    //                            Name = reader["name"]?.ToString(),
    //                            Name = reader["name"]?.ToString(),
    //                            Name = reader["name"]?.ToString(),
    //                            Name = reader["name"]?.ToString(),
    //                            Name = reader["name"]?.ToString(),
    //                            Name = reader["name"]?.ToString(),
    //                            Name = reader["name"]?.ToString(),
    //                            Usuario = reader["usuario"]?.ToString(),
    //                            Operacion = reader["operacion"]?.ToString(),
    //                            Nombre = reader["nombre"]?.ToString(),
    //                            Bitmap = reader["bitmap"]?.ToString()
    //                        });
    //                    }
    //                }
    //            }

    //            return lista;
    //        }
}
 
