using Minotti.Data;
using System.Data.Odbc;

using Minotti.utils;
using System.Data;
namespace Minotti.Repositories
{
    public class d_param_x_operacion : datastore
    {
        public string? operacion { get; set; }
        public int? orden { get; set; }
        public string? titulo { get; set; }
        public string? objeto { get; set; }
        public string? parametros { get; set; }
        public string? cierra { get; set; }

        // SQL EXACTO del SRD (mismo SELECT y ORDER BY)
        // :perfil -> ? (ODBC)
        private const string SQL =
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