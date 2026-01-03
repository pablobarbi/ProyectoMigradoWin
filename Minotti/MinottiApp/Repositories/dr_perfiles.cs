using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dr_perfiles
    {
        public string Perfil { get; set; }
        public string Nombre { get; set; }
        public string Bitmap { get; set; }




        public static List<dr_perfiles> GetAll()
        {
            const string sql = @"
SELECT dba.acc_perfiles.perfil,
       dba.acc_perfiles.nombre,
       dba.acc_perfiles.bitmap
  FROM dba.acc_perfiles
 ORDER BY dba.acc_perfiles.nombre";

            var lista = SQLCA.ExecuteReaderList(
                sql,
                r => new dr_perfiles
                {
                    Perfil = r["perfil"] as string ?? string.Empty,
                    Nombre = r["nombre"] as string ?? string.Empty,
                    Bitmap = r["bitmap"] as string ?? string.Empty
                },
                cmd =>
                {
                    // sin parámetros
                });

            return lista;
        }


        //        public static List<dr_perfiles> GetAll()
        //        {
        //            var lista = new List<dr_perfiles>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_perfiles.perfil,
        //        dba.acc_perfiles.nombre,
        //        dba.acc_perfiles.bitmap
        //   FROM dba.acc_perfiles
        //  ORDER BY dba.acc_perfiles.nombre
        //                ", connection);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new dr_perfiles
        //                        {
        //                            Perfil = reader["perfil"].ToString(),
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
