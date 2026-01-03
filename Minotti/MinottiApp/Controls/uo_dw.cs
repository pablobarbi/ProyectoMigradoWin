using System;
using System.Windows.Forms;

namespace Minotti.Controls
{
    // Migración de PowerBuilder: uo_dw.sru (datawindow userobject)
    // Se mantiene el nombre del tipo: uo_dw
    public partial class uo_dw : UserControl
    {
        public uo_dw()
        {
            InitializeComponent();
        }

        // ====== Compatibilidad y utilitarios (nombres PB) ======
        public int AcceptText() => 1;
        public int ModifiedCount() => 0;
        public int Update(bool ab_accept, bool ab_resetFlag) => 1;

        public int DeleteRow(long fila)
        {
            try
            {
                if (grid.DataSource is System.Data.DataTable dt && fila >= 1 && fila <= dt.Rows.Count)
                {
                    dt.Rows.RemoveAt((int)fila - 1);
                    return 1;
                }
                return -1;
            }
            catch { return -1; }
        }

        public void SetTransObject(object SQLCA) { this.SQLCA = SQLCA; }
        public void uof_SetDataObject(string data_object) => uof_setdataobject(data_object);

        public void uof_setitem(long fila, int columna, string valor)
        {
            if (grid.DataSource is System.Data.DataTable dt &&
                fila >= 1 && fila <= dt.Rows.Count &&
                columna >= 1 && columna <= dt.Columns.Count)
            {
                dt.Rows[(int)fila - 1][columna - 1] = valor;
            }
        }

        public int uof_Ancho() => this.Width;
        public int uof_Largo() => this.Height;

        // Propiedades auxiliares para compatibilidad PB
        public int Y { get => this.Top; set => this.Top = value; }
        public int cant_filas { get; set; } = 1;
        public int[] ii_claves { get; set; } = Array.Empty<int>();
        public bool rb_menu { get; set; } = false;
        public bool ib_avisar_primer_fila_activa { get; set; } = false;
        public bool flag_row_change { get; set; } = false;

        private string _dw_impresion = string.Empty;
        public object SQLCA { get; private set; } = null!;

        // Compatibilidad con uof_setdwimpresion / uof_getdwimpresion
        // PB: dw_impresion = data_object / Return(dw_impresion)
        public void uof_setdwimpresion(string data_object)
        {
            _dw_impresion = data_object ?? string.Empty;
        }

        public string uof_getdwimpresion() => _dw_impresion;

        /// <summary>
        /// Equivalente al This.Print() de la DataWindow en PB.
        /// Punto de extensión para implementar la impresión real.
        /// </summary>
        public virtual void Print()
        {
            // PB: la DataWindow tiene un método Print() que imprime el contenido.
            // Acá no invento lógica de impresión; dejá este método como hook
            // y cuando quieras implementar impresión real del grid, lo hacés acá.
        }

        /// <summary>
        /// PB: public subroutine uof_imprimir ();
        ///      OpenWithParm(w_opciones_de_impresion, This)
        ///      end subroutine
        ///
        /// Aproximación: llamamos directo a Print(), sin ventana intermedia.
        /// </summary>
        public void uof_imprimir()
        {
            // Original PB:
            // OpenWithParm(w_opciones_de_impresion, This)
            //
            // Para no inventar el formulario de opciones, acá simplemente
            // delegamos en Print(). Si más adelante migrás w_opciones_de_impresion,
            // podés reemplazar esta implementación para abrir ese Form.
            Print();
        }

        // ====== Stubs de métodos con mismos nombres que en PB ======
        public int uof_cant_parametros() { return 0; }
        public long uof_retrieve(string[] parametros) { return 1; }
        public long uof_retrieve() { return 1; }

        public bool uof_getclaves(ref string[] parametros, int fila)
        {
            if (ii_claves == null || ii_claves.Length == 0)
            {
                parametros = Array.Empty<string>();
                return false;
            }

            var tmp = new string[ii_claves.Length];
            for (int i = 0; i < ii_claves.Length; i++)
                tmp[i] = uof_getitem(fila, ii_claves[i]);

            parametros = tmp;
            return true;
        }

        public bool uof_getregistro(ref string[] parametros, int fila)
        {
            parametros = Array.Empty<string>();
            return false;
        }

        public bool uof_getargumentos(ref string[] parametros, int fila)
        {
            parametros = Array.Empty<string>();
            return false;
        }

        public int sort() { return 1; }
        public int filter() { return 1; }
        public int rowsdiscard(long s, long e, dwbuffer f) { return 1; }
        public int rowsmove(long s, long e, dwbuffer f, datawindow d, long i, dwbuffer t) { return 1; }
        public int rowsmove(long s, long e, dwbuffer f, datastore d, long i, dwbuffer t) { return 1; }
        public int rowsmove(long s, long e, dwbuffer f, datawindowchild d, long i, dwbuffer t) { return 1; }

        public void uof_aplicar_estilos() { }
        public string uof_getfilter() { return string.Empty; }
        public int deleterow(long fila) { return DeleteRow(fila); }
        public int uof_setclaves(string[] parametros, int fila) { return 1; }
        public int uof_setregistro(string[] parametros, int fila) { return 1; }
        public int wf_settaborder_campos_visibles() { return 1; }
        public void uof_setdataobject(string data_object) { /* alias para SetDataObject */ }
        public void uof_edicion(string sector, string estilo) { }
        public void uof_edicion(int campo, string estilo) { }
        public void uof_marcar_seleccion(int modo) { }
        public void uof_settaborderoriginal(int arg_col) { }

        // Lectura item (similar a GetItemString en PB)
        public string uof_getitem(long fila, int columna)
        {
            if (grid.DataSource is System.Data.DataTable dt &&
                fila >= 1 && fila <= dt.Rows.Count &&
                columna >= 1 && columna <= dt.Columns.Count)
            {
                return dt.Rows[(int)fila - 1][columna - 1]?.ToString() ?? string.Empty;
            }

            return string.Empty;
        }
    }

    // Placeholders PB para mantener firmas
    public class dwbuffer { }
    public class datawindow { }
    public class datastore { }
    public class datawindowchild { }
}
