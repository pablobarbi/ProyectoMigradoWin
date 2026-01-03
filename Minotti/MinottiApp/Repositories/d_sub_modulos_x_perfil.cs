using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Repositories
{
    public class d_sub_modulos_x_perfil
    {
        public string? submodulo { get; set; }
        public string? nombre { get; set; }
        public string? modulo { get; set; }

        // SQL del SRD (misma lógica). ODBC => parámetro posicional '?'
        // NO agrego ORDER BY porque el SRD no lo tiene en el SQL (solo sort=).
        private const string SQL_RETRIEVE =
@"SELECT DISTINCT dba.acc_operaciones_x_modulo.modulo + '*****' + dba.acc_operaciones_x_modulo.submodulo submodulo,
                dba.acc_submodulos.nombre,
                dba.acc_operaciones_x_modulo.modulo
   FROM dba.acc_submodulos,
        dba.acc_operaciones_x_modulo,
        dba.acc_modulos_x_perfil
  WHERE dba.acc_operaciones_x_modulo.submodulo = dba.acc_submodulos.submodulo
    AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
    AND dba.acc_modulos_x_perfil.perfil = ?";

        public static List<d_sub_modulos_x_perfil> Retrieve(string perfil)
        {
            if (SQLCA.Connection == null)
                throw new InvalidOperationException("SQLCA.Connection es null (no inicializada).");

            var list = new List<d_sub_modulos_x_perfil>();

            try
            {
                using var cmd = SQLCA.Connection.CreateCommand();
                cmd.CommandText = SQL_RETRIEVE;

                cmd.Parameters.Add(new OdbcParameter
                {
                    OdbcType = OdbcType.Char,
                    Value = perfil
                });

                using var rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(new d_sub_modulos_x_perfil
                    {
                        submodulo = rd.IsDBNull(0) ? null : rd.GetString(0),
                        nombre = rd.IsDBNull(1) ? null : rd.GetString(1),
                        modulo = rd.IsDBNull(2) ? null : rd.GetString(2),
                    });
                }

                SQLCA.SqlCode = 0;
                SQLCA.SqlErrText = null;
                return list;
            }
            catch (Exception ex)
            {
                SQLCA.SqlCode = -1;
                SQLCA.SqlErrText = ex.Message;
                throw;
            }
        }
    }
}
