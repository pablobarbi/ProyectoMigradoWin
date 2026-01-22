using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dk_repertos_totales_bak : IDataWindowMetadata
    {
        public string DataObject => "dk_repertos_totales_bak";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("reperto_parcial", "decimal(0)")
            {
                DbName = "reperto_parcial.reperto_parcial",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = true,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("capitulo", "decimal(0)")
            {
                DbName = "reperto_parcial.capitulo",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("rubrica", "decimal(0)")
            {
                DbName = "reperto_parcial.rubrica",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica", "decimal(0)")
            {
                DbName = "reperto_parcial.subrubrica",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica2", "decimal(0)")
            {
                DbName = "subrubrica2",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica3", "decimal(0)")
            {
                DbName = "subrubrica3",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica4", "decimal(0)")
            {
                DbName = "subrubrica4",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica5", "decimal(0)")
            {
                DbName = "subrubrica5",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica6", "decimal(0)")
            {
                DbName = "subrubrica6",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica7", "decimal(0)")
            {
                DbName = "subrubrica7",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica8", "decimal(0)")
            {
                DbName = "subrubrica8",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica9", "decimal(0)")
            {
                DbName = "subrubrica9",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica10", "decimal(0)")
            {
                DbName = "subrubrica10",
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
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT reperto_parcial.reperto_parcial,
       reperto_parcial.capitulo,
       reperto_parcial.rubrica,
       reperto_parcial.subrubrica,
       reperto_parcial.subrubrica2,
       reperto_parcial.subrubrica3,
       reperto_parcial.subrubrica4,
       reperto_parcial.subrubrica5,
       reperto_parcial.subrubrica6,
       reperto_parcial.subrubrica7,
       reperto_parcial.subrubrica8,
       reperto_parcial.subrubrica9,
       reperto_parcial.subrubrica10,
       'S' seleccionado
  FROM reperto_parcial
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"reperto_parcial";

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
