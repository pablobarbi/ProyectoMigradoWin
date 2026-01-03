using Minotti.utils;
using Minotti.Views.Pbl.Views;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Abm.Controls
{
    // global type w_lista from w_abm_lista
    public partial class w_lista : w_abm_lista
    {
        public w_lista()
        {
            InitializeComponent();
        }

        // event activate
        public override void activate()
        {
            // en PB NO llama super acá
            PBGlobals.m_mdi.m_confirmar.Enabled = false;
            PBGlobals.m_mdi.m_borrar.Enabled = false;
            PBGlobals.m_mdi.m_insertar.Enabled = false;
        }
    }
}
