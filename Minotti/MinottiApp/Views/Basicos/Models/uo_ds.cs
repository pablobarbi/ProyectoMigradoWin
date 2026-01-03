using Minotti.Functions;
using Minotti.utils; 
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Minotti.Views.Basicos.Models
{
    /// <summary>
    /// Traducción de uo_ds (datastore) de PowerBuilder.
    /// Hereda de una base que emule el datastore PB: Describe, Retrieve, RowCount, GetItem*, etc.
    /// </summary>
    public class uo_ds : datastore  // PBDataStoreBase: tu clase base emulando DataStore
    {
        // Asumimos que uo_ds envuelve una DataTable
        

        // ================== variables ==================

        // boolean ib_registrar_usuario = FALSE
        // Marca si hay columnas usr_upd/fec_upd para registrar usuario/fecha.
        private bool ib_registrar_usuario = false;

        // public: cat_columna at_col[]
        // Usamos índice 1-based: at_col[0] se deja vacío a propósito.
        public List<cat_columna?> at_col { get; } = new List<cat_columna?>();

        // public: integer ii_claves[]
        // También 1-based: ii_claves[0] no se usa.
        public List<int> ii_claves { get; } = new List<int>();

        /// <summary>
        /// PB alias: cant_filas
        /// Lectura = RowCount()
        /// Escritura = NO-OP (permitida por compatibilidad PB)
        /// </summary>
        public int cant_filas
        {
            get => this.RowCount();
            set
            {
                // PB permitía asignar aunque no tuviera efecto real
                // En C# lo absorbemos silenciosamente
            }
        }
        // ================== ctor ==================

        public uo_ds()
        {
            // Reservo índice 0 para mantener semántica 1-based de PB
            at_col.Add(null);
            ii_claves.Add(0);
        }

        // =========================================================
        //  uof_getfiltroclave (long row)
        // =========================================================
        /// <summary>
        /// Devuelve un string tipo "campo1 = 'valor1' and campo2 = 'valor2'" 
        /// usando las columnas clave definidas en ii_claves.
        /// </summary>
        public string uof_getfiltroclave(long row)
        {
            int cantidad = ii_claves.Count - 1;
            if (cantidad <= 0)
                return string.Empty;

            var partes = new List<string>();

            for (int i = 1; i <= cantidad; i++)
            {
                int col = ii_claves[i];
                if (col <= 0 || col >= at_col.Count || at_col[col] == null)
                    continue;

                string colName = at_col[col]!.Nombre ?? string.Empty;
                string value = uof_getitem(row, col) ?? string.Empty;

                partes.Add($"{colName} = '{value}'");
            }

            return string.Join(" and ", partes);
        }

        // =========================================================
        //  uof_setdataobject (string data_object)
        // =========================================================
        /// <summary>
        /// Setea el DataObject, arma at_col[] e ii_claves[], required, filtro, initial, etc.,
        /// igual que en el uo_ds de PB pero usando Describe().
        /// </summary>
        public void uof_setdataobject(string data_object)
        {
            if (string.IsNullOrWhiteSpace(data_object))
                throw new ArgumentException("data_object no puede ser nulo ni vacío.", nameof(data_object));

            // Carga el DataObject
            this.DataObject = data_object;

            // Reseteo banderas y metadata
            ib_registrar_usuario = false;

            at_col.Clear();
            at_col.Add(null);      // índice 0 inutilizado
            ii_claves.Clear();
            ii_claves.Add(0);      // índice 0 inutilizado

            int camposValorInicial = guo_app.ds_valor_inicial?.RowCount() ?? 0;

            // -------------------------------------------------------
            // Recorre todos los objetos de la datawindow
            // DataWindow.Objects -> lista separada por tab
            // -------------------------------------------------------
            string param = this.Describe("DataWindow.Objects");
            while (!string.IsNullOrEmpty(param))
            {
                // f_cortar_string: mismo contrato que PB: 
                // toma el primer token hasta delimitador y recorta param.
                string sAux = f_cortar_string.fcortar_string(param, "\t");

                // Si existe un objeto llamado "usr_upd", se registra usuario
                if (sAux == "usr_upd")
                {
                    ib_registrar_usuario = true;
                }
            }

            // -------------------------------------------------------
            // Recorre uno a uno los campos
            // -------------------------------------------------------
            int columnCount = int.Parse(this.Describe("DataWindow.Column.Count"));

            for (int iAux = 1; iAux <= columnCount; iAux++)
            {
                // Garantizar espacio 1-based en at_col
                while (at_col.Count <= iAux)
                    at_col.Add(new cat_columna());

                var colMeta = at_col[iAux] ?? new cat_columna();

                // Nombre, título y tipo
                colMeta.Nombre = this.Describe("#" + iAux + ".Name");
                colMeta.Titulo = this.Describe(colMeta.Nombre + "_t.Text");

                string coltype = this.Describe("#" + iAux + ".Coltype");
                colMeta.Tipo = coltype.Length >= 5 ? coltype.Substring(0, 5).ToLowerInvariant() : coltype.ToLowerInvariant();
                // Valores posibles: long, decim, date, datet, numbe, real, char(, time

                // TabOrder original
                colMeta.TabOrder = this.Describe("#" + iAux + ".TabSequence");

                // Filtro (Criteria.Dialog)
                string critDialog = (this.Describe("#" + iAux + ".Criteria.Dialog") ?? "").ToUpperInvariant();
                if (critDialog == "YES")
                {
                    colMeta.Filtro = true;
                    this.Modify("#" + iAux + ".Criteria.Dialog=NO");
                }
                else
                {
                    colMeta.Filtro = false;
                }

                // Requerido: revisa los 4 estilos (EDIT, DDLB, DDDW, EDITMASK)
                colMeta.Requerido = false;

                string editRequired = (this.Describe("#" + iAux + ".Edit.Required") ?? "").ToUpperInvariant();
                string ddlbRequired = (this.Describe("#" + iAux + ".DDLB.Required") ?? "").ToUpperInvariant();
                string dddwRequired = (this.Describe("#" + iAux + ".DDDW.Required") ?? "").ToUpperInvariant();
                string maskRequired = (this.Describe("#" + iAux + ".EditMask.Required") ?? "").ToUpperInvariant();

                if (editRequired == "YES")
                {
                    colMeta.Requerido = true;
                    this.Modify("#" + iAux + ".Edit.Required=NO");
                }
                else if (ddlbRequired == "YES")
                {
                    colMeta.Requerido = true;
                    this.Modify("#" + iAux + ".DDLB.Required=NO");
                }
                else if (dddwRequired == "YES")
                {
                    colMeta.Requerido = true;
                    this.Modify("#" + iAux + ".DDDW.Required=NO");
                }
                else if (maskRequired == "YES")
                {
                    colMeta.Requerido = true;
                    this.Modify("#" + iAux + ".EditMask.Required=NO");
                }

                // Claves
                string isKey = (this.Describe("#" + iAux + ".Key") ?? "").ToUpperInvariant();
                if (isKey == "YES")
                {
                    ii_claves.Add(iAux); // guardo nro de columna PowerBuilder (1-based)
                }

                // Valor inicial (DS d_valor_inicial)
                if (camposValorInicial > 0 && guo_app.ds_valor_inicial != null)
                {
                    // Find("campo = 'X'", 1, campos)
                    string criterio = $"campo = '{colMeta.Nombre}'";
                    int m = guo_app.ds_valor_inicial.Find(criterio, 1, camposValorInicial);

                    if (m > 0)
                    {
                        string valorInicial = guo_app.ds_valor_inicial.GetItemString(m, "valor_inicial") ?? string.Empty;
                        this.Modify($"{colMeta.Nombre}.Initial='{valorInicial}'");
                    }
                }

                at_col[iAux] = colMeta;
            }
        }

        // =========================================================
        //  uof_getitem (long fila, integer columna)
        // =========================================================
        /// <summary>
        /// Devuelve el valor de una celda como string,
        /// formateando según el tipo (char, long, decim, date, datet, time).
        /// </summary>
        public string uof_getitem(long fila, int columna)
        {
            if (columna <= 0 || columna >= at_col.Count || at_col[columna] == null)
                return string.Empty;

            if (fila <= 0 || fila > this.RowCount())
                return string.Empty;

            string retorno = string.Empty;
            string tipo = at_col[columna]!.Tipo?.ToLowerInvariant() ?? string.Empty;

            try
            {
                switch (tipo)
                {
                    case string t when t.StartsWith("char("):
                        retorno = this.GetItemString(fila, columna) ?? string.Empty;
                        break;

                    case "long":
                    case "numbe":
                    case "real":
                        double? num = this.GetItemNumber(fila, columna);
                        retorno = num?.ToString() ?? string.Empty;
                        break;

                    case "decim":
                        decimal? dec = this.GetItemDecimal(fila, columna);
                        retorno = dec?.ToString() ?? string.Empty;
                        break;

                    case "date":
                        DateTime? fecha = this.GetItemDate(fila, columna);
                        retorno = fecha.HasValue ? f_date_a_string.fdate_a_string(fecha.Value) : string.Empty;
                        break;

                    case "datet":
                        DateTime? dt = this.GetItemDateTime(fila, columna);
                        retorno = dt.HasValue ? f_datetime_a_string.fdatetime_a_string(dt.Value) : string.Empty;
                        break;

                    case "time":
                        TimeSpan? ts = this.GetItemTime(fila, columna);
                        retorno = ts?.ToString() ?? string.Empty;
                        break;
                }
            }
            catch
            {
                retorno = string.Empty;
            }

            return retorno ?? string.Empty;
        }

        // =========================================================
        //  uof_retrieve(string[] parametros)
        // =========================================================
        /// <summary>
        /// Llama a Retrieve con la cantidad de parámetros que haya en el arreglo.
        /// Replica la lógica de PB donde los argumentos se obtienen con f_Get_ds_argumentos.
        /// </summary>
        public long uof_retrieve(string[] parametros)
        {
            // iAux = f_Get_ds_argumentos(This, s_arg[], s_tipo[])
            string[] s_arg;
            string[] s_tipo;

            int iAux = f_get_ds_argumentos.fget_ds_argumentos(this, out s_arg, out s_tipo);
            long retorno = -1;

            if (iAux < 0)
            {
                MessageBox.Show("Falló la Get_dw_Argumentos", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else if (iAux > 0 && (parametros == null || parametros.Length == 0))
            {
                // f_fijar_parametros(s_arg[], parametros[])
                parametros = f_fijar_parametros.ffijar_parametros(s_arg);
            }

            // Reemplaza los nulos por strings vacías
            if (parametros != null)
            {
                for (int i = 0; i < parametros.Length; i++)
                {
                    if (parametros[i] == null)
                        parametros[i] = string.Empty;
                }
            }

            int cantArgs = s_arg?.Length ?? 0;

            switch (cantArgs)
            {
                case 0:
                    retorno = this.Retrieve();
                    break;
                case 1:
                    retorno = this.Retrieve(parametros[0]);
                    break;
                case 2:
                    retorno = this.Retrieve(parametros[0], parametros[1]);
                    break;
                case 3:
                    retorno = this.Retrieve(parametros[0], parametros[1], parametros[2]);
                    break;
                case 4:
                    retorno = this.Retrieve(parametros[0], parametros[1], parametros[2], parametros[3]);
                    break;
                case 5:
                    retorno = this.Retrieve(parametros[0], parametros[1], parametros[2], parametros[3], parametros[4]);
                    break;
                case 6:
                    retorno = this.Retrieve(parametros[0], parametros[1], parametros[2], parametros[3], parametros[4], parametros[5]);
                    break;
                case 7:
                    retorno = this.Retrieve(parametros[0], parametros[1], parametros[2], parametros[3], parametros[4], parametros[5], parametros[6]);
                    break;
                case 8:
                    retorno = this.Retrieve(parametros[0], parametros[1], parametros[2], parametros[3], parametros[4], parametros[5], parametros[6], parametros[7]);
                    break;
                case 9:
                    retorno = this.Retrieve(parametros[0], parametros[1], parametros[2], parametros[3], parametros[4], parametros[5], parametros[6], parametros[7], parametros[8]);
                    break;
                case 10:
                    retorno = this.Retrieve(parametros[0], parametros[1], parametros[2], parametros[3], parametros[4], parametros[5], parametros[6], parametros[7], parametros[8], parametros[9]);
                    break;
                default:
                    // Si tenés más de 10 args, acá podrías extender el switch
                    retorno = this.Retrieve(parametros);
                    break;
            }

            return retorno;
        }

        // Overload sin parámetros: igual que PB
        public long uof_retrieve()
        {
            string[] parametros = Array.Empty<string>();
            return uof_retrieve(parametros);
        }

        // =========================================================
        //  uof_getclaves (ref string[] parametros, integer fila)
        // =========================================================
        /// <summary>
        /// Llena 'parametros' con los valores de las columnas clave para la fila indicada.
        /// Devuelve false si alguno es nulo (o vacío).
        /// </summary>
        public bool uof_getclaves(ref string[] parametros, int fila)
        {
            var temp = new List<string>();
            bool retorno = true;

            int cantClaves = ii_claves.Count - 1;
            if (cantClaves <= 0)
            {
                parametros = Array.Empty<string>();
                return true;
            }

            for (int i = 1; i <= cantClaves; i++)
            {
                int col = ii_claves[i];
                string val = uof_getitem(fila, col) ?? string.Empty;

                temp.Add(val);

                // PB hace IsNull(parametros[iAux]): acá aproximamos tratando null/empty como "no válido".
                if (string.IsNullOrEmpty(val))
                    retorno = false;
            }

            parametros = temp.ToArray();
            return retorno;
        }

        // PB compatibility: DataStore.Destroy()
        public void Destroy()
        {
            // Intentionally empty - PB cleanup mapped to GC in .NET
        }

        // =========================================================
        //  CopyRow (PB compatible)
        // =========================================================
        /// <summary>
        /// Copia una fila dentro del mismo datastore.
        /// Equivalente a DataStore.CopyRow() de PowerBuilder.
        /// Parámetros y retorno 1-based.
        /// </summary>
        public int CopyRow(int fromRow, int toRow)
        {
            if (fromRow <= 0 || fromRow > this.RowCount())
                return -1;

            // En PB: si toRow <= 0 o > RowCount → inserta al final
            int insertAt;
            if (toRow <= 0 || toRow > this.RowCount())
                insertAt = this.RowCount() + 1;
            else
                insertAt = toRow;

            // Inserta nueva fila
            int newRow = this.InsertRow(insertAt);

            if (newRow <= 0)
                return -1;

            int colCount = at_col.Count - 1;

            // Copia columna por columna (1-based)
            for (int col = 1; col <= colCount; col++)
            {
                var meta = at_col[col];
                if (meta == null)
                    continue;

                try
                {
                    switch (meta.Tipo)
                    {
                        case string t when t.StartsWith("char"):
                            this.SetItem(newRow, col, this.GetItemString(fromRow, col));
                            break;

                        case "long":
                        case "numbe":
                        case "real":
                            this.SetItem(newRow, col, this.GetItemNumber(fromRow, col));
                            break;

                        case "decim":
                            this.SetItem(newRow, col, this.GetItemDecimal(fromRow, col));
                            break;

                        case "date":
                            this.SetItem(newRow, col, this.GetItemDate(fromRow, col));
                            break;

                        case "datet":
                            this.SetItem(newRow, col, this.GetItemDateTime(fromRow, col));
                            break;

                        case "time":
                            this.SetItem(newRow, col, this.GetItemTime(fromRow, col));
                            break;

                        default:
                            // fallback defensivo
                            this.SetItem(newRow, col, this.GetItemString(fromRow, col));
                            break;
                    }
                }
                catch
                {
                    // PB ignora errores de copia de celda
                }
            }

            return newRow;
        }


        // =========================================================
        //  CopyRow desde otro uo_ds (PB compatible)
        // =========================================================
        public int CopyRow(uo_ds fromDs, int fromRow, int toRow)
        {
            if (fromDs == null)
                return -1;

            if (fromRow <= 0 || fromRow > fromDs.RowCount())
                return -1;

            int insertAt = (toRow <= 0 || toRow > this.RowCount())
                ? this.RowCount() + 1
                : toRow;

            int newRow = this.InsertRow(insertAt);
            if (newRow <= 0)
                return -1;

            int colCount = Math.Min(this.at_col.Count, fromDs.at_col.Count) - 1;

            for (int col = 1; col <= colCount; col++)
            {
                var meta = this.at_col[col];
                if (meta == null) continue;

                try
                {
                    switch (meta.Tipo)
                    {
                        case string t when t.StartsWith("char"):
                            this.SetItem(newRow, col, fromDs.GetItemString(fromRow, col));
                            break;

                        case "long":
                        case "numbe":
                        case "real":
                            this.SetItem(newRow, col, fromDs.GetItemNumber(fromRow, col));
                            break;

                        case "decim":
                            this.SetItem(newRow, col, fromDs.GetItemDecimal(fromRow, col));
                            break;

                        case "date":
                            this.SetItem(newRow, col, fromDs.GetItemDate(fromRow, col));
                            break;

                        case "datet":
                            this.SetItem(newRow, col, fromDs.GetItemDateTime(fromRow, col));
                            break;

                        case "time":
                            this.SetItem(newRow, col, fromDs.GetItemTime(fromRow, col));
                            break;
                    }
                }
                catch
                {
                    // PB ignora errores de copia
                }
            }

            return newRow;
        }

        // =========================================================
        //  CopyRow (PB compatible)
        //  CopyRow(source_ds, source_row) -> inserta al final
        // =========================================================
        public int CopyRow(uo_ds fromDs, int fromRow)
        {
            if (fromDs == null)
                return -1;

            if (fromRow <= 0 || fromRow > fromDs.RowCount())
                return -1;

            // En PB: sin toRow => inserta al final
            int toRow = this.RowCount() + 1;

            return CopyRow(fromDs, fromRow, toRow);
        }


        /// <summary>
        /// PB: RowsCopy(s, e, f, d, i, t)
        /// Alias PB expuesto en uo_ds
        /// </summary>
        public virtual int RowsCopy(
            long startRow,
            long endRow,
            dwbuffer fromBuffer,
            uo_ds dest,
            long insertRow,
            dwbuffer toBuffer)
        {
            if (dest == null) return -1;

            // uo_ds ES datastore → llamamos directo al base
            return base.RowsCopy(
                startRow,
                endRow,
                fromBuffer,
                dest,
                insertRow,
                toBuffer
            );
        }

        // =========================================================
        //  Helpers: resolver índice de columna por nombre (PB compatible)
        // =========================================================
        private int uof_getcolindex(string columnName)
        {
            if (string.IsNullOrWhiteSpace(columnName))
                return 0;

            // at_col es 1-based (posición 0 vacía)
            for (int i = 1; i < at_col.Count; i++)
            {
                var c = at_col[i];
                if (c?.Nombre == null) continue;

                if (string.Equals(c.Nombre, columnName, StringComparison.OrdinalIgnoreCase))
                    return i;
            }

            return 0; // no encontrada
        }

        // =========================================================
        //  GetItemLong overloads (PB compatible)
        // =========================================================
        public long GetItemLong(long row, int column)
        {
            double? val = this.GetItemNumber(row, column);
            return val.HasValue ? Convert.ToInt64(val.Value) : 0L;
        }

        public long GetItemLong(int row, int column)
        {
            return GetItemLong((long)row, column);
        }

        public long GetItemLong(long row, string columnName)
        {
            int col = uof_getcolindex(columnName);
            if (col <= 0) return 0L;

            return GetItemLong(row, col);
        }

        public long GetItemLong(int row, string columnName)
        {
            return GetItemLong((long)row, columnName);
        }

        // =========================================================
        //  GetNullableLong (helper .NET para emular IsNull + GetItemLong)
        // =========================================================
        public long? GetNullableLong(long row, int column)
        {
            // Si es NULL en el datastore, GetItemNumber devuelve null
            double? val = this.GetItemNumber(row, column);
            if (!val.HasValue) return null;

            try
            {
                return Convert.ToInt64(val.Value);
            }
            catch
            {
                return null;
            }
        }

        public long? GetNullableLong(int row, int column)
        {
            return GetNullableLong((long)row, column);
        }

        public long? GetNullableLong(long row, string columnName)
        {
            int col = uof_getcolindex(columnName);
            if (col <= 0) return null;

            return GetNullableLong(row, col);
        }

        public long? GetNullableLong(int row, string columnName)
        {
            return GetNullableLong((long)row, columnName);
        }


        // =========================================================
        //  setdataobject (PB compatible alias)
        // =========================================================
        public void SetDataObject(string data_object)
        {
            uof_setdataobject(data_object);
        }

    }
}
