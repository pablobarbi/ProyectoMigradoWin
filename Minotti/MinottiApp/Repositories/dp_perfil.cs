using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dp_perfil
    {
        public string Perfil { get; set; }


        public static List<dp_perfil> GetAll()
        {
            const string sql = @"SELECT perfil FROM dba.acc_perfiles ORDER BY perfil";

            var lista = SQLCA.ExecuteList(
                sql,
                r => new dp_perfil
                {
                    Perfil = r["perfil"]?.ToString() ?? string.Empty
                },
                cmd =>
                {
                    // sin parámetros
                });

            return lista;
        }
        //public static List<dp_perfil> GetAll()
        //{
        //    var lista = new List<dp_perfil>();
        //    string connectionString = "DSN=tu_dsn_aqui";

        //    using (var connection = new OdbcConnection(connectionString))
        //    {
        //        connection.Open();
        //        var command = new OdbcCommand(@"SELECT perfil FROM dba.acc_perfiles ORDER BY perfil", connection);

        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                lista.Add(new dp_perfil
        //                {
        //                    Perfil = reader["perfil"].ToString()
        //                });
        //            }
        //        }
        //    }

        //    return lista;
        //}
    }
}
