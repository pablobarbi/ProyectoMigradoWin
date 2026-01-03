using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class d_perfil
    {
        public string Perfil { get; set; }
        public string Nombre { get; set; }
        public string Bitmap { get; set; }


        public static List<d_perfil> GetByPerfil(string perfil)
        {
            const string sql = @"
SELECT dba.acc_perfiles.perfil,
       dba.acc_perfiles.nombre,
       dba.acc_perfiles.bitmap
  FROM dba.acc_perfiles
 WHERE dba.acc_perfiles.perfil = ?";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new d_perfil
                {
                    Perfil = reader["perfil"]?.ToString() ?? string.Empty,
                    Nombre = reader["nombre"]?.ToString() ?? string.Empty,
                    Bitmap = reader["bitmap"]?.ToString() ?? string.Empty
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

        //        public static List<d_perfil> GetByPerfil(string perfil)
        //        {
        //            var lista = new List<d_perfil>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_perfiles.perfil,
        //        dba.acc_perfiles.nombre,
        //        dba.acc_perfiles.bitmap
        //   FROM dba.acc_perfiles
        //  WHERE dba.acc_perfiles.perfil = :perfil
        //                ", connection);
        //                command.Parameters.AddWithValue("@perfil", perfil);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new d_perfil
        //                        {
        //                            Perfil = reader["perfil"].ToString(),
        //                            Nombre = reader["nombre"].ToString(),
        //                            Bitmap = reader["bitmap"].ToString()
        //                        });
        //                    }
        //                }
        //            }

        //            return lista;
        //        }
    }
}
