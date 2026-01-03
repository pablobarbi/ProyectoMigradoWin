using Minotti.Data;
using Minotti.Views.Basicos.Models;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    // Migración de PowerBuilder: w_seleccion_fila_dddw.srw (window) desde w_sheet
    // Mantengo el nombre del tipo: w_seleccion_fila_dddw
    // Base: uso w_operacion para compatibilidad con tus otras ventanas (w_sheet aún no migrada).
    // PB: global type w_seleccion_fila_dddw from w_sheet
    public partial class w_seleccion_fila_dddw : w_sheet
    {
        // cat_seleccion_row at_seleccion_row
        private cat_seleccion_row at_seleccion_row;

        // String is_nombre_columna = ''
        // String is_nombre_col_desc = ''
        // Long   il_q_filas
        private string is_nombre_columna = string.Empty;
        private string is_nombre_col_desc = string.Empty;
        private long il_q_filas;

        public w_seleccion_fila_dddw(cat_seleccion_row param) : this()
        {
            at_seleccion_row = param;
        }

        public w_seleccion_fila_dddw()
        {
            InitializeComponent();

            // eventos de botones
            cb_ok.Click += cb_ok_Click;
            cb_cancelar.Click += cb_cancelar_Click;

            // eventos sobre la dw de selección
            dw_seleccion.DoubleClick += dw_seleccion_DoubleClick;
            dw_seleccion.Click += dw_seleccion_Click;

            // evento sobre dw_buscar (equivalente a editchanged)
            dw_buscar.TextChanged += dw_buscar_TextChanged;

            // load de la ventana (equivalente al open + ue_leer_parametros + ue_iniciar + ue_ajustar_tamaño)
            this.Load += w_seleccion_fila_dddw_Load;
        }

        // ========================================================
        // Ciclo de vida (equivalente a open/ue_* de PB
        // ========================================================

        private void w_seleccion_fila_dddw_Load(object? sender, EventArgs e)
        {
            ue_leer_parametros();
            ue_iniciar();
            ue_ajustar_tamaño();
        }

        /// <summary>
        /// PB: event ue_leer_parametros
        /// </summary>
        public  virtual void ue_leer_parametros()
        {
            // at_seleccion_row = Message.PowerObjectParm ya vino por constructor

            // dw_buscar.SetTransObject(SQLCA)
            dw_buscar.SetTransObject(SQLCA.Connection);
            // dw_buscar.InsertRow(0)
            dw_buscar.InsertRow(0);

            // selecciono el objeto dw de acuerdo al codigo que busco
            dw_seleccion.uof_setdataobject(at_seleccion_row.dataobject);
            dw_seleccion.SetTransObject(SQLCA.Connection);
        }

        /// <summary>
        /// PB: event ue_iniciar
        /// </summary>
        public  virtual void ue_iniciar()
        {
            // Recupero los datos de la lista
            dw_seleccion.Retrieve();

            il_q_filas = dw_seleccion.RowCount();

            // nombre del campo clave y descripción (campos 1 y 2)
            is_nombre_columna = dw_seleccion.Describe("#1.Name");
            is_nombre_col_desc = dw_seleccion.Describe("#2.Name");

            // inserto el campo descripcion en la dw_busqueda
            if (!string.IsNullOrEmpty(at_seleccion_row.descripcion))
            {
                // row 1, col 1
                dw_buscar.SetItem(1, 1, Left(at_seleccion_row.descripcion, 60));

                // si viene también valor_columna, intento posicionar
                if (!string.IsNullOrEmpty(at_seleccion_row.valor_columna))
                {
                    if (wf_buscar_fila() == -1)
                    {
                        // limpio la dw de búsqueda
                        dw_buscar.Reset();
                    }
                }
            }

            // Seteo la fila de busqueda
            dw_buscar.SetFocus();
            dw_buscar.SetColumn(1);
            dw_buscar.SetRow(1);
        }

        /// <summary>
        /// PB: event ue_ajustar_tamaño
        /// </summary>
        public  virtual void ue_ajustar_tamaño()
        {
            int cant_filas = 10;

            dw_buscar.Left = 40;
            dw_buscar.Top = 40;

            dw_seleccion.Width = dw_seleccion.uof_ancho() + 100;
            dw_seleccion.Height = dw_seleccion.uof_largo(cant_filas) + 10;
            dw_seleccion.Left = 40;
            dw_seleccion.Top = dw_buscar.Top + dw_buscar.Height + 20;

            cb_cancelar.Top = dw_seleccion.Top + dw_seleccion.Height + 20;
            cb_ok.Top = cb_cancelar.Top;

            cb_cancelar.Left = 40;
            cb_ok.Left = dw_seleccion.Width + dw_seleccion.Left - cb_ok.Width;

            if (dw_seleccion.Height > dw_buscar.Height)
            {
                this.Width = dw_seleccion.Left + dw_seleccion.Width + 120;
            }
            else
            {
                this.Width = dw_buscar.Left + dw_buscar.Width + 120;
            }

            this.Height = cb_cancelar.Top + cb_cancelar.Height + 120;
        }

        // ========================================================
        // wf_buscar_fila (función PB pública)
        // ========================================================

        // public function integer wf_buscar_fila ()
        public int wf_buscar_fila()
        {
            string condicion = string.Empty;

            // Nombre de la columna que es clave
            if (is_nombre_columna == "!" ||
                is_nombre_columna == "?" ||
                is_nombre_columna == null)
            {
                return -1;
            }

            switch (at_seleccion_row.tipo_columna)
            {
                case "NUMB":
                case "DECI":
                case "LONG":
                    condicion = is_nombre_columna + " = " + at_seleccion_row.valor_columna;
                    break;

                case "CHAR":
                case "STRI":
                case "DATE":
                    condicion = is_nombre_columna + " = '" + at_seleccion_row.valor_columna + "'";
                    break;
            }

            // Busco la fila, si la encuentro la selecciono
            int row = dw_seleccion.Find(condicion, 1, (int)il_q_filas);
            if (row > 0)
            {
                dw_seleccion.SetRow(row);
                dw_seleccion.SelectRow(row, true);
                dw_seleccion.ScrollToRow(row);
            }
            else
            {
                return -1;
            }

            return 1;
        }

        // ========================================================
        // Eventos GUI / equivalentes PB
        // ========================================================

        private void cb_cancelar_Click(object? sender, EventArgs e)
        {
            // PB: at_seleccion_row.valor_retorno = -1; CloseWithReturn(Parent, at_seleccion_row)
            at_seleccion_row.valor_retorno = -1;
            this.Tag = at_seleccion_row;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cb_ok_Click(object? sender, EventArgs e)
        {
            // PB: event clicked de cb_ok
            int row = dw_seleccion.GetRow();
            if (row > 0)
            {
                at_seleccion_row.valor_retorno = 1;
                at_seleccion_row.descripcion = dw_seleccion.GetItemString(row, 2);

                string colType = dw_seleccion.Describe("#1.ColType");
                string prefix = (colType ?? string.Empty).ToUpper().PadRight(4).Substring(0, 4);

                switch (prefix)
                {
                    case "STRI":
                    case "CHAR":
                        at_seleccion_row.valor_columna = dw_seleccion.GetItemString(row, 1);
                        break;

                    case "NUMB":
                    case "LONG":
                        at_seleccion_row.valor_columna =
                            Convert.ToString(dw_seleccion.GetItemNumber(row, 1));
                        break;

                    case "DECI":
                        at_seleccion_row.valor_columna =
                            Convert.ToString(dw_seleccion.GetItemDecimal(row, 1));
                        break;

                    case "DATE":
                        var dt = dw_seleccion.GetItemDate(row, 1);
                        at_seleccion_row.valor_columna = f_date_a_string(dt);
                        break;

                        // Case 'DATET' (si tenés f_datetime_a_string, lo agregás acá)
                }

                this.Tag = at_seleccion_row;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // PB: cb_cancelar.Event Trigger clicked()
                cb_cancelar_Click(sender, e);
            }
        }

        private void dw_seleccion_DoubleClick(object? sender, EventArgs e)
        {
            // PB: doubleclicked -> cb_ok.event Trigger Clicked()
            cb_ok_Click(sender, e);
        }

        private void dw_seleccion_Click(object? sender, EventArgs e)
        {
            // PB: clicked; this.selectrow(0,false); this.selectrow(row,true); dw_buscar.SetItem(1,1,...)

            int row = dw_seleccion.GetRow();
            if (row <= 0) return;

            dw_seleccion.SelectRow(0, false);
            dw_seleccion.SelectRow(row, true);

            string desc = dw_seleccion.GetItemString(row, 2);
            dw_buscar.SetItem(1, 1, desc);
        }

        private void dw_buscar_TextChanged(object? sender, EventArgs e)
        {
            // PB: dw_buscar editchanged
            int size;
            int resp;
            string item;
            string condicion;
            int ll_row;

            SetPointerHourGlass();
            dw_buscar.SetRedraw(false);

            item = dw_buscar.GetText();
            item = (item ?? string.Empty).ToUpper();
            size = item.Length;

            if (size > 0)
            {
                condicion = $"Upper ( Left({is_nombre_col_desc},{size}) ) = '{item}'";

                ll_row = dw_seleccion.Find(condicion, 1, (int)il_q_filas);
                if (ll_row != 0)
                {
                    resp = dw_seleccion.SelectRow(0, false);
                    resp = dw_seleccion.SelectRow(ll_row, true);
                    resp = dw_seleccion.ScrollToRow(ll_row);

                    // si quisieras copiar la descripción nuevamente:
                    // dw_buscar.SetItem(1,1, Left(dw_seleccion.GetItemString(ll_row,2),60));
                }
                else
                {
                    // beep / nada
                }
            }

            dw_buscar.SetRedraw(true);
            SetPointerArrow();
        }

        // Helpers equivalentes a SetPointer(HourGlass!/Arrow!)
        private void SetPointerHourGlass()
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        private void SetPointerArrow()
        {
            Cursor.Current = Cursors.Arrow;
        }

        // Equivalente PB Left()
        private static string Left(string? s, int len)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            if (len <= 0) return string.Empty;
            if (len >= s.Length) return s;
            return s.Substring(0, len);
        }

        // Stub para f_date_a_string – vos ya deberías tenerlo migrado
        private string f_date_a_string(DateTime date)
        {
            // Ajustá al formato que uses en el resto del sistema
            return date.ToString("yyyy-MM-dd");
        }
    }
}
