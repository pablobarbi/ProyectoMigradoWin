using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_sub_modulos_x_perfil : IDataWindowMetadata
    {
        public string DataObject => "d_sub_modulos_x_perfil";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("submodulo", "char(18)")
            {
                DbName = "submodulo",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("nombre", "char(40)")
            {
                DbName = "acc_submodulos.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("acc_operaciones_x_modulo_modulo", "char(5)")
            {
                DbName = "acc_operaciones_x_modulo.modulo",
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
SELECT DISTINCT acc_operaciones_x_modulo.modulo || '********' || acc_operaciones_x_modulo.submodulo as submodulo,
       acc_submodulos.nombre,
       acc_operaciones_x_modulo.modulo
  FROM acc_submodulos,
       acc_operaciones_x_modulo,
       acc_modulos_x_perfil
 WHERE acc_operaciones_x_modulo.submodulo = acc_submodulos.submodulo
   AND acc_operaciones_x_modulo.modulo = acc_modulos_x_perfil.modulo
   AND acc_modulos_x_perfil.perfil = :perfil 
"" arguments=((""perfil"", string))  sort=""submodulo A
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
