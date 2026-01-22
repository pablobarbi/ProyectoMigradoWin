using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dk_rubricas_del_capitulo : IDataWindowMetadata
    {
        public string DataObject => "dk_rubricas_del_capitulo";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("capitulaciones_capitulo", "decimal(0)")
            {
                DbName = "capitulaciones.capitulo",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("capitulaciones_rubrica", "decimal(0)")
            {
                DbName = "capitulaciones.rubrica",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("rubricas_nombre", "char(255)")
            {
                DbName = "rubricas.nombre",
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
SELECT capitulaciones.capitulo,
       capitulaciones.rubrica,
       rubricas.nombre
  FROM capitulaciones,
       rubricas
 WHERE capitulaciones.rubrica = rubricas.rubrica
   AND capitulaciones.capitulo = :capitulo    
 ORDER BY rubricas.nombre
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"capitulaciones";

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
