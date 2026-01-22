using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_operaciones_x_perfil : IDataWindowMetadata
    {
        public string DataObject => "d_operaciones_x_perfil";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("operacion", "char(5)")
            {
                DbName = "acc_operaciones.operacion",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("nombre", "char(30)")
            {
                DbName = "acc_operaciones.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("modulo", "char(5)")
            {
                DbName = "acc_operaciones_x_modulo.modulo",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT DISTINCT dba.acc_operaciones.operacion, 
                dba.acc_operaciones.nombre, 
                dba.acc_operaciones_x_modulo.modulo 
           FROM dba.acc_modulos_x_perfil, 
                dba.acc_operaciones_x_modulo, 
                dba.acc_operaciones 
          WHERE dba.acc_operaciones_x_modulo.operacion = dba.acc_operaciones.operacion 
            AND dba.acc_operaciones_x_modulo.modulo = dba.acc_modulos_x_perfil.modulo 
            AND dba.acc_modulos_x_perfil.perfil = :perfil 
          ORDER BY dba.acc_operaciones_x_modulo.modulo, 
                   dba.acc_operaciones.operacion"" arguments=((""perfil"", string))  sort=""modulo A operacion A
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
