using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti.Models
{
    /// <summary>
    /// Migración de SRD: d_sub_modulos_x_perfil.srd
    /// Mantengo el nombre de la clase igual al archivo.
    /// Columnas esperadas por la DataWindow:
    ///   - submodulo
    ///   - nombre
    ///   - acc_operaciones_x_modulo_modulo
    /// </summary>
    public static class d_sub_modulos_x_perfil1
    {
        /// <summary>Consulta original extraída del SRD (con :perfil).</summary>
        public const string Retrieve = @"SELECT DISTINCT acc_operaciones_x_modulo.modulo || '********' || acc_operaciones_x_modulo.submodulo as submodulo,
       acc_submodulos.nombre,
       acc_operaciones_x_modulo.modulo
  FROM acc_submodulos,
       acc_operaciones_x_modulo,
       acc_modulos_x_perfil
 WHERE acc_operaciones_x_modulo.submodulo = acc_submodulos.submodulo
   AND acc_operaciones_x_modulo.modulo = acc_modulos_x_perfil.modulo
   AND acc_modulos_x_perfil.perfil = :perfil";

        /// <summary>Consulta con alias explícitos que respetan los nombres de columnas del SRD.</summary>
        public const string Sql = @"SELECT DISTINCT
    acc_operaciones_x_modulo.modulo || '********' || acc_operaciones_x_modulo.submodulo AS submodulo,
    acc_submodulos.nombre AS nombre,
    acc_operaciones_x_modulo.modulo AS acc_operaciones_x_modulo_modulo
FROM acc_submodulos, acc_operaciones_x_modulo, acc_modulos_x_perfil
WHERE acc_operaciones_x_modulo.submodulo = acc_submodulos.submodulo
  AND acc_operaciones_x_modulo.modulo = acc_modulos_x_perfil.modulo
  AND acc_modulos_x_perfil.perfil = :perfil";

        /// <summary>
        /// Ejecuta la consulta usando SQLCA.Connection (ODBC). 
        /// Devuelve un DataTable con columnas: submodulo, nombre, acc_operaciones_x_modulo_modulo.
        /// </summary>
        public static DataTable RetrieveToDataTable(params object[] parametros)
        {
            string sql = string.IsNullOrWhiteSpace(Retrieve) ? Sql : Retrieve;

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
