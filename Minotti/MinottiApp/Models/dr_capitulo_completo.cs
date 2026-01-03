using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: dr_capitulo_completo.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dr_capitulo_completo
    {
        // Consulta original detectada desde el SRD (puede estar vacía si el objeto es sólo de update)
        public const string Sql = @"SELECT cap.capitulo_nombre,  
cap.rubrica_nombre,        
cap.subrubrica_nombre,   
cap.subrubrica01_nombre,    
cap.subrubrica02_nombre,      
cap.subrubrica03_nombre,        
cap.subrubrica04_nombre,        
cap.subrubrica05_nombre,        
cap.subrubrica06_nombre,        
cap.subrubrica07_nombre,       
cap.subrubrica08_nombre,       
cap.subrubrica09_nombre,       
cap.subrubrica10_nombre,       
cm.medicamento,       
cm.valor     
FROM capitulaciones_matriz cap           , capitulacion_med cm   
WHERE cap.capitulo = :capitulo      AND
cap.capitulo = cm.capitulo      AND 
cap.rubrica = cm.rubrica 
UNION  
SELECT cap.capitulo_nombre,          
cap.rubrica_nombre,         
cap.subrubrica_nombre,     
cap.subrubrica01_nombre,   
cap.subrubrica02_nombre,    
cap.subrubrica03_nombre,      
cap.subrubrica04_nombre,      
cap.subrubrica05_nombre,      
cap.subrubrica06_nombre,       
cap.subrubrica07_nombre,      
cap.subrubrica08_nombre,    
cap.subrubrica09_nombre,    
cap.subrubrica10_nombre,    
cm.medicamento,         
cm.valor     
FROM capitulaciones_matriz cap           , rubricacion_med cm   
WHERE cap.capitulo = :capitulo      AND 
cap.rubrica = cm.rubrica      AND 
cap.subrubrica = cm.subrubrica 
UNION   
SELECT cap.capitulo_nombre,       
cap.rubrica_nombre,          
cap.subrubrica_nombre,      
cap.subrubrica01_nombre,  
cap.subrubrica02_nombre,     
cap.subrubrica03_nombre,      
cap.subrubrica04_nombre,    
cap.subrubrica05_nombre,     
cap.subrubrica06_nombre,    
cap.subrubrica07_nombre,     
cap.subrubrica08_nombre,     
cap.subrubrica09_nombre,  
cap.subrubrica10_nombre,    
cm.medicamento,        
cm.valor    
FROM capitulaciones_matriz cap           , subrubricacion_med cm  
WHERE cap.capitulo = :capitulo      AND
cap.subrubrica = cm.subrubrica_padre      AND 
cap.subrubrica01 = cm.subrubrica_hija 
UNION  
SELECT cap.capitulo_nombre,   
cap.rubrica_nombre,       
cap.subrubrica_nombre,  
cap.subrubrica01_nombre,   
cap.subrubrica02_nombre,  
cap.subrubrica03_nombre,    
cap.subrubrica04_nombre,      
cap.subrubrica05_nombre,     
cap.subrubrica06_nombre,      
cap.subrubrica07_nombre,       
cap.subrubrica08_nombre,     
cap.subrubrica09_nombre,    
cap.subrubrica10_nombre,     
cm.medicamento,         
cm.valor     
FROM capitulaciones_matriz cap           , subrubricacion_med cm   
WHERE cap.capitulo = :capitulo      AND
cap.subrubrica01 = cm.subrubrica_padre      AND 
cap.subrubrica02 = cm.subrubrica_hija 
UNION   
SELECT cap.capitulo_nombre,   
cap.rubrica_nombre,   
cap.subrubrica_nombre, 
cap.subrubrica01_nombre,
cap.subrubrica02_nombre,       
cap.subrubrica03_nombre,     
cap.subrubrica04_nombre,    
cap.subrubrica05_nombre,    
cap.subrubrica06_nombre,    
cap.subrubrica07_nombre,    
cap.subrubrica08_nombre,     
cap.subrubrica09_nombre,    
cap.subrubrica10_nombre,   
cm.medicamento,        
cm.valor     
FROM capitulaciones_matriz cap           , subrubricacion_med cm    
WHERE cap.capitulo = :capitulo      AND 
cap.subrubrica02 = cm.subrubrica_padre  
AND cap.subrubrica03 = cm.subrubrica_hija
UNION  
SELECT cap.capitulo_nombre,  
cap.rubrica_nombre,      
cap.subrubrica_nombre, 
cap.subrubrica01_nombre,   
cap.subrubrica02_nombre,  
cap.subrubrica03_nombre,   
cap.subrubrica04_nombre,   
cap.subrubrica05_nombre,    
cap.subrubrica06_nombre,    
cap.subrubrica07_nombre,    
cap.subrubrica08_nombre,    
cap.subrubrica09_nombre,    
cap.subrubrica10_nombre,     
cm.medicamento,       
cm.valor     
FROM capitulaciones_matriz cap           , subrubricacion_med cm   
WHERE cap.capitulo = :capitulo      AND
cap.subrubrica03 = cm.subrubrica_padre      AND
cap.subrubrica04 = cm.subrubrica_hija 
UNION  
SELECT cap.capitulo_nombre,        
cap.rubrica_nombre,      
cap.subrubrica_nombre,   
cap.subrubrica01_nombre,  
cap.subrubrica02_nombre,    
cap.subrubrica03_nombre,     
cap.subrubrica04_nombre,      
cap.subrubrica05_nombre,       
cap.subrubrica06_nombre,   
cap.subrubrica07_nombre,     
cap.subrubrica08_nombre,     
cap.subrubrica09_nombre,     
cap.subrubrica10_nombre,      
cm.medicamento,       
cm.valor    
FROM capitulaciones_matriz cap           , subrubricacion_med cm   
WHERE cap.capitulo = :capitulo      AND
cap.subrubrica04 = cm.subrubrica_padre      AND 
cap.subrubrica05 = cm.subrubrica_hija 
UNION   
SELECT cap.capitulo_nombre,       
cap.rubrica_nombre,        
cap.subrubrica_nombre,   
cap.subrubrica01_nombre,  
cap.subrubrica02_nombre,   
cap.subrubrica03_nombre,   
cap.subrubrica04_nombre,   
cap.subrubrica05_nombre,  
cap.subrubrica06_nombre,   
cap.subrubrica07_nombre,    
cap.subrubrica08_nombre,     
cap.subrubrica09_nombre,   
cap.subrubrica10_nombre,    
cm.medicamento,       
cm.valor    
FROM capitulaciones_matriz cap           , subrubricacion_med cm  
WHERE cap.capitulo = :capitulo      AND
cap.subrubrica05 = cm.subrubrica_padre      AND 
cap.subrubrica06 = cm.subrubrica_hija 
UNION  
SELECT cap.capitulo_nombre,     
cap.rubrica_nombre,    
cap.subrubrica_nombre,       
cap.subrubrica01_nombre,      
cap.subrubrica02_nombre,     
cap.subrubrica03_nombre, 
cap.subrubrica04_nombre,   
cap.subrubrica05_nombre,   
cap.subrubrica06_nombre,    
cap.subrubrica07_nombre,      
cap.subrubrica08_nombre,       
cap.subrubrica09_nombre,     
cap.subrubrica10_nombre,      
cm.medicamento,       
cm.valor     
FROM capitulaciones_matriz cap           , subrubricacion_med cm  
WHERE cap.capitulo = :capitulo      AND
cap.subrubrica06 = cm.subrubrica_padre      AND
cap.subrubrica07 = cm.subrubrica_hija 
UNION  
SELECT cap.capitulo_nombre,    
cap.rubrica_nombre,        
cap.subrubrica_nombre,    
cap.subrubrica01_nombre,      
cap.subrubrica02_nombre, 
cap.subrubrica03_nombre,  
cap.subrubrica04_nombre,    
cap.subrubrica05_nombre,    
cap.subrubrica06_nombre,     
cap.subrubrica07_nombre,     
cap.subrubrica08_nombre,    
cap.subrubrica09_nombre,     
cap.subrubrica10_nombre,     
cm.medicamento,        
cm.valor     
FROM capitulaciones_matriz cap           , subrubricacion_med cm  
WHERE cap.capitulo = :capitulo      AND 
cap.subrubrica07 = cm.subrubrica_padre      AND
cap.subrubrica08 = cm.subrubrica_hija
UNION 
SELECT cap.capitulo_nombre,       
cap.rubrica_nombre,     
cap.subrubrica_nombre,  
cap.subrubrica01_nombre, 
cap.subrubrica02_nombre,    
cap.subrubrica03_nombre,        
cap.subrubrica04_nombre,     
cap.subrubrica05_nombre,    
cap.subrubrica06_nombre,    
cap.subrubrica07_nombre,      
cap.subrubrica08_nombre,   
cap.subrubrica09_nombre,   
cap.subrubrica10_nombre,   
cm.medicamento,        
cm.valor     
FROM capitulaciones_matriz cap           , subrubricacion_med cm   
WHERE cap.capitulo = :capitulo      AND
cap.subrubrica08 = cm.subrubrica_padre      AND
cap.subrubrica09 = cm.subrubrica_hija 
UNION  
SELECT cap.capitulo_nombre,    
cap.rubrica_nombre,        
cap.subrubrica_nombre, 
cap.subrubrica01_nombre,  
cap.subrubrica02_nombre,   
cap.subrubrica03_nombre,    
cap.subrubrica04_nombre,     
cap.subrubrica05_nombre,     
cap.subrubrica06_nombre,    
cap.subrubrica07_nombre,     
cap.subrubrica08_nombre,   
cap.subrubrica09_nombre,    
cap.subrubrica10_nombre,     
cm.medicamento,       
cm.valor    
FROM capitulaciones_matriz cap           , subrubricacion_med cm   
WHERE cap.capitulo = :capitulo      AND 
cap.subrubrica09 = cm.subrubrica_padre      AND
cap.subrubrica10 = cm.subrubrica_hija 
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