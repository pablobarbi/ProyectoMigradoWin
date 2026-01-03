using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: dr_pacientes_diagnostico.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dr_pacientes_diagnostico
    {
        // Consulta original detectada desde el SRD (puede estar vacía si el objeto es sólo de update)
        public const string Sql = @"SELECT diagnosticos.paciente,        diagnosticos.diagnostico,        diagnosticos.fecha_visita,        diagnosticos.diag_nosologico,        diagnosticos.diag_medicamentoso,        diagnosticos.diag_miasmatico,        diagnosticos.diag_otro,        diagnosticos.repertorizacion,        diagnosticos.primera,        diagnosticos.curado   FROM diagnosticos  WHERE diagnosticos.paciente = :paciente";

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
diagnosticos
        */
    }
}