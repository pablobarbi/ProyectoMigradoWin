using System;
using System.Collections.Generic;
using System.Data;

namespace Minotti
{
    /// <summary>
    /// Migración de SRD: d_saveas.srd
    /// DataWindow sin SELECT (estructura en memoria) con columnas:
    ///   - columnname   (char(50))
    ///   - displayname  (char(10))
    ///   - use_display  (char(1))
    /// Se mantiene el nombre del archivo y de los campos internos.
    /// </summary>
    public class d_saveas
    {
        public const string DataWindowName = "d_saveas";

        // Modelo de fila manteniendo los nombres PB
        public class Row
        {
            public string? columnname { get; set; }
            public string? displayname { get; set; }
            public string? use_display { get; set; } // 'Y'/'N' (char(1))
        }

        // Contenedor de filas (equivalente a DataWindow buffer)
        private readonly List<Row> _rows = new List<Row>();
        public IReadOnlyList<Row> rows => _rows;

        public d_saveas() { }

        /// <summary>Agrega una fila respetando los nombres y tipos PB.</summary>
        public void InsertRow(string? columnname, string? displayname, string? use_display)
        {
            _rows.Add(new Row
            {
                columnname = columnname,
                displayname = displayname,
                use_display = use_display
            });
        }

        /// <summary>Resetea el contenido (equivalente a Reset()).</summary>
        public void Reset()
        {
            _rows.Clear();
        }

        /// <summary>Exporta a DataTable con los mismos nombres de columnas.</summary>
        public DataTable ToDataTable()
        {
            var dt = new DataTable(DataWindowName);
            dt.Columns.Add("columnname", typeof(string));
            dt.Columns.Add("displayname", typeof(string));
            dt.Columns.Add("use_display", typeof(string));

            foreach (var r in _rows)
            {
                dt.Rows.Add(r.columnname, r.displayname, r.use_display);
            }
            return dt;
        }
    }
}
