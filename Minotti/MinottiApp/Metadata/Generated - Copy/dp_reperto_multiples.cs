using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dp_reperto_multiples : IDataWindowMetadata
    {
        public string DataObject => "dp_reperto_multiples";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("reperto_desde", "decimal(0)")
            {
                DbName = "reperto_total_diag.reperto_desde",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 10,
            },
            new DataWindowColumn("reperto_hasta", "decimal(0)")
            {
                DbName = "reperto_total_diag.reperto_hasta",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 20,
            },
            new DataWindowColumn("fecha_desde", "date")
            {
                DbName = "reperto_total_diag.fecha_desde",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 30,
            },
            new DataWindowColumn("fecha_hasta", "date")
            {
                DbName = "reperto_total_diag.fecha_hasta",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 40,
            },
            new DataWindowColumn("paciente", "long")
            {
                DbName = "reperto_total_diag.paciente",
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
SELECT reperto_total_diag.reperto_total AS reperto_desde,
       reperto_total_diag.reperto_total AS reperto_hasta,
       reperto_total_diag.fecha AS fecha_desde,
       reperto_total_diag.fecha AS fecha_hasta,
       reperto_total_diag.paciente
  FROM reperto_total_diag
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
