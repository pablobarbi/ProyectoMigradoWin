using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: duo_capitulaciones.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class duo_capitulaciones
    {
        // Consulta original detectada desde el SRD
        public const string Sql = @"SELECT capitulaciones.capitulo,        capitulaciones.rubrica,        capitulos.nombre,        rubricas.nombre   FROM capitulaciones,        rubricas,        capitulos  WHERE capitulaciones.rubrica = rubricas.rubrica    AND capitulaciones.capitulo = capitulos.capitulo    AND ((capitulaciones.capitulo = :capitulo) OR (:capitulo = 0))";

        // Carga los datos usando ODBC (SQL Anywhere 9 via DSN).
        public static DataTable RetrieveToDataTable(params object[] parametros)
        {
            return SQLCA.ExecuteDataTable(Sql, cmd =>
            {
                foreach (var p in parametros)
                {
                    var prm = cmd.CreateParameter();
                    prm.Value = p ?? DBNull.Value;
                    cmd.Parameters.Add(prm);
                }
            });
        }
    }
}