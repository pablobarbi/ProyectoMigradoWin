using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dp_medicamentos_desde_hasta : IDataWindowMetadata
    {
        public string DataObject => "dp_medicamentos_desde_hasta";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("med1", "char(10)")
            {
                DbName = "med1",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 10,
            },
            new DataWindowColumn("med2", "char(10)")
            {
                DbName = "med2",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = true,
                TabOrder = 20,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT medicamentos.medicamento AS med1,
       medicamentos.medicamento AS med2
  FROM medicamentos
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
