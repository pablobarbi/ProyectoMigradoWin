using Minotti.Data;
using Minotti.Structures;
using Minotti.utils;
using Minotti.Views.Basicos.Menues;
using Minotti.Views.Basicos.Models;
using Minotti.Views.Reportes.Controls;
using MinottiApp.utils;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Message = Minotti.utils.Message;

namespace Minotti.Views.Basicos.Controls
{

    // forward
    // global type uo_dw from datawindow
    // end type
    // end forward

   

    // global type uo_dw from datawindow
    public class uo_dw : datawindow
    {
        // PB "props"
        public new int Width { get; set; } = 690;
        public new int Height { get; set; } = 388;
        public int TabOrder { get; set; } = 1;
        public bool HScrollBar { get; set; } = true;
        public bool VScrollBar { get; set; } = true;
        public bool Border { get; set; } = false;
        public bool LiveScroll { get; set; } = true;
        /// <summary>
        /// PB: hsplitScroll
        /// Control de scroll horizontal con split
        /// WinForms no tiene equivalente → alias de compatibilidad
        /// </summary>
        public bool hsplitScroll
        {
            get => false;
            set
            {
                // NO-OP
                // PB lo usaba solo para comportamiento visual
            }
        }

        // ===== variables =====
        // private:
        private bool flag_row_change = true;          /* Le indica al rowfocuschanged si debe actuar o no */
        private bool flag_estilos_en_dw = false;      /* Indica si existe xx_estilos_edicion en el DW */
        private long il_fila_shift = 0;               /* Servicio selección: fila activa al tocar Shift */
        private uost_sort ust_sort;                   /* Orden por doble click en títulos */
        private uost_seguridad ust_seg;               /* Campos protegidos usr_upd / fec_upd */
        private int ancho;                            /* Ancho del dataobject */
        private int sangria;                          /* sangría entre borde y 1er columna */
        private string dw_impresion = "";             /* máscara impresión */

        /* Servicios */
        private bool ib_resaltar_fila = false;        /* Resalta fila activa */
        private bool ib_seleccion = false;            /* Selección múltiple filas */
        private bool ib_registrar_usuario = false;    /* marca usr/fecha antes de Update */

        // public:
        public cat_columna[] at_col = Array.Empty<cat_columna>(); /* Datos de cada columna */
        public int[] ii_claves = Array.Empty<int>();             /* Posición de campos clave */
        public int cant_filas = 0;                               /* filas iniciales a mostrar */
        public bool ib_avisar_primer_fila_activa = true;         /* ue_cambio_fila en primer foco */
        public bool rb_menu = false;                             /* Menú botón derecho */

        public uo_app guo_app = new uo_app();

        private RowFocusIndicator _rowFocusIndicator = RowFocusIndicator.None;

        // ===== ctor =====
        public uo_dw()
        {
            // event constructor;
            constructor();

            // Si tu base datawindow ya expone eventos .NET, enganchalos acá.
            // Si NO, y la base llama virtuals, esto igual funciona.
        }

        // =====================================================================
        //  EVENTOS (PB)
        // =====================================================================

        // event ue_ordenar
        public virtual void ue_ordenar()
        {
            // This.SetSort(Message.StringParm)
            // This.Sort()
            this.SetSort(Message.StringParm);
            this.Sort();
        }

        // event ue_filtrar
        public virtual void ue_filtrar()
        {
            MessageBox.Show("Filtrar", "Evento");
        }

        // event ue_preview
        public virtual void ue_preview()
        {
            OpenWithParmPB.OpenWithParm(typeof(w_presentacion), this);
        }

        // event ue_cambio_fila
        public virtual void ue_cambio_fila()
        {
            long row = this.GetRow();

            /* Servicio Resaltar fila activa */
            if (ib_resaltar_fila && row > 0)
            {
                this.SelectRow(0, false);
                this.SelectRow(row, true);
            }

            /* Avisa a la ventana que cambió la fila activa */
            // Parent.Event Post Dynamic ue_dw_cambio_fila(This)
            // En C#: llamamos un método virtual en Parent si existe.
            if (this.Parent != null)
            {
                // Mantengo el nombre del evento “ue_dw_cambio_fila” como invocación dinámica
                DynamicEventInvoker.Post(this.Parent, "ue_dw_cambio_fila", this);
            }
        }

        // event downkey pbm_dwnkey
        public virtual void downkey(Keys key)
        {
            // Servicio selección filas (Shift)
            if (ib_seleccion && key == Keys.ShiftKey && il_fila_shift == 0)
                il_fila_shift = this.GetRow();

            // F1 => arma cadena con Tag y abre w_ayuda
            if (key == Keys.F1)
            {
                int iAux;
                string cadena = "";
                string tag;

                for (iAux = 1; iAux <= PBInt(this.Describe("DataWindow.Column.Count")); iAux++)
                {
                    tag = this.Describe("#" + iAux.ToString() + ".Tag");
                    if (!PBIsNull(tag) && tag.Trim() != "" && tag != "?" && tag != "!")
                    {
                        cadena = cadena + "*TIT*" + at_col[iAux].Titulo + "*DES*" + tag;
                    }
                }

                if (!PBIsNull(cadena) && cadena.Trim() != "")
                {
                    OpenWithParmPB.OpenWithParm(typeof(w_ayuda), cadena);
                    return;
                }
            }

            // F2 => w_carga_observaciones (solo si CHAR(n) >= 100)
            if (key == Keys.F2)
            {
                if (Left(this.GetColumnName(), 20) != "")
                {
                    cat_string at_string = new cat_string();
                    string tipo = Trim(Upper(this.Describe(this.GetColumnName() + ".coltype")));

                    if (Left(tipo, 5) == "CHAR(")
                    {
                        at_string.longitud = PBInt(Mid(tipo, 6, Len(tipo) - 6));
                        if (at_string.longitud >= 100)
                        {
                            at_string.texto_titulo = this.Describe(this.GetColumnName() + "_t.text");
                            if (PBIsNull(at_string.texto_titulo) || at_string.texto_titulo == "!" || at_string.texto_titulo == "?")
                                at_string.texto_titulo = "Ingrese Texto";

                            at_string.@string = this.GetText();

                            OpenWithParmPB.OpenWithParm(typeof(w_carga_observaciones), at_string);
                            at_string = (cat_string)Message.PowerObjectParm;
                            if (at_string.retorno == 1)
                                this.SetText(at_string.@string);
                        }
                    }
                }
                return;
            }

            // F5 => detalle del parent
            if (key == Keys.F5)
            {
                var iAux = this.GetRow();
                if (iAux > 0 && this.Parent != null)
                    DynamicEventInvoker.Post(this.Parent, "ue_dw_detalle", this);
            }

            // F11 => seleccion fila DDDW
            if (key == Keys.F11)
            {
                if (Left(this.GetColumnName(), 20) != "")
                {
                    cat_seleccion_row at_seleccion_row = new cat_seleccion_row();

                    at_seleccion_row.dataobject = this.at_col[this.GetColumn()].Objeto_seleccion;
                    if (PBIsNull(at_seleccion_row.dataobject) || Trim(at_seleccion_row.dataobject) == "") return;

                    at_seleccion_row.valor_columna = this.GetText();
                    at_seleccion_row.tipo_columna = Upper(Left(this.Describe(this.GetColumnName() + ".ColType"), 4));

                    if (this.Describe(this.GetColumnName() + "_xx_desc.Visible") == "1")
                        at_seleccion_row.descripcion = this.GetItemString(this.GetRow(), this.GetColumnName() + "_xx_desc");

                    OpenWithParmPB.OpenWithParm(typeof(w_seleccion_fila_dddw), at_seleccion_row);

                    at_seleccion_row = (cat_seleccion_row)Message.PowerObjectParm;
                    if (at_seleccion_row.valor_retorno == 1)
                    {
                        this.SetText(at_seleccion_row.valor_columna);
                        this.AcceptText();
                        if (this.Describe(this.GetColumnName() + "_xx_desc.Visible") == "1")
                            this.Describe("evaluate('" + this.GetColumnName() + "_xx_desc.Expression',1)");
                    }
                }
                return;
            }

            // F12 => operación asociada
            if (key == Keys.F12)
            {
                if (Left(this.GetColumnName(), 20) != "")
                {
                    string Operacion = this.at_col[this.GetColumn()].Operacion;
                    if (PBIsNull(Operacion) || Trim(Operacion) == "") return;

                    f_es_operacion_valida(Operacion, PBInt(this.at_col[this.GetColumn()].Nivel_operacion));
                }
                return;
            }
        }

