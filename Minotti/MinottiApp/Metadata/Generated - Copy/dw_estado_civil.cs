using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dw_estado_civil : IDataWindowMetadata
    {
        public string DataObject => "dw_estado_civil";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("estado_civil", "decimal(0)")
            {
                DbName = "mdp_estado_civil.estado_civil",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = true,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("descripcion", "char(40)")
            {
                DbName = "mdp_estado_civil.descripcion",
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
SELECT mdp_estado_civil.estado_civil,
       mdp_estado_civil.descripcion
  FROM mdp_estado_civil
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"mdp_estado_civil";

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
