using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_param_x_operacion : IDataWindowMetadata
    {
        public string DataObject => "d_param_x_operacion";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("operacion", "char(5)")
            {
                DbName = "acc_parametros.operacion",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 10,
            },
            new DataWindowColumn("orden", "long")
            {
                DbName = "acc_parametros.orden",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 20,
            },
            new DataWindowColumn("titulo", "char(80)")
            {
                DbName = "acc_parametros.titulo",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 30,
            },
            new DataWindowColumn("objeto", "char(40)")
            {
                DbName = "acc_parametros.objeto",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 40,
            },
            new DataWindowColumn("parametros", "char(256)")
            {
                DbName = "acc_parametros.parametros",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 50,
            },
            new DataWindowColumn("cierra", "char(1)")
            {
                DbName = "acc_parametros.cierra",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 60,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT DISTINCT 
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
   AND dba.acc_modulos_x_perfil.perfil = :perfil
 ORDER BY dba.acc_parametros.operacion,
       dba.acc_parametros.orden"" arguments=((""perfil"", string))  sort=""operacion A orden A
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"";

        // PB: table.updatewhere (0/1)
        public int UpdateWhere => 0;

        // PB: table.updatekeyinplace (yes/no)
        public bool UpdateKeyInPlace => false;

        public string[] Estilos => Array.Empty<string>();
        public string[] SeleccionFila => Array.Empty<string>();

        public string Operaciones => string.Empty;

        public bool UsaUsuario => false;
        public bool UsaFecha => false;
    }
}
