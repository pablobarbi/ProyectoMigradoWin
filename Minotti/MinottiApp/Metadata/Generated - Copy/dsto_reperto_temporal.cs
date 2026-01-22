using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dsto_reperto_temporal : IDataWindowMetadata
    {
        public string DataObject => "dsto_reperto_temporal";

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
                TabOrder = 32766,
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
                DbName = "reperto_parcial.subrubrica2",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica3", "decimal(0)")
            {
                DbName = "reperto_parcial.subrubrica3",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica4", "decimal(0)")
            {
                DbName = "reperto_parcial.subrubrica4",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica5", "decimal(0)")
            {
                DbName = "reperto_parcial.subrubrica5",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica6", "decimal(0)")
            {
                DbName = "reperto_parcial.subrubrica6",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica7", "decimal(0)")
            {
                DbName = "reperto_parcial.subrubrica7",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica8", "decimal(0)")
            {
                DbName = "reperto_parcial.subrubrica8",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica9", "decimal(0)")
            {
                DbName = "reperto_parcial.subrubrica9",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica10", "decimal(0)")
            {
                DbName = "reperto_parcial.subrubrica10",
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
SELECT reperto_parcial, capitulo, rubrica, subrubrica, subrubrica2, subrubrica3, subrubrica4, subrubrica5, subrubrica6, subrubrica7, subrubrica8, subrubrica9, subrubrica10
	FROM reperto_parcial
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"reperto_parcial";

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
