using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class d_campos_invisibles
    {
        public string campo { get; set; }




        public static List<d_campos_invisibles> GetAll()
        {
            const string sql = @"
SELECT dba.par_campoinvisible.campo
  FROM dba.par_campoinvisible";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new d_campos_invisibles
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




        //public static List<d_campos_invisibles> GetAll()
        //{
        //    var lista = new List<d_campos_invisibles>();
        //    string connectionString = "DSN=tu_dsn_aqui";

        //    using (var connection = new OdbcConnection(connectionString))
        //    {
        //        connection.Open();
        //        var command = new OdbcCommand(@"SELECT dba.par_campoinvisible.campo FROM dba.par_campoinvisible", connection);

        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                lista.Add(new d_campos_invisibles
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
