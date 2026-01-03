using System;
using System.Windows.Forms;

namespace Minotti.Views
{
    public partial class w_abm_lista_seleccion : w_abm_lista
    {
        private string is_nombre_columna, idata;
        private int il_q_filas;
        private string is_back_color = "15794175";
        private bool ib_modificar_dw_busqueda = false;

        public w_abm_lista_seleccion()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dw_buscar = new dw_buscar();
            this.Controls.Add(dw_buscar);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (dw_buscar != null)
            {
                dw_buscar.Dispose();
                dw_buscar = null;
            }
        }
    }
}
