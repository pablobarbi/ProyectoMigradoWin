using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: dk_subrubricas_de_la_subrubrica.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dk_subrubricas_de_la_subrubrica
    {
        // Consulta original detectada desde el SRD
        public const string Sql = @"SELECT subrubricaciones.subrubrica_padre,       
                                                   subrubricaciones.subrubrica_hija,
                                                   subrubricas.nombre, 
                                                   subrubricaciones.posicion, 
                                                   CASE WHEN substr(subrubricas.nombre,1,11)='-EN GENERAL' THEN 'A A' || subrubricas.nombre 
                                                        WHEN substr(subrubricas.nombre,1,1)='-' THEN 'A B' || subrubricas.nombre 
                                                        WHEN substr(subrubricas.nombre,1,1)='_' THEN 'A C' || subrubricas.nombre 
                                                        WHEN substr(subrubricas.nombre,1,1) between '0' and '9' and substr(subrubricas.nombre,2,1) ='-' 
                                                        THEN 'A D' || '0' || subrubricas.nombre WHEN substr(subrubricas.nombre,1,1) between '0' and '9' 
                                                        THEN 'A D' || subrubricas.nombre WHEN substr(subrubricas.nombre,1,1) ='#' THEN 'ZZC' || 
                                                                subrubricas.nombre WHEN substr(subrubricas.nombre,1,1)='*' 
                                                        THEN 'ZZD' || subrubricas.nombre ELSE subrubricas.nombre END as subrubricas_nombre_orden   
                                           FROM subrubricaciones,subrubricas  
                                           WHERE subrubricaciones.subrubrica_hija = subrubricas.subrubrica    AND 
                                                 subrubricaciones.subrubrica_padre = ? 
                                           ORDER BY 5";

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