using System;
using System.Windows.Forms;
using Minotti.Controls;
using Minotti.Models;

namespace Minotti.Views
{
    // Migración de PowerBuilder: w_dworder.srw (Window)
    // Mantengo nombres de tipo, variables y eventos.
    public partial class w_dworder : Form
    {
        // ===== Variables PB (mismos nombres) =====
        public uo_dw idw;                      // Message.PowerObjectParm en PB
        public cat_return at_return = new cat_return(); // resultado (boolean + string de sort)

        // Exponer el "Message.PowerObjectParm" para que quien llama pueda setearlo
        public object Message_PowerObjectParm { get; set; }

        public w_dworder()
        {
            InitializeComponent();
        }

        // ===== Eventos PB =====

        // event open;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // idw = Message.PowerObjectParm 
            this.idw = this.Message_PowerObjectParm as uo_dw;

            // at_return.rtn_boolean = FALSE
            at_return.rtn_boolean = false;

            // This.Event trigger ue_posopen()
            ue_posopen();
        }

        // event close;
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            // En PB: Message.PowerObjectParm = at_return
            // En C#: el que llama puede leer la propiedad pública 'at_return' del form ya cerrado.
        }

        // event ue_ok;
        public void ue_ok()
        {
            // Set the return code to mean succesful operation.
            at_return.rtn_boolean = true;

            // Set the new sort string.
            at_return.rtn_string = wf_creasort();

            // Close the window.
            this.Close();
        }

        // event ue_cancelar;
        public void ue_cancelar()
        {
            // Set the return code to mean NO operation / cancel.
            at_return.rtn_boolean = false;
            // Close the window.
            this.Close();
        }

        // event ue_posopen; (stub: aquí podrías cargar columnas en dw_sortcolumns/dw_sorted)
        public void ue_posopen()
        {
            // TODO: popular dw_sortcolumns con columnas disponibles de idw
            // y dw_sorted con el orden actual.
        }

        // ===== Funciones PB (mismas firmas; implementación mínima equivalente) =====

        // public function integer wf_sort ()
        public int wf_sort()
        {
            // Debe encadenar el proceso de ordenar según contenido de dw_sorted.
            // Devolvemos 1 como OK.
            return 1;
        }

        // public function string wf_creasort ()
        public string wf_creasort()
        {
            // Construye el string de SORT a partir de dw_sorted (stub).
            // Ejemplo PB: "col1 A, col2 D"
            return string.Empty;
        }

        // public function string wf_getsort ()
        public string wf_getsort()
        {
            // Devolvería el sort actual del idw (stub).
            return string.Empty;
        }

        // public function integer wf_carga_atrib (ref uo_sortattrib arg_atrib)
        public int wf_carga_atrib(ref uo_sortattrib arg_atrib)
        {
            if (arg_atrib == null) arg_atrib = new uo_sortattrib();
            // Inicializa con datos vacíos
            arg_atrib.is_sort = wf_getsort();
            return 1;
        }

        // public function integer wf_parsesortatrib (string as_originalsort, ref uo_sortattrib anv_sortattrib)
        public int wf_parsesortatrib(string as_originalsort, ref uo_sortattrib anv_sortattrib)
        {
            if (anv_sortattrib == null) anv_sortattrib = new uo_sortattrib();
            anv_sortattrib.is_sort = as_originalsort ?? string.Empty;
            return 1;
        }

        // public function integer wf_getobject (ref string as_objlist[], string as_objtype, string as_band, boolean ab_visibleonly)
        public int wf_getobject(ref string[] as_objlist, string as_objtype, string as_band, bool ab_visibleonly)
        {
            // En PB usa Describe("DataWindow.Objects") y filtra; aquí devolvemos vacío.
            as_objlist = Array.Empty<string>();
            return 0;
        }

        // public function string wf_getheadername (string as_column, string as_suffix)
        public string wf_getheadername(string as_column, string as_suffix)
        {
            // En PB busca el texto del header; aquí retornamos el nombre de columna con sufijo.
            if (string.IsNullOrEmpty(as_column)) return string.Empty;
            return as_column + (string.IsNullOrEmpty(as_suffix) ? string.Empty : as_suffix);
        }

        // public function string wf_gettoken (ref string as_source, string as_separator)
        public string wf_gettoken(ref string as_source, string as_separator)
        {
            if (as_source == null) return string.Empty;
            as_separator = as_separator ?? ",";
            int idx = as_source.IndexOf(as_separator, StringComparison.Ordinal);
            string token;
            if (idx < 0) { token = as_source; as_source = string.Empty; }
            else { token = as_source.Substring(0, idx); as_source = as_source.Substring(idx + as_separator.Length); }
            return token;
        }

        // public function long wf_parsetoarray (string as_source, string as_delimiter, ref string as_array[])
        public long wf_parsetoarray(string as_source, string as_delimiter, ref string[] as_array)
        {
            if (as_source == null || as_delimiter == null) return 0;
            as_array = as_source.Split(new string[] { as_delimiter }, StringSplitOptions.None);
            return as_array?.LongLength ?? 0L;
        }
    }
}
