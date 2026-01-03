using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dw_submodulos
    {
        public string Submodulo { get; set; }
        public string Nombre { get; set; }



        public static List<dw_submodulos> GetAll()
        {
            const string sql = @"
SELECT acc_submodulos.submodulo,
       acc_submodulos.nombre
  FROM acc_submodulos";

            var lista = SQLCA.ExecuteReaderList(
                sql,
                r => new dw_submodulos
                {
                    Submodulo = r["submodulo"] as string ?? string.Empty,
                    Nombre = r["nombre"] as string ?? string.Empty
                },
                cmd =>
                {
                    // sin parámetros
                });

            return lista;
        }
        //        public static List<dw_submodulos> GetAll()
        //        {
        //            var lista = new List<dw_submodulos>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT acc_submodulos.submodulo,
        //       acc_submodulos.nombre
        //  FROM acc_submodulos
        //                ", connection);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new dw_submodulos
        //                        {
        //                            Submodulo = reader["submodulo"].ToString(),
        //                            Nombre = reader["nombre"].ToString()
        //                        });
        //                    }
        //                }
        //            }

        //            return lista;
        //        }
    }
}
