using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dl_operaciones_por_modulo
    {
        public string Modulo { get; set; }
        public string Nombre_modulo { get; set; }
        public string Bitmap_modulo { get; set; }
        public string Operacion { get; set; }
        public string Nombre_operacion { get; set; }
        public string Bitmap_operacion { get; set; }
        public string Alta { get; set; }
        public string Baja { get; set; }
        public string Modificacion { get; set; }
        public string Nombre { get; set; }
        public string Bitmap { get; set; }


        public static List<dl_operaciones_por_modulo> GetAll()
        {
            const string sql = @"
SELECT  dba.acc_operaciones_x_modulo.modulo,
        dba.acc_modulos.nombre             AS nombre_modulo,
        dba.acc_modulos.bitmap             AS bitmap_modulo,
        dba.acc_operaciones_x_modulo.operacion,
        dba.acc_operaciones.nombre         AS nombre_operacion,
        dba.acc_operaciones.bitmap         AS bitmap_operacion,
        UPPER(dba.acc_operaciones_x_modulo.alta)         AS alta,
        UPPER(dba.acc_operaciones_x_modulo.baja)         AS baja,
        UPPER(dba.acc_operaciones_x_modulo.modificacion) AS modificacion,
        dba.acc_modulos.nombre             AS nombre,
        dba.acc_modulos.bitmap             AS bitmap
  FROM   dba.acc_modulos,
         dba.acc_operaciones,
         dba.acc_operaciones_x_modulo
 WHERE  dba.acc_modulos.modulo = dba.acc_operaciones_x_modulo.modulo
   AND  dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion
 ORDER BY dba.acc_modulos.nombre,
          dba.acc_operaciones.nombre";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new dl_operaciones_por_modulo
                {
                    Modulo = reader["modulo"]?.ToString() ?? string.Empty,
                    Nombre_modulo = reader["nombre_modulo"]?.ToString() ?? string.Empty,
                    Bitmap_modulo = reader["bitmap_modulo"]?.ToString() ?? string.Empty,
                    Operacion = reader["operacion"]?.ToString() ?? string.Empty,
                    Nombre_operacion = reader["nombre_operacion"]?.ToString() ?? string.Empty,
                    Bitmap_operacion = reader["bitmap_operacion"]?.ToString() ?? string.Empty,
                    Alta = reader["alta"]?.ToString() ?? string.Empty,
                    Baja = reader["baja"]?.ToString() ?? string.Empty,
                    Modificacion = reader["modificacion"]?.ToString() ?? string.Empty,
                    Nombre = reader["nombre"]?.ToString() ?? string.Empty,
                    Bitmap = reader["bitmap"]?.ToString() ?? string.Empty
                },
                cmd =>
                {
                    // sin parámetros
                }
            );

            return lista;
        }

        
        
        
        
        //        public static List<dl_operaciones_por_modulo> GetAll()
        //        {
        //            var lista = new List<dl_operaciones_por_modulo>();
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
        //                        lista.Add(new dl_operaciones_por_modulo
        //                        {
        //                            Modulo = reader["modulo"]?.ToString(),
        //                            Nombre_modulo = reader["nombre_modulo"]?.ToString(),
        //                            Bitmap_modulo = reader["bitmap_modulo"]?.ToString(),
        //                            Operacion = reader["operacion"]?.ToString(),
        //                            Nombre_operacion = reader["nombre_operacion"]?.ToString(),
        //                            Bitmap_operacion = reader["bitmap_operacion"]?.ToString(),
        //                            Alta = reader["alta"]?.ToString(),
        //                            Baja = reader["baja"]?.ToString(),
        //                            Modificacion = reader["modificacion"]?.ToString(),
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
