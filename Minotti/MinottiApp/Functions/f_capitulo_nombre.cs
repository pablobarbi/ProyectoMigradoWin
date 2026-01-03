// Archivo generado automáticamente desde f_capitulo_nombre.srf
// NOMBRES y firmas conservados. Lógica original en f_capitulo_nombre.original.pb.txt
using Minotti.Data;
using System;
using System.Data.Odbc;
using System.Windows.Forms;


namespace Minotti.Functions
{
    public static class f_capitulo_nombre
    {
         
        public static string? fcapitulo_nombre(int ai_capitulo)
        {
            const string sql = @"
                                 SELECT nombre
                                 FROM capitulos
                                 WHERE capitulo = ?";

            return SQLCA.ExecuteScalar<string>(sql, cmd =>
            {
                // ODBC: usa ? posicional; el nombre del parámetro no importa
                var p = new OdbcParameter { Value = ai_capitulo };
                cmd.Parameters.Add(p);
            });
        }
    }
}
