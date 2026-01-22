using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dsto_reperto_parcial_med : IDataWindowMetadata
    {
        public string DataObject => "dsto_reperto_parcial_med";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("reperto_parcial", "decimal(0)")
            {
                DbName = "reperto_parcial_med.reperto_parcial",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 10,
            },
            new DataWindowColumn("orden", "long")
            {
                DbName = "reperto_parcial_med.orden",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 20,
            },
            new DataWindowColumn("medicamento", "char(10)")
            {
                DbName = "reperto_parcial_med.medicamento",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 30,
            },
            new DataWindowColumn("valor", "long")
            {
                DbName = "reperto_parcial_med.valor",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 40,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT reperto_parcial_med.reperto_parcial,
       reperto_parcial_med.orden,
       reperto_parcial_med.medicamento,
       reperto_parcial_med.valor
  FROM reperto_parcial_med
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"reperto_parcial_med";

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
