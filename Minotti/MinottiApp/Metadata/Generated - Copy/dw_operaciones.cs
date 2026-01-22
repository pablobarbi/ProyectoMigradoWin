using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dw_operaciones : IDataWindowMetadata
    {
        public string DataObject => "dw_operaciones";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("operacion", "char(5)")
            {
                DbName = "acc_operaciones.operacion",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("nombre", "char(30)")
            {
                DbName = "acc_operaciones.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT dba.acc_operaciones.operacion,
       dba.acc_operaciones.nombre
  FROM dba.acc_operaciones
 ORDER BY dba.acc_operaciones.nombre
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"acc_operaciones";

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
