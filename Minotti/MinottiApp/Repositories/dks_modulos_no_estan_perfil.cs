using Minotti.Data;
using Minotti.utils;
using System;
using System.Data;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class dks_modulos_no_estan_perfil : datastore
    {
        // === Columnas (referenciales, como en PB) ===
        public string? Modulo { get; set; }
        public string? Nombre { get; set; }

        // === SQL EXTRADO (SIN TOCAR) ===
        private const string SQL = @"
SELECT dba.acc_modulos.modulo,
       dba.acc_modulos.nombre
  FROM dba.acc_modulos
 WHERE NOT EXISTS (
           SELECT ''
             FROM dba.acc_modulos_perfil
            WHERE dba.acc_modulos_perfil.perfil = ?
              AND dba.acc_modulos_perfil.modulo = dba.acc_modulos.modulo
       )";

        public override int Retrieve(params object?[] args)
        {
            if (SQLCA.Connection == null)
                throw new InvalidOperationException("SQLCA.Connection es null");

            try
            {
                using var cmd = SQLCA.Connection.CreateCommand();
                cmd.CommandText = SQL;

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