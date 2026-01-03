using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class d_modulos_por_perfil
    {
        public string Perfil { get; set; }
        public string Modulo { get; set; }


        public static List<d_modulos_por_perfil> GetByPerfil(string perfil)
        {
            const string sql = @"
SELECT dba.acc_modulos_x_perfil.perfil,
       dba.acc_modulos_x_perfil.modulo
  FROM dba.acc_modulos_x_perfil
 WHERE dba.acc_modulos_x_perfil.perfil = ?";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new d_modulos_por_perfil
                {
                    Perfil = reader["perfil"]?.ToString() ?? string.Empty,
                    Modulo = reader["modulo"]?.ToString() ?? string.Empty
                },
                cmd =>
                {
                    // ODBC usa parámetros posicionales (?)
                    var p = cmd.CreateParameter();
                    p.Value = perfil ?? string.Empty;
                    cmd.Parameters.Add(p);
                }
            );

            return lista;
        }
//        public static List<d_modulos_por_perfil> GetByPerfil(string perfil)
//        {
//            var lista = new List<d_modulos_por_perfil>();
//            string connectionString = "DSN=tu_dsn_aqui";

//            using (var connection = new OdbcConnection(connectionString))
//            {
//                connection.Open();
//                var command = new OdbcCommand(@"
//SELECT dba.acc_modulos_x_perfil.perfil,//        dba.acc_modulos_x_perfil.modulo//   FROM dba.acc_modulos_x_perfil//  WHERE dba.acc_modulos_x_perfil.perfil = :perfil
//                ", connection);
//                command.Parameters.AddWithValue("@perfil", perfil);

//                using (var reader = command.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        lista.Add(new d_modulos_por_perfil
//                        {
//                            Perfil = reader["perfil"].ToString(),
//                            Modulo = reader["modulo"].ToString()
//                        });
//                    }
//                }
//            }

//            return lista;
//        }
    }
}
