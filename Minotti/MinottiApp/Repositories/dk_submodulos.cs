using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dk_submodulos
    {
        public string Submodulo { get; set; }
        public string Nombre { get; set; }
        public string Bitmap { get; set; }

        public static List<dk_submodulos> GetAll()
        {
            const string sql = @"
SELECT dba.acc_submodulos.submodulo,
       dba.acc_submodulos.nombre,
       dba.acc_submodulos.bitmap
  FROM dba.acc_submodulos
 ORDER BY dba.acc_submodulos.nombre";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new dk_submodulos
                {
                    Submodulo = reader["submodulo"]?.ToString() ?? string.Empty,
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

        
        
        //        public static List<dk_submodulos> GetAll()
        //        {
        //            var lista = new List<dk_submodulos>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_submodulos.submodulo,
        //       dba.acc_submodulos.nombre,
        //       dba.acc_submodulos.bitmap
        //  FROM dba.acc_submodulos
        // ORDER BY dba.acc_submodulos.nombre

        //                ", connection);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new dk_submodulos
        //                        {
        //                            Submodulo = reader["submodulo"].ToString(),
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
