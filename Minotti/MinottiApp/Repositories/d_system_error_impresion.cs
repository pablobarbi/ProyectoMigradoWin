using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class d_system_error_impresion
    {
        public string nro_error { get; set; }
        public string fecha_hora { get; set; }
        public string lugar { get; set; }
        public string evento { get; set; }
        public string objeto { get; set; }
        public string linea_script { get; set; }
        public string mensaje_error { get; set; }


        public static List<d_system_error_impresion> GetAll()
        {
            const string sql = @"
SELECT dba.errores_sistema.nro_error,
       dba.errores_sistema.fecha_hora,
       dba.errores_sistema.lugar,
       dba.errores_sistema.evento,
       dba.errores_sistema.objeto,
       dba.errores_sistema.linea_script,
       dba.errores_sistema.mensaje_error
  FROM dba.errores_sistema";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new d_system_error_impresion
                {
                    nro_error = reader["nro_error"]?.ToString() ?? string.Empty,
                    fecha_hora = reader["fecha_hora"]?.ToString() ?? string.Empty,
                    lugar = reader["lugar"]?.ToString() ?? string.Empty,
                    evento = reader["evento"]?.ToString() ?? string.Empty,
                    objeto = reader["objeto"]?.ToString() ?? string.Empty,
                    linea_script = reader["linea_script"]?.ToString() ?? string.Empty,
                    mensaje_error = reader["mensaje_error"]?.ToString() ?? string.Empty
                },
                cmd =>
                {
                    // sin parámetros
                }
            );

            return lista;
        }



        //        public static List<d_system_error_impresion> GetAll()
        //        {
        //            var lista = new List<d_system_error_impresion>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.errores_sistema.nro_error, dba.errores_sistema.fecha_hora, dba.errores_sistema.lugar, dba.errores_sistema.evento, dba.errores_sistema.objeto, dba.errores_sistema.linea_script, dba.errores_sistema.mensaje_error FROM dba.errores_sistema
        //                ", connection);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new d_system_error_impresion
        //                        {
        //                            nro_error = reader["nro_error"]?.ToString(),
        //                            fecha_hora = reader["fecha_hora"]?.ToString(),
        //                            lugar = reader["lugar"]?.ToString(),
        //                            evento = reader["evento"]?.ToString(),
        //                            objeto = reader["objeto"]?.ToString(),
        //                            linea_script = reader["linea_script"]?.ToString(),
        //                            mensaje_error = reader["mensaje_error"]?.ToString()
        //                        });
        //                    }
        //                }
        //            }

        //            return lista;
        //        }
    }
}
