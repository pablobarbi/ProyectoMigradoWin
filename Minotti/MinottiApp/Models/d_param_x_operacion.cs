using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti.Models
{
    /// <summary>
    /// Migración de PowerBuilder DataWindow: d_param_x_operacion.srd
    /// Se mantiene el nombre y se extrae la consulta.
    /// </summary>
    public static class d_param_x_operacion
    {
        public const string SqlOriginal = @"""SELECT DISTINCT 
		 dba.acc_parametros.operacion,
       dba.acc_parametros.orden,
       dba.acc_parametros.titulo,
       dba.acc_parametros.objeto,
       dba.acc_parametros.parametros,
       dba.acc_parametros.cierra
  FROM dba.acc_parametros,
       dba.acc_operaciones_x_modulo,
       dba.acc_modulos_x_perfil
 WHERE dba.acc_operaciones_x_modulo.operacion = dba.acc_parametros.operacion
   AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
   AND dba.acc_modulos_x_perfil.perfil = :perfil
 ORDER BY dba.acc_parametros.operacion,
       dba.acc_parametros.orden""";
        public const string SqlOdbc     = @"""SELECT DISTINCT 
		 dba.acc_parametros.operacion,
       dba.acc_parametros.orden,
       dba.acc_parametros.titulo,
       dba.acc_parametros.objeto,
       dba.acc_parametros.parametros,
       dba.acc_parametros.cierra
  FROM dba.acc_parametros,
       dba.acc_operaciones_x_modulo,
       dba.acc_modulos_x_perfil
 WHERE dba.acc_operaciones_x_modulo.operacion = dba.acc_parametros.operacion
   AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
   AND dba.acc_modulos_x_perfil.perfil = ?
 ORDER BY dba.acc_parametros.operacion,
       dba.acc_parametros.orden""";

        public static DataTable RetrieveToDataTable(params object[] parametros)
        {
            string sql = string.IsNullOrWhiteSpace(SqlOdbc) ? SqlOriginal : SqlOdbc;

            return SQLCA.ExecuteDataTable(sql, cmd =>
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
