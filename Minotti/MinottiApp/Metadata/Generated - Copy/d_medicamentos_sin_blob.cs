using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class d_medicamentos_sin_blob : IDataWindowMetadata
    {
        public string DataObject => "d_medicamentos_sin_blob";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("medicamento", "char(10)")
            {
                DbName = "medicamentos.medicamento",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = true,
                TabOrder = 10,
            },
            new DataWindowColumn("descripcion", "char(50)")
            {
                DbName = "medicamentos.descripcion",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = true,
                TabOrder = 20,
            },
            new DataWindowColumn("observaciones", "char(255)")
            {
                DbName = "medicamentos.observaciones",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 30,
            },
            new DataWindowColumn("imagen_asociada", "char(255)")
            {
                DbName = "medicamentos.imagen_asociada",
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
SELECT medicamentos.medicamento,
       medicamentos.descripcion,
       medicamentos.observaciones,
       medicamentos.imagen_asociada
  FROM medicamentos
 WHERE medicamentos.medicamento = :medicamento
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"medicamentos";

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
