using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class d_parametros_x_operacion
    {
        public string Operacion { get; set; }
        public long Orden { get; set; }
        public string Titulo { get; set; }
        public string Objeto { get; set; }
        public string Parametros { get; set; }
        public bool Cierra { get; set; }

        public static List<d_parametros_x_operacion> GetByOperacion(string operacion)
        {
            const string sql = @"
SELECT dba.acc_parametros.operacion,
       dba.acc_parametros.orden,
       dba.acc_parametros.titulo,
       dba.acc_parametros.objeto,
       dba.acc_parametros.parametros,
       dba.acc_parametros.cierra
  FROM dba.acc_parametros
 WHERE dba.acc_parametros.operacion = ?";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new d_parametros_x_operacion
                {
                    Operacion = reader["operacion"]?.ToString() ?? string.Empty,
                    Orden = reader["orden"] == DBNull.Value ? 0L : Convert.ToInt64(reader["orden"]),
                    Titulo = reader["titulo"]?.ToString() ?? string.Empty,
                    Objeto = reader["objeto"]?.ToString() ?? string.Empty,
                    Parametros = reader["parametros"]?.ToString() ?? string.Empty,
                    Cierra = reader["cierra"] != DBNull.Value && Convert.ToBoolean(reader["cierra"])
                },
                cmd =>
                {
                    var p = cmd.CreateParameter();
                    p.Value = operacion ?? string.Empty;
                    cmd.Parameters.Add(p);
                }
            );

            return lista;
        }
        //        public static List<d_parametros_x_operacion> GetByOperacion(string operacion)
        //        {
        //            var lista = new List<d_parametros_x_operacion>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_parametros.operacion,   
        //        dba.acc_parametros.orden,   
        //        dba.acc_parametros.titulo,   
        //        dba.acc_parametros.objeto,   
        //        dba.acc_parametros.parametros,   
        //        dba.acc_parametros.cierra  
        //   FROM dba.acc_parametros  
        //  WHERE dba.acc_parametros.operacion = :operacion
        //                ", connection);
        //                command.Parameters.AddWithValue("@operacion", operacion);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new d_parametros_x_operacion
        //                        {
        //                            Operacion = reader["operacion"].ToString(),
        //                            Orden = Convert.ToInt64(reader["orden"]),
        //                            Titulo = reader["titulo"].ToString(),
        //                            Objeto = reader["objeto"].ToString(),
        //                            Parametros = reader["parametros"].ToString(),
        //                            Cierra = Convert.ToBoolean(reader["cierra"])
        //                        });
        //                    }
        //                }
        //            }

        //            return lista;
        //        }
    }
}
