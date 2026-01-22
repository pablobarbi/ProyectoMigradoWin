using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dk_reperto_lista_para_multiple : IDataWindowMetadata
    {
        public string DataObject => "dk_reperto_lista_para_multiple";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("reperto_total", "decimal(0)")
            {
                DbName = "reperto_total_diag.reperto_total",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("fecha", "date")
            {
                DbName = "reperto_total_diag.fecha",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("comentario", "char(50)")
            {
                DbName = "reperto_total_diag.comentario",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("paciente", "long")
            {
                DbName = "reperto_total_diag.paciente",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("marca", "char(1)")
            {
                DbName = "reperto_total_diag.marca",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("seleccionado", "char(1)")
            {
                DbName = "seleccionado",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 10,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT reperto_total_diag.reperto_total,
       reperto_total_diag.fecha,
       reperto_total_diag.comentario,
       reperto_total_diag.paciente,
       reperto_total_diag.marca,
       'N' seleccionado
  FROM reperto_total_diag
 WHERE reperto_total_diag.reperto_total >= :rep_desde
   AND reperto_total_diag.reperto_total <= :rep_hasta
   AND reperto_total_diag.fecha >= YMD(SUBSTR(:fecha_desde, 7, 4), SUBSTR(:fecha_desde, 4, 2), SUBSTR(:fecha_desde, 1, 2))
   AND reperto_total_diag.fecha <= YMD(SUBSTR(:fecha_hasta, 7, 4), SUBSTR(:fecha_hasta, 4, 2), SUBSTR(:fecha_hasta, 1, 2))
   AND ((reperto_total_diag.paciente = :paciente) OR (:paciente = '0'))
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"reperto_total_diag";

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
