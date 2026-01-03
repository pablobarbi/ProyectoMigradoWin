using System.Collections.Generic;
using Minotti.Data;

namespace Minotti.Repositories
{
    public class d_modulo
    {
        private readonly string _connectionString = "DSN=tu_dsn_aqui";
        public string ModuloId { get; set; }
        public string Nombre { get; set; }
        public string Bitmap { get; set; }


        public List<d_modulo> GetById(string modulo)
        {
            const string sql = @"
SELECT dba.acc_modulos.modulo,
       dba.acc_modulos.nombre,
       dba.acc_modulos.bitmap
  FROM dba.acc_modulos
 WHERE dba.acc_modulos.modulo = ?";

            var lista = SQLCA.ExecuteList(
                sql,
                reader => new d_modulo
                {
                    ModuloId = reader["modulo"]?.ToString() ?? string.Empty,
                    Nombre = reader["nombre"]?.ToString() ?? string.Empty,
                    Bitmap = reader["bitmap"]?.ToString() ?? string.Empty
                },
                cmd =>
                {
                    // ODBC usa parámetros posicionales (?)
                    var p = cmd.CreateParameter();
                    p.Value = modulo ?? string.Empty;
                    cmd.Parameters.Add(p);
                }
            );

            return lista;
        }



        //public List<d_modulo> GetById(string modulo)
        //{
        //    var lista = new List<d_modulo>();
        //    using (var connection = new OdbcConnection(_connectionString))
        //    {
        //        connection.Open();
        //        var command = new OdbcCommand(@"SELECT dba.acc_modulos.modulo,
        //                                               dba.acc_modulos.nombre,
        //                                               dba.acc_modulos.bitmap
        //                                        FROM dba.acc_modulos
        //                                        WHERE dba.acc_modulos.modulo = ?", connection);
        //        command.Parameters.AddWithValue("@modulo", modulo);
        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                lista.Add(new d_modulo
        //                {
        //                    ModuloId = reader["modulo"].ToString(),
        //                    Nombre = reader["nombre"].ToString(),
        //                    Bitmap = reader["bitmap"].ToString()
        //                });
        //            }
        //        }
        //    }
        //    return lista;
        //}
    }
}
