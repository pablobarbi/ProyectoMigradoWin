using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti.Models
{
    /// <summary>
    /// Migración de PowerBuilder DataWindow: d_sub_modulos_x_perfil.srd
    /// Se mantiene el nombre y se extrae la consulta.
    /// </summary>
    public static class d_sub_modulos_x_perfil
    {
        public const string SqlOriginal = @"""SELECT DISTINCT dba.acc_operaciones_x_modulo.modulo + '*****' + dba.acc_operaciones_x_modulo.submodulo submodulo,
       dba.acc_submodulos.nombre,
       dba.acc_operaciones_x_modulo.modulo
  FROM dba.acc_submodulos,
       dba.acc_operaciones_x_modulo,
       dba.acc_modulos_x_perfil
 WHERE dba.acc_operaciones_x_modulo.submodulo = dba.acc_submodulos.submodulo
   AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
   AND dba.acc_modulos_x_perfil.perfil = :perfil""";
        public const string SqlOdbc     = @"""SELECT DISTINCT dba.acc_operaciones_x_modulo.modulo + '*****' + dba.acc_operaciones_x_modulo.submodulo submodulo,
       dba.acc_submodulos.nombre,
       dba.acc_operaciones_x_modulo.modulo
  FROM dba.acc_submodulos,
       dba.acc_operaciones_x_modulo,
       dba.acc_modulos_x_perfil
 WHERE dba.acc_operaciones_x_modulo.submodulo = dba.acc_submodulos.submodulo
   AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
   AND dba.acc_modulos_x_perfil.perfil = ?""";
        
        public static DataTable Retrieve(OdbcConnection cnn, params object[] parametros)
        {
            if (cnn is null) throw new ArgumentNullException(nameof(cnn));
            if (cnn.State != ConnectionState.Open) cnn.Open();

            using var cmd = cnn.CreateCommand();
            cmd.CommandText = string.IsNullOrWhiteSpace(SqlOriginal) ? SqlOdbc : SqlOriginal;

            foreach (var p in parametros)
            {
                var prm = cmd.CreateParameter();
                prm.Value = p ?? DBNull.Value;
                cmd.Parameters.Add(prm);
            }

            var dt = new DataTable();
            using var da = new OdbcDataAdapter((OdbcCommand)cmd);
            da.Fill(dt);
            return dt;
        }
    }
}
