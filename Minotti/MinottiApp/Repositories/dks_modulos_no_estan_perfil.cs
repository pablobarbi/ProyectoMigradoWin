using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dks_modulos_no_estan_perfil
    {
        public string Modulo { get; set; }
        public string Nombre { get; set; }


        public static List<dks_modulos_no_estan_perfil> GetByPerfil(string perf)
        {
            const string sql = @"
SELECT dba.acc_modulos.modulo,
       dba.acc_modulos.nombre
  FROM dba.acc_modulos
 WHERE NOT EXISTS (
           SELECT ''
             FROM dba.acc_modulos_perfil
            WHERE dba.acc_modulos_perfil.perfil = ?
              AND dba.acc_modulos_perfil.modulo = dba.acc_modulos.modulo
       )";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new dks_modulos_no_estan_perfil
                {
                    Modulo = reader["modulo"]?.ToString() ?? string.Empty,
                    Nombre = reader["nombre"]?.ToString() ?? string.Empty
                },
                cmd =>
                {
                    var p = cmd.CreateParameter();
                    p.Value = perf ?? string.Empty;
                    cmd.Parameters.Add(p);
                }
            );

            return lista;
        }




        //        public static List<dks_modulos_no_estan_perfil> GetByPerfil(string perf)
        //        {
        //            var lista = new List<dks_modulos_no_estan_perfil>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_modulos.modulo,   
        //          dba.acc_modulos.nombre  
        //     FROM dba.acc_modulos


        //    WHERE NOT EXISTS (SELECT ''  
        //                      FROM dba.acc_modulos_perfil
        //                      WHERE dba.acc_modulos_perfil.perfil = :perf AND  
        //                      dba.acc_modulos_perfil.modulo = dba.acc_modulos.modulo)
        //                ", connection);
        //                command.Parameters.AddWithValue("@perf", perf);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new dks_modulos_no_estan_perfil
        //                        {
        //                            Modulo = reader["modulo"].ToString(),
        //                            Nombre = reader["nombre"].ToString()
        //                        });
        //                    }
        //                }
        //            }

        //            return lista;
        //        }
    }
}
