using System;
using System.Windows.Forms;

namespace Minotti.Views
{
    public partial class w_lista : w_abm_lista
    {
        public w_lista()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // call w_abm_lista::create
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            // call w_abm_lista::destroy
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            // m_mdi.m_operaciones.m_confirmar.Enabled = false;
            // m_mdi.m_operaciones.m_borrar.Enabled = false;
            // m_mdi.m_operaciones.m_insertar.Enabled = false;
        }
    }
}
