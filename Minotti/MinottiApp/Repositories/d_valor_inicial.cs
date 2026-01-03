using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class d_valor_inicial
    {
        public string campo { get; set; }
        public string valor_inicial { get; set; }


        public static List<d_valor_inicial> GetAll()
        {
            const string sql = @"
SELECT dba.par_valor_inicial.campo,
       dba.par_valor_inicial.valor_inicial
  FROM dba.par_valor_inicial";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new d_valor_inicial
                {
                    campo = reader["campo"]?.ToString() ?? string.Empty,
                    valor_inicial = reader["valor_inicial"]?.ToString() ?? string.Empty
                },
                cmd =>
                {
                    // sin parámetros
                }
            );

            return lista;
        }


        //        public static List<d_valor_inicial> GetAll()
        //        {
        //            var lista = new List<d_valor_inicial>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.par_valor_inicial.campo, dba.par_valor_inicial.valor_inicial FROM dba.par_valor_inicial
        //                ", connection);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new d_valor_inicial
        //                        {
        //                            campo = reader["campo"]?.ToString(),
        //                            valor_inicial = reader["valor_inicial"]?.ToString()
        //                        });
        //                    }
        //                }
        //            }

        //            return lista;
        //        }
    }
}
