using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_saveas : IDataWindowMetadata
    {
        public string DataObject => "d_saveas";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("columnname", "char(50)")
            {
                DbName = "columnname",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = false,
                EsRequerido = false,
            },
            new DataWindowColumn("displayname", "char(10)")
            {
                DbName = "displayname",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = false,
                EsRequerido = false,
            },
            new DataWindowColumn("use_display", "char(1)")
            {
                DbName = "use_display",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = false,
                EsRequerido = false,
            }
        };

        // PB: table.retrieve
        public string Sql => @"

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