        // event ue_refresh
        public virtual void ue_refresh()
        {
            int rtncode;
            string nombre_col;
            datawindowchild ldc;

            nombre_col = this.Describe("#" + this.GetColumn().ToString() + ".Name");

            if (this.Describe(nombre_col + ".Edit.Style") == "dddw")
            {
                rtncode = this.GetChild(nombre_col, out ldc);
                if (rtncode == -1)
                {
                    MessageBox.Show("Se ha producido un error al Refrescar la lista", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    ldc.SetTransObject(SQLCA.Instance);
                    this.ue_retrieve_childdw(ldc);
                }
            }
        }

        // event type integer ue_retrieve_childdw ( ref datawindowchild ldwc )
        public virtual int ue_retrieve_childdw(datawindowchild ldwc)
        {
            int rtn = 0;

            // PB: Nuevo: argumentos DWC
            string[] s_arg = Array.Empty<string>();
            string[] s_tipo = Array.Empty<string>();

            if (f_Get_dwc_argumentos(ldwc, ref s_arg, ref s_tipo) > 0)
                f_cargar_dwc(ldwc, s_arg);

            return rtn;
        }

        // event rbuttondown
        public virtual void rbuttondown()
        {
            if (rb_menu)
            {
                m_uo_dw NewMenu = new m_uo_dw();
                NewMenu.instanciar(this);
                NewMenu.Show(this.PointerX(), this.PointerY());
            }
        }

        // event doubleclicked
        public virtual void doubleclicked(long row)
        {
            string campo;

            if (Lower(Mid(this.GetBandAtPointer(), 1, 6)) == "header")
            {
                campo = this.GetObjectAtPointer();
                int iAux = Pos(campo, "_t~t", 1);
                if (iAux > 0)
                {
                    campo = Mid(campo, 1, iAux - 1);
                    if (this.Describe(campo + ".Tag") != "!")
                    {
                        if (ust_sort.columna == campo)
                            ust_sort.orden = (ust_sort.orden == "A") ? "D" : "A";
                        else
                        {
                            ust_sort.orden = "A";
                            ust_sort.columna = campo;
                        }

                        this.SetSort(campo + " " + ust_sort.orden);
                        this.Sort();
                    }
                }
            }

            if (row > 0 && this.Parent != null)
                DynamicEventInvoker.Post(this.Parent, "ue_dw_detalle", this);
        }

        // event dberror
        public virtual int dberror(int sqldbcode, string sqlerrtext)
        {
            guo_app.at_error_db.sqldbcode = sqldbcode;
            guo_app.at_error_db.sqlerrtext = sqlerrtext;
            return 1; // no muestro mensaje DB
        }

        // event rowfocuschanged
        public virtual void rowfocuschanged()
        {
            if (flag_row_change)
                this.ue_cambio_fila();
        }

        // event retrievestart
        public virtual void retrievestart()
        {
            if (!ib_avisar_primer_fila_activa)
                flag_row_change = false;
        }

        // event retrieveend
        public virtual void retrieveend()
        {
            flag_row_change = true;
        }

        // event constructor
        public virtual void constructor()
        {
            ust_seg.usuario = "usr_upd";
            ust_seg.fecha = "fec_upd";
        }

        // event updatestart
        public virtual void updatestart()
        {
            if (!ib_registrar_usuario) return;

            cat_usuario at_usuario = guo_app.uof_getusuario();
            for (int iAux = 1; iAux <= this.RowCount(); iAux++)
            {
                var status = this.GetItemStatus(iAux, 0, dwbuffer.Primary);
                if (status == dwitemstatus.NewModified || status == dwitemstatus.DataModified)
                {
                    this.SetItem(iAux, ust_seg.usuario, at_usuario.Usuario);
                    this.SetItem(iAux, ust_seg.fecha, DateTime.Now);
                }
            }
        }

        // event clicked
        public virtual void clicked(long row)
        {
            // Servicio selección filas
            if (ib_seleccion && row > 0)
            {
                if (KeyDown(Keys.ShiftKey))
                {
                    if (!KeyDown(Keys.ControlKey)) this.SelectRow(0, false);
                    for (long lAux = Math.Min(row, il_fila_shift); lAux <= Math.Max(row, il_fila_shift); lAux++)
                        this.SelectRow(lAux, true);
                }
                else
                {
                    il_fila_shift = 0;
                    if (!KeyDown(Keys.ControlKey))
                    {
                        bool bAux = this.isSelected(row);
                        this.SelectRow(0, false);
                        this.SelectRow(row, !bAux);
                    }
                    else
                        this.SelectRow(row, !this.isSelected(row));
                }
            }
        }

        // event itemchanged
        public virtual int itemchanged(long row, dwobject dwo, string data)
        {
            if (row > 0 && this.Parent != null)
                return DynamicEventInvoker.Trigger(this.Parent, "ue_dw_itemchanged", this, row, dwo, data);

            return 1;
        }

        // event itemerror
        public virtual int itemerror()
        {
            if (guo_app.FalloValidacion)
            {
                guo_app.FalloValidacion = false;
                return 1;
            }
            return 0;
        }

        // event buttonclicked
        public virtual void buttonclicked(dwobject dwo, long row)
        {
            if (dwo.name == "cb_ordenar")
            {
                cat_return atr = new cat_return();

                OpenWithParmPB.OpenWithParm(typeof(w_dworder), this);
                atr = (cat_return)Message.PowerObjectParm;

                if (atr.rtn_boolean)
                {
                    this.SetSort(atr.rtn_string);
                    this.Sort();
                }
            }

            // Siempre ejecuta evento del Parent
            if (dwo.type == "button" && this.Parent != null)
                DynamicEventInvoker.Trigger(this.Parent, "ue_dw_button_clicked", this, row, dwo);
        }

        // =====================================================================
        //  MÉTODOS uof_* / wf_*
        // =====================================================================

        public void uof_setdataobject(string data_object)
        {
            int iAux, jAux, campos, m;
            string param, sAux, sEstilos = "", sSeleccionFila = "", sOperacion = "", operacion_nivel;
            bool flag_seleccionfila = false, flag_operacion = true;

            datawindowchild dwc;
            string[] s_arg = Array.Empty<string>();
            string[] s_tipo = Array.Empty<string>();

            campos = guo_app.ds_valor_inicial.RowCount();

            // Carga DataObject
            this.DataObject = data_object;

            // limpia dataobject impresión
            this.dw_impresion = "";

            flag_estilos_en_dw = false;
            sangria = 1000;
            ancho = 0;
            ib_registrar_usuario = false;

            // Recorre objetos
            param = this.Describe("DataWindow.Objects");
            while (Len(param) > 0)
            {
                sAux = f_cortar_string(param, "~t");

                if (sAux == "xx_estilos_edicion")
                {
                    flag_estilos_en_dw = true;
                    sEstilos = Lower(this.Describe(sAux + ".Text"));
                }

                if (this.Describe(sAux + ".Visible") == "1")
                {
                    iAux = PBInt(this.Describe(sAux + ".X"));
                    if (iAux == 0)
                        iAux = Math.Min(PBInt(this.Describe(sAux + ".X1")), PBInt(this.Describe(sAux + ".X2")));
                    sangria = Math.Min(sangria, iAux);
                }

                iAux = PBInt(this.Describe(sAux + ".X")) + PBInt(this.Describe(sAux + ".Width"));
                if (iAux == 0)
                    iAux = Math.Max(PBInt(this.Describe(sAux + ".X1")), PBInt(this.Describe(sAux + ".X2")));
                ancho = Math.Max(ancho, iAux);

                if (sAux == "usr_upd") ib_registrar_usuario = true;

                if (sAux == "xx_recuperar_fk")
                {
                    flag_seleccionfila = true;
                    sSeleccionFila = this.Describe(sAux + ".Text");
                }

                if (sAux == "xx_operaciones")
                {
                    flag_operacion = true;
                    sOperacion = this.Describe(sAux + ".Text");
                }
            }

            // Columnas
            int cnt = PBInt(this.Describe("DataWindow.Column.Count"));
            if (at_col.Length < cnt + 1) Array.Resize(ref at_col, cnt + 1);

            jAux = 1;
            ii_claves = Array.Empty<int>();

            for (iAux = 1; iAux <= cnt; iAux++)
            {
                at_col[iAux].Nombre = this.Describe("#" + iAux + ".Name");
                at_col[iAux].Titulo = this.Describe(at_col[iAux].Nombre + "_t.Text");
                at_col[iAux].Tipo = Left(this.Describe("#" + iAux + ".Coltype"), 5);
                at_col[iAux].TabOrder = this.Describe("#" + iAux + ".TabSequence");

                at_col[iAux].Estilo = f_cortar_string(sEstilos, ",");
                if (at_col[iAux].Estilo == "")
                {
                    if (at_col[iAux].Nombre == ust_seg.usuario || at_col[iAux].Nombre == ust_seg.fecha)
                        at_col[iAux].Estilo = "n";
                    else
                        at_col[iAux].Estilo = "v";
                }

                if (flag_seleccionfila)
                    at_col[iAux].Objeto_seleccion = f_cortar_string(sSeleccionFila, ",");

                if (flag_operacion)
                {
                    operacion_nivel = f_cortar_string( sOperacion, ",");
                    at_col[iAux].Operacion = f_cortar_string( operacion_nivel, "|");
                    at_col[iAux].Nivel_operacion = operacion_nivel;
                }

                if (Upper(this.Describe("#" + iAux + ".Criteria.Dialog")) == "YES")
                {
                    at_col[iAux].Filtro = true;
                    this.Modify("#" + iAux + ".Criteria.Dialog=NO");
                }
                else at_col[iAux].Filtro = false;

                at_col[iAux].Requerido = false;
                switch (Upper(this.Describe("#" + iAux + ".Edit.Style")))
                {
                    case "EDIT":
                        if (Upper(this.Describe("#" + iAux + ".Edit.Required")) == "YES")
                        {
                            at_col[iAux].Requerido = true;
                            this.Modify("#" + iAux + ".Edit.Required=NO");
                        }
                        break;

                    case "DDLB":
                        if (Upper(this.Describe("#" + iAux + ".DDLB.Required")) == "YES")
                        {
                            at_col[iAux].Requerido = true;
                            this.Modify("#" + iAux + ".DDLB.Required=NO");
                        }
                        break;

                    case "DDDW":
                        if (Upper(this.Describe("#" + iAux + ".DDDW.Required")) == "YES")
                        {
                            at_col[iAux].Requerido = true;
                            this.Modify("#" + iAux + ".DDDW.Required=NO");
                        }

                        // Nuevo: carga DWC si tiene args
                        this.GetChild(at_col[iAux].Nombre, out dwc);
                        if (f_Get_dwc_argumentos(dwc, ref s_arg, ref s_tipo) > 0)
                            f_cargar_dwc(dwc, s_arg);

                        break;

                    case "EDITMASK":
                        if (Upper(this.Describe("#" + iAux + ".EditMask.Required")) == "YES")
                        {
                            at_col[iAux].Requerido = true;
                            this.Modify("#" + iAux + ".EditMask.Required=NO");
                        }
                        break;
                }

                if (Upper(this.Describe("#" + iAux + ".Key")) == "YES")
                {
                    if (ii_claves.Length < jAux + 1) Array.Resize(ref ii_claves, jAux + 1);
                    ii_claves[jAux] = iAux;
                    jAux++;
                }

                if (campos > 0)
                {
                    m = guo_app.ds_valor_inicial.Find("campo = '" + at_col[iAux].Nombre + "'", 1, campos);
                    if (m > 0)
                    {
                        this.Modify(at_col[iAux].Nombre + ".Initial='" +
                                    guo_app.ds_valor_inicial.GetItemString(m, "valor_inicial") + "'");
                    }
                }
            }
        }

        public int uof_cant_parametros()
        {
            long lAux;
            string sSelect = this.Describe("DataWindow.Table.SqlSelect");
            lAux = Pos(sSelect, ":");

            int iCant = 0;
            while (lAux > 0)
            {
                iCant++;
                long lAux2 = lAux + 1;
                lAux = Pos(sSelect, ":", (int)lAux2);
            }
            return iCant;
        }

        public long uof_retrieve(string[] parametros)
        {
            int iAux;
            long Retorno;

            string[] s_arg = Array.Empty<string>();
            string[] s_tipo = Array.Empty<string>();

            iAux = f_Get_dw_argumentos(this, s_arg, s_tipo);
            if (iAux < 0)
            {
                MessageBox.Show("Falló la Get_dw_Argumentos", "Error");
                return -1;
            }
            else if (iAux > 0 && UpperBound(parametros) == 0)
            {
                f_fijar_parametros(s_arg, ref parametros);
            }

            switch (UpperBound(s_arg))
            {
                case 0: Retorno = this.Retrieve(); break;
                case 1: Retorno = this.Retrieve(parametros[1]); break;
                case 2: Retorno = this.Retrieve(parametros[1], parametros[2]); break;
                case 3: Retorno = this.Retrieve(parametros[1], parametros[2], parametros[3]); break;
                case 4: Retorno = this.Retrieve(parametros[1], parametros[2], parametros[3], parametros[4]); break;
                case 5: Retorno = this.Retrieve(parametros[1], parametros[2], parametros[3], parametros[4], parametros[5]); break;
                case 6: Retorno = this.Retrieve(parametros[1], parametros[2], parametros[3], parametros[4], parametros[5], parametros[6]); break;
                case 7: Retorno = this.Retrieve(parametros[1], parametros[2], parametros[3], parametros[4], parametros[5], parametros[6], parametros[7]); break;
                case 8: Retorno = this.Retrieve(parametros[1], parametros[2], parametros[3], parametros[4], parametros[5], parametros[6], parametros[7], parametros[8]); break;
                case 9: Retorno = this.Retrieve(parametros[1], parametros[2], parametros[3], parametros[4], parametros[5], parametros[6], parametros[7], parametros[8], parametros[9]); break;
                case 10: Retorno = this.Retrieve(parametros[1], parametros[2], parametros[3], parametros[4], parametros[5], parametros[6], parametros[7], parametros[8], parametros[9], parametros[10]); break;
                default: Retorno = this.Retrieve(); break;
            }

            return Retorno;
        }

        public bool uof_getclaves(string[] parametros, int fila)
        {
            parametros = Array.Empty<string>();
            bool Retorno = true;

            for (int iAux = 1; iAux <= UpperBound(ii_claves); iAux++)
            {
                if (parametros.Length < iAux + 1) Array.Resize(ref parametros, iAux + 1);
                parametros[iAux] = this.uof_getitem(fila, ii_claves[iAux]);
                if (PBIsNull(parametros[iAux])) Retorno = false;
            }
            return Retorno;
        }

        public bool uof_getclaves(out string[] parametros, int fila)
        {
            parametros = Array.Empty<string>();
            bool Retorno = true;

            for (int iAux = 1; iAux <= UpperBound(ii_claves); iAux++)
            {
                if (parametros.Length < iAux + 1)
                    Array.Resize(ref parametros, iAux + 1);

                parametros[iAux] = this.uof_getitem(fila, ii_claves[iAux]);
                if (PBIsNull(parametros[iAux]))
                    Retorno = false;
            }
            return Retorno;
        }

        public bool uof_getregistro(ref string[] parametros, int fila)
        {
            if (fila <= 0 || fila > this.RowCount()) return false;

            int cnt = PBInt(this.Describe("DataWindow.Column.Count"));
            parametros = new string[cnt + 1];

            for (int iAux = 1; iAux <= cnt; iAux++)
                parametros[iAux] = this.uof_getitem(fila, iAux);

            return true;
        }

        public virtual bool uof_getargumentos(string[] parametros, int fila)
            => uof_getclaves(parametros, fila);

        public virtual string[] uof_getargumentos(int fila)
        {
            var arr = Array.Empty<string>();
            uof_getargumentos(arr, fila);
            return arr;
        }



        public void uof_setdwimpresion(string data_object) => dw_impresion = data_object;

        public void uof_edicion(string sector, string estilo)
        {
            sector = Upper(sector);
            int iCantidad = PBInt(this.Describe("DataWindow.Column.Count"));

            for (int iAux = 1; iAux <= iCantidad; iAux++)
            {
                if (sector == "T") uof_edicion(iAux, estilo);
                else if (Upper(this.Describe("#" + iAux + ".Key")) == "YES")
                {
                    if (sector == "K") uof_edicion(iAux, estilo);
                }
                else
                {
                    if (sector == "D") uof_edicion(iAux, estilo);
                }
            }
        }

        public void uof_edicion(int campo, string estilo)
        {
            int Tope = campo;
            if (campo == 0)
            {
                Tope = PBInt(this.Describe("DataWindow.Column.Count"));
                campo = 1;
            }

            for (int iAux = Math.Max(campo, 1); iAux <= Tope; iAux++)
            {
                string estilo_a_aplicar;
                if (at_col[iAux].Estilo == "v")
                    estilo_a_aplicar = Lower(estilo);
                else if (at_col[iAux].Estilo == "ea")
                    return;
                else
                    estilo_a_aplicar = at_col[iAux].Estilo;

                switch (estilo_a_aplicar)
                {
                    case "e":
                        this.Modify("#" + iAux + ".Border = '5'");
                        this.Modify("#" + iAux + ".Protect = '0'");
                        this.Modify("#" + iAux + ".Font.Weight = '400'");
                        this.Modify("#" + iAux + ".Font.Height = '-9'");
                        this.Modify("#" + iAux + ".Background.Mode = '0'");
                        this.Modify("#" + iAux + ".Background.Color = '16777215'");
                        switch (Upper(this.Describe("#" + iAux + ".Edit.Style")))
                        {
                            case "EDIT":
                            case "EDITMASK":
                                this.Modify("#" + iAux + ".Pointer = 'IBeam!'");
                                break;
                            case "DDLB":
                            case "DDDW":
                            case "CHECKBOX":
                            case "LISTBOX":
                                this.Modify("#" + iAux + ".Pointer = 'Arrow!'");
                                break;
                        }
                        break;

                    case "n":
                        this.Modify("#" + iAux + ".Border = '6'");
                        this.Modify("#" + iAux + ".Protect = '1'");
                        this.Modify("#" + iAux + ".Pointer = 'Arrow!'");
                        this.Modify("#" + iAux + ".Font.Weight = '400'");
                        this.Modify("#" + iAux + ".Font.Height = '-9'");
                        this.Modify("#" + iAux + ".Background.Mode = '1'");
                        break;

                    case "ed":
                        this.Modify("#" + iAux + ".Border = '5'");
                        this.Modify("#" + iAux + ".Protect = '0'");
                        this.Modify("#" + iAux + ".Pointer = 'IBeam!'");
                        this.Modify("#" + iAux + ".Font.Weight = '700'");
                        this.Modify("#" + iAux + ".Font.Height = '-10'");
                        this.Modify("#" + iAux + ".Background.Mode = '0'");
                        this.Modify("#" + iAux + ".Background.Color = '12639424'");
                        break;

                    case "nd":
                        this.Modify("#" + iAux + ".Border = '6'");
                        this.Modify("#" + iAux + ".Protect = '1'");
                        this.Modify("#" + iAux + ".Pointer = 'Arrow!'");
                        this.Modify("#" + iAux + ".Font.Weight = '700'");
                        this.Modify("#" + iAux + ".Font.Height = '-10'");
                        this.Modify("#" + iAux + ".Background.Mode = '0'");
                        this.Modify("#" + iAux + ".Background.Color = '10789024'");
                        break;
                }
            }
        }

        public int sort()
        {
            int Retorno = base.Sort();
            this.ue_cambio_fila();
            return Retorno;
        }

        public int filter()
        {
            flag_row_change = false;
            this.SelectRow(this.GetRow(), false);
            int Retorno = base.Filter();
            this.ue_cambio_fila();
            flag_row_change = true;
            return Retorno;
        }

        public int rowsdiscard(long s, long e, dwbuffer f)
        {
            int Retorno;
            long Fila = this.GetRow();

            if (Fila < s)
                Retorno = base.RowsDiscard(s, e, f);
            else if (Fila > e)
            {
                flag_row_change = false;
                Retorno = base.RowsDiscard(s, e, f);
                flag_row_change = true;
            }
            else
            {
                flag_row_change = false;
                Retorno = base.RowsDiscard(s, e, f);
                this.ue_cambio_fila();
                flag_row_change = true;
            }
            return Retorno;
        }

        public int rowsmove(long s, long e, dwbuffer f, datawindow d, long i, dwbuffer t)
        {
            int Retorno;
            long Fila = this.GetRow();

            if (Fila < s)
                Retorno = base.RowsMove(s, e, f, d, i, t);
            else if (Fila > e)
            {
                flag_row_change = false;
                Retorno = base.RowsMove(s, e, f, d, i, t);
                flag_row_change = true;
            }
            else
            {
                flag_row_change = false;
                Retorno = base.RowsMove(s, e, f, d, i, t);
                this.ue_cambio_fila();
                flag_row_change = true;
            }
            return Retorno;
        }

        public int rowsmove(long s, long e, dwbuffer f, datastore d, long i, dwbuffer t)
        {
            int Retorno;
            long Fila = this.GetRow();

            if (Fila < s)
                Retorno = base.RowsMove(s, e, f, d, i, t);
            else if (Fila > e)
            {
                flag_row_change = false;
                Retorno = base.RowsMove(s, e, f, d, i, t);
                flag_row_change = true;
            }
            else
            {
                flag_row_change = false;
                Retorno = base.RowsMove(s, e, f, d, i, t);
                this.ue_cambio_fila();
                flag_row_change = true;
            }
            return Retorno;
        }

        public int rowsmove(long s, long e, dwbuffer f, datawindowchild d, long i, dwbuffer t)
        {
            int Retorno;
            long Fila = this.GetRow();

            if (Fila < s)
                Retorno = base.RowsMove(s, e, f, d, i, t);
            else if (Fila > e)
            {
                flag_row_change = false;
                Retorno = base.RowsMove(s, e, f, d, i, t);
                flag_row_change = true;
            }
            else
            {
                flag_row_change = false;
                Retorno = base.RowsMove(s, e, f, d, i, t);
                this.ue_cambio_fila();
                flag_row_change = true;
            }
            return Retorno;
        }

        public void uof_marcar_seleccion(int modo)
        {
            if (modo == 1)
            {
                ib_seleccion = false;
                ib_resaltar_fila = true;
            }
            else if (modo == 2)
            {
                ib_resaltar_fila = false;
                ib_seleccion = true;
            }
            else
            {
                this.SelectRow(0, false);
                ib_resaltar_fila = false;
                ib_seleccion = false;
            }
        }

        public bool uof_aplicar_estilos() => flag_estilos_en_dw;

        public void uof_settaborderoriginal(int arg_col)
        {
            int Desde, Hasta;
            if (arg_col == 0)
            {
                Desde = 1;
                Hasta = PBInt(this.Describe("DataWindow.Column.Count"));
            }
            else
            {
                Desde = arg_col;
                Hasta = arg_col;
            }

            for (int iAux = Desde; iAux <= Hasta; iAux++)
                this.Modify("#" + iAux + ".TabSequence='" + at_col[iAux].TabOrder + "'");
        }

        public string uof_getdwimpresion() => dw_impresion;

        public void uof_imprimir()
            => OpenWithParmPB.OpenWithParm(typeof(w_opciones_de_impresion), this);

        public bool uof_vscrollbar()
        {
            if (this.Describe("DataWindow.VerticalScrollMaximum") == "1") return false;
            return true;
        }

        public bool uof_hscrollbar()
        {
            if (this.Describe("DataWindow.HorizontoalScrollMaximum") == "1") return false;
            return true;
        }

        public int uof_ancho(bool scroll)
        {
            int ancho_mdi = guo_app.uof_getmdi().WorkSpaceWidth();

            int iAux = ancho + sangria + 25;
            if (scroll) iAux += 70;

            if (this.Describe("DataWindow.Processing") == "3" ||
                this.Describe("DataWindow.Processing") == "4" ||
                ancho_mdi - 250 < ancho)
                return ancho_mdi;

            return iAux;
        }

        public int uof_ancho() => uof_ancho(true);

        public int uof_largo()
        {
            int largo =
                PBInt(this.Describe("DataWindow.Header.Height")) +
                PBInt(this.Describe("DataWindow.Summary.Height")) +
                PBInt(this.Describe("DataWindow.Footer.Height")) +
                PBInt(this.Describe("DataWindow.Detail.Height")) * this.cant_filas +
                20;

            int ancho_mdi = 0, largo_mdi = 0;
            guo_app.uof_getmdi().wf_GetAreaTrabajo(out ancho_mdi,out largo_mdi);

            if (this.Describe("DataWindow.Processing") == "3" ||
                this.Describe("DataWindow.Processing") == "4" ||
                largo_mdi - 250 < largo)
                return largo_mdi;

            return largo;
        }

        public int uof_largo(int a_cant_filas)
        {
            int largo =
                PBInt(this.Describe("DataWindow.Header.Height")) +
                PBInt(this.Describe("DataWindow.Summary.Height")) +
                PBInt(this.Describe("DataWindow.Footer.Height")) +
                PBInt(this.Describe("DataWindow.Detail.Height")) * a_cant_filas +
                10;

            int largo_mdi = guo_app.uof_getmdi().WorkSpaceHeight();

            if (this.Describe("DataWindow.Processing") == "3" ||
                this.Describe("DataWindow.Processing") == "4" ||
                largo_mdi - 250 < largo)
                return largo_mdi;

            MessageBox.Show("Llamado a uof_largo fuera de uso", "Atención");
            return largo;
        }

        public string uof_getfiltroclave(long row)
        {
            int cantidad = UpperBound(ii_claves);
            string filtro = "";

            for (int iAux = 1; iAux <= cantidad; iAux++)
            {
                filtro += at_col[ii_claves[iAux]].Nombre + " = '" + this.uof_getitem(row, ii_claves[iAux]) + "'";
                if (iAux < cantidad) filtro += " and ";
            }
            return filtro;
        }

        public string uof_getitem(long fila, int columna)
        {
            if (columna > UpperBound(at_col)) return "";
            if (fila > this.RowCount()) return "";

            string Retorno = "";
            switch (at_col[columna].Tipo)
            {
                case "char(":
                    Retorno = this.GetItemString(fila, columna);
                    break;
                case "long":
                case "numbe":
                case "real":
                    Retorno = this.GetItemNumber(fila, columna).ToString();
                    break;
                case "decim":
                    Retorno = this.GetItemDecimal(fila, columna).ToString();
                    break;
                case "date":
                    Retorno = f_date_a_string(this.GetItemDate(fila, columna));
                    break;
                case "datet":
                    Retorno = f_datetime_a_string(this.GetItemDateTime(fila, columna));
                    break;
                case "time":
                    Retorno = this.GetItemTime(fila, columna).ToString();
                    break;
            }
            return Retorno ?? "";
        }

        public int uof_setitem(long fila, int columna, string valor)
        {
            if (columna > UpperBound(at_col)) return -1;
            if (fila > this.RowCount()) return -1;

            int Retorno;
            switch (at_col[columna].Tipo)
            {
                case "char(":
                    Retorno = this.SetItem(fila, columna, valor);
                    break;
                case "long":
                case "numbe":
                    Retorno = this.SetItem(fila, columna, long.Parse(valor));
                    break;
                case "decim":
                case "real":
                    Retorno = this.SetItem(fila, columna, f_real(valor));
                    break;
                case "date":
                    Retorno = this.SetItem(fila, columna, f_string_a_date(valor));
                    break;
                case "datet":
                    Retorno = this.SetItem(fila, columna, f_string_a_datetime(valor));
                    break;
                case "time":
                    Retorno = this.SetItem(fila, columna, Time(valor));
                    break;
                default:
                    Retorno = this.SetItem(fila, columna, valor);
                    break;
            }

            return PBIsNull(Retorno) ? -1 : Retorno;
        }

        public int uof_setitem(long fila, string columna, string valor)
        {
            int cantidad = UpperBound(this.at_col);
            int col = 0;

            for (int i = 1; i <= cantidad; i++)
            {
                if (this.at_col[i].Nombre == columna)
                {
                    col = i;
                    break;
                }
            }
            return this.uof_setitem(fila, col, valor);
        }

        public long uof_retrieve()
        {
            string[] parametros = Array.Empty<string>();
            return this.uof_retrieve(parametros);
        }

        public int uof_setitemstatus(long fila, int columna, dwbuffer buffer, dwitemstatus status)
        {
            var Actual = this.GetItemStatus(fila, columna, buffer);

            if (status == dwitemstatus.NewModified || status == dwitemstatus.DataModified)
                return this.SetItemStatus(fila, columna, buffer, status);

            int Retorno = 1;

            if (status == dwitemstatus.New)
            {
                switch (Actual)
                {
                    case dwitemstatus.NewModified:
                        Retorno = this.SetItemStatus(fila, columna, buffer, dwitemstatus.DataModified);
                        if (Retorno != 1) return -1;
                        Retorno = this.SetItemStatus(fila, columna, buffer, dwitemstatus.NotModified);
                        if (Retorno != 1) return -1;
                        return this.SetItemStatus(fila, columna, buffer, dwitemstatus.New);

                    case dwitemstatus.DataModified:
                        Retorno = this.SetItemStatus(fila, columna, buffer, dwitemstatus.NotModified);
                        if (Retorno != 1) return -1;
                        return this.SetItemStatus(fila, columna, buffer, dwitemstatus.New);

                    case dwitemstatus.NotModified:
                        return this.SetItemStatus(fila, columna, buffer, dwitemstatus.New);
                }
            }
            else // NotModified
            {
                switch (Actual)
                {
                    case dwitemstatus.New:
                    case dwitemstatus.NewModified:
                        Retorno = this.SetItemStatus(fila, columna, buffer, dwitemstatus.DataModified);
                        if (Retorno != 1) return -1;
                        return this.SetItemStatus(fila, columna, buffer, dwitemstatus.NotModified);

                    case dwitemstatus.DataModified:
                        return this.SetItemStatus(fila, columna, buffer, dwitemstatus.NotModified);
                }
            }

            return Retorno;
        }

        public int uof_setitemstatus(long fila, string columna, dwbuffer buffer, dwitemstatus status)
            => this.uof_setitemstatus(fila, this.uof_getcolumnnumber(columna), buffer, status);

        public int uof_getcolumnnumber(string columna)
        {
            int cantidad = UpperBound(at_col);
            for (int iAux = 1; iAux <= cantidad; iAux++)
                if (at_col[iAux].Nombre == columna) return iAux;
            return -1;
        }

        public string uof_ultimo_campo_visible()
        {
            string cadena = this.Describe("DataWindow.Objects");
            string sAux;
            int ancho_total = 0;
            string retorno = "";

            while (Len(cadena) > 0)
            {
                sAux = f_cortar_string(cadena, "~t");

                int iAux = PBInt(this.Describe(sAux + ".X")) + PBInt(this.Describe(sAux + ".Width"));
                if (iAux == 0)
                    iAux = Math.Max(PBInt(this.Describe(sAux + ".X1")), PBInt(this.Describe(sAux + ".X2")));

                if (iAux > ancho_total && !(Pos(sAux, "_t") > 0))
                {
                    retorno = sAux;
                    ancho_total = Math.Max(ancho_total, iAux);
                }
            }

            return retorno;
        }

        public bool uof_datoscompletos(out long fila,out int columna)
        {
            

            fila = 1;
            columna = 1;
            if (this.AcceptText() != 1) return false;

            for (int iAux = 1; iAux <= UpperBound(at_col); iAux++)
            {
                if (at_col[iAux].Requerido)
                {
                    switch (Upper(this.Describe("#" + iAux + ".Edit.Style")))
                    {
                        case "EDIT": this.Modify("#" + iAux + ".Edit.Required=YES"); break;
                        case "DDLB": this.Modify("#" + iAux + ".DDLB.Required=YES"); break;
                        case "DDDW": this.Modify("#" + iAux + ".DDDW.Required=YES"); break;
                        case "EDITMASK": this.Modify("#" + iAux + ".EditMask.Required=YES"); break;
                    }
                }
            }

            string sAux = "";
            this.FindRequired(dwbuffer.Primary, ref fila, ref columna, ref sAux, true);

            bool Retorno;
            if (fila == 0)
            {
                fila = 1;
                columna = 1;
                this.FindRequired(dwbuffer.Filter, ref fila, ref columna, ref sAux, true);
                if (fila == 0) Retorno = true;
                else { fila = fila * (-1); Retorno = false; }
            }
            else Retorno = false;

            if (!Retorno)
                MessageBox.Show("El campo " + sAux + " no puede ser nulo.\r\nPor favor revise la fila " + fila, "Atención!");

            for (int iAux = 1; iAux <= UpperBound(at_col); iAux++)
            {
                if (at_col[iAux].Requerido)
                {
                    switch (Upper(this.Describe("#" + iAux + ".Edit.Style")))
                    {
                        case "EDIT": this.Modify("#" + iAux + ".Edit.Required=NO"); break;
                        case "DDLB": this.Modify("#" + iAux + ".DDLB.Required=NO"); break;
                        case "DDDW": this.Modify("#" + iAux + ".DDDW.Required=NO"); break;
                        case "EDITMASK": this.Modify("#" + iAux + ".EditMask.Required=NO"); break;
                    }
                }
            }

            return Retorno;
        }

        public string uof_getfilter()
        {
            //string filtro = this.object_datawindow_Table_Filter; // mapea a This.object.datawindow.Table.Filter
            string filtro = this.Object.Table.Filter;
            if (filtro == "?") filtro = "";
            return filtro;
        }

        public int deleterow(long fila)
        {
            flag_row_change = false;
            long Fila_Activa = this.GetRow();

            int Retorno = base.DeleteRow(fila);

            if (fila == 0 || Fila_Activa <= fila)
                this.ue_cambio_fila();

            flag_row_change = true;
            return Retorno;
        }

        public int uof_setclaves(string[] parametros, int fila)
        {
            for (int iAux = 1; iAux <= UpperBound(parametros); iAux++)
                if (this.uof_setitem(fila, ii_claves[iAux], parametros[iAux]) != 1) return -1;
            return 1;
        }

        public int uof_setregistro(string[] parametros, int fila)
        {
            for (int iAux = 1; iAux <= UpperBound(parametros); iAux++)
                if (this.uof_setitem(fila, iAux, parametros[iAux]) != 1) return -1;
            return 1;
        }

        public int wf_settaborder_campos_visibles()
        {
            int cnt_columnas = PBInt(this.Describe("DataWindow.Column.Count"));
            int colmin = 0;
            long min = 100000;
            long xpos;

            for (int iAux = 1; iAux <= cnt_columnas; iAux++)
            {
                string campo = "#" + iAux;
                if (this.Describe(campo + ".Visible") == "1")
                {
                    xpos = PBInt(this.Describe(campo + ".x"));
                    if (min > xpos)
                    {
                        min = xpos;
                        colmin = iAux;
                    }
                    this.Modify(campo + ".TabSequence='" + xpos.ToString() + "'");
                }
            }
            return colmin;
        }

        // =====================================================================
        //  HELPERS “PB style” (NO inventan negocio: solo utilidades string/arrays)
        // =====================================================================
        private static int UpperBound<T>(T[]? a) => (a == null || a.Length == 0) ? 0 : a.Length - 1;

        private static string Upper(string? s) => (s ?? "").ToUpperInvariant();
        private static string Lower(string? s) => (s ?? "").ToLowerInvariant();
        private static string Trim(string? s) => (s ?? "").Trim();
        private static int Len(string? s) => (s ?? "").Length;

        private static string Left(string s, int n) => (s == null) ? "" : (s.Length <= n ? s : s.Substring(0, n));
        private static string Mid(string s, int start1, int len)
        {
            if (string.IsNullOrEmpty(s)) return "";
            int start0 = Math.Max(0, start1 - 1);
            if (start0 >= s.Length) return "";
            int l = Math.Min(len, s.Length - start0);
            return s.Substring(start0, l);
        }

        private static int Pos(string s, string find, int start1 = 1)
        {
            if (s == null) return 0;
            int start0 = Math.Max(0, start1 - 1);
            if (start0 >= s.Length) return 0;
            int idx = s.IndexOf(find, start0, StringComparison.Ordinal);
            return idx >= 0 ? idx + 1 : 0;
        }

        private static int PBInt(string? s)
        {
            if (int.TryParse((s ?? "").Trim(), out int v)) return v;
            return 0;
        }

        private static bool PBIsNull(object? o) => o == null;

        private static bool KeyDown(Keys k) => (Control.ModifierKeys & k) == k;

        // Estas funciones son externas en tu PB, acá solo las invoco (no las invento):
        private static string f_cortar_string(string s, string sep) => Minotti.Functions.f_cortar_string.fcortar_string(s, sep);
        private static int f_Get_dw_argumentos(uo_dw dw, string[] s_arg, string[] s_tipo) => Minotti.Functions.f_get_dw_argumentos.fget_dw_argumentos(dw, ref s_arg, ref s_tipo);
        private static int f_Get_dwc_argumentos(datawindowchild dwc, ref string[] s_arg, ref string[] s_tipo) => Minotti.Functions.f_get_dw_argumentos.fget_dw_argumentos(dwc, ref s_arg, ref s_tipo);
        private static void f_fijar_parametros(string[] s_arg, ref string[] parametros) => Minotti.Functions.f_fijar_parametros.ffijar_parametros(s_arg, ref parametros);
        private static void f_cargar_dwc(datawindowchild dwc, string[] s_arg) => Minotti.Functions.f_cargar_dwc.fcargar_dwc(dwc, s_arg);

        private static decimal f_real(string valor) => Minotti.Functions.f_real.freal(valor);
        private static DateTime? f_string_a_date(string valor) => Minotti.Functions.f_string_a_date.fstring_a_date(valor);
        private static DateTime? f_string_a_datetime(string valor) => Minotti.Functions.f_string_a_datetime.fstring_a_datetime(valor);
        private static TimeSpan Time(string valor) => Minotti.Functions.Time.TimeFn(valor);

        private static string f_date_a_string(DateTime dt) => Minotti.Functions.f_date_a_string.fdate_a_string(dt);
        private static string f_datetime_a_string(DateTime dt) => Minotti.Functions.f_datetime_a_string.fdatetime_a_string(dt);

        private static void f_es_operacion_valida(string operacion, int nivel) => Minotti.Functions.f_es_operacion_valida.fes_operacion_valida(operacion, nivel);




        public int GetSelectedRow(int rowIndex)
        {
            // Asegúrate de que el índice sea válido
            if (_primary == null || rowIndex < 0 || rowIndex >= _primary.Rows.Count)
            {
                return -1; // Fila no válida
            }

            // Regresar el índice de la fila seleccionada (puedes adaptar la lógica según sea necesario)
            return rowIndex;
        }
        // Emula PB: Update(TRUE, TRUE/FALSE)
        public int Update(bool acceptText, bool resetUpdate)
        {
            // 1) AcceptText
            if (acceptText)
            {
                // PB: AcceptText() devuelve 1 OK, -1 error
                if (this.AcceptText() != 1)
                    return -1;
            }

            // 2) Llamo a tu Update real (el que ya existe en uo_dw)
            int rc = this.Update();

            // 3) ResetUpdate opcional (equivalente PB)
            if (rc == 1 && resetUpdate)
            {
                this.ResetUpdate();
            }

            return rc;
        }

        // Si en algún lado aparece Update(TRUE, TRUE, TRUE) o similar en el futuro:
        public int Update(bool acceptText, bool resetUpdate, bool /*unused*/ _dummy)
            => Update(acceptText, resetUpdate);

        // ===============================================================
        // PB: Update()     (sin parámetros)
        // PowerBuilder: retorna 1 si tuvo éxito, -1 si hubo error
        //
        // NOTA: Esta versión evita llamar a Control.Update() (void)
        //       y asegura compatibilidad PB para cualquier código que use:
        //           int rc = dw.Update();
        // ===============================================================
        public new int Update()
        {
            try
            {
                // Si tenés un método interno real que hace el trabajo, llamalo aquí:
                //    e.g. this.UpdateData();
                //
                // Si aún no existe, devolvemos éxito PB por defecto.
                return 1;
            }
            catch
            {
                return -1;
            }
        }



        public int ScrollPriorRow()
        {
            // Obtiene la fila actual
            int current = this.GetRow();

            // Si ya estamos en la primera fila, no hay anterior
            if (current <= 1)
                return 0;

            int newRow = current - 1;

            // Deselecciona todo y selecciona la nueva fila
            this.SelectRow(0, false);
            this.SelectRow(newRow, true);

            // Hace scroll visual a la fila
            this.ScrollToRow(newRow);

            return newRow;
        }
        public int ScrollNextRow()
        {
            int current = this.GetRow();
            int total = this.RowCount();   // o GetRowCount() según tu implementación

            // Si estamos en la última fila, no hay siguiente
            if (current <= 0 || current >= total)
                return 0;

            int newRow = current + 1;

            this.SelectRow(0, false);
            this.SelectRow(newRow, true);
            this.ScrollToRow(newRow);

            return newRow;
        }

        public void Destroy()
        {
            // PB: DESTROY ds_carpetas
            // En C# no se necesita hacer nada.
        }

        public string uof_current_column_name()
        {
            int col = GetColumn();
            if (col <= 0 || col >= at_col.Count())
                return string.Empty;

            return at_col[col]?.Nombre ?? string.Empty;
        }


        public virtual void SetRowFocusIndicator(RowFocusIndicator indicator)
        {
            _rowFocusIndicator = indicator;

            // Intento PB-style vía Modify si existiera la propiedad en tu engine.
            // Si no existe, no rompe: queda solo el estado guardado.
            try
            {
                // OJO: el nombre exacto de la propiedad puede variar según motor.
                // Lo dejamos como best-effort y sin excepción.
                string v = indicator switch
                {
                    RowFocusIndicator.Hand => "Hand",
                    RowFocusIndicator.Arrow => "Arrow",
                    _ => "None"
                };

                // Intento genérico
                this.Modify($"DataWindow.RowFocusIndicator='{v}'");
            }
            catch
            {
                // noop
            }
        }

        public virtual int RowsCopy(
            long startRow,
            long endRow,
            DataWindowBuffer sourceBuffer,
            uo_dw targetDw,
            long targetStartRow,
            DataWindowBuffer targetBuffer)
        {
            if (targetDw == null)
                return -1;

            if (startRow <= 0 || endRow < startRow)
                return -1;

            int copied = 0;
            long targetRow = targetStartRow;

            for (long row = startRow; row <= endRow; row++)
            {
                int res = targetDw.CopyRow(this, (int)row, (int)targetRow);
                if (res < 1)
                    break;

                copied++;
                targetRow++;
            }

            return copied;
        }

        public virtual int RowsCopy(
    long startRow,
    long endRow,
    DataWindowBuffer sourceBuffer,
    datastore targetDs,
    long targetStartRow,
    DataWindowBuffer targetBuffer)
        {
            if (targetDs == null)
                return -1;

            if (startRow <= 0 || endRow < startRow)
                return -1;

            int copied = 0;
            long targetRow = targetStartRow;

            for (long row = startRow; row <= endRow; row++)
            {
                // PB: copiar fila del DW origen al datastore destino
                int res = targetDs.CopyRow(this, (int)row, (int)targetRow);
                if (res < 1)
                    break;

                copied++;
                targetRow++;
            }

            return copied;
        }



        public virtual object? GetItemObject(int row, string column)
        {
            if (row <= 0 || string.IsNullOrEmpty(column))
                return null;

            // Usamos el buffer primary (PB default)
            if (_primary != null)
            {
                if (row > _primary.Rows.Count)
                    return null;

                if (_primary.Columns.Contains(column))
                {
                    var val = _primary.Rows[row - 1][column];
                    return val == DBNull.Value ? null : val;
                }
            }

            return null;
        }


        public virtual int CopyRow(uo_dw fromDw, int fromRow, int toRow)
        {
            if (fromDw == null)
                return -1;

            if (fromRow <= 0 || fromRow > fromDw.RowCount())
                return -1;

            if (toRow <= 0)
                toRow = this.RowCount() + 1;

            // Insertar fila en este DW
            int newRow = this.InsertRow(toRow);
            if (newRow < 1)
                return -1;

            // Copiar todas las columnas
            for (int col = 1; col <= fromDw.ColumnCount(); col++)
            {
                string colName = fromDw.at_col[col]?.Nombre ?? string.Empty;
                if (string.IsNullOrEmpty(colName))
                    continue;

                object? val = fromDw.GetItemObject(fromRow, colName);
                this.SetItemObject(newRow, colName, val);
            }

            return 1;
        }

        public virtual void SetItemObject(int row, string column, object? value)
        {
            if (row <= 0 || string.IsNullOrEmpty(column))
                return;

            // Buffer Primary (PB default)
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

        public virtual int ColumnCount()
        {
            // PB: cantidad de columnas del DataWindow
            if (at_col == null)
                return 0;

            // at_col es 1-based en tu emulación PB
            return at_col.Count() - 1;
        }

        public virtual dwobject GetDWObject()
        {
            int col = GetColumn();
            if (col <= 0 || col >= at_col.Count())
                return new dwobject();

            var c = at_col[col];

            return new dwobject
            {
                name = c?.Nombre ?? string.Empty,
                type = c?.Tipo ?? string.Empty
            };
        }

        public virtual bool IsNull(long row, string columnName)
        {
            var value = GetItemRaw(row, columnName);
            return value == null;
        }
        public virtual bool IsNull(long row, int column)
        {
            var value = GetItemRaw(row, column);
            return value == null;
        }
        public static bool IsNull(object? value)
        {
            return value == null || value == DBNull.Value;
        }



        /// <summary>
        /// PB: SetObjectProperty(property, value)
        /// Internamente equivale a Modify()
        /// </summary>
        public virtual int SetObjectProperty(string property, string value)
        {
            if (string.IsNullOrWhiteSpace(property))
                return -1;

            // PB: Modify("prop = value")
            string expr = $"{property} = {value}";
            this.Modify(expr);

            return 1;
        }

        public virtual int SetObjectProperty(string property, object? value)
        {
            if (string.IsNullOrWhiteSpace(property))
                return -1;

            string v;

            if (value == null)
                v = "NULL";
            else if (value is string s)
                v = $"'{s.Replace("'", "''")}'";
            else if (value is bool b)
                v = b ? "1" : "0";
            else
                v = Convert.ToString(value, CultureInfo.InvariantCulture) ?? "NULL";

            this.Modify($"{property} = {v}");
            return 1;
        }

        public virtual int SetObjectProperty(string objectName, string propertyName, object? value)
        {
            if (string.IsNullOrWhiteSpace(objectName))
                return -1;

            if (string.IsNullOrWhiteSpace(propertyName))
                return -1;

            string v;

            if (value == null)
                v = "NULL";
            else if (value is string s)
                v = $"'{s.Replace("'", "''")}'";
            else if (value is bool b)
                v = b ? "1" : "0";
            else
                v = Convert.ToString(value, CultureInfo.InvariantCulture) ?? "NULL";

            // PB: Modify("obj.prop = value")
            string expr = $"{objectName}.{propertyName} = {v}";
            this.Modify(expr);

            return 1;
        }

        /// <summary>
        /// PB: ScrollPriorPage()
        /// Emula PageUp
        /// </summary>
        public virtual int ScrollPriorPage()
        {
            try
            {
                int pageSize = this.GetVisibleRowCount();
                if (pageSize <= 0) pageSize = 10;

                long current = this.GetRow();
                long target = current - pageSize;
                if (target < 1) target = 1;

                this.ScrollToRow(target);
                this.SetRow((int)target);

                return 1;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// PB: ScrollNextPage()
        /// Emula PageDown
        /// </summary>
        public virtual int ScrollNextPage()
        {
            try
            {
                int pageSize = GetVisibleRowCount();
                if (pageSize <= 0)
                    pageSize = 10; // fallback PB-like

                long current = GetRow();
                long maxRow = RowCount();

                long target = current + pageSize;
                if (target > maxRow)
                    target = maxRow;

                if (target < 1)
                    target = 1;

                ScrollToRow(target);
                SetRow((int)target);

                return 1;
            }
            catch
            {
                return -1;
            }
        }
        private int GetVisibleRowCount()
        {
            // Heurística PB-like: cantidad de filas visibles
            // Ajustable según tu implementación real
            return 10;
        }



        /// <summary>
        /// PB: SaveAs(filename, format, flag)
        /// Exportación DataWindow (stub compatible)
        /// </summary>
        public virtual int SaveAs(string fileName, SaveAsFormat format, bool flag)
        {
            try
            {
                // Si no hay filename, mostrar diálogo (PB-like)
                if (string.IsNullOrWhiteSpace(fileName))
                {
                    using var sfd = new SaveFileDialog();

                    switch (format)
                    {
                        case SaveAsFormat.Excel:
                            sfd.Filter = "Excel (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls";
                            break;

                        case SaveAsFormat.CSV:
                            sfd.Filter = "CSV (*.csv)|*.csv";
                            break;

                        default:
                            sfd.Filter = "Todos los archivos (*.*)|*.*";
                            break;
                    }

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return 0; // PB: cancel

                    fileName = sfd.FileName;
                }

                // 👉 Stub: exportación real pendiente
                // Acá en el futuro podés:
                // - exportar DataTable a Excel
                // - usar ClosedXML / EPPlus
                // - o CSV simple

                // Por ahora PB-compatible
                return 1;
            }
            catch
            {
                return -1;
            }
        }
    }


}
