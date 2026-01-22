using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dk_diagnosticos : IDataWindowMetadata
    {
        public string DataObject => "dk_diagnosticos";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("paciente", "long")
            {
                DbName = "diagnosticos.paciente",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("diagnostico", "long")
            {
                DbName = "diagnosticos.diagnostico",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("fecha_visita", "date")
            {
                DbName = "diagnosticos.fecha_visita",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("pacientes_nombre", "char(50)")
            {
                DbName = "pacientes.nombre",
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
SELECT diagnosticos.paciente,
       diagnosticos.diagnostico,
       diagnosticos.fecha_visita,
       pacientes.nombre
  FROM diagnosticos, pacientes
 WHERE diagnosticos.paciente = pacientes.paciente
 ORDER BY pacientes.nombre,
       diagnosticos.diagnostico
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"diagnosticos";

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
