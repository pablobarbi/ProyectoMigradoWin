using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dr_pacientes_historia_clinica : IDataWindowMetadata
    {
        public string DataObject => "dr_pacientes_historia_clinica";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("paciente", "long")
            {
                DbName = "pacientes_historias.paciente",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("hist_clin", "char(32766)")
            {
                DbName = "pacientes_historias.hist_clin",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = false,
                EsRequerido = false,
                TabOrder = 10,
            }
        };

        // PB: table.retrieve
        public string Sql => @"
SELECT pacientes_historias.paciente,
       pacientes_historias.hist_clin
  FROM pacientes_historias
 WHERE pacientes_historias.paciente = :paciente
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"pacientes_historias";

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
