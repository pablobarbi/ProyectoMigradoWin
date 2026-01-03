
using Minotti.Data;
using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Controls;
using Minotti.Views.Basicos.Models;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Capitulos.Controls
{
    public partial class w_carga_medicamentos : w_carga
    {
        // PB variables
        private string is_nombre_columna = string.Empty;
        private string idata = string.Empty;
        private long il_q_filas;
        private string is_back_color = "15794175";
        private bool ib_modificar_dw_busqueda = false;
        private string is_TipoUpdate = string.Empty;

        public w_carga_medicamentos()
        {
            InitializeComponent();

            // Wire events (si tu uo_dw expone eventos .NET; si no, no rompe)
            TryWireDwBuscarEvents();
        }

        // =====================================================
        // PB: public function integer wf_medicamentos_seleccionados ()
        // =====================================================
        public int wf_medicamentos_seleccionados()
        {
            long i, cnt, valor;

            cnt = 0;
            for (i = 1; i <= dw_1.RowCount(); i++)
            {
                valor = (long)dw_1.GetItemNumber(i, "valor");
                if (valor == 1 || valor == 2 || valor == 3)
                {
                    cnt = cnt + 1;
                }
            }

            return (int)cnt;
        }

        // =====================================================
        // PB: event ue_iniciar
        // =====================================================
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            int tope, iAux, tamaño, scroll, current_col, total_med;
            string col, ult_campo, nombre;
            string[] argumentos = new string[3];

            is_TipoUpdate = astp_w_seleccion.parametros[1];
            argumentos[1] = astp_w_seleccion.parametros[2];
            argumentos[2] = astp_w_seleccion.parametros[3];

            dw_1.uof_retrieve(argumentos);

            // Inserto una fila en dw_buscar
            if (dw_buscar.RowCount() <= 0)
                dw_buscar.InsertRow(0);

            if (!ib_modificar_dw_busqueda)
            {
                tope = Convert.ToInt32(dw_buscar.Describe("DataWindow.Column.Count"));
                for (iAux = 1; iAux <= tope; iAux++)
                {
                    col = "#" + Convert.ToString(iAux);

                    // solo dejo visibles los campos que son del detalle
                    nombre = dw_buscar.Describe(col + ".Name");
                    if (dw_buscar.Describe(nombre + ".Band") == "detail")
                        dw_buscar.Modify(col + ".Visible = 1");
                    else
                        dw_buscar.Modify(col + ".Visible = 0");

                    if (dw_buscar.Describe(col + ".Visible") == "1")
                    {
                        // Le saco la propiedad de Rectangulo en el foco
                        switch (dw_buscar.Describe(col + ".Edit.Style").ToUpperInvariant())
                        {
                            case "EDIT":
                                dw_buscar.Modify(col + ".Edit.FocusRectangle=no");
                                break;
                            case "DDDW":
                                dw_buscar.Modify(col + ".dddw.FocusRectangle=no");
                                break;
                            case "DDLB":
                                dw_buscar.Modify(col + ".ddlb.FocusRectangle=no");
                                break;
                            case "EDITMASK":
                                dw_buscar.Modify(col + ".EditMask.FocusRectangle=no");
                                break;
                        }

                        // Borde, protect, background, etc.
                        dw_buscar.Modify(col + ".Border='2'"); // Box
                        dw_buscar.Modify(col + ".Protect='0'");
                        dw_buscar.Modify(col + ".Background.Mode='0'");
                        dw_buscar.Modify(col + ".Background.Color='" + is_back_color + "'");
                        dw_buscar.Modify(col + ".Height.AutoSize=No");
                    }
                }
            }

            if (!ib_modificar_dw_busqueda)
            {
                // Modifico el tamaño del ultimo campo visible
                ult_campo = dw_buscar.uof_ultimo_campo_visible();
                tamaño = Convert.ToInt32(dw_buscar.Describe(ult_campo + ".Width"));
                scroll = dw_1.Width - Convert.ToInt32(dw_buscar.Describe(ult_campo + ".X")) - tamaño;
                tamaño = tamaño + scroll - 5;

                dw_buscar.Modify(ult_campo + ".Width= " + Convert.ToString(tamaño));

                // Setea el orden de los campos visibles
                current_col = dw_buscar.wf_settaborder_campos_visibles();
                if (current_col > 0)
                    dw_buscar.SetColumn(current_col);

                ib_modificar_dw_busqueda = true;
            }

            // Recupero cantidad de filas
            il_q_filas = dw_1.RowCount();

            // Modifico titulo con seleccionados
            total_med = wf_medicamentos_seleccionados();
            this.Text = "Seleccione los medicamentos para la rubrica - Seleccionados: " + Convert.ToString(total_med);

            // foco en dw_buscar
            dw_buscar.SetFocus();
        }

        // =====================================================
        // PB: event ue_leer_parametros
        // =====================================================
        public override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            // Inserto un fila en blanco a la dw de busqueda de la descripcion
            dw_buscar.uof_setdataobject(dw_1.DataObject);
            dw_buscar.SetTransObject(SQLCA.Instance);
            dw_buscar.cant_filas = 1;

            // Solo dejo ver el Detalle, y doy el color a la DataWindow
            dw_buscar.Modify("Datawindow.Header.Height=0");
            dw_buscar.Modify("Datawindow.Footer.Height=0");
            dw_buscar.Modify("Datawindow.Summary.Height=0");
            dw_buscar.Modify("Datawindow.Color=" + Convert.ToString(this.BackColor));
        }

        // =====================================================
        // PB: event ue_dw_itemchanged
        // =====================================================
        public virtual int ue_dw_itemchanged(uo_dw arg_objeto)
        {
            base.ue_dw_itemchanged(arg_objeto);

            int size, resp;
            string item, condicion;
            long ll_row;
            string colName = string.Empty;

            if (arg_objeto != dw_buscar) return 0;

            // Si está en una DropDownDatawindow
            var style = dw_buscar.Describe("#" + Convert.ToString(dw_buscar.GetColumn()) + ".Edit.Style");
            if (style != null)
            {
                var st = style.ToUpperInvariant();
                if (st == "DDDW" || st == "DDLB")
                {
                    item = dw_buscar.GetText();
                    size = item?.Length ?? 0;

                    if (size > 0)
                    {
                        switch (dw_buscar.at_col[dw_buscar.GetColumn()].Tipo)
                        {
                            case "char(":
                                //condicion = "Left(" + dwo.name + "," + Convert.ToString(size) + ")= '" + item + "'";
                                colName = arg_objeto.uof_current_column_name();
                                if (string.IsNullOrEmpty(colName)) return 0;

                                condicion = $"Left({colName},{size}) = '{item}'";
                                break;

                            case "long":
                            case "numbe":
                            case "real":
                            case "decim":
                                //if (!PBUtils.IsNumber(item)) return 0;
                                //condicion = dwo.name + "= " + item;

                                if (!PBUtils.IsNumber(item)) return 0;

                                colName = arg_objeto.uof_current_column_name();
                                if (string.IsNullOrEmpty(colName)) return 0;

                                condicion = $"{colName} = {item}";
                                break;

                            case "date":
                            case "datet":
                            case "time":
                                //condicion = dwo.name + "= " + item;
                                colName = arg_objeto.uof_current_column_name();
                                if (string.IsNullOrEmpty(colName)) return 0;

                                condicion = $"{colName} = {item}";

                                break;

                            default:
                                return 0;
                        }

                      PBUtils.SetPointerHourglass();
                        ll_row = dw_1.Find(condicion, 1, (int)il_q_filas);
                        if (ll_row != 0)
                        {
                            resp = dw_1.SelectRow(0, false);
                            resp = dw_1.SelectRow(ll_row, true);
                            resp = dw_1.ScrollToRow(ll_row);
                        }
                        PBUtils.SetPointerArrow();
                    }
                }
            }

            return 0;
        }

        // =====================================================
        // PB: event ue_acomodar_objetos
        // =====================================================
        public override void ue_acomodar_objetos()
        {
            int espacio_botones, borde_boton;

            // dw_1
            dw_1.Height = dw_1.uof_largo();
            dw_1.Width = dw_1.uof_ancho();
            dw_1.Y = s_esp.borde;
            dw_1.X = s_esp.borde;

            // dw_buscar
            dw_buscar.Height = dw_buscar.uof_largo();
            dw_buscar.Width = dw_1.Width;
            dw_buscar.X = dw_1.X;
            dw_buscar.Y = dw_1.Y + dw_1.Height + s_esp.borde;

            // tamaño ventana
            this.Height = dw_1.uof_largo() + dw_buscar.uof_largo() + 4 * s_esp.borde + pb_cancelar.Height + s_esp.largo;
            this.Width = Math.Max(dw_1.Width, pb_cancelar.Width * 2 + s_esp.borde) + 2 * s_esp.borde + s_esp.ancho;

            // botones
            pb_cancelar.Y = dw_buscar.Y + dw_buscar.Height + s_esp.borde;
            pb_continuar.Y = pb_cancelar.Y;

            espacio_botones = (int)((this.Width - pb_cancelar.Width * 2 - s_esp.borde) / 2.0);

            borde_boton = (int)(espacio_botones * 0.6);
            pb_continuar.X = borde_boton;
            pb_cancelar.X = this.Width - borde_boton - pb_cancelar.Width;

            this.wf_centrar_response();
        }

        // =====================================================
        // PB: event ue_continuar
        // =====================================================
        public override void ue_continuar()
        {
            base.ue_continuar();

            int i;
            uo_ds ds_medicacion;
            long ll_Capitulo, ll_Rubrica, ll_Fila, ll_SubRubrica;
            long ll_Medicamentos, ll_Valor, ll_FilaMod, ll_SubRubricaPadre, ll_SubRubricaHija;
            string[] ls_Argumentos = new string[3];
            string ls_Medicamento, ls_Filtro;

            if (dw_1.AcceptText() < 0) return;

            astr_w_seleccion.opcion = 1;

            // Obtengo argumentos
            dw_1.uof_getargumentos(astr_w_seleccion.s_det, dw_1.GetRow());

            if (is_TipoUpdate == "CAPITULACION")
            {
                ll_Capitulo = Convert.ToInt64(astp_w_seleccion.parametros[2]);
                ll_Rubrica = Convert.ToInt64(astp_w_seleccion.parametros[3]);
                ls_Argumentos[1] = astp_w_seleccion.parametros[2];
                ls_Argumentos[2] = astp_w_seleccion.parametros[3];

                ds_medicacion = new uo_ds();
                ds_medicacion.uof_setdataobject("dsto_actualiza_capitulacion_med");
                ds_medicacion.SetTransObject(SQLCA.Instance);
                ds_medicacion.uof_retrieve(ls_Argumentos);

                for (ll_Medicamentos = 1; ll_Medicamentos <= dw_1.RowCount(); ll_Medicamentos++)
                {
                    ls_Medicamento = dw_1.GetItemString(ll_Medicamentos, "medicamento");
                    ll_Valor = (long)dw_1.GetItemNumber(ll_Medicamentos, "valor");

                    if (ll_Valor == 1 || ll_Valor == 2 || ll_Valor == 3)
                    {
                        ls_Filtro = "medicamento = \"" + ls_Medicamento + "\"";
                        ll_FilaMod = ds_medicacion.Find(ls_Filtro, 1, ds_medicacion.RowCount());
                        if (ll_FilaMod > 0)
                        {
                            ds_medicacion.SetItem(ll_FilaMod, "valor", ll_Valor);
                        }
                        else
                        {
                            ll_Fila = ds_medicacion.InsertRow(0);
                            ds_medicacion.SetItem(ll_Fila, "capitulo", ll_Capitulo);
                            ds_medicacion.SetItem(ll_Fila, "rubrica", ll_Rubrica);
                            ds_medicacion.SetItem(ll_Fila, "medicamento", ls_Medicamento);
                            ds_medicacion.SetItem(ll_Fila, "valor", ll_Valor);
                        }
                    }

                    if (ll_Valor == 0)
                    {
                        ls_Filtro = "medicamento = \"" + ls_Medicamento + "\"";
                        ll_FilaMod = ds_medicacion.Find(ls_Filtro, 1, ds_medicacion.RowCount());
                        if (ll_FilaMod > 0)
                            ds_medicacion.DeleteRow(ll_FilaMod);
                    }
                }

                ds_medicacion.AcceptText();
                ds_medicacion.Update();
            }
            else if (is_TipoUpdate == "RUBRICACION")
            {
                ll_Rubrica = Convert.ToInt64(astp_w_seleccion.parametros[2]);
                ll_SubRubrica = Convert.ToInt64(astp_w_seleccion.parametros[3]);
                ls_Argumentos[1] = astp_w_seleccion.parametros[2];
                ls_Argumentos[2] = astp_w_seleccion.parametros[3];

                ds_medicacion = new uo_ds();
                ds_medicacion.uof_setdataobject("dsto_actualiza_rubricacion_med");
                ds_medicacion.SetTransObject(SQLCA.Instance);
                ds_medicacion.uof_retrieve(ls_Argumentos);

                for (ll_Medicamentos = 1; ll_Medicamentos <= dw_1.RowCount(); ll_Medicamentos++)
                {
                    ls_Medicamento = dw_1.GetItemString(ll_Medicamentos, "medicamento");
                    ll_Valor = (long)dw_1.GetItemNumber(ll_Medicamentos, "valor");

                    if (ll_Valor == 1 || ll_Valor == 2 || ll_Valor == 3)
                    {
                        ls_Filtro = "medicamento = \"" + ls_Medicamento + "\"";
                        ll_FilaMod = ds_medicacion.Find(ls_Filtro, 1, ds_medicacion.RowCount());
                        if (ll_FilaMod > 0)
                        {
                            ds_medicacion.SetItem(ll_FilaMod, "valor", ll_Valor);
                        }
                        else
                        {
                            ll_Fila = ds_medicacion.InsertRow(0);
                            ds_medicacion.SetItem(ll_Fila, "rubrica", ll_Rubrica);
                            ds_medicacion.SetItem(ll_Fila, "subrubrica", ll_SubRubrica);
                            ds_medicacion.SetItem(ll_Fila, "medicamento", ls_Medicamento);
                            ds_medicacion.SetItem(ll_Fila, "valor", ll_Valor);
                        }
                    }

                    if (ll_Valor == 0)
                    {
                        ls_Filtro = "medicamento = \"" + ls_Medicamento + "\"";
                        ll_FilaMod = ds_medicacion.Find(ls_Filtro, 1, ds_medicacion.RowCount());
                        if (ll_FilaMod > 0)
                            ds_medicacion.DeleteRow(ll_FilaMod);
                    }
                }

                ds_medicacion.AcceptText();
                ds_medicacion.Update();
            }
            else if (is_TipoUpdate == "SUBRUBRICACION")
            {
                ll_SubRubricaPadre = Convert.ToInt64(astp_w_seleccion.parametros[2]);
                ll_SubRubricaHija = Convert.ToInt64(astp_w_seleccion.parametros[3]);
                ls_Argumentos[1] = astp_w_seleccion.parametros[2];
                ls_Argumentos[2] = astp_w_seleccion.parametros[3];

                ds_medicacion = new uo_ds();
                ds_medicacion.uof_setdataobject("dsto_actualiza_subrubricacion_med");
                ds_medicacion.SetTransObject(SQLCA.Instance);
                ds_medicacion.uof_retrieve(ls_Argumentos);

                for (ll_Medicamentos = 1; ll_Medicamentos <= dw_1.RowCount(); ll_Medicamentos++)
                {
                    ls_Medicamento = dw_1.GetItemString(ll_Medicamentos, "medicamento");
                    ll_Valor = (long)dw_1.GetItemNumber(ll_Medicamentos, "valor");

                    if (ll_Valor == 1 || ll_Valor == 2 || ll_Valor == 3)
                    {
                        ls_Filtro = "medicamento = \"" + ls_Medicamento + "\"";
                        ll_FilaMod = ds_medicacion.Find(ls_Filtro, 1, ds_medicacion.RowCount());
                        if (ll_FilaMod > 0)
                        {
                            ds_medicacion.SetItem(ll_FilaMod, "valor", ll_Valor);
                        }
                        else
                        {
                            ll_Fila = ds_medicacion.InsertRow(0);
                            ds_medicacion.SetItem(ll_Fila, "subrubrica_padre", ll_SubRubricaPadre);
                            ds_medicacion.SetItem(ll_Fila, "subrubrica_hija", ll_SubRubricaHija);
                            ds_medicacion.SetItem(ll_Fila, "medicamento", ls_Medicamento);
                            ds_medicacion.SetItem(ll_Fila, "valor", ll_Valor);
                        }
                    }

                    if (ll_Valor == 0)
                    {
                        ls_Filtro = "medicamento = \"" + ls_Medicamento + "\"";
                        ll_FilaMod = ds_medicacion.Find(ls_Filtro, 1, ds_medicacion.RowCount());
                        if (ll_FilaMod > 0)
                            ds_medicacion.DeleteRow(ll_FilaMod);
                    }
                }

                ds_medicacion.AcceptText();
                ds_medicacion.Update();
            }
            else
            {
                // PB: "HAY QUE VER ESTE ESPACIO..."
                // No invento nada.
            }

            // Cierro la ventana
            Close();
        }

        // =====================================================
        // PB: dw_buscar events
        // =====================================================

        // PB dw_buscar::editchanged
        private void dw_buscar_editchanged(string data)
        {
            int size, resp;
            string item, condicion;
            long ll_row;

            item = data;
            size = item?.Length ?? 0;

            condicion = null;

            if (size > 0)
            {
                // PB: dwo.name => nombre de la columna actual del DW
                string colName = dw_buscar.uof_current_column_name();
                if (string.IsNullOrEmpty(colName)) return;

                switch (dw_buscar.at_col[dw_buscar.GetColumn()].Tipo)
                {
                    case "char(":
                        condicion = $"Left({colName},{size}) = '{item}'";
                        break;

                    case "long":
                    case "numbe":
                    case "real":
                    case "decim":
                        if (!PBUtils.IsNumber(item)) return;
                        condicion = $"{colName} = {item}";
                        break;

                    default:
                        return;
                }

                if (string.IsNullOrEmpty(condicion)) return;

                PBUtils.SetPointerHourglass();

                ll_row = dw_1.Find(condicion, 1, (int)il_q_filas);
                if (ll_row != 0)
                {
                    resp = dw_1.SelectRow(0, false);
                    resp = dw_1.SelectRow(ll_row, true);
                    resp = dw_1.ScrollToRow(ll_row);
                }

                PBUtils.SetPointerArrow();
            }


            PBUtils.SetPointerArrow();
        }

        // PB dw_buscar::itemchanged
        private void dw_buscar_itemchanged(string data)
        {
            int size, resp;
            string item, condicion, tipo;
            long ll_row;

            item = data;
            size = item?.Length ?? 0;

            if (size > 0)
            {
                tipo = dw_buscar.at_col[dw_buscar.GetColumn()].Tipo;
                if (tipo == "date" || tipo == "datet" || tipo == "time")
                {
                    PBUtils.SetPointerHourglass();
                    //condicion = dwo.name + " >= " + item;
                    string colName = dw_buscar.uof_current_column_name();
                    if (string.IsNullOrEmpty(colName)) return;

                    condicion = $"{colName} >= {item}";


                    ll_row = dw_1.Find(condicion, 1, (int)il_q_filas);
                    if (ll_row != 0)
                    {
                        resp = dw_1.SelectRow(0, false);
                        resp = dw_1.SelectRow(ll_row, true);
                        resp = dw_1.ScrollToRow(ll_row);
                    }
                    PBUtils.SetPointerArrow();
                }
            }
        }

        // PB dw_buscar::itemfocuschanged
        private void dw_buscar_itemfocuschanged(long row)
        {
            int iAux;
            string nulo = null;

            for (iAux = 1; iAux <= Convert.ToInt32(dw_buscar.Describe("DataWindow.Column.Count")); iAux++)
            {
                dw_buscar.uof_setitem(row, iAux, nulo);
            }
        } 
      

        /// <summary>
        /// Intenta conectar eventos .NET si tu uo_dw los expone.
        /// No inventa lógica: solo “cablea” llamadas a los mismos scripts PB.
        /// </summary>
        private void TryWireDwBuscarEvents()
        {
            var t = dw_buscar.GetType();

            // Si existen eventos .NET con estos nombres, los conectamos.
            // (Si no existen, no pasa nada.)
            WireIfExists(t, "EditChanged", (Action<string>)dw_buscar_editchanged);
            WireIfExists(t, "ItemChanged", (Action<string>)dw_buscar_itemchanged);
            WireIfExists(t, "ItemFocusChanged", (Action<long>)dw_buscar_itemfocuschanged);

            void WireIfExists(Type type, string eventName, Delegate handler)
            {
                var ev = type.GetEvent(eventName);
                if (ev == null) return;
                ev.AddEventHandler(dw_buscar, handler);
            }
        }
    }
}
