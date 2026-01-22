using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_modulos_x_perfil : IDataWindowMetadata
    {
        public string DataObject => "d_modulos_x_perfil";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("modulo", "char(5)")
            {
                DbName = "acc_modulos.modulo",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("nombre", "char(20)")
            {
                DbName = "acc_modulos.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("perfil", "char(5)")
            {
                DbName = "acc_modulos_x_perfil.perfil",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT DISTINCT dba.acc_modulos.modulo, 
                dba.acc_modulos.nombre, 
                dba.acc_modulos_x_perfil.perfil 
           FROM dba.acc_modulos, 
                dba.acc_modulos_x_perfil 
          WHERE dba.acc_modulos.modulo = dba.acc_modulos_x_perfil.modulo 
            AND dba.acc_modulos_x_perfil.perfil = :perfil 
          ORDER BY dba.acc_modulos.modulo"" arguments=((""perfil"", string))  sort=""modulo A
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
