using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dk_operaciones
    {
        public string Operacion { get; set; }
        public string Nombre { get; set; }
        public string Bitmap { get; set; }



        public static List<dk_operaciones> GetAll()
        {
            const string sql = @"
SELECT dba.acc_operaciones.operacion,
       dba.acc_operaciones.nombre,
       dba.acc_operaciones.bitmap
  FROM dba.acc_operaciones
 ORDER BY dba.acc_operaciones.nombre ASC";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new dk_operaciones
                {
                    Operacion = reader["operacion"]?.ToString() ?? string.Empty,
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


        ////        public static List<dk_operaciones> GetAll()
        //        {
        //            var lista = new List<dk_operaciones>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_operaciones.operacion,
        //        dba.acc_operaciones.nombre,
        //        dba.acc_operaciones.bitmap
        //   FROM dba.acc_operaciones  
        //  ORDER BY dba.acc_operaciones.nombre ASC
        //                ", connection);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new dk_operaciones
        //                        {
        //                            Operacion = reader["operacion"].ToString(),
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
