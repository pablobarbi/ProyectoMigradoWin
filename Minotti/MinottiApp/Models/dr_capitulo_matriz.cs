using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: dr_capitulo_matriz.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dr_capitulo_matriz
    {
        // Consulta original detectada desde el SRD (puede estar vacía si el objeto es sólo de update)
        public const string Sql = @"SELECT capitulo_nombre,     
rubrica_nombre,    
subrubrica_nombre,   
subrubrica01_nombre,    
subrubrica02_nombre,    
subrubrica03_nombre,   
subrubrica04_nombre,   
subrubrica05_nombre,    
subrubrica06_nombre,    
subrubrica07_nombre,    
subrubrica08_nombre,     
subrubrica09_nombre,    
subrubrica10_nombre     
FROM capitulaciones_matriz  
WHERE UPPER(capitulo_nombre    ) LIKE '%' + UPPER(:filtro) + '%'       OR 
UPPER(rubrica_nombre     ) LIKE '%' + UPPER(:filtro) + '%'       OR 
UPPER(subrubrica_nombre  ) LIKE '%' + UPPER(:filtro) + '%'       OR 
UPPER(subrubrica01_nombre) LIKE '%' + UPPER(:filtro) + '%'       OR
UPPER(subrubrica02_nombre) LIKE '%' + UPPER(:filtro) + '%'       OR 
UPPER(subrubrica03_nombre) LIKE '%' + UPPER(:filtro) + '%'       OR
UPPER(subrubrica04_nombre) LIKE '%' + UPPER(:filtro) + '%'       OR 
UPPER(subrubrica05_nombre) LIKE '%' + UPPER(:filtro) + '%'       OR
UPPER(subrubrica06_nombre) LIKE '%' + UPPER(:filtro) + '%'       OR 
UPPER(subrubrica07_nombre) LIKE '%' + UPPER(:filtro) + '%'       OR 
UPPER(subrubrica08_nombre) LIKE '%' + UPPER(:filtro) + '%'       OR 
UPPER(subrubrica09_nombre) LIKE '%' + UPPER(:filtro) + '%'       OR 
UPPER(subrubrica10_nombre) LIKE '%' + UPPER(:filtro) + '%' 
ORDER BY 1,2,3";

        /// <summary>
        /// Carga los datos usando ODBC (SQL Anywhere 9 via DSN).
        /// Respeta nombres y estructura. Ajustá el DSN en Config.AppConfig.
        /// </summary>
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

        // ====== PowerBuilder UPDATE definition (conservado tal cual) ======
        /*
(No se detectó bloque UPDATE en el SRD)
        */
    }
}