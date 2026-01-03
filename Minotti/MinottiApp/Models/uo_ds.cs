using System;
using System.Data;

namespace Minotti.Models
{
    /// <summary>
    /// Emulación sencilla de uo_ds (DataStore) de PowerBuilder.
    /// Mantiene nombres de métodos: RowCount, GetItemNumber, GetItemString, InsertRow,
    /// SetItem, SetFilter, Filter, RowsCopy, uof_SetDataObject, uof_Retrieve, etc.
    /// Internamente usa un DataTable + DataView.
    /// </summary>
    public class uo_ds : IDisposable
    {
        // Nombre del DataWindow/DataObject asociado (duo_capitulaciones, etc.)
        public string dataobject { get; private set; } = string.Empty;

        private readonly DataTable _table = new DataTable();
        private string _filter = string.Empty;

        // Vista que respeta el filtro (equivalente a Filter() en PB)
        private DataView View => _table.DefaultView;

        public uo_ds()
        {
        }

        /// <summary>
        /// Compatibilidad con PB: SetTransObject(SQLCA).
        /// En C# no usamos el trans directamente porque SQLCA es estático, así que es NO-OP.
        /// </summary>
        public void SetTransObject(object? sqlca)
        {
            // Intencionalmente vacío.
        }

        /// <summary>
        /// Compatibilidad con PB: uof_SetDataObject('duo_xxx')
        /// Sólo guarda el nombre. La lógica de Retrieve real se puede implementar después.
        /// </summary>
        public void uof_SetDataObject(string as_dataobject)
        {
            dataobject = as_dataobject ?? string.Empty;
        }

        /// <summary>
        /// Equivalente a RowCount() de PB. Respeta el filtro (View).
        /// </summary>
        public int RowCount()
        {
            return View.Count;
        }

        /// <summary>
        /// Equivalente a Reset() de PB.
        /// </summary>
        public void Reset()
        {
            _table.Clear();
        }

        /// <summary>
        /// Equivalente a GetItemNumber( row, column ) de PB.
        /// Usa índices 1-based como PB.
        /// </summary>
        public double GetItemNumber(int row, string column)
        {
            if (row < 1 || row > View.Count)
                return 0;

            var value = View[row - 1][column];
            if (value == null || value == DBNull.Value)
                return 0;

            return Convert.ToDouble(value);
        }

        /// <summary>
        /// Equivalente a GetItemString( row, column ) de PB.
        /// Usa índices 1-based como PB.
        /// </summary>
        public string GetItemString(int row, string column)
        {
            if (row < 1 || row > View.Count)
                return string.Empty;

            var value = View[row - 1][column];
            if (value == null || value == DBNull.Value)
                return string.Empty;

            return Convert.ToString(value) ?? string.Empty;
        }

        /// <summary>
        /// Equivalente a InsertRow( row ) de PB.
        /// row = 0 o fuera de rango => inserta al final.
        /// Devuelve el índice 1-based de la nueva fila (en la vista sin orden).
        /// </summary>
        public int InsertRow(int row)
        {
            var newRow = _table.NewRow();

            int insertIndex;
            if (row <= 0 || row > _table.Rows.Count)
                insertIndex = _table.Rows.Count;
            else
                insertIndex = row - 1;

            _table.Rows.InsertAt(newRow, insertIndex);

            // Reaplicar filtro actual por si lo hubiera
            View.RowFilter = _filter ?? string.Empty;

            // Devolvemos 1-based index (suponiendo sin sort)
            return insertIndex + 1;
        }

        /// <summary>
        /// Equivalente a SetItem( row, column, value ) de PB.
        /// </summary>
        public void SetItem(int row, string column, object? value)
        {
            if (row < 1 || row > View.Count)
                return;

            var viewRow = View[row - 1];
            var dataRow = viewRow.Row;

            if (!_table.Columns.Contains(column))
            {
                var type = value?.GetType() ?? typeof(string);
                _table.Columns.Add(column, type);
            }

            dataRow[column] = value ?? DBNull.Value;
        }

        /// <summary>
        /// Equivalente a SetFilter( expression ) de PB.
        /// </summary>
        public void SetFilter(string expression)
        {
            _filter = expression ?? string.Empty;
        }

        /// <summary>
        /// Equivalente a Filter() de PB: aplica RowFilter sobre la vista.
        /// </summary>
        public void Filter()
        {
            View.RowFilter = _filter ?? string.Empty;
        }

        /// <summary>
        /// Equivalente a RowsCopy( start, end, Primary!, ds_destino, pos_destino, Primary! ).
        /// Ignoramos los buffers (Primary!, etc.) porque no aplican en DataTable.
        /// Respeta el RowFilter actual de origen y destino.
        /// </summary>
        public void RowsCopy(int startRow, int endRow, object fromBuffer, uo_ds target, int targetStartRow, object toBuffer)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            if (startRow < 1)
                startRow = 1;
            if (endRow > RowCount())
                endRow = RowCount();

            for (int i = startRow; i <= endRow; i++)
            {
                var srcViewRow = View[i - 1];
                var srcDataRow = srcViewRow.Row;

                int targetRowIndex = target.InsertRow(targetStartRow);
                var targetViewRow = target.View[targetRowIndex - 1];
                var targetDataRow = targetViewRow.Row;

                // Asegurar columnas en destino
                foreach (DataColumn col in _table.Columns)
                {
                    if (!target._table.Columns.Contains(col.ColumnName))
                        target._table.Columns.Add(col.ColumnName, col.DataType);

                    targetDataRow[col.ColumnName] = srcDataRow[col.ColumnName];
                }
            }
        }

        /// <summary>
        /// Stub de uof_Retrieve para compatibilidad.
        /// Por ahora sólo hace Reset(). La lógica real de SELECT se puede
        /// implementar más adelante mapeando dataobject a SQL y usando Minotti.Data.SQLCA.
        /// </summary>
        public void uof_Retrieve(params string[] as_param)
        {
            // TODO: implementar SELECT real según "dataobject" usando Minotti.Data.SQLCA
            _table.Clear();
        }

        /// <summary>
        /// Devuelve el DataTable interno por si necesitás bindearlo a controles.
        /// </summary>
        public DataTable AsDataTable()
        {
            return _table;
        }

        /// <summary>
        /// Para que se pueda llamar ds.Dispose() como en PB DESTROY.
        /// </summary>
        public void Dispose()
        {
            _table.Dispose();
        }
    }
}
