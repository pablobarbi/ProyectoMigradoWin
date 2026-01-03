using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti.Models
{
    /// <summary>
    /// Migración de PowerBuilder DataWindow: d_modulos_x_perfil.srd
    /// Se mantiene el NOMBRE del archivo/clase y se **extrae la consulta**.
    /// </summary>
    public static class d_modulos_x_perfil
    {
        /// <summary>
        /// Consulta original extraída del .srd (sin alteraciones).
        /// </summary>
        public const string SqlOriginal = @"""SELECT DISTINCT dba.acc_modulos.modulo, 
                dba.acc_modulos.nombre, 
                dba.acc_modulos_x_perfil.perfil 
           FROM dba.acc_modulos, 
                dba.acc_modulos_x_perfil 
          WHERE dba.acc_modulos.modulo = dba.acc_modulos_x_perfil.modulo 
            AND dba.acc_modulos_x_perfil.perfil = :perfil 
          ORDER BY dba.acc_modulos.modulo""";
        
        /// <summary>
        /// Consulta adaptada para ODBC (parámetros :nombre -> ?). 
        /// Si no hay parámetros en el .srd, coincide con la original.
        /// </summary>
        public const string SqlOdbc = @"""SELECT DISTINCT dba.acc_modulos.modulo, 
                dba.acc_modulos.nombre, 
                dba.acc_modulos_x_perfil.perfil 
           FROM dba.acc_modulos, 
                dba.acc_modulos_x_perfil 
          WHERE dba.acc_modulos.modulo = dba.acc_modulos_x_perfil.modulo 
            AND dba.acc_modulos_x_perfil.perfil = ? 
          ORDER BY dba.acc_modulos.modulo""";
        
        /// <summary>
        /// Ejecuta la consulta y devuelve un DataTable.
        /// Si la consulta usa parámetros, pásalos en el mismo orden en que aparecen.
        /// </summary>
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
