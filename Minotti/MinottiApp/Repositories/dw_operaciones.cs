using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dw_operaciones
    {
        public string Operacion { get; set; }
        public string Nombre { get; set; }

        public static List<dw_operaciones> GetAll()
        {
            const string sql = @"
SELECT dba.acc_operaciones.operacion,
       dba.acc_operaciones.nombre
  FROM dba.acc_operaciones
 ORDER BY dba.acc_operaciones.nombre";

            var lista = SQLCA.ExecuteReaderList(
                sql,
                r => new dw_operaciones
                {
                    Operacion = r["operacion"] as string ?? string.Empty,
                    Nombre = r["nombre"] as string ?? string.Empty
                },
                cmd =>
                {
                    // sin parámetros
                });

            return lista;
        }



        //        public static List<dw_operaciones> GetAll()
        //        {
        //            var lista = new List<dw_operaciones>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_operaciones.operacion,
        //        dba.acc_operaciones.nombre
        //   FROM dba.acc_operaciones
        //  ORDER BY dba.acc_operaciones.nombre
        //                ", connection);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new dw_operaciones
        //                        {
        //                            Operacion = reader["operacion"].ToString(),
        //                            Nombre = reader["nombre"].ToString()
        //                        });
        //                    }
        //                }
        //            }

        //            return lista;
        //        }
    }
}
