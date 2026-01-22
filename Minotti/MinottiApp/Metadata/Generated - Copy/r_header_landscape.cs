using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class r_header_landscape : IDataWindowMetadata
    {
        public string DataObject => "r_header_landscape";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("compute_0001", "decimal(0)")
            {
                DbName = "compute_0001",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT count(*) 
   FROM dba.acc_usuarios
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
