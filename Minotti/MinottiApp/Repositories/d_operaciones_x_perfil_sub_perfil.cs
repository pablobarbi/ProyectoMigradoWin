using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Repositories
{
    public class d_operaciones_x_perfil_sub_perfil
    {

        public string? operacion { get; set; }
        public string? nombre { get; set; }
        public string? submodulo { get; set; }
        public string? modulo { get; set; }

        // SQL del SRD (misma lógica). ODBC => parámetro posicional '?'
        // NO agrego ORDER BY porque en el SRD no está en el SQL (solo sort=).
        private const string SQL_RETRIEVE =
@"SELECT DISTINCT dba.acc_operaciones.operacion,
                dba.acc_operaciones.nombre,
                dba.acc_operaciones_x_modulo.modulo + '*****' + dba.acc_operaciones_x_modulo.submodulo submodulo,
                dba.acc_operaciones_x_modulo.modulo
   FROM dba.acc_modulos_x_perfil,
        dba.acc_operaciones_x_modulo,
        dba.acc_operaciones
  WHERE dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion
    AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
    AND dba.acc_modulos_x_perfil.perfil = ?";

        public static List<d_operaciones_x_perfil_sub_perfil> Retrieve(string perfil)
        {
            if (SQLCA.Connection == null)
                throw new InvalidOperationException("SQLCA.Connection es null (no inicializada).");

            var list = new List<d_operaciones_x_perfil_sub_perfil>();

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
                    list.Add(new d_operaciones_x_perfil_sub_perfil
                    {
                        operacion = rd.IsDBNull(0) ? null : rd.GetString(0),
                        nombre = rd.IsDBNull(1) ? null : rd.GetString(1),
                        submodulo = rd.IsDBNull(2) ? null : rd.GetString(2),
                        modulo = rd.IsDBNull(3) ? null : rd.GetString(3),
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
 
