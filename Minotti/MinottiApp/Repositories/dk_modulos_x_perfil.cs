using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dk_modulos_x_perfil
    {
        public string Perfil { get; set; }
        public string Modulo { get; set; }
        public string Nombre_modulo { get; set; }
        public string Nombre { get; set; }


        public static List<dk_modulos_x_perfil> GetByPerfil(string perfil)
        {
            const string sql = @"
SELECT dba.acc_modulos_x_perfil.perfil,
       dba.acc_modulos_x_perfil.modulo,
       dba.acc_modulos.nombre nombre_modulo
  FROM dba.acc_modulos_x_perfil,
       dba.acc_modulos
 WHERE dba.acc_modulos_x_perfil.modulo = dba.acc_modulos.modulo
   AND dba.acc_modulos_x_perfil.perfil = ?";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new dk_modulos_x_perfil
                {
                    Perfil = reader["perfil"]?.ToString() ?? string.Empty,
                    Modulo = reader["modulo"]?.ToString() ?? string.Empty,
                    Nombre_modulo = reader["nombre_modulo"]?.ToString() ?? string.Empty,
                    // En el SQL no hay columna "nombre"
                    Nombre = string.Empty // TODO: mapear si agregás columna en el SELECT
                },
                cmd =>
                {
                    var p = cmd.CreateParameter();
                    p.Value = perfil ?? string.Empty;
                    cmd.Parameters.Add(p);
                }
            );

            return lista;
        }


        //        public static List<dk_modulos_x_perfil> GetByPerfil(string perfil)
        //        {
        //            var lista = new List<dk_modulos_x_perfil>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_modulos_x_perfil.perfil,        dba.acc_modulos_x_perfil.modulo,        dba.acc_modulos.nombre nombre_modulo   FROM dba.acc_modulos_x_perfil,        dba.acc_modulos  WHERE dba.acc_modulos_x_perfil.modulo = dba.acc_modulos.modulo    AND dba.acc_modulos_x_perfil.perfil = :perfil
        //                ", connection);
        //                command.Parameters.AddWithValue("@perfil", perfil);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new dk_modulos_x_perfil
        //                        {
        //                            Perfil = reader["perfil"]?.ToString(),
        //                            Modulo = reader["modulo"]?.ToString(),
        //                            Nombre_modulo = reader["nombre_modulo"]?.ToString(),
        //                            Nombre = reader["nombre"]?.ToString()
        //                        });
        //                    }
        //                }
        //            }

        //            return lista;
        //        }
    }
}
