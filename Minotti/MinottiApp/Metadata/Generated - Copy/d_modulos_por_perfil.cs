using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_modulos_por_perfil : IDataWindowMetadata
    {
        public string DataObject => "d_modulos_por_perfil";

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
                TabOrder = 20,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT dba.acc_modulos_x_perfil.perfil,
       dba.acc_modulos_x_perfil.modulo
  FROM dba.acc_modulos_x_perfil
 WHERE dba.acc_modulos_x_perfil.perfil = :perfil
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
