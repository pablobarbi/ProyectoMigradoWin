using Minotti.Data;
using Minotti.utils;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    // 🔥 CLAVE: hereda de datastore
    public class d_perfiles_x_usuario : datastore
    {
        // === Columnas del DataWindow (como en PB) ===
        public string? perfil { get; set; }
        public string? nombre { get; set; }

        // === SQL EXACTO del SRD / DW ===
        private const string SQL_RETRIEVE = @"
            SELECT DISTINCT acc_perfiles.perfil,
                            acc_perfiles.nombre
              FROM acc_perfiles,
                   acc_usuarios
             WHERE acc_perfiles.perfil = acc_usuarios.perfil
               AND acc_usuarios.usuario = ?
        ";

        // === Retrieve PB-like ===
        // args[0] = usuario
        public override int Retrieve(params object?[] args)
        {
            if (args == null || args.Length == 0)
                throw new ArgumentException(
                    "d_perfiles_x_usuario.Retrieve requiere parámetro: usuario");

            var usuarioParam = args[0];

            if (SQLCA.Connection == null)
                throw new InvalidOperationException(
                    "SQLCA.Connection es null (no inicializada).");

            try
            {
                using var cmd = SQLCA.Connection.CreateCommand();
                cmd.CommandText = SQL_RETRIEVE;

                // ODBC => parámetro posicional
                cmd.Parameters.Add(new OdbcParameter
                {
                    OdbcType = OdbcType.Char,
                    Value = usuarioParam
                });

                using var da = new OdbcDataAdapter((OdbcCommand)cmd);
                var dt = new DataTable();
                da.Fill(dt);

                // 🔥 Cargar datos en el motor DataWindow
                this.SetData(dt);

                SQLCA.SqlCode = 0;
                SQLCA.SqlErrText = null;

                // PB: Retrieve devuelve RowCount
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
