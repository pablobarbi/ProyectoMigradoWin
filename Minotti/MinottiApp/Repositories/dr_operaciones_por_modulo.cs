using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

using Minotti.utils;
using System.Data;
namespace Minotti.Repositories
{



    public class dr_operaciones_por_modulo : datastore
    {
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
SELECT dba.acc_operaciones_x_modulo.modulo,
       dba.acc_modulos.nombre       AS nombre_modulo,
       dba.acc_modulos.bitmap       AS bitmap_modulo,
       dba.acc_operaciones_x_modulo.operacion,
       dba.acc_operaciones.nombre   AS nombre_operacion,
       dba.acc_operaciones.bitmap   AS bitmap_operacion,
       upper(dba.acc_operaciones_x_modulo.alta)         AS alta,
       upper(dba.acc_operaciones_x_modulo.baja)         AS baja,
       upper(dba.acc_operaciones_x_modulo.modificacion) AS modificacion
  FROM dba.acc_modulos,
       dba.acc_operaciones,
       dba.acc_operaciones_x_modulo
 WHERE dba.acc_modulos.modulo = dba.acc_operaciones_x_modulo.modulo
   AND dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion
 ORDER BY dba.acc_modulos.nombre";





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