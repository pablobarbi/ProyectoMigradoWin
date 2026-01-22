using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dl_un_medicamento_un_valor : IDataWindowMetadata
    {
        public string DataObject => "dl_un_medicamento_un_valor";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("capitulo_nombre", "char(255)")
            {
                DbName = "capitulaciones_matriz.capitulo_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("rubrica_nombre", "char(255)")
            {
                DbName = "capitulaciones_matriz.rubrica_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica_nombre", "char(255)")
            {
                DbName = "capitulaciones_matriz.subrubrica_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica01_nombre", "char(255)")
            {
                DbName = "capitulaciones_matriz.subrubrica01_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica02_nombre", "char(255)")
            {
                DbName = "capitulaciones_matriz.subrubrica02_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica03_nombre", "char(255)")
            {
                DbName = "capitulaciones_matriz.subrubrica03_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica04_nombre", "char(255)")
            {
                DbName = "capitulaciones_matriz.subrubrica04_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica05_nombre", "char(255)")
            {
                DbName = "capitulaciones_matriz.subrubrica05_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica06_nombre", "char(255)")
            {
                DbName = "capitulaciones_matriz.subrubrica06_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica07_nombre", "char(255)")
            {
                DbName = "capitulaciones_matriz.subrubrica07_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica08_nombre", "char(255)")
            {
                DbName = "capitulaciones_matriz.subrubrica08_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica09_nombre", "char(255)")
            {
                DbName = "capitulaciones_matriz.subrubrica09_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica10_nombre", "char(255)")
            {
                DbName = "capitulaciones_matriz.subrubrica10_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("valor", "long")
            {
                DbName = "capitulacion_med.valor",
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
