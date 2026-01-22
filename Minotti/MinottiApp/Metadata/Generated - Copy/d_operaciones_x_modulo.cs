using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_operaciones_x_modulo : IDataWindowMetadata
    {
        public string DataObject => "d_operaciones_x_modulo";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("modulo", "char(5)")
            {
                DbName = "acc_operaciones_x_modulo.modulo",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("operacion", "char(5)")
            {
                DbName = "acc_operaciones_x_modulo.operacion",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 10,
            },
            new DataWindowColumn("submodulo", "char(5)")
            {
                DbName = "acc_operaciones_x_modulo.submodulo",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 20,
            },
            new DataWindowColumn("alta", "char(1)")
            {
                DbName = "acc_operaciones_x_modulo.alta",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 30,
            },
            new DataWindowColumn("baja", "char(1)")
            {
                DbName = "acc_operaciones_x_modulo.baja",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 40,
            },
            new DataWindowColumn("modificacion", "char(1)")
            {
                DbName = "acc_operaciones_x_modulo.modificacion",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 50,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT dba.acc_operaciones_x_modulo.modulo,
       dba.acc_operaciones_x_modulo.operacion,
       dba.acc_operaciones_x_modulo.submodulo,
       dba.acc_operaciones_x_modulo.alta,
       dba.acc_operaciones_x_modulo.baja,
       dba.acc_operaciones_x_modulo.modificacion
  FROM dba.acc_operaciones_x_modulo
 WHERE dba.acc_operaciones_x_modulo.modulo = :modulo
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"dba.acc_operaciones_x_modulo";

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
