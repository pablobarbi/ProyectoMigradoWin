using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_diagnosticos : IDataWindowMetadata
    {
        public string DataObject => "d_diagnosticos";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("paciente", "long")
            {
                DbName = "diagnosticos.paciente",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = true,
                TabOrder = 10,
            },
            new DataWindowColumn("diagnostico", "long")
            {
                DbName = "diagnosticos.diagnostico",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 20,
            },
            new DataWindowColumn("fecha_visita", "date")
            {
                DbName = "diagnosticos.fecha_visita",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 30,
            },
            new DataWindowColumn("diag_nosologico", "char(50)")
            {
                DbName = "diagnosticos.diag_nosologico",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 40,
            },
            new DataWindowColumn("diag_medicamentoso", "char(50)")
            {
                DbName = "diagnosticos.diag_medicamentoso",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 50,
            },
            new DataWindowColumn("diag_miasmatico", "char(50)")
            {
                DbName = "diagnosticos.diag_miasmatico",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 60,
            },
            new DataWindowColumn("diag_otro", "char(50)")
            {
                DbName = "diagnosticos.diag_otro",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 70,
            },
            new DataWindowColumn("repertorizacion", "long")
            {
                DbName = "diagnosticos.repertorizacion",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 80,
            },
            new DataWindowColumn("primera", "char(1)")
            {
                DbName = "diagnosticos.primera",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 90,
            },
            new DataWindowColumn("curado", "char(1)")
            {
                DbName = "diagnosticos.curado",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 100,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT diagnosticos.paciente,
       diagnosticos.diagnostico,
       diagnosticos.fecha_visita,
       diagnosticos.diag_nosologico,
       diagnosticos.diag_medicamentoso,
       diagnosticos.diag_miasmatico,
       diagnosticos.diag_otro,
       diagnosticos.repertorizacion,
       diagnosticos.primera,
       diagnosticos.curado
  FROM diagnosticos
 WHERE diagnosticos.paciente = :paciente
   AND diagnosticos.diagnostico = :diagnostico
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
