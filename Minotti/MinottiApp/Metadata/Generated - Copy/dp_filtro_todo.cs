using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dp_filtro_todo : IDataWindowMetadata
    {
        public string DataObject => "dp_filtro_todo";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("nombre", "char(255)")
            {
                DbName = "capitulos.nombre",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = true,
                TabOrder = 10,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT capitulos.nombre
  FROM capitulos
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"a";

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
