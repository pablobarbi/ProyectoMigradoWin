using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: dl_pacientes.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dl_pacientes
    {
        // Consulta original detectada desde el SRD
        public const string Sql = @"SELECT pacientes.paciente,     
                                                   pacientes.nombre,    
                                                   pacientes.domicilio, 
                                                   pacientes.telefono,      
                                                   pacientes.sexo,        
                                                   pacientes.fecha_nacimiento,  
                                                   pacientes.ultima_visita,    
                                                   pacientes.ocupacion,       
                                                   pacientes.estado_civil,     
                                                   pacientes.cantidad_hijos   
                                           FROM pacientes  
                                           WHERE (pacientes.paciente = ?) OR 
                                                    (? = '')";

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