using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: duo_subrubricaciones.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class duo_subrubricaciones
    {
        // Consulta original detectada desde el SRD
        public const string Sql = @"SELECT subrubricaciones.subrubrica_padre,        subrubricaciones.subrubrica_hija,        subrubricaciones.posicion,        subrubricas.nombre   FROM subrubricaciones,        subrubricas  WHERE subrubricaciones.subrubrica_hija = subrubricas.subrubrica    AND subrubricaciones.subrubrica_padre = :subrubrica  ORDER by subrubricaciones.posicion";

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