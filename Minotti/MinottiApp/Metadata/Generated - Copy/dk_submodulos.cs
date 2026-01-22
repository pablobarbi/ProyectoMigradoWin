using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dk_submodulos : IDataWindowMetadata
    {
        public string DataObject => "dk_submodulos";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("submodulo", "char(8)")
            {
                DbName = "acc_submodulos.submodulo",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("nombre", "char(20)")
            {
                DbName = "acc_submodulos.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("bitmap", "char(40)")
            {
                DbName = "acc_submodulos.bitmap",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
PBSELECT( VERSION(400) TABLE(NAME=~""dba.acc_submodulos~"" ) COLUMN(NAME=~""dba.acc_submodulos.submodulo~"") COLUMN(NAME=~""dba.acc_submodulos.nombre~"") COLUMN(NAME=~""dba.acc_submodulos.bitmap~""))
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"dba.acc_submodulos";

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
