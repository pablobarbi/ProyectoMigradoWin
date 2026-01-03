using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dk_operaciones_x_modulo
    {
        public string Modulo { get; set; }
        public string Operacion { get; set; }
        public string Submodulo { get; set; }
        public string Alta { get; set; }
        public string Baja { get; set; }
        public string Modificacion { get; set; }



        public static List<dk_operaciones_x_modulo> GetByModulo(string modulo)
        {
            const string sql = @"
SELECT dba.acc_operaciones_x_modulo.modulo,
       dba.acc_operaciones_x_modulo.operacion,
       dba.acc_operaciones_x_modulo.submodulo,
       dba.acc_operaciones_x_modulo.alta,
       dba.acc_operaciones_x_modulo.baja,
       dba.acc_operaciones_x_modulo.modificacion
  FROM dba.acc_operaciones_x_modulo
 WHERE dba.acc_operaciones_x_modulo.modulo = ?";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new dk_operaciones_x_modulo
                {
                    Modulo = reader["modulo"]?.ToString() ?? string.Empty,
                    Operacion = reader["operacion"]?.ToString() ?? string.Empty,
                    Submodulo = reader["submodulo"]?.ToString() ?? string.Empty,
                    Alta = reader["alta"]?.ToString() ?? string.Empty,
                    Baja = reader["baja"]?.ToString() ?? string.Empty,
                    Modificacion = reader["modificacion"]?.ToString() ?? string.Empty
                },
                cmd =>
                {
                    var p = cmd.CreateParameter();
                    p.Value = modulo ?? string.Empty;
                    cmd.Parameters.Add(p);
                }
            );

            return lista;
        }
        //        public static List<dk_operaciones_x_modulo> GetByModulo(string modulo)
        //        {
        //            var lista = new List<dk_operaciones_x_modulo>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_operaciones_x_modulo.modulo,        dba.acc_operaciones_x_modulo.operacion,        dba.acc_operaciones_x_modulo.submodulo,        dba.acc_operaciones_x_modulo.alta,        dba.acc_operaciones_x_modulo.baja,        dba.acc_operaciones_x_modulo.modificacion   FROM dba.acc_operaciones_x_modulo  WHERE dba.acc_operaciones_x_modulo.modulo = :modulo
        //                ", connection);
        //                command.Parameters.AddWithValue("@modulo", modulo);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new dk_operaciones_x_modulo
        //                        {
        //                            Modulo = reader["modulo"]?.ToString(),
        //                            Operacion = reader["operacion"]?.ToString(),
        //                            Submodulo = reader["submodulo"]?.ToString(),
        //                            Alta = reader["alta"]?.ToString(),
        //                            Baja = reader["baja"]?.ToString(),
        //                            Modificacion = reader["modificacion"]?.ToString()
        //                        });
        //                    }
        //                }
        //            }

        //            return lista;
        //        }
    }
}
