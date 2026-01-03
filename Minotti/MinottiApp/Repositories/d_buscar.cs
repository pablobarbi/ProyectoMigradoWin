using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class d_buscar
    {
        public string campo { get; set; }




        public static List<d_buscar> GetAll()
        {
            const string sql = @"SELECT * FROM dba.<tu_tabla_de_busqueda>";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new d_buscar
                {
                    campo = reader["campo"]?.ToString() ?? string.Empty
                },
                cmd =>
                {
                    // sin parámetros
                }
            );

            return lista;
        }




        //public static List<d_buscar> GetAll()
        //{
        //    var lista = new List<d_buscar>();
        //    string connectionString = "DSN=tu_dsn_aqui";

        //    using (var connection = new OdbcConnection(connectionString))
        //    {
        //        connection.Open();
        //        var command = new OdbcCommand(@"SELECT * FROM dba.<tu_tabla_de_busqueda>", connection);

        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                lista.Add(new d_buscar
        //                {
        //                    campo = reader["campo"]?.ToString()
        //                });
        //            }
        //        }
        //    }

        //    return lista;
        //}
    }
}
