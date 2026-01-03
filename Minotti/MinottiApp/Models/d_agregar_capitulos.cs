
using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti.Models
{
    public class d_agregar_capitulos
    {
        const string sql = "SELECT nombre FROM capitulos WHERE capitulo = ?";

        public static string? dagregar_capitulos(int ai_capitulo)
        {

            string? nombre = SQLCA.ExecuteScalar<string>(sql, cmd =>
            {
                cmd.Parameters.Add(new OdbcParameter { Value = ai_capitulo });
            });

            return nombre;
        }
    }
}
