using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_modulo : IDataWindowMetadata
    {
        public string DataObject => "d_modulo";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("modulo", "char(8)")
            {
                DbName = "acc_modulos.modulo",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 10,
            },
            new DataWindowColumn("nombre", "char(40)")
            {
                DbName = "acc_modulos.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 20,
            },
            new DataWindowColumn("bitmap", "char(40)")
            {
                DbName = "acc_modulos.bitmap",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT dba.acc_modulos.modulo,   
       dba.acc_modulos.nombre,   
       dba.acc_modulos.bitmap  
  FROM dba.acc_modulos  
 WHERE dba.acc_modulos.modulo = :modulo
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"dba.acc_modulos";

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
