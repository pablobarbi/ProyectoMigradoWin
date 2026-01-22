using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_carpetas : IDataWindowMetadata
    {
        public string DataObject => "d_carpetas";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("nombre", "char(8)")
            {
                DbName = "acc_carpetas.nombre",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 10,
            },
            new DataWindowColumn("pagina", "long")
            {
                DbName = "acc_carpetas.pagina",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 20,
            },
            new DataWindowColumn("titulo", "char(80)")
            {
                DbName = "acc_carpetas.titulo",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 30,
            },
            new DataWindowColumn("objeto", "char(40)")
            {
                DbName = "acc_carpetas.objeto",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 40,
            },
            new DataWindowColumn("parametros", "char(255)")
            {
                DbName = "acc_carpetas.parametros",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 50,
            },
            new DataWindowColumn("bitmap", "char(40)")
            {
                DbName = "acc_carpetas.bitmap",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 60,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT dba.acc_carpetas.nombre,
       dba.acc_carpetas.pagina,
       dba.acc_carpetas.titulo,
       dba.acc_carpetas.objeto,
       dba.acc_carpetas.parametros,
       dba.acc_carpetas.bitmap
  FROM dba.acc_carpetas
 WHERE dba.acc_carpetas.nombre = :carpeta
 ORDER BY dba.acc_carpetas.pagina ASC
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"dba.acc_carpetas";

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
