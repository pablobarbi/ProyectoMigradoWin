using Minotti.Data;
using Minotti.utils;
using Minotti.Views.Basicos.Controls;
using Minotti.Views.Pbl.Views;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Abm.Controls
{
    public partial class w_abm_lista_seleccion : w_abm_lista
    {
        /* Controles */
        public uo_dw dw_buscar;
        

        /* Variables */
        string is_nombre_columna, idata;
        int il_q_filas;
        string is_back_color = "15794175";
        bool ib_modificar_dw_busqueda = false;

        public w_abm_lista_seleccion()
        {
            InitializeComponent();

            // PB create/destroy lo resolvemos con eventos WinForms sin duplicar Dispose.
            this.Load += (_, __) => OnCreatePB();
            this.FormClosing += (_, __) => close(); // ya tenías close()
        }

        private void OnCreatePB()
        {
            // PB: on w_abm_lista_seleccion.create
            // call super::create  -> WinForms base ya corre por constructor/Load de la base

            if (dw_buscar == null || dw_buscar.IsDisposed)
            {
                dw_buscar = new uo_dw();
                this.Controls.Add(dw_buscar);
            }
        }

        // --------------------------------------------------------------------
        // events
        // --------------------------------------------------------------------

        public void activate()
        {
            base.activate();
          PBGlobals.m_mdi.m_confirmar.Enabled = false;
        }

        public virtual void ue_dw_detalle(object? sender = null)
        {
            // PB-style base method. Intentionally empty.
        }

        public override void ue_acomodar_objetos()
        {
            int largo_dw1 = this.wf_largo_disponible() - s_esp.borde - dw_buscar.uof_largo();

            dw_1.Width = Math.Min(dw_1.uof_ancho(), this.wf_ancho_disponible());
            dw_1.Height = largo_dw1;
            dw_1.Top = s_esp.borde;
            this.wf_centrarobjeto(dw_1);

            dw_buscar.Height = dw_buscar.uof_largo();
            dw_buscar.Width = dw_1.Width;
            dw_buscar.Left = dw_1.Left;
            dw_buscar.Top = dw_1.Top + dw_1.Height + s_esp.borde;
        }

        public override void ue_ajustar_tamaño()
        {
            this.Width = dw_1.uof_ancho() + s_esp.ancho + 2 * s_esp.borde;
            this.Height =
                dw_1.uof_largo() + s_esp.largo + 2 * s_esp.borde
                + dw_buscar.uof_largo() + 80;
        }

        public override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            dw_buscar.uof_setdataobject(dw_1.DataObject);
            dw_buscar.SetTransObject(SQLCA.Instance);
            dw_buscar.cant_filas = 1;

            dw_buscar.Modify("Datawindow.Header.Height=0");
            dw_buscar.Modify("Datawindow.Footer.Height=0");
            dw_buscar.Modify("Datawindow.Summary.Height=0");
            dw_buscar.Modify("Datawindow.Color=" + this.BackColor);
        }

        public override int ue_dw_itemchanged(uo_dw arg_objeto, long row, int column, string data)
        {
            int size, resp;
            string item, condicion;
            long ll_row;

            if (arg_objeto != dw_buscar) return 0;

            string style = dw_buscar.Describe("#" + dw_buscar.GetColumn() + ".Edit.Style").ToUpper();

            if (style == "DDDW" || style == "DDLB")
            {
                item = dw_buscar.GetText();
                size = item.Length;
                string colName = string.Empty;
                if (size > 0)
                {
                    switch (dw_buscar.at_col[dw_buscar.GetColumn()].Tipo)
                    {
                        case "char(":
                            //condicion = $"Left({dwo.name},{size})= '{item}'";
                            colName = dw_buscar.at_col[dw_buscar.GetColumn()]?.Nombre ?? string.Empty;
                            condicion = colName + " = " + item;
                            break;

                        case "long":
                        case "numbe":
                        case "real":
                        case "decim":
                            if (!PBUtils.IsNumber(item)) return 0;
                            //condicion = $"{dwo.name}= {item}";

                            colName = dw_buscar.uof_current_column_name();
                            if (string.IsNullOrEmpty(colName)) return 0;

                            condicion = $"{colName} = {item}";
                            break;

                        case "date":
                        case "datet":
                        case "time":
                            //condicion = $"{dwo.name}= {item}";
                            colName = dw_buscar.uof_current_column_name(); // o dw_1 según corresponda
                            if (string.IsNullOrEmpty(colName)) return 0;

                            condicion = $"{colName} = {item}";
                            break;

                        default:
                            return 0;
                    }

                   PBUtils.SetPointerHourglass();
                    ll_row = dw_1.Find(condicion, 1, il_q_filas);
                    if (ll_row != 0)
                    {
                        resp = dw_1.SelectRow(0, false);
                        resp = dw_1.SelectRow(ll_row, true);
                        resp = dw_1.ScrollToRow(ll_row);
                    }
                    PBUtils.SetPointerArrow();
                }
            }

            return 0;
        }

        public override void ue_iniciar()
        {
            base.ue_iniciar();

            int tope, iAux, tamaño, scroll, current_col;
            string col, ult_campo, nombre;

            if (at_op.Accion != "A")
            {
                if (dw_buscar.RowCount() <= 0) dw_buscar.InsertRow(0);

                if (!ib_modificar_dw_busqueda)
                {
                    tope = Convert.ToInt32(dw_buscar.Describe("DataWindow.Column.Count"));

                    for (iAux = 1; iAux <= tope; iAux++)
                    {
                        col = "#" + iAux;
                        nombre = dw_buscar.Describe(col + ".Name");

                        if (dw_buscar.Describe(nombre + ".Band") == "detail")
                            dw_buscar.Modify(col + ".Visible = 1");
                        else
                            dw_buscar.Modify(col + ".Visible = 0");

                        if (dw_buscar.Describe(col + ".Visible") == "1")
                        {
                            string editStyle = dw_buscar.Describe(col + ".Edit.Style").ToUpper();

                            switch (editStyle)
                            {
                                case "EDIT": dw_buscar.Modify(col + ".Edit.FocusRectangle=no"); break;
                                case "DDDW": dw_buscar.Modify(col + ".dddw.FocusRectangle=no"); break;
                                case "DDLB": dw_buscar.Modify(col + ".ddlb.FocusRectangle=no"); break;
                                case "EDITMASK": dw_buscar.Modify(col + ".EditMask.FocusRectangle=no"); break;
                            }

                            dw_buscar.Modify(col + ".Border='2'");
                            dw_buscar.Modify(col + ".Protect='0'");
                            dw_buscar.Modify(col + ".Background.Mode='0'");
                            dw_buscar.Modify(col + ".Background.Color='" + is_back_color + "'");
                            dw_buscar.Modify(col + ".Height.AutoSize=No");
                        }
                    }

                    ult_campo = dw_buscar.uof_ultimo_campo_visible();
                    tamaño = Convert.ToInt32(dw_buscar.Describe(ult_campo + ".Width "));
                    scroll = dw_1.Width - Convert.ToInt32(dw_buscar.Describe(ult_campo + ".X ")) - tamaño;
                    tamaño = tamaño + scroll - 5;

                    dw_buscar.Modify(ult_campo + ".Width= " + tamaño);

                    current_col = dw_buscar.wf_settaborder_campos_visibles();
                    if (current_col > 0) dw_buscar.SetColumn(current_col);

                    ib_modificar_dw_busqueda = true;
                }
            }

            il_q_filas = dw_1.RowCount();
            dw_buscar.SetFocus();
        }

        public override void close()
        {
            base.close();

            // PB: on destroy -> destroy(this.dw_buscar)
            if (dw_buscar != null && !dw_buscar.IsDisposed)
            {
                // Si tu framework usa DestroyUserObject o similar, usalo acá.
                dw_buscar.Dispose();
            }
        } 
    }
}
