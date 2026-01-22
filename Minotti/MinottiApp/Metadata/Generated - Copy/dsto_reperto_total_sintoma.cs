using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dsto_reperto_total_sintoma : IDataWindowMetadata
    {
        public string DataObject => "dsto_reperto_total_sintoma";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("reperto_total", "decimal(0)")
            {
                DbName = "reperto_total_sin.reperto_total",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 130,
            },
            new DataWindowColumn("reperto_sintoma", "decimal(0)")
            {
                DbName = "reperto_total_sin.reperto_sintoma",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("capitulo", "decimal(0)")
            {
                DbName = "reperto_total_sin.capitulo",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 10,
            },
            new DataWindowColumn("rubrica", "decimal(0)")
            {
                DbName = "reperto_total_sin.rubrica",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 20,
            },
            new DataWindowColumn("subrubrica", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 30,
            },
            new DataWindowColumn("subrubrica2", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica2",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 40,
            },
            new DataWindowColumn("subrubrica3", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica3",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 50,
            },
            new DataWindowColumn("subrubrica4", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica4",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 60,
            },
            new DataWindowColumn("subrubrica5", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica5",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 70,
            },
            new DataWindowColumn("subrubrica6", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica6",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 80,
            },
            new DataWindowColumn("subrubrica7", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica7",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 90,
            },
            new DataWindowColumn("subrubrica8", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica8",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 100,
            },
            new DataWindowColumn("subrubrica9", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica9",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 110,
            },
            new DataWindowColumn("subrubrica10", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica10",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 120,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT reperto_total_sin.reperto_total,
         reperto_total_sin.reperto_sintoma,
         reperto_total_sin.capitulo,
         reperto_total_sin.rubrica,
         reperto_total_sin.subrubrica,
         reperto_total_sin.subrubrica2,
         reperto_total_sin.subrubrica3,
         reperto_total_sin.subrubrica4,
         reperto_total_sin.subrubrica5,
         reperto_total_sin.subrubrica6,
         reperto_total_sin.subrubrica7,
         reperto_total_sin.subrubrica8,
         reperto_total_sin.subrubrica9,
         reperto_total_sin.subrubrica10
    FROM reperto_total_sin,
         reperto_total
   WHERE reperto_total.reperto_total = :reperto
     AND reperto_total.reperto_total = reperto_total_sin.reperto_total
     AND reperto_total.reperto_sintoma = reperto_total_sin.reperto_sintoma
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"reperto_total_sin";

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
