using System.Windows.Forms;

namespace Minotti
{
    /// <summary>
    /// Migrado desde PowerBuilder Window 'w_borrar_reperto' (derivada de w_abm_lista_seleccion).
    /// No hay eventos/SQL en el SRW provisto; se porta el control 'dw_buscar' con el mismo nombre.
    /// </summary>
    public partial class w_borrar_reperto : Form
    {
        public w_borrar_reperto()
        {
            InitializeComponent();
        }
    }
}