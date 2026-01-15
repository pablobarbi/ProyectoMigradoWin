using Minotti.Data;
using Minotti.utils;
using System;
using System.Data;
using System.Data.Odbc;

namespace MinottiApp.Repositories
{
    // ⚠️ CLAVE: hereda de datawindow, NO implementa IDataWindow
    public class d_modulos_x_perfil : datastore
    {
        // === Columnas del DataWindow (como en PB) ===
        public string? modulo { get; set; }
        public string? nombre { get; set; }
        public string? perfil { get; set; }

        // === SQL EXACTO del SRD / DW ===
        private const string SQL_RETRIEVE =
@"SELECT DISTINCT dba.acc_modulos.modulo,
                dba.acc_modulos.nombre,
                dba.acc_modulos_x_perfil.perfil
   FROM dba.acc_modulos,
        dba.acc_modulos_x_perfil
  WHERE dba.acc_modulos.modulo = dba.acc_modulos_x_perfil.modulo
    AND dba.acc_modulos_x_perfil.perfil = ?
  ORDER BY dba.acc_modulos.modulo";
        public override int Retrieve(params object?[] args)
        {
            if (args == null || args.Length == 0)
                throw new ArgumentException(
                    "d_modulos_x_perfil.Retrieve requiere parámetro: perfil");

            if (SQLCA.Connection == null)
                throw new InvalidOperationException("SQLCA.Connection es null");

            try
            {
                using var cmd = SQLCA.Connection.CreateCommand();
                cmd.CommandText = SQL_RETRIEVE;

                // Parámetro posicional ODBC: ?
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
