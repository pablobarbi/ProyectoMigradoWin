using Minotti.utils;
using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    // =========================================================
    // $PBExportHeader$uo_dw.sru
    // General. Objeto tipo Data Window, con funcionalidad adicional.
    // =========================================================
    public class uo_dw : datawindow
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

        public override void constructor()
        {
            // PB:
            // ust_seg.usuario = "usr_upd"
            // ust_seg.Fecha   = "fec_upd"
        }

        public override void destructor()
        {
        }
    }
}
