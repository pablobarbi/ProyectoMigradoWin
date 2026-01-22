using System;
using System.Collections.Generic;

namespace Minotti.Metadata
{
    public interface IDataWindowMetadata
    {
        string DataObject { get; }
        List<DataWindowColumn> Columns { get; }

        // PB: table.retrieve
        string Sql { get; }

        // PB: table.update
        string Update { get; }

        // PB: table.updatewhere (0/1)
        int UpdateWhere { get; }

        // PB: table.updatekeyinplace (yes/no)
        bool UpdateKeyInPlace { get; }

        string[] Estilos { get; }
        string[] SeleccionFila { get; }
        string Operaciones { get; }
        bool UsaUsuario { get; }
        bool UsaFecha { get; }
    }

    public class DataWindowColumn
    {
        public DataWindowColumn() { }

        public DataWindowColumn(string nombre, string tipo)
        {
            Nombre = nombre;
            Tipo = tipo;
        }

        public string Nombre { get; set; } = string.Empty;

        // PB: table.column.dbname
        public string DbName { get; set; } = string.Empty;

        // PB: table.column.type  (char(40), long, decimal, etc.)
        public string Tipo { get; set; } = string.Empty;

        public string Titulo { get; set; } = string.Empty;

        // PB: table.column.key=yes
        public bool EsClave { get; set; } = false;

        // Compat (si tu lógica lo usa)
        public bool EsClavePrimaria { get; set; } = false;

        // PB: table.column.identity=yes
        public bool EsIdentity { get; set; } = false;

        // PB: table.column.updatewhereclause=yes
        public bool UpdateWhereClause { get; set; } = false;

        // PB: edit.required / ddlb.required / dddw.required / editmask.required
        public bool EsRequerido { get; set; } = false;

        public string? ObjetoSeleccion { get; set; } = null;
        public string? Operacion { get; set; } = null;
        public string? NivelOperacion { get; set; } = null;
        public int? TabOrder { get; set; } = null;

        // Si después querés mapear valores tipo DDLB (Values=)
        public string[] Valores { get; set; } = Array.Empty<string>();
    }
}
