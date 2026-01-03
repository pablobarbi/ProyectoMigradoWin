using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dp_usuario
    {
        public string Usuario { get; set; }


        public static List<dp_usuario> GetAll()
        {
            const string sql = @"SELECT usuario FROM dba.acc_usuarios ORDER BY usuario";

            var lista = SQLCA.ExecuteList(
                sql,
                r => new dp_usuario
                {
                    Usuario = r["usuario"]?.ToString() ?? string.Empty
                },
                cmd =>
                {
                    // sin parámetros
                });

            return lista;
        }



        //public static List<dp_usuario> GetAll()
        //{
        //    var lista = new List<dp_usuario>();
        //    string connectionString = "DSN=tu_dsn_aqui";

        //    using (var connection = new OdbcConnection(connectionString))
        //    {
        //        connection.Open();
        //        var command = new OdbcCommand(@"SELECT usuario FROM dba.acc_usuarios ORDER BY usuario", connection);

        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                lista.Add(new dp_usuario
        //                {
        //                    Usuario = reader["usuario"].ToString()
        //                });
        //            }
        //        }
        //    }

        //    return lista;
        //}
    }
}
