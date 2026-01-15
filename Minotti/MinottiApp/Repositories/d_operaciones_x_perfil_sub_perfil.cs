using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Minotti.utils;
using System.Data;
namespace Minotti.Repositories
{
    public class d_operaciones_x_perfil_sub_perfil : datastore
    {

        public string? operacion { get; set; }
        public string? nombre { get; set; }
        public string? submodulo { get; set; }
        public string? modulo { get; set; }

        // SQL del SRD (misma lógica). ODBC => parámetro posicional '?'
        // NO agrego ORDER BY porque en el SRD no está en el SQL (solo sort=).
        private const string SQL =
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




        public override int Retrieve(params object?[] args)
        {
            if (SQLCA.Connection == null)
                throw new InvalidOperationException("SQLCA.Connection es null");

            try
            {
                using var cmd = SQLCA.Connection.CreateCommand();
                cmd.CommandText = SQL;

                var prm0 = cmd.CreateParameter();
                prm0.Value = args[0];
                cmd.Parameters.Add(prm0);

                using var da = new OdbcDataAdapter((OdbcCommand)cmd);
                var dt = new DataTable();
                da.Fill(dt);

                this.SetData(dt);
                return this.RowCount();
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