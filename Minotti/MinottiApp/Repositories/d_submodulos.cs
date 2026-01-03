using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class d_submodulos
    {
        public string Submodulo { get; set; }
        public string Nombre { get; set; }
        public string Bitmap { get; set; }


        public static List<d_submodulos> GetBySubmodulo(string submod)
        {
            const string sql = @"
SELECT dba.acc_submodulos.submodulo,
       dba.acc_submodulos.nombre,
       dba.acc_submodulos.bitmap
  FROM dba.acc_submodulos
 WHERE dba.acc_submodulos.submodulo = ?";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new d_submodulos
                {
                    Submodulo = reader["submodulo"]?.ToString() ?? string.Empty,
                    Nombre = reader["nombre"]?.ToString() ?? string.Empty,
                    Bitmap = reader["bitmap"]?.ToString() ?? string.Empty
                },
                cmd =>
                {
                    // ODBC → parámetro posicional
                    var p = cmd.CreateParameter();
                    p.Value = submod ?? string.Empty;
                    cmd.Parameters.Add(p);
                }
            );

            return lista;
        }





        //        public static List<d_submodulos> GetBySubmodulo(string submod)
        //        {
        //            var lista = new List<d_submodulos>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_submodulos.submodulo,   
        //          dba.acc_submodulos.nombre,   
        //          dba.acc_submodulos.bitmap  
        //     FROM dba.acc_submodulos
        // 	WHERE dba.acc_submodulos.submodulo = :submod
        //                ", connection);
        //                command.Parameters.AddWithValue("@submod", submod);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new d_submodulos
        //                        {
        //                            Submodulo = reader["submodulo"].ToString(),
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
