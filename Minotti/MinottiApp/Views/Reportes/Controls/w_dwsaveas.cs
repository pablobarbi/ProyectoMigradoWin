using Minotti.Views.Basicos.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Reportes.Controls
{
    /// <summary>
    /// Migración de PowerBuilder: w_dwsaveas.srw
    /// Posiciones y tamaños 1:1 según XAML PBWPF.
    /// </summary>
    public partial class w_dwsaveas : Form
    {
        // === variables ===
        protected long il_availablerow;
        protected long il_sortingrow;

        protected uo_sortattrib inv_sortattrib = new();
        protected cat_return at_return = new();

        public uo_ds? idw;
        public bool ib_visibleonly;

        /// <summary>
        /// PB: DragIcon (alias de compatibilidad)
        /// WinForms no lo soporta → NO-OP
        /// </summary>
        public Icon? DragIcon
        {
            get => null;
            set
            {
                // NO-OP
                // PB lo usaba solo como propiedad visual
            }
        }
        public w_dwsaveas()
        {
            InitializeComponent();
            this.DragIcon = new Icon("ARROWL.ICO");
        }

        // === open ===
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            idw = this.Tag as uo_ds;
            at_return.rtn_boolean = false;

            ue_posopen();
        }

        // === close ===
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.Tag = idw;
            base.OnFormClosing(e);
        }

        // === eventos ===
        private void ue_ok()
        {
            at_return.rtn_boolean = true;
            wf_eliminarcolumnas();
            this.Close();
        }

        private void ue_cancelar()
        {
            at_return.rtn_boolean = false;
            this.Close();
        }

        private void ue_posopen()
        {
            Cursor = Cursors.WaitCursor;

            wf_carga_atrib(inv_sortattrib);

            dw_sorted.SetRedraw(false);

            int max = inv_sortattrib.is_sortcolumns.Length;
            for (int i = 0; i < max; i++)
            {
                int row = dw_sorted.InsertRow(0);
                dw_sorted.SetItem(row, "columnname", inv_sortattrib.is_sortcolumns[i]);
                dw_sorted.SetItem(row, "displayname", inv_sortattrib.is_colnamedisplay[i]);
                dw_sorted.SetItem(row, "use_display", inv_sortattrib.ib_usedisplay[i] ? "1" : "0");
            }

            dw_sorted.SetRedraw(true);
            Cursor = Cursors.Default;
        }

        // === funciones PB 1:1 ===

        protected string wf_creasort()
        {
            string sort = "";
            int rows = dw_sorted.RowCount();

            for (int i = 1; i <= rows; i++)
            {
                string col = dw_sorted.GetItemString(i, "columnname");
                if (string.IsNullOrWhiteSpace(col)) continue;

                string item = dw_sorted.GetItemString(i, "use_display") == "1"
                    ? $"LookUpDisplay({col}) "
                    : $"{col} ";

                item += dw_sorted.GetItemString(i, "sort_order") + " ";
                sort += item;
            }

            return sort;
        }

        public string wf_getsort()
        {
            if (idw == null) return "";
            return idw.Describe("DataWindow.Table.Sort");
        }

        public int wf_sort()
        {
            return idw?.Sort() ?? -1;
        }

        public int wf_eliminarcolumnas()
        {
            for (int i = 1; i <= dw_sortcolumns.RowCount(); i++)
            {
                string col = dw_sortcolumns.GetItemString(i, "columnname");
                idw?.Modify($"destroy column {col}");
            }
            return 1;
        }

        public int wf_carga_atrib(uo_sortattrib arg)
        {
            if (idw == null) return -1;

            ib_visibleonly = false;
            string[] cols;
            wf_getobject(out cols, "column", "*", false);

            arg.is_sortcolumns = cols;

            arg.is_colnamedisplay = new string[cols.Length];
            arg.ib_usedisplay = new bool[cols.Length];

            for (int i = 0; i < cols.Length; i++)
            {
                arg.is_colnamedisplay[i] = wf_getheadername(cols[i], "_t");
                arg.ib_usedisplay[i] = false;
            }

            return 1;
        }

        // helpers PB
        public string wf_getheadername(string col, string suf)
        {
            string h = idw?.Describe($"{col}{suf}.Text") ?? "!";
            if (h == "!" || string.IsNullOrWhiteSpace(h)) return col;
            return h.Replace("_", " ").Replace("~r~n", " ");
        }

        public int wf_getobject(out string[] list, string type, string band, bool visible)
        {
            list = Array.Empty<string>();
            if (idw == null) return 0;

            string objs = idw.Describe("DataWindow.Objects");
            list = objs.Split('\t', StringSplitOptions.RemoveEmptyEntries);
            return list.Length;
        }
    }
}
