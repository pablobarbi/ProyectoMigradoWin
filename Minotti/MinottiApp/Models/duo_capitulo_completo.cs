using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: duo_capitulo_completo.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class duo_capitulo_completo
    {
        // Consulta original detectada desde el SRD
        public const string Sql = @"SELECT capitulacion_med.capitulo,          capitulos.nombre,          rubricas.rubrica,          rubricas.nombre,          subrubricas.subrubrica AS subrubrica01,          subrubricas.nombre  AS subrubrica01_nombre,          subrubricas.subrubrica AS subrubrica02,          subrubricas.nombre  AS subrubrica02_nombre,          subrubricas.subrubrica AS subrubrica03,          subrubricas.nombre  AS subrubrica03_nombre,          subrubricas.subrubrica AS subrubrica04,          subrubricas.nombre  AS subrubrica04_nombre,          subrubricas.subrubrica AS subrubrica05,          subrubricas.nombre  AS subrubrica05_nombre,          subrubricas.subrubrica AS subrubrica06,          subrubricas.nombre  AS subrubrica06_nombre,          subrubricas.subrubrica AS subrubrica07,          subrubricas.nombre  AS subrubrica07_nombre,          subrubricas.subrubrica AS subrubrica08,          subrubricas.nombre  AS subrubrica08_nombre,          subrubricas.subrubrica AS subrubrica09,          subrubricas.nombre  AS subrubrica09_nombre,          subrubricas.subrubrica AS subrubrica10,          subrubricas.nombre  AS subrubrica10_nombre,          capitulacion_med.medicamento,          capitulacion_med.valor     FROM capitulacion_med,          capitulos,          rubricas,          subrubricas    WHERE capitulacion_med.capitulo = capitulos.capitulo      AND capitulacion_med.rubrica = rubricas.rubrica";

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