using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dw_subrubricas : IDataWindowMetadata
    {
        public string DataObject => "dw_subrubricas";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("subrubrica", "decimal(0)")
            {
                DbName = "subrubricas.subrubrica",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = true,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("nombre", "char(255)")
            {
                DbName = "subrubricas.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 10,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT subrubricas.subrubrica,
       subrubricas.nombre
  FROM subrubricas
ORDER BY 2
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"subrubricas";

        // PB: table.updatewhere (0/1)
        public int UpdateWhere => 1;

        // PB: table.updatekeyinplace (yes/no)
        public bool UpdateKeyInPlace => false;

        public string[] Estilos => Array.Empty<string>();
        public string[] SeleccionFila => Array.Empty<string>();

        public string Operaciones => string.Empty;

        public bool UsaUsuario => false;
        public bool UsaFecha => false;
    }
}
