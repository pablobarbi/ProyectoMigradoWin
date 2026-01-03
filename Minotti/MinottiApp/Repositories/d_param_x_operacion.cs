using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Repositories
{
    public class d_param_x_operacion
    {
        public string? operacion { get; set; }
        public int? orden { get; set; }
        public string? titulo { get; set; }
        public string? objeto { get; set; }
        public string? parametros { get; set; }
        public string? cierra { get; set; }

        // SQL EXACTO del SRD (mismo SELECT y ORDER BY)
        // :perfil -> ? (ODBC)
        private const string SQL_RETRIEVE =
@"SELECT DISTINCT 
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
         dba.acc_parametros.orden";

        public static List<d_param_x_operacion> Retrieve(string perfil)
        {
            if (SQLCA.Connection == null)
                throw new InvalidOperationException("SQLCA.Connection no inicializada.");

            var list = new List<d_param_x_operacion>();

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
                    list.Add(new d_param_x_operacion
                    {
                        operacion = rd.IsDBNull(0) ? null : rd.GetString(0),
                        orden = rd.IsDBNull(1) ? (int?)null : Convert.ToInt32(rd.GetValue(1)),
                        titulo = rd.IsDBNull(2) ? null : rd.GetString(2),
                        objeto = rd.IsDBNull(3) ? null : rd.GetString(3),
                        parametros = rd.IsDBNull(4) ? null : rd.GetString(4),
                        cierra = rd.IsDBNull(5) ? null : rd.GetString(5)
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
