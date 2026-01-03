using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti.Models
{
    /// <summary>
    /// Migración de PowerBuilder DataWindow: d_operaciones_x_perfil.srd
    /// Se mantiene el nombre y se extrae la consulta.
    /// </summary>
    public static class d_operaciones_x_perfil
    {
        public const string SqlOriginal = @"""SELECT DISTINCT dba.acc_operaciones.operacion, 
                dba.acc_operaciones.nombre, 
                dba.acc_operaciones_x_modulo.modulo 
           FROM dba.acc_modulos_x_perfil, 
                dba.acc_operaciones_x_modulo, 
                dba.acc_operaciones 
          WHERE dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion 
            AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo 
            AND dba.acc_modulos_x_perfil.perfil = :perfil 
          ORDER BY dba.acc_operaciones_x_modulo.modulo, 
                   dba.acc_operaciones.operacion""";
        public const string SqlOdbc     = @"""SELECT DISTINCT dba.acc_operaciones.operacion, 
                dba.acc_operaciones.nombre, 
                dba.acc_operaciones_x_modulo.modulo 
           FROM dba.acc_modulos_x_perfil, 
                dba.acc_operaciones_x_modulo, 
                dba.acc_operaciones 
          WHERE dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion 
            AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo 
            AND dba.acc_modulos_x_perfil.perfil = ? 
          ORDER BY dba.acc_operaciones_x_modulo.modulo, 
                   dba.acc_operaciones.operacion""";
        
       

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
