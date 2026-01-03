using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dr_operaciones
    {
        public string Operacion { get; set; }
        public string Nombre { get; set; }
        public string Bitmap { get; set; }


        public static List<dr_operaciones> GetAll()
        {
            const string sql = @"
SELECT dba.acc_operaciones.operacion,
       dba.acc_operaciones.nombre,
       dba.acc_operaciones.bitmap
  FROM dba.acc_operaciones
 ORDER BY dba.acc_operaciones.nombre";

            var lista = SQLCA.ExecuteList(
                sql,
                r => new dr_operaciones
                {
                    Operacion = r["operacion"]?.ToString() ?? string.Empty,
                    Nombre = r["nombre"]?.ToString() ?? string.Empty,
                    Bitmap = r["bitmap"]?.ToString() ?? string.Empty
                },
                cmd =>
                {
                    // sin parámetros
                });

            return lista;
        }

        
        
        //        public static List<dr_operaciones> GetAll()
        //        {
        //            var lista = new List<dr_operaciones>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_operaciones.operacion,
        //        dba.acc_operaciones.nombre,
        //        dba.acc_operaciones.bitmap
        //   FROM dba.acc_operaciones
        //  ORDER BY dba.acc_operaciones.nombre
        //                ", connection);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new dr_operaciones
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
