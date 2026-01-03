using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: dl_pacientes_historia_clinica.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dl_pacientes_historia_clinica
    {
        // Consulta original detectada desde el SRD
        public const string Sql = @"SELECT  pacientes_historias.paciente,  
                                                    pacientes_historias.hist_clin  
                                           FROM pacientes_historias 
                                           WHERE pacientes_historias.paciente = :paciente";

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