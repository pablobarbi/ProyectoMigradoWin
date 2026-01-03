using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace Minotti
{
    /// <summary>
    /// Migración de SRD: r_summary.srd
    /// Incluye SELECT extraído del SRD.
    /// Se preservan los nombres de columnas 1:1.
    /// </summary>
    public class r_summary
    {
        public const string DataWindowName = "r_summary";
        public const string SELECT_SQL = @"SELECT count(*) FROM dba.acc_usuarios";

        // Modelo de fila (nombres PB)
        public class Row
        {
            // (Sin columnas definidas en el SRD)
            // Si más adelante el SRD trae column(name=..., type=...), se agregan aquí 1:1.
        }

        private readonly List<Row> _rows = new();
        public IReadOnlyList<Row> rows => _rows;

        public void Reset() => _rows.Clear();

        public void InsertRow(Row r) => _rows.Add(r);

        public DataTable ToDataTable()
        {
            var dt = new DataTable(DataWindowName);
            // No hay columnas en el SRD; exporta filas vacías si existieran en el buffer.
            foreach (var _ in _rows)
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
            foreach (DataRow _ in dt.Rows)
            {
                var row = new Row();
                _rows.Add(row);
            }
            return _rows.Count;
        }
    }
}
