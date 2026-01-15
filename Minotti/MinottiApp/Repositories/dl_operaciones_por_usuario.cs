using Minotti.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;

using Minotti.utils;
namespace Minotti.Repositories
{

    public class dl_operaciones_por_usuario : datastore{

        public string usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string modulo { get; set; }
        public string nombre_modulo { get; set; }
        public string bitmap_modulo { get; set; }
        public string operacion { get; set; }
        public string nombre_operacion { get; set; }
        public string bitmap_operacion { get; set; }
        public string alta { get; set; }
        public string baja { get; set; }
        public string modificacion { get; set; }


        private const string SQL = @"
SELECT dba.acc_usuarios.usuario,
       dba.acc_usuarios.nombre nombre_usuario,
       dba.acc_operaciones_x_modulo.modulo,
       dba.acc_modulos.nombre,
       dba.acc_modulos.bitmap,
       dba.acc_operaciones_x_modulo.operacion,
       dba.acc_operaciones.nombre,
       dba.acc_operaciones.bitmap,
       upper(dba.acc_operaciones_x_modulo.alta) alta,
       upper(dba.acc_operaciones_x_modulo.baja) baja,
       upper(dba.acc_operaciones_x_modulo.modificacion) modificacion
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



        /// <summary>
        /// Equivalente al retrieve del DataWindow dl_operaciones_por_usuario.
        /// Argumento: usuario (string), como en arguments=(("usuario", string))
        /// </summary>

        


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