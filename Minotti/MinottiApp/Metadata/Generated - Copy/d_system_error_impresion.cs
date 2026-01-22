using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_system_error_impresion : IDataWindowMetadata
    {
        public string DataObject => "d_system_error_impresion";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("nro_error", "long")
            {
                DbName = "errores_sistema.nro_error",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("fecha_hora", "datetime")
            {
                DbName = "errores_sistema.fecha_hora",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("lugar", "char(255)")
            {
                DbName = "errores_sistema.lugar",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("evento", "char(255)")
            {
                DbName = "errores_sistema.evento",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("objeto", "char(255)")
            {
                DbName = "errores_sistema.objeto",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("linea_script", "long")
            {
                DbName = "errores_sistema.linea_script",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("mensaje_error", "char(255)")
            {
                DbName = "errores_sistema.mensaje_error",
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
SELECT dba.errores_sistema.nro_error,   
			dba.errores_sistema.fecha_hora,   
         dba.errores_sistema.lugar,   
         dba.errores_sistema.evento,   
         dba.errores_sistema.objeto,   
         dba.errores_sistema.linea_script,   
			dba.errores_sistema.mensaje_error  
    FROM dba.errores_sistema
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"dba.errores_sistema";

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
