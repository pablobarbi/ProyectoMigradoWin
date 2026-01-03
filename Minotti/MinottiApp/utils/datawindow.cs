using Minotti.Structures;
using Minotti.Views.Basicos.Controls;
using Minotti.Views.Reportes.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Minotti.utils
{
    // ======= Enums PB-like =======
    public enum dwbuffer
    {
        Primary,
        Filter,
        Delete
    }

    public enum dwitemstatus
    {
        NotModified,
        DataModified,
        New,
        NewModified
    }

    // PB dwo (DataWindow object)
    public sealed class dwobject
    {
        public string? name { get; set; }
        public string? type { get; set; }
    }

    // ======= DataWindowChild (PB-like) =======
    public class datawindowchild : datawindow
    {
        public datawindowchild() { }
        public datawindowchild(string? syntax) : base(syntax) { }

        // PB: ldwc.SetTransObject(SQLCA)
        public virtual void SetTransObject(object? trans) => _transObject = trans;

        private object? _transObject;
    }

    // ======= DataStore (PB-like) =======
    public class datastore : datawindow
    {
        public datastore() { }
        public datastore(string? syntax) : base(syntax) { }

        /// <summary>
        /// PB: Find("campo = 'X'", start, end) -> retorna fila (1-based) o 0 si no encuentra.
        /// </summary>
        public virtual int Find(string expression, long start, long end)
        {
            EnsurePrimaryTable();
            if (_primary == null) return 0;

            if (string.IsNullOrWhiteSpace(expression)) return 0;

            int rowCount = _primary.Rows.Count;
            if (rowCount <= 0) return 0;

            // PB usa 1..RowCount
            int s = (int)start;
            int e = (int)end;

            if (s <= 0) s = 1;
            if (e <= 0) e = rowCount;

            if (s > rowCount) return 0;
            if (e > rowCount) e = rowCount;
            if (e < s) return 0;

            try
            {
                // DataTable.Select usa expresión tipo DataColumn Expression
                // Devuelve DataRow[] sin garantizar orden por índice, así que iteramos en rango.
                for (int r = s; r <= e; r++)
                {
                    var row = _primary.Rows[r - 1];

                    // Evaluamos expression sobre esta fila usando DataView RowFilter:
                    // forma segura sin “inventar” parser PB: clonamos una view y filtramos por PK de la fila.
                    // Pero más simple: usamos Compute no aplica; entonces usamos RowFilter con un DataView
                    // apuntando a la misma tabla, y match por referencia.
                    // => Opción directa: usamos Select(expression) y luego ubicamos el índice.
                }

                // Ruta simple + fiel: Select(expression) y luego buscamos el primer match dentro del rango.
                DataRow[] matches = _primary.Select(expression);
                if (matches == null || matches.Length == 0) return 0;

                for (int r = s; r <= e; r++)
                {
                    var row = _primary.Rows[r - 1];
                    for (int k = 0; k < matches.Length; k++)
                    {
                        if (ReferenceEquals(row, matches[k]))
                            return r; // 1-based
                    }
                }

                return 0;
            }
            catch
            {
                // PB: ante error de expresión normalmente devuelve 0 (o -1 en algunos casos),
                // pero como tu código espera "m > 0", devolvemos 0.
                return 0;
            }
        }

        public virtual long Find(string expression)
        {
            return Find(expression, 1, RowCount());
        }

        public virtual int CopyRow(uo_dw fromDw, int fromRow, int toRow)
        {
            if (fromDw == null)
                return -1;

            if (fromRow <= 0 || fromRow > fromDw.RowCount())
                return -1;

            // Si no hay filas aún, insertar al final
            if (toRow <= 0)
                toRow = RowCount() + 1;

            // Crear una nueva fila en este datastore
            int newRow = InsertRow(toRow);
            if (newRow < 1)
                return -1;

            // Copiar columnas
            for (int col = 1; col <= fromDw.ColumnCount(); col++)
            {
                string colName = fromDw.at_col[col]?.Nombre ?? string.Empty;
                if (string.IsNullOrEmpty(colName))
                    continue;

                object? val = fromDw.GetItemObject(fromRow, colName);
                SetItemObject(newRow, colName, val);
            }

            return 1;
        }

        /// <summary>
        /// PB: RowsCopy(s, e, f, d, i, t)
        /// Copia filas desde este datastore a otro
        /// </summary>
        public virtual int RowsCopy(
            long startRow,
            long endRow,
            dwbuffer fromBuffer,
            datastore dest,
            long insertRow,
            dwbuffer toBuffer)
        {
            if (dest == null) return -1;

            try
            {
                int s = (int)startRow;
                int e = (int)endRow;
                int ins = (int)insertRow;

                if (s <= 0) s = 1;
                if (e < s) return 0;

                if (ins <= 0) ins = 1;

                for (int r = s; r <= e; r++)
                {
                    // PB: CopyRow + InsertRow implícito
                    int newRow = dest.InsertRow(ins);
                    dest.CopyRow(this, r, newRow, toBuffer);
                    ins++;
                }

                return 1;
            }
            catch
            {
                return -1;
            }
        }


        /// <summary>
        /// PB: CopyRow(sourceDW, sourceRow, destRow, buffer)
        /// Copia una fila desde otro datastore a este
        /// </summary>
        public virtual int CopyRow(
            datastore source,
            int sourceRow,
            int destRow,
            dwbuffer buffer)
        {
            if (source == null) return -1;

            try
            {
                // Aseguramos tablas primarias
                source.EnsurePrimaryTable();
                this.EnsurePrimaryTable();

                if (source._primary == null || this._primary == null)
                    return -1;

                if (sourceRow <= 0 || sourceRow > source._primary.Rows.Count)
                    return -1;

                if (destRow <= 0)
                    destRow = this._primary.Rows.Count + 1;

                var src = source._primary.Rows[sourceRow - 1];
                var dst = this._primary.NewRow();

                for (int c = 0; c < this._primary.Columns.Count && c < source._primary.Columns.Count; c++)
                    dst[c] = src[c];

                this._primary.Rows.InsertAt(dst, destRow - 1);

                return destRow;
            }
            catch
            {
                return -1;
            }
        }

        public virtual int CopyRow(datastore source, int sourceRow)
        {
            return CopyRow(source, sourceRow, this.RowCount() + 1, dwbuffer.Primary);
        }

        public virtual int CopyRow(datastore source, int sourceRow, int destRow)
        {
            return CopyRow(source, sourceRow, destRow, dwbuffer.Primary);
        }

        public virtual void SetItemObject(int row, string column, object? value)
        {
            if (row <= 0 || string.IsNullOrEmpty(column))
                return;

            // Si internamente usás DataTable
            if (_primary != null)
            {
                if (row > _primary.Rows.Count)
                    return;

                if (_primary.Columns.Contains(column))
                {
                    _primary.Rows[row - 1][column] = value ?? DBNull.Value;
                }
            }
        }

        // PB-like: uof_retrieve(any)
        public virtual long uof_retrieve(object? arg1)
            => this.Retrieve(arg1);

        public virtual long uof_retrieve(object? arg1, object? arg2)
            => this.Retrieve(arg1, arg2);

        public virtual long uof_retrieve(object? arg1, object? arg2, object? arg3)
            => this.Retrieve(arg1, arg2, arg3);
    }

    /// <summary>
    /// Emulación PB-like de DataWindow. Mantiene API y nombres para que el código migrado compile.
    /// Implementación real: adaptarla luego a tu motor (SQLCA + DataTable/Dapper/etc).
    /// </summary>
    public class datawindow : UserControl
    {
        // (si no lo tenías)
        protected int _currentColumn = 0;
        // (si no lo tenías)
        protected bool _redrawEnabled = true;
        public Control? Control { get; set; }  // Control WinForms asociado (si existe)

        public virtual void SetFocus()
        {
            // PB: si no hay control visual asociado, no hace nada.
            if (Control != null && !Control.IsDisposed && Control.CanFocus)
                Control.Focus();
        }

        public virtual int SetRedraw(bool redraw)
        {
            _redrawEnabled = redraw;
            return 1;
        }
        public virtual int SetColumn(int column)
        {
            // PB: setcolumn(n) posiciona la columna actual para edición/navegación
            _currentColumn = column;
            return 1;
        }

        public virtual int SetColumn(string columnName)
        {
            int col = GetColumnNumber(columnName);
            if (col <= 0) return -1;
            return SetColumn(col);
        }

        // PB: SetTransObject(SQLCA)
        public object? TransObject { get; private set; }

        public virtual void SetTransObject(object? transObject)
        {
            TransObject = transObject;
        }
        public int X
        {
            get => this.Left;
            set => this.Left = value;
        }

        public int Y
        {
            get => this.Top;
            set => this.Top = value;
        }

         

        // PB usa Parent para eventos y navegación.
        // En WinForms, Control.Parent existe y debe ser Control.
        // Acá soportamos ambos:
        public new dynamic Parent { get; set; }
         


        // ======= PB: dw.Object.DataWindow.Syntax =======
        public sealed class DataWindowInner
        {
            public string? Syntax { get; set; }
        }

        public sealed class DataWindowObject
        {
            public DataWindowInner DataWindow { get; } = new DataWindowInner();

            // PB usa: This.Object.DataWindow.Table.Filter
            public DataWindowTable Table { get; } = new DataWindowTable();
        }

        public sealed class DataWindowTable
        {
            public string Filter { get; set; } = string.Empty;
            public string SqlSelect { get; set; } = string.Empty;
        }

        public DataWindowObject Object { get; } = new DataWindowObject();

        public string? Syntax
        {
            get => Object.DataWindow.Syntax;
            set => Object.DataWindow.Syntax = value;
        }

        // ======= Propiedades comunes PB (algunas las usás en uo_dw) =======
        public string DataObject { get; set; } = string.Empty;

        public int width { get; set; }
        public int height { get; set; }

        // ======= Estado interno mínimo =======
        public  DataSet _ds = new DataSet("dw");
        public  DataTable? _primary;
        public  int _currentRow = 0;

        // ======= Eventos PB-like =======
        public event Action<long>? RowFocusChanged;
        public event Func<long, dwobject, string, int>? ItemChanged; // (row, dwo, data) => return int
        public event Func<int>? DBError; // return 1 para "no mostrar"
        public event Action? RetrieveStart;
        public event Action? RetrieveEnd;

        // ======= Constructores =======
        public datawindow() { }
        public datawindow(string? syntax) { Syntax = syntax; }

        // ======= API PB-like (stubs + algunos básicos) =======

        // PB: Describe("DataWindow.Column.Count") etc.
        public virtual string Describe(string expression)
        {
            // Si querés, después lo conectamos a un parser de SRD.
            // Por ahora, devolvemos "?" como PB cuando no existe.
            if (string.Equals(expression, "DataWindow.Objects", StringComparison.OrdinalIgnoreCase))
                return string.Empty;

            if (string.Equals(expression, "DataWindow.Column.Count", StringComparison.OrdinalIgnoreCase))
                return _primary?.Columns.Count.ToString() ?? "0";

            if (string.Equals(expression, "DataWindow.Table.SqlSelect", StringComparison.OrdinalIgnoreCase))
                return Object.Table.SqlSelect ?? string.Empty;

            if (string.Equals(expression, "DataWindow.VerticalScrollMaximum", StringComparison.OrdinalIgnoreCase))
                return "0";

            if (string.Equals(expression, "DataWindow.HorizontoalScrollMaximum", StringComparison.OrdinalIgnoreCase))
                return "0";

            return "?";
        }

        // PB: Modify("col.Border = '5'")
        public virtual int Modify(string expression)
        {
            // Stub: en PB retorna 1 si ok, -1 si error. Acá dejamos 1.
            // Si luego querés soportar Modify real, lo parseamos y aplicamos.
            return 1;
        }

        // PB: SetSort("campo A/D") + Sort()
        public virtual void SetSort(string sortExpression) => _sortExpression = sortExpression;
        public  string _sortExpression = string.Empty;

        public virtual int Sort()
        {
            // Stub: sin engine real.
            // Si tenés DataTable, podés aplicar DefaultView.Sort.
            if (_primary == null) return 0;

            try
            {
                _primary.DefaultView.Sort = _sortExpression;
                _primary = _primary.DefaultView.ToTable();
                return 1;
            }
            catch
            {
                return -1;
            }
            finally
            {
                TriggerRowFocusChanged();
            }
        }

        // PB: SetFilter / Filter()
        public virtual int SetFilter(string filterExpression)
        {
            Object.Table.Filter = filterExpression ?? string.Empty;
            return 1;
        }

        public virtual int Filter()
        {
            if (_primary == null) return 0;

            try
            {
                var dv = _primary.DefaultView;
                dv.RowFilter = Object.Table.Filter ?? string.Empty;
                _primary = dv.ToTable();
                return 1;
            }
            catch
            {
                return -1;
            }
            finally
            {
                TriggerRowFocusChanged();
            }
        }

        // PB: RowCount(), GetRow(), SetRow()
        public virtual int RowCount() => _primary?.Rows.Count ?? 0;
        public virtual int RowCount(dwbuffer buffer)
        {
            return buffer switch
            {
                dwbuffer.Primary => _primary?.Rows.Count ?? 0,                
                _ => 0
            };
        }
        public virtual int GetRow() => _currentRow;
        public virtual void SetRow(int row)
        {
            _currentRow = row;
            TriggerRowFocusChanged();
        }

        // PB: Retrieve(...)
        public virtual long Retrieve(params object?[] args)
        {
            // Stub: el retrieve real depende de tu motor (SQLCA).
            // Mantengo eventos y retorno típico.
            RetrieveStart?.Invoke();

            // No invento SQL: si no hay tabla, queda vacío
            EnsurePrimaryTable();
            _primary!.Clear();

            RetrieveEnd?.Invoke();
            TriggerRowFocusChanged();
            return RowCount();
        }

        // PB: GetItemString/Number/Decimal/Date/DateTime/Time
        public virtual string GetItemString(long row, int column)
        {
            var value = GetItemRaw(row, column);
            return value?.ToString() ?? string.Empty;
        } 
        // PB-like overload: GetItemString(row, "colname")
        public virtual string GetItemString(long row, string columnName)
        {
            int col = this.GetColumnNumber(columnName);
            if (col <= 0) return string.Empty;
            return GetItemString(row, col);
        }

        // PB: GetItemString(row, column, buffer, convertNull)
        public virtual string GetItemString(
            long row,
            string columnName,
            DataWindowBuffer buffer,
            bool convertNull)
        {
            // En esta etapa solo soportamos Primary (PB default)
            if (buffer != DataWindowBuffer.Primary)
                return string.Empty;

            var value = GetItemRaw(row, columnName);

            if (value == null)
                return convertNull ? string.Empty : null!;

            return value.ToString() ?? string.Empty;
        }

        public virtual double GetItemNumber(long row, int column)
        {
            var value = GetItemRaw(row, column);
            if (value == null) return 0;
            return Convert.ToDouble(value);
        }
        // Opcional: helper PB-friendly para cuando en PB es "integer(...)"
        public virtual double GetItemNumber(long row, string columnName)
        {
            int col = GetColumnNumber(columnName);
            if (col <= 0) return 0;
            return GetItemNumber(row, col);
        }

        // Opcional: helper PB-friendly para cuando en PB es "integer(...)"
        public virtual int GetItemNumberInt(long row, string columnName)
        {
            double n = GetItemNumber(row, columnName);
            return (int)n;
        }

        public virtual int GetItemNumberInt(long row, int column)
        {
            double n = GetItemNumber(row, column);
            return (int)n;
        }


        public virtual decimal GetItemDecimal(long row, int column)
        {
            var value = GetItemRaw(row, column);
            if (value == null) return 0m;
            return Convert.ToDecimal(value);
        }

        public virtual decimal GetItemDecimal(long row, string columnName)
        {
            if (string.IsNullOrWhiteSpace(columnName))
                return 0m;

            var value = GetItemRaw(row, columnName);
            if (value == null) return 0m;

            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return 0m;
            }
        }


        public virtual DateTime GetItemDateTime(long row, int column)
        {
            var value = GetItemRaw(row, column);
            if (value == null) return DateTime.MinValue;
            return Convert.ToDateTime(value);
        }

        public virtual DateTime GetItemDate(long row, int column) => GetItemDateTime(row, column).Date;

        public virtual TimeSpan GetItemTime(long row, int column)
        {
            var dt = GetItemDateTime(row, column);
            return dt.TimeOfDay;
        }


        // PB: SetItem(row, col, value)
        public virtual int SetItem(long row, int column, object? value)
        {
            EnsurePrimaryTable();
            if (_primary == null) return -1;

            int r = (int)row;
            if (r <= 0 || r > _primary.Rows.Count) return -1;
            if (column <= 0 || column > _primary.Columns.Count) return -1;

            _primary.Rows[r - 1][column - 1] = value ?? DBNull.Value;
            return 1;
        }

        public virtual int SetItem(long row, string columnName, object? value)
        {
            int col = GetColumnNumber(columnName);
            if (col <= 0) return -1;
            return SetItem(row, col, value);
        }




        // PB: DeleteRow(0) (0 = current en PB muchas veces)
        public virtual int DeleteRow(long row)
        {
            EnsurePrimaryTable();
            if (_primary == null) return -1;

            int r = (int)row;
            if (r == 0) r = _currentRow;
            if (r <= 0 || r > _primary.Rows.Count) return -1;

            _primary.Rows.RemoveAt(r - 1);
            if (_currentRow > RowCount()) _currentRow = RowCount();
            TriggerRowFocusChanged();
            return 1;
        }

        // PB: AcceptText()
        public virtual int AcceptText() => 1;

        // PB: FindRequired(buffer,...)
        public virtual int FindRequired(dwbuffer buffer, ref long row, ref int column, ref string columnName, bool stopOnError)
        {
            // Stub: no valida, devuelve "no encontró faltantes"
            row = 0;
            column = 0;
            columnName = string.Empty;
            return 1;
        }

        // PB: GetChild(nombre_col, ref ldc)
        public virtual int GetChild(string columnName, out datawindowchild child)
        {
            // Stub: devuelve un child vacío para compilar.
            child = new datawindowchild();
            return 1;
        }

        public virtual void SelectRowVoid(long row, bool select) { /* stub */ }

        // PB: SelectRow / IsSelected
        // PB compatible: devuelve int (1 ok, -1 error)
        public virtual int SelectRow(long row, bool select)
        {
            try
            {
                SelectRowVoid(row, select);
                return 1;
            }
            catch
            {
                return -1;
            }
        }

        public virtual bool isSelected(long row) => false;

        // PB: GetText/SetText (texto del editor activo)
        public virtual string GetText() => string.Empty;
        public virtual int SetText(string value) => 1;

        // PB: GetColumnName/GetColumn
        public virtual string GetColumnName() => string.Empty;
        public virtual int GetColumn() => 0;
        // Hook: la base NO asume cómo mapear nombre->índice.
       // uo_dw lo va a implementar usando at_col[] o su diccionario.
        public virtual int GetColumnNumber(string columnName) => -1;

        // PB: GetBandAtPointer / GetObjectAtPointer / PointerX/Y etc (stubs)
        public virtual string GetBandAtPointer() => string.Empty;
        public virtual string GetObjectAtPointer() => string.Empty;
        public virtual int PointerX() => 0;
        public virtual int PointerY() => 0;

        // PB: GetItemStatus/SetItemStatus
        public virtual dwitemstatus GetItemStatus(long row, int column, dwbuffer buffer) => dwitemstatus.NotModified;
        public virtual int SetItemStatus(long row, int column, dwbuffer buffer, dwitemstatus status) => 1;

        // ======= Helpers =======
        public  object? GetItemRaw(long row, int column)
        {
            EnsurePrimaryTable();
            if (_primary == null) return null;

            int r = (int)row;
            if (r <= 0 || r > _primary.Rows.Count) return null;
            if (column <= 0 || column > _primary.Columns.Count) return null;

            var val = _primary.Rows[r - 1][column - 1];
            return val == DBNull.Value ? null : val;
        }

        public object? GetItemRaw(long row, string columnName)
        {
            if (string.IsNullOrWhiteSpace(columnName))
                return null;

            EnsurePrimaryTable();
            if (_primary == null)
                return null;

            int r = (int)row;
            if (r <= 0 || r > _primary.Rows.Count)
                return null;

            // Buscar columna por nombre (PB-style, case-insensitive)
            if (!_primary.Columns.Contains(columnName))
                return null;

            var val = _primary.Rows[r - 1][columnName];
            return val == DBNull.Value ? null : val;
        }




        public void EnsurePrimaryTable()
        {
            if (_primary != null) return;

            _primary = new DataTable("Primary");
            _ds.Tables.Add(_primary);
        }

        public  void TriggerRowFocusChanged()
        {
            RowFocusChanged?.Invoke(_currentRow);
        }

        public virtual int ModifiedCount()
        {
            int count = 0;

            int rows = this.RowCount();
            for (int row = 1; row <= rows; row++)
            {
                var status = this.GetItemStatus(row, 0, dwbuffer.Primary);

                if (status == dwitemstatus.DataModified ||
                    status == dwitemstatus.NewModified)
                {
                    count++;
                }
            }

            return count;
        }

        public virtual int ModifiedCount(dwbuffer buffer)
        {
            int count = 0;

            int rows = this.RowCount(buffer);
            for (int row = 1; row <= rows; row++)
            {
                var status = this.GetItemStatus(row, 0, buffer);

                if (status == dwitemstatus.DataModified ||
                    status == dwitemstatus.NewModified)
                {
                    count++;
                }
            }

            return count;
        }



        public virtual int RowsDiscard(long s, long e, dwbuffer f)
        {
            // Stub PB: si querés comportamiento real después, lo implementamos.
            // Retorna 1 si OK, -1 si error.
            EnsurePrimaryTable();
            if (_primary == null) return -1;

            try
            {
                int start = (int)s;
                int end = (int)e;

                if (start <= 0) start = 1;
                if (end <= 0) end = 1;
                if (end < start) return 1;

                int max = _primary.Rows.Count;
                if (max <= 0) return 1;

                if (start > max) return 1;
                if (end > max) end = max;

                // borrar desde el final para no mover índices
                for (int r = end; r >= start; r--)
                    _primary.Rows.RemoveAt(r - 1);

                if (_currentRow > _primary.Rows.Count) _currentRow = _primary.Rows.Count;

                TriggerRowFocusChanged();
                return 1;
            }
            catch
            {
                return -1;
            }
        }

        public virtual int RowsMove(long s, long e, dwbuffer f, datawindow d, long i, dwbuffer t)
        {
            // Stub PB: movemos filas (Primary) de esta DW a otra DW.
            EnsurePrimaryTable();
            d?.EnsurePrimaryTable();

            if (_primary == null) return -1;
            if (d == null || d._primary == null) return -1;

            try
            {
                int start = (int)s;
                int end = (int)e;
                int insertAt = (int)i;

                if (start <= 0) start = 1;
                if (end <= 0) end = start;
                if (end < start) return 1;

                int max = _primary.Rows.Count;
                if (max <= 0) return 1;

                if (start > max) return 1;
                if (end > max) end = max;

                if (insertAt <= 0) insertAt = 1;
                if (insertAt > d._primary.Rows.Count + 1) insertAt = d._primary.Rows.Count + 1;

                // Copiar estructura si destino no tiene columnas
                if (d._primary.Columns.Count == 0)
                {
                    foreach (DataColumn col in _primary.Columns)
                        d._primary.Columns.Add(col.ColumnName, col.DataType);
                }

                // Insertar copias en destino
                int destIndex = insertAt - 1; // 0-based
                for (int r = start; r <= end; r++)
                {
                    var srcRow = _primary.Rows[r - 1];
                    var newRow = d._primary.NewRow();
                    for (int c = 0; c < d._primary.Columns.Count && c < _primary.Columns.Count; c++)
                        newRow[c] = srcRow[c];
                    d._primary.Rows.InsertAt(newRow, destIndex);
                    destIndex++;
                }

                // Borrar del origen (desde el final)
                for (int r = end; r >= start; r--)
                    _primary.Rows.RemoveAt(r - 1);

                if (_currentRow > _primary.Rows.Count) _currentRow = _primary.Rows.Count;

                TriggerRowFocusChanged();
                d.TriggerRowFocusChanged();
                return 1;
            }
            catch
            {
                return -1;
            }
        }

        // Overloads PB-like (para que compile tu uo_dw tal cual)
        public virtual int RowsMove(long s, long e, dwbuffer f, datastore d, long i, dwbuffer t)
            => RowsMove(s, e, f, (datawindow)d, i, t);

        public virtual int RowsMove(long s, long e, dwbuffer f, datawindowchild d, long i, dwbuffer t)
            => -1; // si después necesitás childdw real lo implementamos


        // ==============================
        // PB-compatible overload
        // RowsMove(long, long, RowMoveType, datawindow, long)
        // ==============================
        public int RowsMove(long s, long e, RowMoveType moveType, datawindow d, long insertRow)
        {
            // PB: RowMoveType solo indica la intención (Delete, Insert, etc.)
            // Para Delete!, PB mueve filas a la Deleted buffer.
            // En C#, usamos dwbuffer.Delete (si lo necesitás después lo implemento).

            dwbuffer fromBuffer = dwbuffer.Primary;   // origen por defecto
            dwbuffer toBuffer = dwbuffer.Primary;   // destino por defecto

            switch (moveType)
            {
                case RowMoveType.Delete:
                    // PB: RowsMove(..., Delete!, dw)
                    toBuffer = dwbuffer.Delete;       // manda a deleted buffer
                    break;

                case RowMoveType.Insert:
                    // PB: Insert! → insertar en row destino
                    toBuffer = dwbuffer.Primary;
                    break;

                default:
                    // otros movimientos no cambian buffers
                    break;
            }

            return RowsMove(s, e, fromBuffer, d, insertRow, toBuffer);
        }

        public int RowsMove(
    long s,
    long e,
    PBRowMoveMode moveMode,
    datawindow d,
    long insertRow,
    dwbuffer targetBuffer)
        {
            // PBRowMoveMode es solo intención
            // Traducimos a buffers PB reales

            dwbuffer fromBuffer = dwbuffer.Primary;
            dwbuffer toBuffer = targetBuffer;

            switch (moveMode)
            {
                case PBRowMoveMode.Delete:
                    // PB: Delete! → mover a Deleted buffer
                    toBuffer = dwbuffer.Delete;
                    break;

                case PBRowMoveMode.Before:
                case PBRowMoveMode.After:
                case PBRowMoveMode.Replace:
                default:
                    // se mantienen los buffers recibidos
                    break;
            }

            return RowsMove(s, e, fromBuffer, d, insertRow, toBuffer);
        }



        public virtual void TriggerEvent(string eventName)
        {
            if (string.IsNullOrWhiteSpace(eventName)) return;

            // PB no es case-sensitive
            var name = eventName.Trim();

            // Busca un método con ese nombre (public o non-public, instancia)
            var mi = GetType().GetMethod(
                name,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.IgnoreCase);

            if (mi == null) return;

            // Solo soportamos sin parámetros acá (PB TriggerEvent simple)
            if (mi.GetParameters().Length != 0) return;

            mi.Invoke(this, null);
        }

        public virtual int InsertRow(long row)
        {
            EnsurePrimaryTable();
            if (_primary == null) return -1;

            // PB: row = 0 => inserta arriba (antes de la fila 1)
            int insertPos0;
            if (row <= 0) insertPos0 = 0;
            else
            {
                // PB es 1-based; clamp
                int r = (int)row;
                if (r > _primary.Rows.Count + 1) r = _primary.Rows.Count + 1;
                insertPos0 = r - 1; // 0-based position
            }

            try
            {
                var dr = _primary.NewRow();

                // Inicializo con DBNull para todas las columnas existentes
                for (int c = 0; c < _primary.Columns.Count; c++)
                    dr[c] = DBNull.Value;

                _primary.Rows.InsertAt(dr, insertPos0);

                // PB devuelve el índice 1-based de la fila insertada
                _currentRow = insertPos0 + 1;
                TriggerRowFocusChanged();
                return _currentRow;
            }
            catch
            {
                return -1;
            }
        }

        public virtual int Reset()
        {
            EnsurePrimaryTable();
            _primary!.Clear();
            _currentRow = 0;
            TriggerRowFocusChanged();
            return 1;
        }

        public virtual int ResetUpdate()
        {
            // PB: limpia flags de update (modified/new/deleted) en los buffers.
            // En tu engine actual no estás trackeando itemstatus real,
            // así que devolvemos éxito y dejamos consistente ModifiedCount() = 0
            // si vos basás ModifiedCount en flags internos.
            //
            // Si más adelante agregás tracking real, acá es donde lo reseteás.
            return 1;
        }
        public virtual int share_data(datawindow? source)
        {
            if (source == null) return -1;

            // comparte las mismas referencias (PB ShareData)
            this._ds = source._ds;
            this._primary = source._primary;

            // también podés copiar row actual si querés PB-like
            this._currentRow = source._currentRow;

            return 1;
        }

        public virtual void ShareDataOff()
        {
            // Si no hay data, no hay nada que cortar
            if (_ds == null && _primary == null)
                return;

            // Cortar sharing: clonar buffers
            if (_ds != null)
                _ds = _ds.Copy();

            if (_primary != null)
                _primary = _primary.Copy();

            // _currentRow se mantiene (PB no lo resetea)
        }


        // Dentro de datawindow
        protected readonly HashSet<int> _deletedRowsPrimary = new(); // 1-based row numbers

        public virtual int DeletedCount()
        {
            return DeletedCount(dwbuffer.Primary);
        }

        public virtual int DeletedCount(dwbuffer buffer)
        {
            return buffer switch
            {
                dwbuffer.Primary => _deletedRowsPrimary.Count,
                _ => 0
            };
        }

        // Dentro de datawindow
        public virtual int Find(string expression, int startRow, int endRow)
        {
            EnsurePrimaryTable();
            if (_primary == null) return 0;

            if (string.IsNullOrWhiteSpace(expression)) return 0;

            int rows = RowCount();
            if (rows <= 0) return 0;

            // Normalizo rango (PB es 1-based e inclusive)
            int start = Math.Max(1, startRow);
            int end = endRow <= 0 ? rows : Math.Min(endRow, rows);
            if (start > end) return 0;

            // Expression PB que usás: "columnname = 'X'"
            // DataView.RowFilter acepta "columnname = 'X'" también (si la columna existe)
            var dv = new DataView(_primary) { RowFilter = expression };

            // Busco la primera fila del DataTable cuyo índice (1-based) esté dentro del rango
            // y que además cumpla el filtro. Para eso comparo referencias DataRow.
            var matches = new HashSet<DataRow>(dv.Cast<DataRowView>().Select(v => v.Row));

            for (int r = start; r <= end; r++)
            {
                // Si estás usando borrados PB-like (DeletedCount), podés saltear borradas:
                if (_deletedRowsPrimary.Contains(r)) continue;

                var row = _primary.Rows[r - 1];
                if (matches.Contains(row))
                    return r;
            }

            return 0;
        }

        // Dentro de datawindow
        public virtual int ScrollToRow(long row)
        {
            int r = (int)row;

            int max = RowCount();
            if (max <= 0) return -1;

            if (r < 1) r = 1;
            if (r > max) r = max;

            SetRow(r); // PB: mueve el foco a esa fila (y en UI real también scrollea)
            return 1;
        }

        public void Destroy()
        {
            // PB: DESTROY ds  → en .NET no hace nada
        }

        /// <summary>
        /// PB: Print()
        /// </summary>
        public virtual int Print()
        {
            // Stub PB-compatible
            // En el futuro: implementación real de impresión
            return 1;
        }

        /// <summary>
        /// PB: Print(showPreview)
        /// </summary>
        public virtual int Print(bool showPreview)
        {
            // showPreview = true  → Preview
            // showPreview = false → Directo
            // Por ahora, stub PB-compatible
            return 1;
        }


        public virtual int RowsCopy(
    long startRow,
    long endRow,
    dwbuffer fromBuffer,
    datawindow dest,
    long insertRow,
    dwbuffer toBuffer)
        {
            if (dest is datastore ds)
                return RowsCopy(startRow, endRow, fromBuffer, ds, insertRow, toBuffer);

            return -1;
        }


    }
}
