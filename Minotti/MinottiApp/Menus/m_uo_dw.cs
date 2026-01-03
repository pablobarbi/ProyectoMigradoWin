using System;
using System.Windows.Forms;

namespace Minotti.Menus
{
    // Migración de PowerBuilder: m_uo_dw.srm (menu)
    // Se mantiene el nombre del tipo: m_uo_dw
    public partial class m_uo_dw : MenuStrip
    {
        // Exponemos eventos equivalentes a los TriggerEvent('...') del SRM
        public event EventHandler Ordenar;
        public event EventHandler Filtrar;
        public event EventHandler Preview;

        public m_uo_dw()
        {
            InitializeComponent();
        }

        // Handlers que invocan los eventos públicos (equivalentes a Llamador.TriggerEvent('...'))
        private void m_ordenar_Click(object sender, EventArgs e) => Ordenar?.Invoke(this, EventArgs.Empty);
        private void m_filtrar_Click(object sender, EventArgs e) => Filtrar?.Invoke(this, EventArgs.Empty);
        private void m_preview_Click(object sender, EventArgs e) => Preview?.Invoke(this, EventArgs.Empty);
    }
}
