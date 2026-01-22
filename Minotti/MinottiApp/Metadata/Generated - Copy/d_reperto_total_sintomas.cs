using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_reperto_total_sintomas : IDataWindowMetadata
    {
        public string DataObject => "d_reperto_total_sintomas";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("reperto_total_reperto_total", "decimal(0)")
            {
                DbName = "reperto_total.reperto_total",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("reperto_total_reperto_sintoma", "decimal(0)")
            {
                DbName = "reperto_total.reperto_sintoma",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("reperto_total_orden", "long")
            {
                DbName = "reperto_total.orden",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("reperto_total_sin_capitulo", "decimal(0)")
            {
                DbName = "reperto_total_sin.capitulo",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("reperto_total_sin_rubrica", "decimal(0)")
            {
                DbName = "reperto_total_sin.rubrica",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("reperto_total_sin_subrubrica", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("reperto_total_sin_subrubrica2", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica2",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("reperto_total_sin_subrubrica3", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica3",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("reperto_total_sin_subrubrica4", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica4",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("reperto_total_sin_subrubrica5", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica5",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("reperto_total_sin_subrubrica6", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica6",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("reperto_total_sin_subrubrica7", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica7",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("reperto_total_sin_subrubrica8", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica8",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("reperto_total_sin_subrubrica9", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica9",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("reperto_total_sin_subrubrica10", "decimal(0)")
            {
                DbName = "reperto_total_sin.subrubrica10",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("subrubricas_nombre", "char(255)")
            {
                DbName = "subrubricas.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubricas_nombre", "char(255)")
            {
                DbName = "subrubricas.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubricas_nombre", "char(255)")
            {
                DbName = "subrubricas.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubricas_nombre", "char(255)")
            {
                DbName = "subrubricas.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubricas_nombre", "char(255)")
            {
                DbName = "subrubricas.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubricas_nombre", "char(255)")
            {
                DbName = "subrubricas.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubricas_nombre", "char(255)")
            {
                DbName = "subrubricas.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubricas_nombre", "char(255)")
            {
                DbName = "subrubricas.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubricas_nombre", "char(255)")
            {
                DbName = "subrubricas.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubricas_nombre", "char(255)")
            {
                DbName = "subrubricas.nombre",
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

";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"";

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
