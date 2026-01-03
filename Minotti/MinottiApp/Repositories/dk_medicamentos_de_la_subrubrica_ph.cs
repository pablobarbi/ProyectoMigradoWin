using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    // Migrado desde PowerBuilder DataWindow: dk_medicamentos_de_la_subrubrica_ph.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dk_medicamentos_de_la_subrubrica_ph
    {
        // Consulta original detectada desde el SRD
        public const string Sql = @"SELECT subrubricacion_med.medicamento, 
                                           medicamentos.descripcion,
                                           subrubricacion_med.valor,
                                           'S' seleccionado   
                                    FROM subrubricacion_med, medicamentos  
                                    WHERE subrubricacion_med.medicamento = medicamentos.medicamento AND 
                                          subrubricacion_med.subrubrica_padre = :subrubrica_padre AND 
                                          subrubricacion_med.subrubrica_hija  = :subrubrica_hija  
                                   UNION SELECT medicamentos.medicamento,        
                                                medicamentos.descripcion,
                                                ' ' valor,        
                                                'N' seleccionado   
                                        FROM medicamentos  WHERE medicamentos.medicamento NOT IN ( SELECT subrubricacion_med.medicamento FROM subrubricacion_med                                           WHERE subrubricacion_med.subrubrica_padre = :subrubrica_padre AND subrubricacion_med.subrubrica_hija = :subrubrica_hija ) ORDER BY 3 DESC , 1 ASC";


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

        // Carga los datos usando ODBC (SQL Anywhere 9 via DSN).
        //public static DataTable Retrieve(OdbcConnection? externalConnection = null, params OdbcParameter[] parameters)
        //{
        //    bool created = false;
        //    var cn = externalConnection;
        //    if (cn == null)
        //    {
        //        // Se espera Minotti.Config.AppConfig con Dsn/Uid/Pwd (mantener nombres existentes)
        //        cn = new OdbcConnection("DSN=" + Config.AppConfig.SqlAnywhereDsn + ";UID=" + Config.AppConfig.SqlAnywhereUid + ";PWD=" + Config.AppConfig.SqlAnywherePwd);
        //        created = true;
        //    }
        //    using var cmd = cn.CreateCommand();
        //    cmd.CommandText = RetrieveSql;
        //    if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
        //    var dt = new DataTable();
        //    try
        //    {
        //        if (created) cn.Open();
        //        using var da = new OdbcDataAdapter((OdbcCommand)cmd);
        //        da.Fill(dt);
        //    }
        //    finally
        //    {
        //        if (created && cn != null) cn.Dispose();
        //    }
        //    return dt;
        //}
    }
}