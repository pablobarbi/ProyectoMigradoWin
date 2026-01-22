using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dsto_medicamentos_subrubrica : IDataWindowMetadata
    {
        public string DataObject => "dsto_medicamentos_subrubrica";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("rubrica", "decimal(0)")
            {
                DbName = "rubricacion_med.rubrica",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("subrubrica", "decimal(0)")
            {
                DbName = "rubricacion_med.subrubrica",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("medicamento", "char(10)")
            {
                DbName = "rubricacion_med.medicamento",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("valor", "long")
            {
                DbName = "rubricacion_med.valor",
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
SELECT rubricacion_med.rubrica,
       rubricacion_med.subrubrica,
       rubricacion_med.medicamento,
       rubricacion_med.valor
  FROM rubricacion_med
 WHERE rubricacion_med.rubrica = :rubrica
   AND rubricacion_med.subrubrica = :subrubrica
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"rubricacion_med";

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
