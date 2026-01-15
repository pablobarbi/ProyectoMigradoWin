using Minotti.Data;
using Minotti.utils;
using System.Data;
using System.Data.Odbc;

namespace Minotti.Repositories
{
    public class d_agregar_rubricas : datastore
    {
        // SQL exacto del SRD (sin cambios)
        private const string SQL = @"SELECT rubricas.nombre
                                     FROM rubricas";

        /// <summary>
        /// Retrieve de la DW rubricas (sin parámetros).
        /// </summary> 
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

