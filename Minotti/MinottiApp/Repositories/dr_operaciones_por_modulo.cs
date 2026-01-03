using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dr_operaciones_por_modulo
    {
        public string modulo { get; set; } = string.Empty;
        public string nombre_modulo { get; set; } = string.Empty;
        public string bitmap_modulo { get; set; } = string.Empty;
        public string operacion { get; set; } = string.Empty;
        public string nombre_operacion { get; set; } = string.Empty;
        public string bitmap_operacion { get; set; } = string.Empty;
        public string alta { get; set; } = string.Empty;
        public string baja { get; set; } = string.Empty;
        public string modificacion { get; set; } = string.Empty;


        private const string Sql = @"
SELECT dba.acc_operaciones_x_modulo.modulo,
       dba.acc_modulos.nombre       AS nombre_modulo,
       dba.acc_modulos.bitmap       AS bitmap_modulo,
       dba.acc_operaciones_x_modulo.operacion,
       dba.acc_operaciones.nombre   AS nombre_operacion,
       dba.acc_operaciones.bitmap   AS bitmap_operacion,
       upper(dba.acc_operaciones_x_modulo.alta)         AS alta,
       upper(dba.acc_operaciones_x_modulo.baja)         AS baja,
       upper(dba.acc_operaciones_x_modulo.modificacion) AS modificacion
  FROM dba.acc_modulos,
       dba.acc_operaciones,
       dba.acc_operaciones_x_modulo
 WHERE dba.acc_modulos.modulo = dba.acc_operaciones_x_modulo.modulo
   AND dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion
 ORDER BY dba.acc_modulos.nombre";


        public static List<dr_operaciones_por_modulo> Retrieve()
        {
            return SQLCA.ExecuteList(
                Sql,
                r => new dr_operaciones_por_modulo
                {
                    modulo = r["modulo"]?.ToString() ?? string.Empty,
                    nombre_modulo = r["nombre_modulo"]?.ToString() ?? string.Empty,
                    bitmap_modulo = r["bitmap_modulo"]?.ToString() ?? string.Empty,
                    operacion = r["operacion"]?.ToString() ?? string.Empty,
                    nombre_operacion = r["nombre_operacion"]?.ToString() ?? string.Empty,
                    bitmap_operacion = r["bitmap_operacion"]?.ToString() ?? string.Empty,
                    alta = r["alta"]?.ToString() ?? string.Empty,
                    baja = r["baja"]?.ToString() ?? string.Empty,
                    modificacion = r["modificacion"]?.ToString() ?? string.Empty
                },
                cmd =>
                {
                    // sin parámetros
                });
        }


//        public static List<dr_operaciones_por_modulo> GetAll()
//        {
//            var lista = new List<dr_operaciones_por_modulo>();
//            string connectionString = "DSN=tu_dsn_aqui";

//            using (var connection = new OdbcConnection(connectionString))
//            {
//                connection.Open();
//                var command = new OdbcCommand(@"
//SELECT dba.acc_operaciones_x_modulo.modulo,        dba.acc_modulos.nombre,        dba.acc_modulos.bitmap,        dba.acc_operaciones_x_modulo.operacion,        dba.acc_operaciones.nombre,        dba.acc_operaciones.bitmap,        upper(dba.acc_operaciones_x_modulo.alta) alta,        upper(dba.acc_operaciones_x_modulo.baja) baja,        upper(dba.acc_operaciones_x_modulo.modificacion) modificacion   FROM dba.acc_modulos,        dba.acc_operaciones,        dba.acc_operaciones_x_modulo  WHERE dba.acc_modulos.modulo = dba.acc_operaciones_x_modulo.modulo    AND dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion  ORDER BY dba.acc_modulos.nombre,        dba.acc_operaciones.nombre
//                ", connection);


//                using (var reader = command.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        lista.Add(new dr_operaciones_por_modulo
//                        {
//                            Name = reader["name"]?.ToString(),
//                            Name = reader["name"]?.ToString(),
//                            Name = reader["name"]?.ToString(),
//                            Name = reader["name"]?.ToString(),
//                            Name = reader["name"]?.ToString(),
//                            Name = reader["name"]?.ToString(),
//                            Name = reader["name"]?.ToString(),
//                            Name = reader["name"]?.ToString(),
//                            Name = reader["name"]?.ToString(),
//                            Modulo = reader["modulo"]?.ToString(),
//                            Operacion = reader["operacion"]?.ToString(),
//                            Nombre = reader["nombre"]?.ToString(),
//                            Bitmap = reader["bitmap"]?.ToString()
//                        });
//                    }
//                }
//            }

//            return lista;
//        }
    }
}
