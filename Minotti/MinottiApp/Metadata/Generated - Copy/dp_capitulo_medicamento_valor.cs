using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dp_capitulo_medicamento_valor : IDataWindowMetadata
    {
        public string DataObject => "dp_capitulo_medicamento_valor";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("capitulo", "decimal(0)")
            {
                DbName = "capitulacion_med.capitulo",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 10,
            },
            new DataWindowColumn("medicamento", "char(10)")
            {
                DbName = "capitulacion_med.medicamento",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 20,
            },
            new DataWindowColumn("valor", "long")
            {
                DbName = "capitulacion_med.valor",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 30,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT capitulacion_med.capitulo,
       capitulacion_med.medicamento,
       capitulacion_med.valor
  FROM capitulacion_med
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
