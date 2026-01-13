using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Repositories
{
    public static class d_submodulos_x_perfil
    {
        public static DataTable Retrieve(string perfil)
        {
            const string sql = @"
SELECT DISTINCT
       acc_operaciones_x_modulo.modulo || '********' || acc_operaciones_x_modulo.submodulo AS submodulo,
       acc_submodulos.nombre,
       acc_operaciones_x_modulo.modulo AS acc_operaciones_x_modulo_modulo
  FROM acc_submodulos,
       acc_operaciones_x_modulo,
       acc_modulos_x_perfil
 WHERE acc_operaciones_x_modulo.submodulo = acc_submodulos.submodulo
   AND acc_operaciones_x_modulo.modulo = acc_modulos_x_perfil.modulo
   AND acc_modulos_x_perfil.perfil = ?
 ORDER BY submodulo
";

            return SQLCA.ExecuteDataTable(sql, perfil);
        }
    }
}
