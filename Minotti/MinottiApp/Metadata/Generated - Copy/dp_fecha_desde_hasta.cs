using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dp_fecha_desde_hasta : IDataWindowMetadata
    {
        public string DataObject => "dp_fecha_desde_hasta";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("fecha_desde", "date")
            {
                DbName = "diagnosticos.fecha_desde",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 10,
            },
            new DataWindowColumn("fecha_hasta", "date")
            {
                DbName = "diagnosticos.fecha_hasta",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 20,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT diagnosticos.fecha_visita as fecha_desde,
       diagnosticos.fecha_visita as fecha_hasta
  FROM diagnosticos
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"xxx";

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
