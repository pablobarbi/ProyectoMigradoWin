using Minotti.Data;
using Minotti.utils;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class d_operaciones_x_perfil_sub_modulo : datastore
    {
        // === Columnas del DataWindow (referenciales, como en PB) ===
        public string? operacion { get; set; }
        public string? nombre { get; set; }
        public string? submodulo { get; set; }
        public string? modulo { get; set; }

        // === SQL EXTRAÍDO DEL SRD (SIN MODIFICAR) ===
        private const string SQL = @"
SELECT DISTINCT dba.acc_operaciones.operacion, 
                dba.acc_operaciones.nombre, 
                dba.acc_operaciones_x_modulo.modulo + '*****' + dba.acc_operaciones_x_modulo.submodulo AS submodulo,
                dba.acc_operaciones_x_modulo.modulo 
           FROM dba.acc_modulos_x_perfil, 
                dba.acc_operaciones_x_modulo, 
                dba.acc_operaciones 
          WHERE dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion 
            AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo 
            AND dba.acc_modulos_x_perfil.perfil = ?
          ORDER BY dba.acc_operaciones_x_modulo.modulo,
                   submodulo,
                   dba.acc_operaciones.operacion";

        // === Retrieve PB-like ===
        // args[0] = perfil
        public override int Retrieve(params object?[] args)
        {
            if (args == null || args.Length == 0)
                throw new ArgumentException(
                    "d_operaciones_x_perfil_sub_modulo.Retrieve requiere parámetro: perfil");

            if (SQLCA.Connection == null)
                throw new InvalidOperationException("SQLCA.Connection es null");

            try
            {
                using var cmd = SQLCA.Connection.CreateCommand();
                cmd.CommandText = SQL;

                // Parámetro ODBC posicional
                var prm = cmd.CreateParameter();
                prm.Value = args[0];
                cmd.Parameters.Add(prm);

                using var da = new OdbcDataAdapter((OdbcCommand)cmd);
                var dt = new DataTable();
                da.Fill(dt);

                this.SetData(dt);

                SQLCA.SqlCode = 0;
                SQLCA.SqlErrText = null;

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
