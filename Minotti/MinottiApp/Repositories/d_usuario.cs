using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class d_usuario
    {
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string Perfil { get; set; }

        public static List<d_usuario> GetByUsuario(string usuario)
        {
            const string sql = @"
SELECT dba.acc_usuarios.usuario,
       dba.acc_usuarios.nombre,
       dba.acc_usuarios.clave,
       dba.acc_usuarios.perfil
  FROM dba.acc_usuarios
 WHERE dba.acc_usuarios.usuario = ?";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new d_usuario
                {
                    Usuario = reader["usuario"]?.ToString() ?? string.Empty,
                    Nombre = reader["nombre"]?.ToString() ?? string.Empty,
                    Clave = reader["clave"]?.ToString() ?? string.Empty,
                    Perfil = reader["perfil"]?.ToString() ?? string.Empty
                },
                cmd =>
                {
                    var p = cmd.CreateParameter();
                    p.Value = usuario ?? string.Empty;
                    cmd.Parameters.Add(p);
                }
            );

            return lista;
        }



        //        public static List<d_usuario> GetByUsuario(string usuario)
        //        public static List<d_usuario> GetByUsuario(string usuario)
        //        {
        //            var lista = new List<d_usuario>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_usuarios.usuario,
        //        dba.acc_usuarios.nombre,
        //        dba.acc_usuarios.clave,
        //        dba.acc_usuarios.perfil  
        //   FROM dba.acc_usuarios
        //  WHERE dba.acc_usuarios.usuario = :usuario
        //                ", connection);
        //                command.Parameters.AddWithValue("@usuario", usuario);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new d_usuario
        //                        {
        //                            Usuario = reader["usuario"].ToString(),
        //                            Nombre = reader["nombre"].ToString(),
        //                            Clave = reader["clave"].ToString(),
        //                            Perfil = reader["perfil"].ToString()
        //                        });
        //                    }
        //                }
        //            }

        //            return lista;
        //        }
    }
}
