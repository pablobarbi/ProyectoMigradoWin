using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: dl_pacientes_diagnosticos_tipo_fecha.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dl_pacientes_diagnosticos_tipo_fecha
    {
        // Consulta original detectada desde el SRD
        public const string Sql = @"SELECT  diagnosticos.paciente,    
                                                    diagnosticos.diagnostico,     
                                                    diagnosticos.fecha_visita,   
                                                    diagnosticos.curado   
                                           FROM diagnosticos  
                                           WHERE (   (:tipo_diagnostico = 'N') AND 
                                                    (diagnosticos.diag_nosologico like ?)  OR 
                                                    (:tipo_diagnostico = 'M') AND
                                                    (diagnosticos.diag_medicamentoso like ?)         OR
                                                    (:tipo_diagnostico = 'I') AND 
                                                    (diagnosticos.diag_miasmatico like ?)         OR 
                                                    (:tipo_diagnostico = 'O') AND 
                                                    (diagnosticos.diag_otro like ?) )    AND 
                                                    diagnosticos.fecha_visita  >= YMD(SUBSTR(?, 7, 4), SUBSTR(?, 4, 2), SUBSTR(?, 1, 2))    AND 
                                                    diagnosticos.fecha_visita  <= YMD(SUBSTR(?, 7, 4), SUBSTR(?, 4, 2), SUBSTR(?, 1, 2))";

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