using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dsto_actualiza_subrubricacion_med : IDataWindowMetadata
    {
        public string DataObject => "dsto_actualiza_subrubricacion_med";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("subrubrica_padre", "decimal(0)")
            {
                DbName = "subrubricacion_med.subrubrica_padre",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("subrubrica_hija", "decimal(0)")
            {
                DbName = "subrubricacion_med.subrubrica_hija",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("medicamento", "char(10)")
            {
                DbName = "subrubricacion_med.medicamento",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("valor", "long")
            {
                DbName = "subrubricacion_med.valor",
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
SELECT subrubricacion_med.subrubrica_padre,
       subrubricacion_med.subrubrica_hija,
       subrubricacion_med.medicamento,
       subrubricacion_med.valor
  FROM subrubricacion_med
WHERE subrubricacion_med.subrubrica_padre = :padre
 AND   subrubricacion_med.subrubrica_hija = :hija
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"subrubricacion_med";

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
