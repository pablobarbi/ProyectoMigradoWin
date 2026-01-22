using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dks_modulos_no_estan_perfil : IDataWindowMetadata
    {
        public string DataObject => "dks_modulos_no_estan_perfil";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("modulo", "char(8)")
            {
                DbName = "acc_modulos.modulo",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 0,
            },
            new DataWindowColumn("nombre", "char(40)")
            {
                DbName = "acc_modulos.nombre",
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
SELECT dba.acc_modulos.modulo,   
         dba.acc_modulos.nombre  
    FROM dba.acc_modulos

         
   WHERE NOT EXISTS (SELECT ''  
                     FROM dba.acc_modulos_perfil
                     WHERE dba.acc_modulos_perfil.perfil = :perf AND  
                     dba.acc_modulos_perfil.modulo = dba.acc_modulos.modulo)
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"dba.acc_modulos";

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
