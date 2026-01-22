using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dk_subrubricas_de_la_rubrica : IDataWindowMetadata
    {
        public string DataObject => "dk_subrubricas_de_la_rubrica";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("rubricaciones_rubrica", "decimal(0)")
            {
                DbName = "rubricaciones.rubrica",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("rubricaciones_subrubrica", "decimal(0)")
            {
                DbName = "rubricaciones.subrubrica",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("rubricaciones_posicion", "long")
            {
                DbName = "rubricaciones.posicion",
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
            new DataWindowColumn("subrubricas_nombre_orden", "char(259)")
            {
                DbName = "subrubricas_nombre_orden",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT rubricaciones.rubrica,
       rubricaciones.subrubrica,
       rubricaciones.posicion,
       subrubricas.nombre,
CASE
WHEN substr(subrubricas.nombre,1,11)='-EN GENERAL' THEN 'A A' ||
subrubricas.nombre
WHEN substr(subrubricas.nombre,1,1)='-' THEN 'A B' || subrubricas.nombre
WHEN substr(subrubricas.nombre,1,1)='_' THEN 'A C' || subrubricas.nombre
WHEN substr(subrubricas.nombre,1,1) between '0' and '9' and
substr(subrubricas.nombre,2,1) ='-' THEN 'A D' || '0' ||
subrubricas.nombre
WHEN substr(subrubricas.nombre,1,1) between '0' and '9' THEN 'A D' ||
subrubricas.nombre
WHEN substr(subrubricas.nombre,1,1) ='#' THEN 'ZZC' || subrubricas.nombre
WHEN substr(subrubricas.nombre,1,1)='*' THEN 'ZZD' || subrubricas.nombre
ELSE subrubricas.nombre
END as subrubricas_nombre_orden
  FROM rubricaciones,
       subrubricas
 WHERE rubricaciones.subrubrica = subrubricas.subrubrica
   AND rubricaciones.rubrica = :rubrica
ORDER BY 5
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"rubricaciones";

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
