using System;
using System.Collections.Generic;
using Minotti.Metadata;

namespace Minotti.Metadata.Generated
{
    public class dr_pacientes : IDataWindowMetadata
    {
        public string DataObject => "dr_pacientes";

        public List<DataWindowColumn> Columns => new()
        {
            new DataWindowColumn("paciente", "long")
            {
                DbName = "pacientes.paciente",
                EsClave = true,
                EsClavePrimaria = true,
                EsIdentity = true,
                UpdateWhereClause = true,
                EsRequerido = false,
            },
            new DataWindowColumn("nombre", "char(50)")
            {
                DbName = "pacientes.nombre",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("domicilio", "char(50)")
            {
                DbName = "pacientes.domicilio",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("telefono", "char(15)")
            {
                DbName = "pacientes.telefono",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("sexo", "char(1)")
            {
                DbName = "pacientes.sexo",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("fecha_nacimiento", "date")
            {
                DbName = "pacientes.fecha_nacimiento",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("ultima_visita", "date")
            {
                DbName = "pacientes.ultima_visita",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("ocupacion", "char(50)")
            {
                DbName = "pacientes.ocupacion",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("estado_civil", "long")
            {
                DbName = "pacientes.estado_civil",
                EsClave = false,
                EsClavePrimaria = false,
                EsIdentity = false,
                UpdateWhereClause = true,
                EsRequerido = false,
                TabOrder = 32766,
            },
            new DataWindowColumn("cantidad_hijos", "long")
            {
                DbName = "pacientes.cantidad_hijos",
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
SELECT pacientes.paciente,
       pacientes.nombre,
       pacientes.domicilio,
       pacientes.telefono,
       pacientes.sexo,
       pacientes.fecha_nacimiento,
       pacientes.ultima_visita,
       pacientes.ocupacion,
       pacientes.estado_civil,
       pacientes.cantidad_hijos
  FROM pacientes
 WHERE (pacientes.paciente = :paciente) OR (:paciente = '0')
";

        // Aliases (compatibilidad)
        public string sql => Sql;
        public string SQL => Sql;

        // PB: table.update (puede venir vacío en DW read-only)
        public string Update => @"pacientes";

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
