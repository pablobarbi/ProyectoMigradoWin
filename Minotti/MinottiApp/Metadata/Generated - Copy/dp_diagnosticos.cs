using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dp_diagnosticos : IDataWindowMetadata
    {
        public string DataObject => "dp_diagnosticos";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("paciente", "long")
            {
                DbName = "diagnosticos.paciente",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("fecha_desde", "date")
            {
                DbName = "diagnosticos.fecha_desde",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 20,
            },
            new DataWindowColumn("fecha_hasta", "date")
            {
                DbName = "diagnosticos.fecha_hasta",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 30,
            },
            new DataWindowColumn("diag_nosologico", "char(50)")
            {
                DbName = "diagnosticos.diag_nosologico",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = true,
                TabOrder = 50,
            },
            new DataWindowColumn("tipo_diagnostico", "char(1)")
            {
                DbName = "tipo_diagnostico",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = true,
                TabOrder = 40,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT diagnosticos.paciente,
       diagnosticos.fecha_visita fecha_desde,
       diagnosticos.fecha_visita fecha_hasta,
       diagnosticos.diag_nosologico,
       'N' tipo_diagnostico
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
