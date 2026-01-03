using Minotti.utils;
using Minotti.Views.Basicos.Controls;
using Minotti.Views.Basicos.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    // Migración de PowerBuilder: w_dworder.srw (Window)
    // Mantengo nombres de tipo, variables y eventos.
    // global type w_dworder from Window
    public partial class w_dworder : Form
    {
        // === Variables PB ===
        // public :
        public  long il_availablerow;
        public  long il_sortingrow;
        public  uo_sortattrib inv_sortattrib = new uo_sortattrib();
        public  cat_return at_return = new cat_return();

        // Public:
        public uo_dw idw { get; set; } = null!;  // datawindow idw
        public bool ib_visibleonly { get; set; } = true;

        // Constructor: recibe la DW a ordenar
        public w_dworder(uo_dw datawindow)
        {
            idw = datawindow ?? throw new ArgumentNullException(nameof(datawindow));

            InitializeComponent();

            // Simula OPEN
            this.Load += w_dworder_Load;

            // Botones
            cb_ok_.Click += cb_ok__clicked;
            cb_cancelar.Click += cb_cancelar_clicked;
        }

        // ==== OPEN (evento) ====
        private void w_dworder_Load(object? sender, EventArgs e)
        {
            // PB: idw = Message.PowerObjectParm (ya vino por ctor)
            at_return.rtn_boolean = false;

            // PB: This.Event trigger ue_posopen()
            ue_posopen();
        }

        // ==== CLOSE (equivalente) ====
        // Quien llame a ShowDialog() leerá at_return luego
        protected  override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            // PB: Message.PowerObjectParm = at_return
            // En C#, exponemos una propiedad:
            //   var dlg = new w_dworder(dw);
            //   if (dlg.at_return.rtn_boolean) { var sort = dlg.at_return.rtn_string; ... }
        }

        // ======================================================
        //  Eventos PB: ue_ok / ue_cancelar / ue_posopen
        // ======================================================

        private void cb_ok__clicked(object? sender, EventArgs e)
        {
            ue_ok();
        }

        private void cb_cancelar_clicked(object? sender, EventArgs e)
        {
            ue_cancelar();
        }

        // event ue_ok;
        private void ue_ok()
        {
            // Set the return code to mean succesful operation.
            at_return.rtn_boolean = true;

            // Set the new sort string.
            at_return.rtn_string = wf_creasort();

            // Close the window.
            this.Close();
        }

        // event ue_cancelar;
        private void ue_cancelar()
        {
            at_return.rtn_boolean = false;
            this.Close();
        }

        // event ue_posopen;
        private void ue_posopen()
        {
            Cursor.Current = Cursors.WaitCursor;

            at_return.rtn_boolean = false;

            // Cargo la estructura con los campos de la dw
            wf_carga_atrib(inv_sortattrib);

            // Turn off re-drawing until all done.
            dw_sortcolumns.SetRedraw(false);

            // Populate the dw_sortcolumns with column names
            int li_sortnumcols = inv_sortattrib.is_sortcolumns?.Length ?? 0;
            for (int li_i = 0; li_i < li_sortnumcols; li_i++)
            {
                // Insert a new row
                int li_newrow = dw_sortcolumns.InsertRow(0);

                // PB arrays 1-based → acá lo manejo 0-based
                string colName = inv_sortattrib.is_sortcolumns[li_i];
                string displayName = inv_sortattrib.is_colnamedisplay?[li_i] ?? colName;
                bool useDisplay = inv_sortattrib.ib_usedisplay?[li_i] ?? false;

                dw_sortcolumns.SetItem(li_newrow, "columnname", colName);
                dw_sortcolumns.SetItem(li_newrow, "displayname", displayName);
                dw_sortcolumns.SetItem(li_newrow, "use_display", useDisplay ? "1" : "0");
            }

            // Sort dw_sortcolumns by displayname A
            dw_sortcolumns.SetSort("displayname A");
            dw_sortcolumns.Sort();

            // Find the current sort columns (dw_sorted) and display them as selected.
            int li_orignumcols = inv_sortattrib.is_origcolumns?.Length ?? 0;
            for (int li_i = 0; li_i < li_orignumcols; li_i++)
            {
                string colName = inv_sortattrib.is_origcolumns[li_i];

                // Find row in dw_sortcolumns
                int li_found = dw_sortcolumns.Find(
                    $"columnname = '{colName}'",
                    1,
                    dw_sortcolumns.RowCount());

                if (li_found > 0)
                {
                    // Move the row from dw_sortcolumns to dw_sorted.
                    int li_rc = dw_sortcolumns.RowsMove(
                        li_found,
                        li_found,
                        dwbuffer.Primary,
                        dw_sorted,
                        dw_sorted.RowCount() + 1,
                        dwbuffer.Primary);

                    // Set sort_order column
                    string sortOrder = inv_sortattrib.is_origorder?[li_i] ?? "A";
                    dw_sorted.SetItem(li_i + 1, "sort_order", sortOrder);
                }
            }

            dw_sortcolumns.SetRedraw(true);
            Cursor.Current = Cursors.Default;
        }

        // ======================================================
        //  Funciones PB wf_* migradas
        // ======================================================

        // public  function string wf_creasort ()
        public  string wf_creasort()
        {
            string ls_sortstring = string.Empty;
            int li_max = dw_sorted.RowCount();

            for (int li_i = 1; li_i <= li_max; li_i++)
            {
                string ls_colname = dw_sorted.GetItemString(li_i, "columnname") ?? string.Empty;
                if (string.IsNullOrWhiteSpace(ls_colname))
                    continue;

                string useDisp = dw_sorted.GetItemString(li_i, "use_display") ?? "0";
                string ls_sortitem;

                if (useDisp == "1")
                {
                    ls_sortitem = $"LookUpDisplay({ls_colname}) ";
                }
                else
                {
                    ls_sortitem = ls_colname + " ";
                }

                string order = dw_sorted.GetItemString(li_i, "sort_order") ?? "A";
                ls_sortitem += order + " ";

                ls_sortstring += ls_sortitem;
            }

            return ls_sortstring;
        }

        // public function integer wf_sort ()
        public int wf_sort()
        {
            // En PB: li_rc = idw.Sort()
            // Acá asumimos que uo_dw tiene un método Sort()
            return idw.Sort();
        }

        // public function string wf_getsort ()
        public string wf_getsort()
        {
            if (idw == null)
                return string.Empty;

            return idw.Describe("DataWindow.Table.Sort") ?? string.Empty;
        }

        // public function integer wf_carga_atrib (ref uo_sortattrib arg_atrib)
        public int wf_carga_atrib(uo_sortattrib arg_atrib)
        {
            int li_numcols;
            int li_numcomputes;
            int li_exclude;
            var ls_sortcolumns_all = new List<string>();
            var ls_sortcolumns_exc = new List<string>();
            var ls_computes = new List<string>();

            string ls_dbname;
            bool lb_exclude;

            ib_visibleonly = true;

            // Validate dw reference.
            if (idw == null)
                return -1;

            // Get current sort
            arg_atrib.is_sort = wf_getsort();

            // Remove space after comma (', ' -> ',')
            arg_atrib.is_sort = f_GlobalReplace(arg_atrib.is_sort, ", ", ",", true);

            // Parse original sort into separate elements
            wf_parsesortatrib(arg_atrib.is_sort, ref arg_atrib);

            // Get visible columns in detail band
            string[] tmpCols = Array.Empty<string>();
            li_numcols = wf_getobject(ref tmpCols, "column", "detail", ib_visibleonly);
            if (li_numcols > 0)
                ls_sortcolumns_all.AddRange(tmpCols);

            // (En esta versión no agregamos computes; si querés, copiamos la parte comentada de PB)
            li_numcomputes = 0; // placeholder, sin computes

            // Excluir columnas (en PB había un array is_excludecolumns; acá no lo usamos)
            li_exclude = 0;
            foreach (var col in ls_sortcolumns_all)
            {
                lb_exclude = false;
                // Si algún día querés exclusiones, las chequeás acá.
                if (!lb_exclude)
                    ls_sortcolumns_exc.Add(col);
            }

            // Copio a la estructura
            arg_atrib.is_sortcolumns = ls_sortcolumns_exc.ToArray();
            li_numcols = arg_atrib.is_sortcolumns.Length;

            //  Use Column Headers
            arg_atrib.is_colnamedisplay = new string[li_numcols];
            for (int li_i = 0; li_i < li_numcols; li_i++)
            {
                arg_atrib.is_colnamedisplay[li_i] =
                    wf_getheadername(arg_atrib.is_sortcolumns[li_i], "_t");
            }

            // Determine if LookUpDisplay should automatically be added
            arg_atrib.ib_usedisplay = new bool[li_numcols];
            for (int li_i = 0; li_i < li_numcols; li_i++)
            {
                // En esta versión no usamos DisplayValue automático
                arg_atrib.ib_usedisplay[li_i] = false;
            }

            return 1;
        }

        // public function integer wf_parsesortatrib (...)
        public int wf_parsesortatrib(string as_originalsort, ref uo_sortattrib anv_sortattrib)
        {
            // Parse original sort into separate elements
            string[] cols = Array.Empty<string>();
            wf_parsetoarray(as_originalsort, ",", ref cols);

            anv_sortattrib.is_origcolumns = cols;
            int li_num_cols = cols.Length;
            anv_sortattrib.is_origorder = new string[li_num_cols];

            for (int li_i = 0; li_i < li_num_cols; li_i++)
            {
                string ls_parse = anv_sortattrib.is_origcolumns[li_i] ?? string.Empty;

                // Remove LookUpDisplay if present
                if (ls_parse.IndexOf("lookupdisplay(", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    ls_parse = f_GlobalReplace(ls_parse, "LookUpDisplay(", "", true);
                    ls_parse = f_GlobalReplace(ls_parse, ")", "", true);
                    ls_parse = ls_parse.Trim();
                }

                anv_sortattrib.is_origcolumns[li_i] = wf_gettoken(ref ls_parse, " ");
                anv_sortattrib.is_origorder[li_i] = ls_parse;
            }

            return 1;
        }

        // public function integer wf_getobject (...)
        public int wf_getobject(ref string[] as_objlist, string as_objtype, string as_band, bool ab_visibleonly)
        {
            var list = new List<string>();

            string ls_ObjString = idw.Describe("DataWindow.Objects") ?? string.Empty;
            if (string.IsNullOrEmpty(ls_ObjString))
            {
                as_objlist = Array.Empty<string>();
                return 0;
            }

            int li_Start = 0;
            while (true)
            {
                int li_Tab = ls_ObjString.IndexOf('\t', li_Start);
                string ls_ObjHolder;
                if (li_Tab >= 0)
                {
                    ls_ObjHolder = ls_ObjString.Substring(li_Start, li_Tab - li_Start);
                    li_Start = li_Tab + 1;
                }
                else
                {
                    ls_ObjHolder = ls_ObjString.Substring(li_Start);
                    li_Start = ls_ObjString.Length;
                }

                if (!string.IsNullOrEmpty(ls_ObjHolder))
                {
                    string type = idw.Describe(ls_ObjHolder + ".type") ?? string.Empty;
                    string band = idw.Describe(ls_ObjHolder + ".band") ?? string.Empty;
                    string visible = idw.Describe(ls_ObjHolder + ".visible") ?? "0";

                    bool typeOk = (type == as_objtype) || (as_objtype == "*");
                    bool bandOk = (band == as_band) || (as_band == "*");
                    bool visibleOk = (visible == "1") || (!ab_visibleonly);

                    if (typeOk && bandOk && visibleOk)
                        list.Add(ls_ObjHolder);
                }

                if (li_Tab < 0)
                    break;
            }

            as_objlist = list.ToArray();
            return as_objlist.Length;
        }

        // public function string wf_getheadername (string as_column, string as_suffix)
        public string wf_getheadername(string as_column, string as_suffix)
        {
            string ls_colhead = idw.Describe(as_column + as_suffix + ".Text") ?? "!";

            if (ls_colhead == "!")
            {
                // No valid column header, use column name
                ls_colhead = as_column;
            }

            // Reemplazos como en PB
            ls_colhead = f_GlobalReplace(ls_colhead, "\r\n", " ", true);
            ls_colhead = f_GlobalReplace(ls_colhead, "\t", " ", true);
            ls_colhead = f_GlobalReplace(ls_colhead, "\r", " ", true);
            ls_colhead = f_GlobalReplace(ls_colhead, "\n", " ", true);
            ls_colhead = f_GlobalReplace(ls_colhead, "_", " ", true);
            ls_colhead = f_GlobalReplace(ls_colhead, "\"", "", true);
            ls_colhead = f_GlobalReplace(ls_colhead, "'", "", true);
            ls_colhead = f_GlobalReplace(ls_colhead, "~", "", true);

            ls_colhead = ls_colhead.Trim();

            if (string.IsNullOrEmpty(ls_colhead))
                ls_colhead = as_column;

            return ls_colhead;
        }

        // public function string wf_gettoken (ref string as_source, string as_separator)
        public string wf_gettoken(ref string as_source, string as_separator)
        {
            if (as_source == null || as_separator == null)
                return string.Empty;

            int li_pos = as_source.IndexOf(as_separator, StringComparison.Ordinal);
            string ls_ret;

            if (li_pos < 0)
            {
                ls_ret = as_source;
                as_source = string.Empty;
            }
            else
            {
                ls_ret = as_source.Substring(0, li_pos);
                as_source = as_source.Substring(li_pos + as_separator.Length);
            }

            return ls_ret;
        }

        // public function long wf_parsetoarray (...)
        public long wf_parsetoarray(string as_source, string as_delimiter, ref string[] as_array)
        {
            if (as_source == null || as_delimiter == null)
            {
                as_array = Array.Empty<string>();
                return 0;
            }

            if (string.IsNullOrWhiteSpace(as_source))
            {
                as_array = Array.Empty<string>();
                return 0;
            }

            var list = new List<string>();
            int start = 0;
            while (true)
            {
                int pos = as_source.IndexOf(as_delimiter, start, StringComparison.OrdinalIgnoreCase);
                if (pos < 0)
                {
                    string last = as_source.Substring(start);
                    if (!string.IsNullOrEmpty(last))
                        list.Add(last);
                    break;
                }

                string part = as_source.Substring(start, pos - start);
                list.Add(part);
                start = pos + as_delimiter.Length;
            }

            as_array = list.ToArray();
            return as_array.LongLength;
        }

        // ======================================================
        //  Helpers locales para reemplazar funciones globales PB
        // ======================================================

        // f_GlobalReplace (string, string, string, boolean caseInsensitive)
        private static string f_GlobalReplace(string input, string find, string replace, bool caseInsensitive)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(find))
                return input ?? string.Empty;

            StringComparison cmp = caseInsensitive
                ? StringComparison.OrdinalIgnoreCase
                : StringComparison.Ordinal;

            int idx = input.IndexOf(find, cmp);
            if (idx < 0)
                return input;

            var result = new System.Text.StringBuilder();
            int last = 0;

            while (idx >= 0)
            {
                result.Append(input, last, idx - last);
                result.Append(replace);
                last = idx + find.Length;
                idx = input.IndexOf(find, last, cmp);
            }

            result.Append(input, last, input.Length - last);
            return result.ToString();
        }
    }
}
