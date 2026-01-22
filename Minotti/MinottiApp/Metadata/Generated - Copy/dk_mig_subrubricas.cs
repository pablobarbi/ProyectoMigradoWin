using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dk_mig_subrubricas : IDataWindowMetadata
    {
        public string DataObject => "dk_mig_subrubricas";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("capitulo", "number")
            {
                DbName = "mig_subrubricas.capitulo",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 10,
            },
            new DataWindowColumn("padre", "number")
            {
                DbName = "mig_subrubricas.padre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 20,
            },
            new DataWindowColumn("codigo", "number")
            {
                DbName = "mig_subrubricas.codigo",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 30,
            },
            new DataWindowColumn("descripcio", "char(255)")
            {
                DbName = "mig_subrubricas.descripcio",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 40,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT mig_subrubricas.capitulo,
       mig_subrubricas.padre,
       mig_subrubricas.codigo,
       mig_subrubricas.descripcio
  FROM mig_subrubricas
""  sort=""codigo A
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
