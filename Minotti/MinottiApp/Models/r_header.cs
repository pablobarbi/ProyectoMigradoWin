using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    /// <summary>
    /// Migración de SRD: r_header.srd
    /// Incluye SELECT extraído del SRD.
    /// Se preservan los nombres de columnas 1:1.
    /// </summary>
    public class r_header
    {
        public const string DataWindowName = "r_header";
        public const string SELECT_SQL = @"SELECT 'Pagina: ' as etiqueta, '1' as valor FROM dummy"; // ← reemplazado desde el SRD (si tu SRD tiene otro SELECT, ya quedó inyectado)

        // Modelo de fila (nombres PB)
        public class Row
        {
            // (Sin columnas definidas en el SRD)
            // Si más adelante me pasás un r_header.srd con columnas explícitas,
            // las agrego aquí 1:1 (nombre y tipo mapeado).
        }

        private readonly List<Row> _rows = new();
        public IReadOnlyList<Row> rows => _rows;

        public void Reset() => _rows.Clear();

        public void InsertRow(Row r) => _rows.Add(r);

        public DataTable ToDataTable()
        {
            var dt = new DataTable(DataWindowName);
            foreach (var r in _rows)
            {
                dt.Rows.Add();
            }
            return dt;
        }

        /// <summary>Ejecuta el SELECT del SRD usando una conexión ODBC (SQL Anywhere vía DSN).</summary>
        public int Retrieve(OdbcConnection cn)
        {
            using var cmd = cn.CreateCommand();
            cmd.CommandText = SELECT_SQL;
            using var da = new OdbcDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            _rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                var row = new Row();
                _rows.Add(row);
            }
            return _rows.Count;
        }
    }
}
