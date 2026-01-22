using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_operaciones : IDataWindowMetadata
    {
        public string DataObject => "d_operaciones";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("operacion", "char(8)")
            {
                DbName = "acc_operaciones.operacion",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 10,
            },
            new DataWindowColumn("nombre", "char(40)")
            {
                DbName = "acc_operaciones.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 20,
            },
            new DataWindowColumn("bitmap", "char(40)")
            {
                DbName = "acc_operaciones.bitmap",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 30,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT 
		dba.acc_operaciones.operacion,   
         dba.acc_operaciones.nombre,   
         dba.acc_operaciones.bitmap  
    from
		dba.acc_operaciones  
   where
		dba.acc_operaciones.operacion = :opera
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"dba.acc_operaciones";

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
