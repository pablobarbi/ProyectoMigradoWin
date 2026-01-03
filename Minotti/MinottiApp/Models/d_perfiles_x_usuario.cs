using Minotti.Data;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti.Models
{
    /// <summary>
    /// Migración de SRD: d_perfiles_x_usuario.srd
    /// - Mantengo el nombre del archivo en la clase: d_perfiles_x_usuario
    /// - Se extrae la consulta del SRD y se provee método para ejecutarla vía SQL Anywhere (ODBC DSN).
    /// - Se incluyen alias para que las columnas coincidan con los nombres de la DataWindow:
    ///   acc_perfiles_perfil, acc_perfiles_nombre.
    /// </summary>
    public static class d_perfiles_x_usuario
    {
        /// <summary>Consulta original extraída del SRD (con :usuario).</summary>
        public const string Retrieve = @"""SELECT DISTINCT acc_perfiles.perfil, 
                acc_perfiles.nombre 
           FROM acc_perfiles, 
                acc_usuarios 
          WHERE acc_perfiles.perfil = acc_usuarios.perfil 
            AND acc_usuarios.usuario = :usuario""";
        
        /// <summary>Consulta con alias (recomendada para mantener nombres de columnas del SRD).</summary>
        public const string Sql = @"""SELECT DISTINCT 
    acc_perfiles.perfil  AS acc_perfiles_perfil,
    acc_perfiles.nombre  AS acc_perfiles_nombre
FROM acc_perfiles, acc_usuarios
WHERE acc_perfiles.perfil = acc_usuarios.perfil
  AND acc_usuarios.usuario = :usuario""";

        /// <summary>
        /// Ejecuta la consulta usando SQLCA.Connection (ODBC). 
        /// Devuelve un DataTable con columnas: acc_perfiles_perfil, acc_perfiles_nombre.
        /// </summary>
        public static DataTable RetrieveByUsuario(string usuario)
        {
            return SQLCA.ExecuteDataTable(Sql, usuario);
        }
    }
}
