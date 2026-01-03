using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class d_modulos_x_perfil2
    {
        public string Perfil { get; set; }
        public string Modulo { get; set; }
        public string Nombre { get; set; }


        public static List<d_modulos_x_perfil2> GetByPerfil(string perf)
        {
            const string sql = @"
SELECT dba.acc_modulos_x_perfil.perfil,
       dba.acc_modulos_x_perfil.modulo,
       dba.acc_modulos.nombre
  FROM dba.acc_modulos_x_perfil,
       dba.acc_modulos
 WHERE dba.acc_modulos.modulo = dba.acc_modulos_x_perfil.modulo
   AND dba.acc_modulos_x_perfil.perfil = ?";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new d_modulos_x_perfil2
                {
                    Perfil = reader["perfil"]?.ToString() ?? string.Empty,
                    Modulo = reader["modulo"]?.ToString() ?? string.Empty,
                    Nombre = reader["nombre"]?.ToString() ?? string.Empty
                },
                cmd =>
                {
                    // ODBC → parámetros posicionales
                    var p = cmd.CreateParameter();
                    p.Value = perf ?? string.Empty;
                    cmd.Parameters.Add(p);
                }
            );

            return lista;
        }


        //        public static List<d_modulos_x_perfil2> GetByPerfil(string perf)
        //        {
        //            var lista = new List<d_modulos_x_perfil2>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_modulos_x_perfil.perfil,
        // 			dba.acc_modulos_x_perfil.modulo,   
        //          dba.acc_modulos.nombre
        //   FROM dba.acc_modulos_x_perfil,   
        //          dba.acc_modulos  
        //    WHERE dba.acc_modulos.modulo = dba.acc_modulos_x_perfil.modulo and  
        //          dba.acc_modulos_x_perfil.perfil = :perf
        //                ", connection);
        //                command.Parameters.AddWithValue("@perf", perf);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new d_modulos_x_perfil2
        //                        {
        //                            Perfil = reader["perfil"].ToString(),
        //                            Modulo = reader["modulo"].ToString(),
        //                            Nombre = reader["nombre"].ToString()
        //                        });
        //                    }
        //                }
        //            }

        //            return lista;
        //        }
    }
}
