using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class d_operaciones_x_modulo__
    {
        public string Modulo { get; set; }
        public string Operacion { get; set; }
        public string Alta { get; set; }
        public string Baja { get; set; }
        public string Modificacion { get; set; }
        public string Xx_descripcion { get; set; }
        public string Nombre { get; set; }
        public bool Modifica { get; set; }




        public static List<d_operaciones_x_modulo__> GetByModulo(string modulo)
        {
            const string sql = @"
SELECT dba.acc_operaciones_x_modulo.modulo,
       dba.acc_operaciones_x_modulo.operacion,
       dba.acc_operaciones_x_modulo.alta,
       dba.acc_operaciones_x_modulo.baja,
       dba.acc_operaciones_x_modulo.modificacion,
       dba.acc_operaciones.nombre
  FROM dba.acc_operaciones_x_modulo,
       dba.acc_operaciones
 WHERE dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion
   AND dba.acc_operaciones_x_modulo.modulo = ?";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new d_operaciones_x_modulo__
                {
                    Modulo = reader["modulo"]?.ToString() ?? string.Empty,
                    Operacion = reader["operacion"]?.ToString() ?? string.Empty,
                    Alta = reader["alta"]?.ToString() ?? string.Empty,
                    Baja = reader["baja"]?.ToString() ?? string.Empty,
                    Modificacion = reader["modificacion"]?.ToString() ?? string.Empty,
                    Nombre = reader["nombre"]?.ToString() ?? string.Empty,

                    // Estas columnas NO están en el SELECT actual.
                    // Antes tu código iba a tirar excepción al leerlas.
                    Xx_descripcion = reader["xx_descripcion"]?.ToString()
                    //,Modifica = string.Empty  // TODO: idem
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




        //        public static List<d_operaciones_x_modulo__> GetByModulo(string modulo)
        //        {
        //            var lista = new List<d_operaciones_x_modulo__>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_operaciones_x_modulo.modulo,        dba.acc_operaciones_x_modulo.operacion,        dba.acc_operaciones_x_modulo.alta,        dba.acc_operaciones_x_modulo.baja,        dba.acc_operaciones_x_modulo.modificacion,        dba.acc_operaciones.nombre   FROM dba.acc_operaciones_x_modulo,        dba.acc_operaciones  WHERE dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion    AND dba.acc_operaciones_x_modulo.modulo = :modulo
        //                ", connection);
        //                command.Parameters.AddWithValue("@modulo", modulo);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new d_operaciones_x_modulo__
        //                        {
        //                            Modulo = reader["modulo"]?.ToString(),
        //                            Operacion = reader["operacion"]?.ToString(),
        //                            Alta = reader["alta"]?.ToString(),
        //                            Baja = reader["baja"]?.ToString(),
        //                            Modificacion = reader["modificacion"]?.ToString(),
        //                            Xx_descripcion = reader["xx_descripcion"]?.ToString(),
        //                            Nombre = reader["nombre"]?.ToString(),
        //                            Modifica = reader["modifica"]?.ToString()
        //                        });
        //                    }
        //                }
        //            }

        //            return lista;
        //        }
    }
}
