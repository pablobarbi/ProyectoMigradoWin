using System;
using System.Linq;
using System.Windows.Forms;
using Minotti.Models;

namespace Minotti.Controls
{
    // Migración de PowerBuilder: uo_tab.sru (userobject from tab)
    // Se mantiene el nombre del tipo: uo_tab
    public partial class uo_tab : UserControl
    {
        // ===== Variables (mismos nombres) =====
        public st_espacios s_esp { get; set; } = new st_espacios();
        public uo_tp[] tp { get; set; } = Array.Empty<uo_tp>();
        public string[] is_parametros { get; set; } = Array.Empty<string>();
        public int i_borde { get; set; } = 40;
        public int i_Cabecera { get; set; } = 250;
        public bool continuar_grabando { get; set; } = true;

        public uo_tab()
        {
            InitializeComponent();
        }

        // ===== Funciones públicas (firmas preservadas) =====

        // public function integer uof_largo ()
        public int uof_largo()
        {
            // Largo disponible: alto del control menos bordes
            int borde = s_esp?.borde ?? 0;
            return Math.Max(0, this.Height - (2 * borde));
        }

        // public function integer uof_ancho ()
        public int uof_ancho()
        {
            int borde = s_esp?.borde ?? 0;
            return Math.Max(0, this.Width - (2 * borde));
        }

        // public function boolean uof_cambios_pendientes ()
        public bool uof_cambios_pendientes()
        {
            // En PB suele chequear si alguna DataWindow tiene ModifiedCount()>0
            // Aquí recorremos páginas y buscamos controles uo_dw para consultar ModifiedCount()
            foreach (TabPage page in tab.TabPages)
            {
                var dw = page.Controls.OfType<uo_dw>().FirstOrDefault();
                if (dw != null && dw.ModifiedCount() > 0) return true;
            }
            return false;
        }

        // ===== Utilitarios para manipular pestañas (no cambian nombres de miembros) =====

        // Crea una pestaña a partir de la estructura uost_tab_info
        public void AddTab(uost_tab_info info)
        {
            if (info == null) return;
            var page = new uo_tp();
            page.Text = info.titulo ?? string.Empty;
            // Si hay que cargar un userobject/datawindow por nombre (info.dw), eso quedará para más adelante.
            // Bitmap (icono) se podría mapear a ImageList si se requiere.
            tab.TabPages.Add(page);
            tp = tab.TabPages.Cast<uo_tp>().ToArray();
        }
    }

    // Placeholder: estructura interna del SRU con mismos nombres
    public class uost_tab_info
    {
        public string titulo { get; set; } = string.Empty;
        public string dw { get; set; } = string.Empty;
        public string bitmap { get; set; } = string.Empty;
    }

    // Placeholder: tipo de página (en PB sería 'uo_tp' dentro del tab). Aquí mapeamos a TabPage para WinForms
    public partial class uo_tp : TabPage
    {
    }
}
