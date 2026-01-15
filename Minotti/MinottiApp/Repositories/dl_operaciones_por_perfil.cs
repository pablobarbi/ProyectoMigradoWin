using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

using Minotti.utils;
using System.Data;
namespace Minotti.Repositories
{



    public class dl_operaciones_por_perfil : datastore
    {
        public string perfil { get; set; } = string.Empty;
        public string nombre_perfil { get; set; } = string.Empty;

        public string modulo { get; set; } = string.Empty;
        public string nombre_modulo { get; set; } = string.Empty;
        public string bitmap_modulo { get; set; } = string.Empty;

        public string operacion { get; set; } = string.Empty;
        public string nombre_operacion { get; set; } = string.Empty;
        public string bitmap_operacion { get; set; } = string.Empty;

        public string alta { get; set; } = string.Empty;
        public string baja { get; set; } = string.Empty;
        public string modificacion { get; set; } = string.Empty;



        private const string SQL = @"
SELECT dba.acc_perfiles.perfil,
       dba.acc_perfiles.nombre            nombre_perfil,
       dba.acc_operaciones_x_modulo.modulo,
       dba.acc_modulos.nombre             nombre_modulo,
       dba.acc_modulos.bitmap             bitmap_modulo,
       dba.acc_operaciones_x_modulo.operacion,
       dba.acc_operaciones.nombre         nombre_operacion,
       dba.acc_operaciones.bitmap         bitmap_operacion,
       upper(dba.acc_operaciones_x_modulo.alta)         alta,
       upper(dba.acc_operaciones_x_modulo.baja)         baja,
       upper(dba.acc_operaciones_x_modulo.modificacion) modificacion
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