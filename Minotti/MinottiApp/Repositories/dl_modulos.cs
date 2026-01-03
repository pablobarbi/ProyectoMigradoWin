using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dl_modulos
    {
        public string Modulo { get; set; }
        public string Nombre { get; set; }
        public string Bitmap { get; set; }


        public static List<dl_modulos> GetAll()
        {
            const string sql = @"
SELECT dba.acc_modulos.modulo,
       dba.acc_modulos.nombre,
       dba.acc_modulos.bitmap
  FROM dba.acc_modulos
 ORDER BY dba.acc_modulos.nombre";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new dl_modulos
                {
                    Modulo = reader["modulo"]?.ToString() ?? string.Empty,
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

        //        public static List<dl_modulos> GetAll()
        //        {
        //            var lista = new List<dl_modulos>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_modulos.modulo,
        //        dba.acc_modulos.nombre,
        //        dba.acc_modulos.bitmap
        //   FROM dba.acc_modulos
        //  ORDER BY dba.acc_modulos.nombre
        //                ", connection);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new dl_modulos
        //                        {
        //                            Modulo = reader["modulo"].ToString(),
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
