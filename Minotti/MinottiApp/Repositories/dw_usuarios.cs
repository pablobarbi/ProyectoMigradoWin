using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dw_usuarios
    {
        public string Usuario { get; set; }
        public string Nombre { get; set; }

        public static List<dw_usuarios> GetAll()
        {
            const string sql = @"
SELECT dba.acc_usuarios.usuario,
       dba.acc_usuarios.nombre
  FROM dba.acc_usuarios
 ORDER BY dba.acc_usuarios.nombre";

            var lista = SQLCA.ExecuteReaderList(
                sql,
                r => new dw_usuarios
                {
                    Usuario = r["usuario"] as string ?? string.Empty,
                    Nombre = r["nombre"] as string ?? string.Empty
                },
                cmd =>
                {
                    // sin parámetros
                });

            return lista;
        }


        //        public static List<dw_usuarios> GetAll()
        //        {
        //            var lista = new List<dw_usuarios>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_usuarios.usuario,
        //        dba.acc_usuarios.nombre
        //   FROM dba.acc_usuarios
        //  ORDER BY dba.acc_usuarios.nombre
        //                ", connection);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new dw_usuarios
        //                        {
        //                            Usuario = reader["usuario"].ToString(),
        //                            Nombre = reader["nombre"].ToString()
        //                        });
        //                    }
        //                }
        //            }

        //            return lista;
        //        }
    }
}
