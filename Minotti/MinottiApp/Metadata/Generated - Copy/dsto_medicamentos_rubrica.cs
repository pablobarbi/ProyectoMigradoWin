using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dsto_medicamentos_rubrica : IDataWindowMetadata
    {
        public string DataObject => "dsto_medicamentos_rubrica";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("capitulo", "decimal(0)")
            {
                DbName = "capitulacion_med.capitulo",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("rubrica", "decimal(0)")
            {
                DbName = "capitulacion_med.rubrica",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("medicamento", "char(10)")
            {
                DbName = "capitulacion_med.medicamento",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("valor", "long")
            {
                DbName = "capitulacion_med.valor",
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
SELECT capitulacion_med.capitulo,
       capitulacion_med.rubrica,
       capitulacion_med.medicamento,
       capitulacion_med.valor
  FROM capitulacion_med
 WHERE capitulacion_med.capitulo = :capitulo
   AND capitulacion_med.rubrica = :rubrica
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"capitulacion_med";

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
