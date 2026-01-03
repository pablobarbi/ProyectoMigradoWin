using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dr_usuarios
    {
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string Perfil { get; set; }
        public string NombrePerfil { get; set; }



        public static List<dr_usuarios> GetAll()
        {
            const string sql = @"
SELECT dba.acc_usuarios.usuario,
       dba.acc_usuarios.nombre,
       dba.acc_usuarios.clave,
       dba.acc_usuarios.perfil,
       dba.acc_perfiles.nombre nombre_perfil
  FROM dba.acc_usuarios,
       dba.acc_perfiles
 WHERE dba.acc_usuarios.perfil = dba.acc_perfiles.perfil
 ORDER BY dba.acc_usuarios.nombre";

            var lista = SQLCA.ExecuteReaderList(
                sql,
                r => new dr_usuarios
                {
                    Usuario = r["usuario"] as string ?? string.Empty,
                    Nombre = r["nombre"] as string ?? string.Empty,
                    Clave = r["clave"] as string ?? string.Empty,
                    Perfil = r["perfil"] as string ?? string.Empty,
                    NombrePerfil = r["nombre_perfil"] as string ?? string.Empty
                },
                cmd =>
                {
                    // sin parámetros
                });

            return lista;
        }



        //        public static List<dr_usuarios> GetAll()
        //        {
        //            var lista = new List<dr_usuarios>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_usuarios.usuario,
        //        dba.acc_usuarios.nombre,
        //        dba.acc_usuarios.clave,
        //        dba.acc_usuarios.perfil,
        //        dba.acc_perfiles.nombre nombre_perfil
        //   FROM dba.acc_usuarios,
        //        dba.acc_perfiles
        //  WHERE dba.acc_usuarios.perfil = dba.acc_perfiles.perfil
        //  ORDER BY dba.acc_usuarios.nombre
        //                ", connection);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new dr_usuarios
        //                        {
        //                            Usuario = reader["usuario"].ToString(),
        //                            Nombre = reader["nombre"].ToString(),
        //                            Clave = reader["clave"].ToString(),
        //                            Perfil = reader["perfil"].ToString(),
        //                            NombrePerfil = reader["nombre_perfil"].ToString()
        //                        });
        //                    }
        //                }
        //            }

        //            return lista;
        //        }
    }
}
