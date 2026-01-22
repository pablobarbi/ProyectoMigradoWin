using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dk_modulos_x_perfil : IDataWindowMetadata
    {
        public string DataObject => "dk_modulos_x_perfil";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("perfil", "char(5)")
            {
                DbName = "acc_modulos_x_perfil.perfil",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("modulo", "char(5)")
            {
                DbName = "acc_modulos_x_perfil.modulo",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("nombre_modulo", "char(20)")
            {
                DbName = "acc_modulos.nombre_modulo",
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
SELECT dba.acc_modulos_x_perfil.perfil,
       dba.acc_modulos_x_perfil.modulo,
       dba.acc_modulos.nombre nombre_modulo
  FROM dba.acc_modulos_x_perfil,
       dba.acc_modulos
 WHERE dba.acc_modulos_x_perfil.modulo = dba.acc_modulos.modulo
   AND dba.acc_modulos_x_perfil.perfil = :perfil
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"dba.acc_modulos_x_perfil";

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
