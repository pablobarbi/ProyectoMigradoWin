using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class d_carpeta
    {
        
        public string Nombre { get; set; }
        public int? Pagina { get; set; }
        public string Titulo { get; set; }
        public string Objeto { get; set; }
        public string Parametros { get; set; }
        public string Bitmap { get; set; }



        // Query del SRD (misma lógica). Solo cambio :carpeta -> ? por ODBC.
        private const string SQL_RETRIEVE =
    @"SELECT dba.acc_carpetas.nombre,
         dba.acc_carpetas.pagina,
         dba.acc_carpetas.titulo,
         dba.acc_carpetas.objeto,
         dba.acc_carpetas.parametros,
         dba.acc_carpetas.bitmap
    FROM dba.acc_carpetas
   WHERE dba.acc_carpetas.nombre = ?
ORDER BY dba.acc_carpetas.pagina ASC";

        public static DataTable Retrieve_DataTable(string carpeta)
        {
            if (SQLCA.Connection == null)
                throw new InvalidOperationException("SQLCA.Connection es null (no inicializada).");

            try
            {
                using var cmd = SQLCA.Connection.CreateCommand();
                cmd.CommandText = SQL_RETRIEVE;

                // ODBC: parámetros posicionales
                cmd.Parameters.Add(new OdbcParameter { OdbcType = OdbcType.Char, Value = carpeta });

                using var da = new OdbcDataAdapter((OdbcCommand)cmd);
                var dt = new DataTable("acc_carpetas");
                da.Fill(dt);

                SQLCA.SqlCode = 0;
                SQLCA.SqlErrText = null;
                return dt;
            }
            catch (Exception ex)
            {
                SQLCA.SqlCode = -1;
                SQLCA.SqlErrText = ex.Message;
                throw;
            }
        }

        public static List<d_carpeta> Retrieve_List(string carpeta)
        {
            if (SQLCA.Connection == null)
                throw new InvalidOperationException("SQLCA.Connection es null (no inicializada).");

            var list = new List<d_carpeta>();

            try
            {
                using var cmd = SQLCA.Connection.CreateCommand();
                cmd.CommandText = SQL_RETRIEVE;
                cmd.Parameters.Add(new OdbcParameter { OdbcType = OdbcType.Char, Value = carpeta });

                using var rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(new d_carpeta
                    {
                        Nombre = rd.IsDBNull(0) ? null : rd.GetString(0),
                        Pagina = rd.IsDBNull(1) ? (int?)null : Convert.ToInt32(rd.GetValue(1)),
                        Titulo = rd.IsDBNull(2) ? null : rd.GetString(2),
                        Objeto = rd.IsDBNull(3) ? null : rd.GetString(3),
                        Parametros = rd.IsDBNull(4) ? null : rd.GetString(4),
                        Bitmap = rd.IsDBNull(5) ? null : rd.GetString(5),
                    });
                }

                SQLCA.SqlCode = 0;
                SQLCA.SqlErrText = null;
                return list;
            }
            catch (Exception ex)
            {
                SQLCA.SqlCode = -1;
                SQLCA.SqlErrText = ex.Message;
                throw;
            }
        }














        //        public List<d_carpeta> GetByNombre(string nombre)
        //        {
        //            const string sql = @"
        //SELECT dba.acc_carpetas.nombre,
        //       dba.acc_carpetas.pagina,
        //       dba.acc_carpetas.titulo,
        //       dba.acc_carpetas.objeto,
        //       dba.acc_carpetas.parametros,
        //       dba.acc_carpetas.bitmap
        //  FROM dba.acc_carpetas
        // WHERE dba.acc_carpetas.nombre = ?
        // ORDER BY dba.acc_carpetas.pagina ASC";

        //            var lista = SQLCA.ExecuteList(
        //                sql,
        //                reader => new d_carpeta
        //                {
        //                    Nombre = reader.IsDBNull(reader.GetOrdinal("nombre"))
        //                        ? string.Empty
        //                        : reader.GetString(reader.GetOrdinal("nombre")),

        //                    Pagina = reader.IsDBNull(reader.GetOrdinal("pagina"))
        //                        ? 0L
        //                        : Convert.ToInt64(reader["pagina"]),

        //                    Titulo = reader.IsDBNull(reader.GetOrdinal("titulo"))
        //                        ? string.Empty
        //                        : reader.GetString(reader.GetOrdinal("titulo")),

        //                    Objeto = reader.IsDBNull(reader.GetOrdinal("objeto"))
        //                        ? string.Empty
        //                        : reader.GetString(reader.GetOrdinal("objeto")),

        //                    Parametros = reader.IsDBNull(reader.GetOrdinal("parametros"))
        //                        ? string.Empty
        //                        : reader.GetString(reader.GetOrdinal("parametros")),

        //                    Bitmap = reader.IsDBNull(reader.GetOrdinal("bitmap"))
        //                        ? string.Empty
        //                        : reader.GetString(reader.GetOrdinal("bitmap"))
        //                },
        //                cmd =>
        //                {
        //                    // ODBC usa parámetros posicionales (?) -> un solo parámetro
        //                    var p = cmd.CreateParameter();
        //                    p.Value = nombre ?? string.Empty;
        //                    cmd.Parameters.Add(p);
        //                }
        //            );

        //            return lista;
        //        }



        //public List<d_carpeta> GetByNombre(string nombre)
        //{
        //    var lista = new List<d_carpeta>();
        //    using (var connection = new OdbcConnection(_connectionString))
        //    {
        //        connection.Open();
        //        var command = new OdbcCommand(@"SELECT dba.acc_carpetas.nombre,
        //                                               dba.acc_carpetas.pagina,
        //                                               dba.acc_carpetas.titulo,
        //                                               dba.acc_carpetas.objeto,
        //                                               dba.acc_carpetas.parametros,
        //                                               dba.acc_carpetas.bitmap
        //                                        FROM dba.acc_carpetas
        //                                        WHERE dba.acc_carpetas.nombre = ?
        //                                        ORDER BY dba.acc_carpetas.pagina ASC", connection);
        //        command.Parameters.AddWithValue("@nombre", nombre);
        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                lista.Add(new d_carpeta
        //                {
        //                    Nombre = reader["nombre"].ToString(),
        //                    Pagina = Convert.ToInt64(reader["pagina"]),
        //                    Titulo = reader["titulo"].ToString(),
        //                    Objeto = reader["objeto"].ToString(),
        //                    Parametros = reader["parametros"].ToString(),
        //                    Bitmap = reader["bitmap"].ToString()
        //                });
        //            }
        //        }
        //    }
        //    return lista;
        //}
    }
}
