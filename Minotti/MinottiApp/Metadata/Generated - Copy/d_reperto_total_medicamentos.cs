using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_reperto_total_medicamentos : IDataWindowMetadata
    {
        public string DataObject => "d_reperto_total_medicamentos";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("reperto_total", "decimal(0)")
            {
                DbName = "reperto_total_med.reperto_total",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("reperto_sintoma", "decimal(0)")
            {
                DbName = "reperto_total_med.reperto_sintoma",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("medicamento", "char(10)")
            {
                DbName = "reperto_total_med.medicamento",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("orden", "decimal(5)")
            {
                DbName = "reperto_total_med.orden",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("puntuacion", "char(5)")
            {
                DbName = "reperto_total_med.puntuacion",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT reperto_total_med.reperto_total,
       reperto_total_med.reperto_sintoma,
       reperto_total_med.medicamento,
       reperto_total_med.orden,
       reperto_total_med.puntuacion
  FROM reperto_total_med
 WHERE reperto_total_med.reperto_total = :reperto_total
   AND reperto_total_med.reperto_sintoma = :reperto_sintoma
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"reperto_total_med";

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
