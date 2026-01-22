using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dp_dos_medicamentos_valor : IDataWindowMetadata
    {
        public string DataObject => "dp_dos_medicamentos_valor";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("capitulo", "decimal(0)")
            {
                DbName = "capitulacion_med.capitulo",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = true,
                TabOrder = 10,
            },
            new DataWindowColumn("medicamento", "char(10)")
            {
                DbName = "capitulacion_med.medicamento",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = true,
                TabOrder = 20,
            },
            new DataWindowColumn("valor", "long")
            {
                DbName = "capitulacion_med.valor",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = true,
                TabOrder = 30,
            },
            new DataWindowColumn("medicamento2", "char(10)")
            {
                DbName = "medicamento2",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = true,
                TabOrder = 40,
            },
            new DataWindowColumn("valor2", "long")
            {
                DbName = "valor2",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = true,
                TabOrder = 50,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT capitulacion_med.capitulo,
       capitulacion_med.medicamento,
       capitulacion_med.valor,
       capitulacion_med.medicamento medicamento2,
       capitulacion_med.valor valor2
  FROM capitulacion_med
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
