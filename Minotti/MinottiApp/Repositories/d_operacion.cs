using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class d_operacion
    {
        public string Operacion { get; set; }
        public string Nombre { get; set; }
        public string Bitmap { get; set; }


        public static List<d_operacion> GetByOperacion(string operacion)
        {
            const string sql = @"
SELECT dba.acc_operaciones.operacion,
       dba.acc_operaciones.nombre,
       dba.acc_operaciones.bitmap
  FROM dba.acc_operaciones
 WHERE dba.acc_operaciones.operacion = ?";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new d_operacion
                {
                    Operacion = reader["operacion"]?.ToString() ?? string.Empty,
                    Nombre = reader["nombre"]?.ToString() ?? string.Empty,
                    Bitmap = reader["bitmap"]?.ToString() ?? string.Empty
                },
                cmd =>
                {
                    var p = cmd.CreateParameter();
                    p.Value = operacion ?? string.Empty;
                    cmd.Parameters.Add(p);
                }
            );

            return lista;
        }
        //        public static List<d_operacion> GetByOperacion(string operacion)
        //        {
        //            var lista = new List<d_operacion>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_operaciones.operacion,
        //        dba.acc_operaciones.nombre,
        //        dba.acc_operaciones.bitmap
        //   FROM dba.acc_operaciones
        //  WHERE dba.acc_operaciones.operacion = :operacion
        //                ", connection);
        //                command.Parameters.AddWithValue("@operacion", operacion);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new d_operacion
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
