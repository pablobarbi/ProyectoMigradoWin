using Minotti.Data;
using System.Data.Odbc;

using Minotti.utils;
using System.Data;
namespace Minotti.Repositories
{



    public class dr_operaciones_por_perfil : datastore
    {


        public string perfil { get; set; }
        public string nombre_perfil { get; set; }
        public string modulo { get; set; }
        public string nombre_modulo { get; set; }
        public string bitmap_modulo { get; set; }
        public string operacion { get; set; }
        public string nombre_operacion { get; set; }
        public string bitmap_operacion { get; set; }
        public string alta { get; set; }
        public string baja { get; set; }
        public string modificacion { get; set; }



        /// <summary>
        /// Equivalente al retrieve del DataWindow dr_operaciones_por_perfil.
        /// Argumento: perfil (string), como en arguments=(("perfil", string))
        ///
        /// En el SRD:
        ///   AND (dba.acc_modulos_x_perfil.perfil = :perfil or :perfil is Null)
        /// </summary>

        private const string SQL = @"
SELECT dba.acc_perfiles.perfil                               AS perfil,
       dba.acc_perfiles.nombre                               AS nombre_perfil,
       dba.acc_operaciones_x_modulo.modulo                   AS modulo,
       dba.acc_modulos.nombre                                AS nombre_modulo,
       dba.acc_modulos.bitmap                                AS bitmap_modulo,
       dba.acc_operaciones_x_modulo.operacion                AS operacion,
       dba.acc_operaciones.nombre                            AS nombre_operacion,
       dba.acc_operaciones.bitmap                            AS bitmap_operacion,
       UPPER(dba.acc_operaciones_x_modulo.alta)              AS alta,
       UPPER(dba.acc_operaciones_x_modulo.baja)              AS baja,
       UPPER(dba.acc_operaciones_x_modulo.modificacion)      AS modificacion
  FROM dba.acc_modulos,
       dba.acc_operaciones,
       dba.acc_operaciones_x_modulo,
       dba.acc_modulos_x_perfil,
       dba.acc_perfiles
 WHERE dba.acc_modulos.modulo = dba.acc_operaciones_x_modulo.modulo
   AND dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion
   AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
   AND dba.acc_modulos_x_perfil.perfil = dba.acc_perfiles.perfil
   AND (dba.acc_modulos_x_perfil.perfil = ? OR ? IS NULL)
 ORDER BY dba.acc_perfiles.nombre,
          dba.acc_modulos.nombre,
          dba.acc_operaciones.nombre";



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

                var prm1 = cmd.CreateParameter();
                prm1.Value = args[1];
                cmd.Parameters.Add(prm1);

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