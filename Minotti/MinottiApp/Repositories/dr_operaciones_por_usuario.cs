using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

using Minotti.utils;
using System.Data;
namespace Minotti.Repositories
{

    

    public class dr_operaciones_por_usuario : datastore{
        public string? usuario { get; set; }
        public string? nombre_usuario { get; set; }
        public string? modulo { get; set; }
        public string? nombre_modulo { get; set; }
        public string? bitmap_modulo { get; set; }
        public string? operacion { get; set; }
        public string? nombre_operacion { get; set; }
        public string? bitmap_operacion { get; set; }
        public string? alta { get; set; }
        public string? baja { get; set; }
        public string? modificacion { get; set; }


        private const string SQL = @"
SELECT dba.acc_usuarios.usuario                               AS usuario,
       dba.acc_usuarios.nombre                                AS nombre_usuario,
       dba.acc_operaciones_x_modulo.modulo                    AS modulo,
       dba.acc_modulos.nombre                                 AS nombre_modulo,
       dba.acc_modulos.bitmap                                 AS bitmap_modulo,
       dba.acc_operaciones_x_modulo.operacion                 AS operacion,
       dba.acc_operaciones.nombre                             AS nombre_operacion,
       dba.acc_operaciones.bitmap                             AS bitmap_operacion,
       UPPER(dba.acc_operaciones_x_modulo.alta)               AS alta,
       UPPER(dba.acc_operaciones_x_modulo.baja)               AS baja,
       UPPER(dba.acc_operaciones_x_modulo.modificacion)       AS modificacion
  FROM dba.acc_modulos,
       dba.acc_operaciones,
       dba.acc_operaciones_x_modulo,
       dba.acc_modulos_x_perfil,
       dba.acc_usuarios
 WHERE dba.acc_modulos.modulo = dba.acc_operaciones_x_modulo.modulo
   AND dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion
   AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo
   AND dba.acc_modulos_x_perfil.perfil = dba.acc_usuarios.perfil
   AND dba.acc_usuarios.usuario = ?
 ORDER BY dba.acc_modulos.nombre,
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