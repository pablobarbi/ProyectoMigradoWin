using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class d_ayuda
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Ayuda { get; set; }

        //        public static List<d_ayuda> GetAll()
        //        {
        //            var lista = new List<d_ayuda>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT ayuda, descripcion FROM dba.acc_ayuda ORDER BY ayuda
        //                ", connection);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new d_ayuda
        //                        {
        //                            Titulo = reader["titulo"]?.ToString(),
        //                            Descripcion = reader["descripcion"]?.ToString(),
        //                            Ayuda = reader["ayuda"]?.ToString()
        //                        });
        //                    }
        //                }
        //            }

        //            return lista;
        //        }


        public static List<d_ayuda> GetAll()
        {
            const string sql = @"
SELECT ayuda,
       titulo,
       descripcion
  FROM dba.acc_ayuda
 ORDER BY ayuda";

            // Usamos SQLCA.ExecuteList para no manejar conexiones acá
            var lista = SQLCA.ExecuteList(
                sql,
                reader => new d_ayuda
                {
                    Ayuda = reader.IsDBNull(reader.GetOrdinal("ayuda"))
                        ? string.Empty
                        : reader.GetString(reader.GetOrdinal("ayuda")),

                    Titulo = reader.IsDBNull(reader.GetOrdinal("titulo"))
                        ? string.Empty
                        : reader.GetString(reader.GetOrdinal("titulo")),

                    Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion"))
                        ? string.Empty
                        : reader.GetString(reader.GetOrdinal("descripcion"))
                },
                cmd =>
                {
                    // Sin parámetros en este SELECT
                }
            );

            return lista;
        }
    }
}
