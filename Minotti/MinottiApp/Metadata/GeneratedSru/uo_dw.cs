using Minotti.Data;
using Minotti.Metadata.GeneratedSru;
using Minotti.Structures;
using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Menues;
using Minotti.Views.Reportes.Controls;
using MinottiApp.Metadata;
using MinottiApp.utils;
using System.Globalization;
using Message = Minotti.utils.Message;

namespace Minotti.Metadata.GeneratedSru
{
    // =========================================================
    // $PBExportHeader$uo_dw.sru
    // General. Objeto tipo Data Window, con funcionalidad adicional.
    // =========================================================
    public class uo_dw : UserObject
    {
        // =========================================================
        // Structures (PB: structure within uo_dw)
        // =========================================================
        public struct uost_sort
        {
            public string columna;
            public string orden;
        }

        public struct uost_seguridad
        {
            public string usuario;
            public string fecha;
        }

        // =========================================================
        // VARIABLES (type variables)
        // =========================================================

        // --- Private ---
        protected bool flag_row_change = true;          // PB: flag_row_change
        protected bool flag_estilos_en_dw = false;      // PB: flag_estilos_en_dw
        protected long il_fila_shift = 0;               // PB: il_fila_shift
        protected uost_sort ust_sort;                   // PB: ust_sort
        protected uost_seguridad ust_seg;               // PB: ust_seg
        protected int ancho;                            // PB: ancho
        protected int sangria;                          // PB: sangria
        protected string dw_impresion;                  // PB: dw_impresion

        protected bool ib_resaltar_fila = false;        // PB: ib_resaltar_fila
        protected bool ib_seleccion = false;            // PB: ib_seleccion
        protected bool ib_registrar_usuario = false;    // PB: ib_registrar_usuario

        // --- Public ---
        public cat_columna[] at_col;                    // PB: at_col[]
        public int[] ii_claves;                         // PB: ii_claves[]
        public int cant_filas = 0;                      // PB: cant_filas
        public bool ib_avisar_primer_fila_activa = true;// PB: ib_avisar_primer_fila_activa
        public bool rb_menu = false;                    // PB: rb_menu


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
        // =========================================================
        // EVENTS (PB events → métodos vacíos por ahora)
        // =========================================================

        protected virtual void ue_ordenar() { }
        protected virtual void ue_filtrar() { }
        protected virtual void ue_preview() { }
        protected virtual void ue_cambio_fila() { }
        protected virtual void ue_refresh() { }
        protected virtual int ue_retrieve_childdw(datawindowchild ldwc) => 0;

        // =========================================================
        // PROTOTYPES (PB forward prototypes)
        // =========================================================

        public virtual void uof_setdataobject(string data_object) { }
        public virtual int uof_cant_parametros() => 0;
        public virtual long uof_retrieve(string[] parametros) => 0;
        public virtual long uof_retrieve() => 0;

        public virtual bool uof_getclaves(ref string[] parametros, int fila) => false;
        public virtual bool uof_getregistro(ref string[] parametros, int fila) => false;
        public virtual bool uof_getargumentos(ref string[] parametros, int fila) => false;

        public virtual void uof_setdwimpresion(string data_object) { }

        public virtual void uof_edicion(string sector, string estilo) { }
        public virtual void uof_edicion(int campo, string estilo) { }

        public virtual int sort() => 0;
        public virtual int filter() => 0;

        public virtual int rowsdiscard(long s, long e, dwbuffer f) => 0;
        public virtual int rowsmove(long s, long e, dwbuffer f, datawindow d, long i, dwbuffer t) => 0;
        public virtual int rowsmove(long s, long e, dwbuffer f, datastore d, long i, dwbuffer t) => 0;
        public virtual int rowsmove(long s, long e, dwbuffer f, datawindowchild d, long i, dwbuffer t) => 0;

        public virtual void uof_marcar_seleccion(int modo) { }
        public virtual bool uof_aplicar_estilos() => false;
        public virtual void uof_settaborderoriginal(int arg_col) { }

        public virtual string uof_getdwimpresion() => null;
        public virtual void uof_imprimir() { }

        public virtual bool uof_vscrollbar() => false;
        public virtual bool uof_hscrollbar() => false;

        public virtual int uof_ancho(bool scroll) => 0;
        public virtual int uof_ancho() => 0;

        public virtual int uof_largo() => 0;
        public virtual int uof_largo(int a_cant_filas) => 0;

        public virtual string uof_getfiltroclave(long row) => null;
        public virtual string uof_getitem(long fila, int columna) => null;

        public virtual int uof_setitem(long fila, int columna, string valor) => 0;
        public virtual int uof_setitem(long fila, string columna, string valor) => 0;

        public virtual int uof_setitemstatus(long fila, int columna, dwbuffer buffer, dwitemstatus status) => 0;
        public virtual int uof_setitemstatus(long fila, string columna, dwbuffer buffer, dwitemstatus status) => 0;

        public virtual int uof_getcolumnnumber(string columna) => -1;
        public virtual string uof_ultimo_campo_visible() => null;

        public virtual bool uof_datoscompletos(ref long fila, ref int columna) => false;
        public virtual string uof_getfilter() => null;

        public virtual int deleterow(long fila) => 0;
        public virtual int uof_setclaves(string[] parametros, int fila) => 0;
        public virtual int uof_setregistro(string[] parametros, int fila) => 0;

        public virtual int wf_settaborder_campos_visibles() => 0;

        // =========================================================
        // CONSTRUCTOR / DESTRUCTOR (PB events)
        // =========================================================

        //public override void constructor()
        //{
        //    // PB:
        //    // ust_seg.usuario = "usr_upd"
        //    // ust_seg.Fecha   = "fec_upd"
        //}

        //public override void destructor()
        //{
        //}

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

        public string uof_current_column_name()
        {
            int col = GetColumn();
            if (col <= 0 || col >= at_col.Count())
                return string.Empty;

            return at_col[col]?.Nombre ?? string.Empty;
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


        public virtual bool uof_getargumentos(string[] parametros, int fila)
            => uof_getclaves(ref parametros, fila);

        public virtual string[] uof_getargumentos(int fila)
        {
            var arr = Array.Empty<string>();
            uof_getargumentos(arr, fila);
            return arr;
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

                    at_seleccion_row.dataobject = this.at_col[this.GetColumn()].objeto_seleccion;
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
    }
}
