using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: dp_capitulo_medicamento_valor.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dp_capitulo_medicamento_valor
    {
        // Consulta original detectada desde el SRD (puede estar vacía si el objeto es sólo de update)
        public const string Sql = @"SELECT  capitulacion_med.capitulo,  
                                                    capitulacion_med.medicamento,      
                                                    capitulacion_med.valor 
                                           FROM capitulacion_med";

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