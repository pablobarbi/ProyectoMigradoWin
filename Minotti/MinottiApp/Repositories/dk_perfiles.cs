using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dk_perfiles
    {
        public string Perfil { get; set; }
        public string Nombre { get; set; }
        public string Bitmap { get; set; }


        public static List<dk_perfiles> GetAll()
        {
            const string sql = @"
SELECT dba.acc_perfiles.perfil,
       dba.acc_perfiles.nombre,
       dba.acc_perfiles.bitmap
  FROM dba.acc_perfiles
 ORDER BY dba.acc_perfiles.nombre";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new dk_perfiles
                {
                    Perfil = reader["perfil"]?.ToString() ?? string.Empty,
                    Nombre = reader["nombre"]?.ToString() ?? string.Empty,
                    Bitmap = reader["bitmap"]?.ToString() ?? string.Empty
                },
                cmd =>
                {
                    // sin parámetros
                }
            );

            return lista;
        }


        //        public static List<dk_perfiles> GetAll()
        //        {
        //            var lista = new List<dk_perfiles>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_perfiles.perfil,
        //        dba.acc_perfiles.nombre,
        //        dba.acc_perfiles.bitmap
        //   FROM dba.acc_perfiles   
        //  ORDER BY dba.acc_perfiles.nombre
        //                ", connection);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new dk_perfiles
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
