using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dr_global_capitulos : IDataWindowMetadata
    {
        public string DataObject => "dr_global_capitulos";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("capitulo", "decimal(0)")
            {
                DbName = "capitulos.capitulo",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = true,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("nombre", "char(255)")
            {
                DbName = "capitulos.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT capitulos.capitulo,
       capitulos.nombre
  FROM capitulos
 WHERE capitulos.nombre like :campo
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"capitulos";

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
