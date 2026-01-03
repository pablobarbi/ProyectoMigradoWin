using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dl_operaciones_por_perfil
    {
        public string perfil { get; set; } = string.Empty;
        public string nombre_perfil { get; set; } = string.Empty;

        public string modulo { get; set; } = string.Empty;
        public string nombre_modulo { get; set; } = string.Empty;
        public string bitmap_modulo { get; set; } = string.Empty;

        public string operacion { get; set; } = string.Empty;
        public string nombre_operacion { get; set; } = string.Empty;
        public string bitmap_operacion { get; set; } = string.Empty;

        public string alta { get; set; } = string.Empty;
        public string baja { get; set; } = string.Empty;
        public string modificacion { get; set; } = string.Empty;




        public static List<dl_operaciones_por_perfil> GetByPerfil(string perfil)
        {
            const string sql = @"
SELECT dba.acc_perfiles.perfil,
       dba.acc_perfiles.nombre            nombre_perfil,
       dba.acc_operaciones_x_modulo.modulo,
       dba.acc_modulos.nombre             nombre_modulo,
       dba.acc_modulos.bitmap             bitmap_modulo,
       dba.acc_operaciones_x_modulo.operacion,
       dba.acc_operaciones.nombre         nombre_operacion,
       dba.acc_operaciones.bitmap         bitmap_operacion,
       upper(dba.acc_operaciones_x_modulo.alta)         alta,
       upper(dba.acc_operaciones_x_modulo.baja)         baja,
       upper(dba.acc_operaciones_x_modulo.modificacion) modificacion
  FROM dba.acc_modulos,
       dba.acc_operaciones,
       dba.acc_operaciones_x_modulo,
       dba.acc_modulos_x_perfil,
       dba.acc_perfiles
 WHERE dba.acc_modulos.modulo = dba.acc_operaciones_x_modulo.modulo
   AND dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion
   AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
   AND dba.acc_modulos_x_perfil.perfil = dba.acc_perfiles.perfil
   AND (dba.acc_modulos_x_perfil.perfil = ? OR ? IS NULL)
 ORDER BY dba.acc_perfiles.nombre,
          dba.acc_modulos.nombre,
          dba.acc_operaciones.nombre";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new dl_operaciones_por_perfil
                {
                    perfil = reader["perfil"]?.ToString() ?? string.Empty,
                    nombre_perfil = reader["nombre_perfil"]?.ToString() ?? string.Empty,
                    modulo = reader["modulo"]?.ToString() ?? string.Empty,
                    nombre_modulo = reader["nombre_modulo"]?.ToString() ?? string.Empty,
                    bitmap_modulo = reader["bitmap_modulo"]?.ToString() ?? string.Empty,
                    operacion = reader["operacion"]?.ToString() ?? string.Empty,
                    nombre_operacion = reader["nombre_operacion"]?.ToString() ?? string.Empty,
                    bitmap_operacion = reader["bitmap_operacion"]?.ToString() ?? string.Empty,
                    alta = reader["alta"]?.ToString() ?? string.Empty,
                    baja = reader["baja"]?.ToString() ?? string.Empty,
                    modificacion = reader["modificacion"]?.ToString() ?? string.Empty
                },
                cmd =>
                {
                    // primer ?
                    var p1 = cmd.CreateParameter();
                    p1.Value = (object?)perfil ?? DBNull.Value;
                    cmd.Parameters.Add(p1);

                    // segundo ?  (para la condición ? IS NULL)
                    var p2 = cmd.CreateParameter();
                    p2.Value = (object?)perfil ?? DBNull.Value;
                    cmd.Parameters.Add(p2);
                }
            );

            return lista;
        }



        //        public static List<dl_operaciones_por_perfil> GetByPerfil(string perfil)
        //        {
        //            var lista = new List<dl_operaciones_por_perfil>();
        //            string connectionString = "DSN=tu_dsn_aqui";

        //            using (var connection = new OdbcConnection(connectionString))
        //            {
        //                connection.Open();
        //                var command = new OdbcCommand(@"
        //SELECT dba.acc_perfiles.perfil,   
        //dba.acc_perfiles.nombre nombre_perfil,  
        //dba.acc_operaciones_x_modulo.modulo,    
        //dba.acc_modulos.nombre,    
        //dba.acc_modulos.bitmap,      
        //dba.acc_operaciones_x_modulo.operacion,  
        //dba.acc_operaciones.nombre,      
        //dba.acc_operaciones.bitmap,      
        //upper(dba.acc_operaciones_x_modulo.alta) alta,    
        //upper(dba.acc_operaciones_x_modulo.baja) baja,   
        //upper(dba.acc_operaciones_x_modulo.modificacion) modificacion 
        //FROM dba.acc_modulos, 
        //dba.acc_operaciones,    
        //dba.acc_operaciones_x_modulo, 
        //dba.acc_modulos_x_perfil,      
        //dba.acc_perfiles 

        //WHERE dba.acc_modulos.modulo = dba.acc_operaciones_x_modulo.modulo    AND 
        //dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion    AND 
        //dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo    AND 
        //dba.acc_modulos_x_perfil.perfil = dba.acc_perfiles.perfil    AND (dba.acc_modulos_x_perfil.perfil = :perfil or :perfil is Null)  ORDER BY dba.acc_perfiles.nombre,           dba.acc_modulos.nombre,           dba.acc_operaciones.nombre
        //                ", connection);
        //                command.Parameters.AddWithValue("@perfil", perfil);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        lista.Add(new dl_operaciones_por_perfil
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
        //                            Name = reader["name"]?.ToString(),
        //                            Name = reader["name"]?.ToString(),
        //                            Perfil = reader["perfil"]?.ToString(),
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
