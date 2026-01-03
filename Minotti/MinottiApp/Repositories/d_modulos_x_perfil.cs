using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class d_modulos_x_perfil
    {
        public string? modulo { get; set; }
        public string? nombre { get; set; }
        public string? perfil { get; set; }

        // Query del SRD (misma lógica). ODBC usa parámetro posicional '?'
        private const string SQL_RETRIEVE =
@"SELECT DISTINCT dba.acc_modulos.modulo,
                dba.acc_modulos.nombre,
                dba.acc_modulos_x_perfil.perfil
   FROM dba.acc_modulos,
        dba.acc_modulos_x_perfil
  WHERE dba.acc_modulos.modulo = dba.acc_modulos_x_perfil.modulo
    AND dba.acc_modulos_x_perfil.perfil = ?
  ORDER BY dba.acc_modulos.modulo";

        public static List<d_modulos_x_perfil> Retrieve(string perfil)
        {
            if (SQLCA.Connection == null)
                throw new InvalidOperationException("SQLCA.Connection es null (no inicializada).");

            var list = new List<d_modulos_x_perfil>();

            try
            {
                using var cmd = SQLCA.Connection.CreateCommand();
                cmd.CommandText = SQL_RETRIEVE;

                // ODBC => parámetros posicionales
                cmd.Parameters.Add(new OdbcParameter { OdbcType = OdbcType.Char, Value = perfil });

                using var rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(new d_modulos_x_perfil
                    {
                        modulo = rd.IsDBNull(0) ? null : rd.GetString(0),
                        nombre = rd.IsDBNull(1) ? null : rd.GetString(1),
                        perfil = rd.IsDBNull(2) ? null : rd.GetString(2),
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
