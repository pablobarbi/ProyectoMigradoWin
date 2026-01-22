using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class duo_capitulo_completo : IDataWindowMetadata
    {
        public string DataObject => "duo_capitulo_completo";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("capitulo", "decimal(0)")
            {
                DbName = "capitulacion_med.capitulo",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("capitulo_nombre", "char(255)")
            {
                DbName = "capitulos.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("rubrica", "decimal(0)")
            {
                DbName = "rubricas.rubrica",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = true,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("rubrica_nombre", "char(255)")
            {
                DbName = "rubricas.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica01", "decimal(0)")
            {
                DbName = "subrubricas.subrubrica01",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = true,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica01_nombre", "char(255)")
            {
                DbName = "subrubricas.subrubrica01_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica02", "decimal(0)")
            {
                DbName = "subrubricas.subrubrica02",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = true,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica02_nombre", "char(255)")
            {
                DbName = "subrubricas.subrubrica02_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica03", "decimal(0)")
            {
                DbName = "subrubricas.subrubrica03",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = true,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica03_nombre", "char(255)")
            {
                DbName = "subrubricas.subrubrica03_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica04", "decimal(0)")
            {
                DbName = "subrubricas.subrubrica04",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = true,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica04_nombre", "char(255)")
            {
                DbName = "subrubricas.subrubrica04_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica05", "decimal(0)")
            {
                DbName = "subrubricas.subrubrica05",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = true,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica05_nombre", "char(255)")
            {
                DbName = "subrubricas.subrubrica05_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica06", "decimal(0)")
            {
                DbName = "subrubricas.subrubrica06",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = true,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica06_nombre", "char(255)")
            {
                DbName = "subrubricas.subrubrica06_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica07", "decimal(0)")
            {
                DbName = "subrubricas.subrubrica07",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = true,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica07_nombre", "char(255)")
            {
                DbName = "subrubricas.subrubrica07_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica08", "decimal(0)")
            {
                DbName = "subrubricas.subrubrica08",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = true,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica08_nombre", "char(255)")
            {
                DbName = "subrubricas.subrubrica08_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica09", "decimal(0)")
            {
                DbName = "subrubricas.subrubrica09",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = true,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica09_nombre", "char(255)")
            {
                DbName = "subrubricas.subrubrica09_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica10", "decimal(0)")
            {
                DbName = "subrubricas.subrubrica10",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = true,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica10_nombre", "char(255)")
            {
                DbName = "subrubricas.subrubrica10_nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("medicamento", "char(10)")
            {
                DbName = "capitulacion_med.medicamento",
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
SELECT capitulacion_med.capitulo,
         capitulos.nombre,
         rubricas.rubrica,
         rubricas.nombre,
         subrubricas.subrubrica AS subrubrica01,
         subrubricas.nombre  AS subrubrica01_nombre,
         subrubricas.subrubrica AS subrubrica02,
         subrubricas.nombre  AS subrubrica02_nombre,
         subrubricas.subrubrica AS subrubrica03,
         subrubricas.nombre  AS subrubrica03_nombre,
         subrubricas.subrubrica AS subrubrica04,
         subrubricas.nombre  AS subrubrica04_nombre,
         subrubricas.subrubrica AS subrubrica05,
         subrubricas.nombre  AS subrubrica05_nombre,
         subrubricas.subrubrica AS subrubrica06,
         subrubricas.nombre  AS subrubrica06_nombre,
         subrubricas.subrubrica AS subrubrica07,
         subrubricas.nombre  AS subrubrica07_nombre,
         subrubricas.subrubrica AS subrubrica08,
         subrubricas.nombre  AS subrubrica08_nombre,
         subrubricas.subrubrica AS subrubrica09,
         subrubricas.nombre  AS subrubrica09_nombre,
         subrubricas.subrubrica AS subrubrica10,
         subrubricas.nombre  AS subrubrica10_nombre,
         capitulacion_med.medicamento,
         capitulacion_med.valor
    FROM capitulacion_med,
         capitulos,
         rubricas,
         subrubricas
   WHERE capitulacion_med.capitulo = capitulos.capitulo
     AND capitulacion_med.rubrica = rubricas.rubrica
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
