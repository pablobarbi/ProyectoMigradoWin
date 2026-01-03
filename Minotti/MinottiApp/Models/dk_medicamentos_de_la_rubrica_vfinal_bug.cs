using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    // Migrado desde PowerBuilder DataWindow: dk_medicamentos_de_la_rubrica_vfinal_bug.srd
    // Mantiene el nombre original del objeto DataWindow.
    public class dk_medicamentos_de_la_rubrica_vfinal_bug
    {
        // Consulta original detectada desde el SRD
        public const string Sql = @"SELECT capitulacion_med.medicamento,        
                                                   medicamentos.descripcion,
                                                   capitulacion_med.valor,    
                                                   'S' seleccionado   
                                            FROM capitulacion_med,medicamentos  
                                            WHERE capitulacion_med.medicamento = medicamentos.medicamento AND 
                                                  capitulacion_med.capitulo = ?    AND 
                                                  capitulacion_med.rubrica = ?  
                                            UNION 
                                            SELECT medicamentos.medicamento,        
                                                   medicamentos.descripcion,        
                                                   ' ' valor,        
                                                   'N' seleccionado   
                                            FROM medicamentos  
                                            WHERE medicamentos.medicamento NOT IN ( 
                                                                            SELECT capitulacion_med.medicamento 
                                                                            FROM capitulacion_med
                                                                            WHERE capitulacion_med.capitulo = ? AND 
                                                                                  capitulacion_med.rubrica = ?)";


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