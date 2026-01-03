using System.Windows.Forms;
using System.ComponentModel;

namespace Minotti.Menus
{
    partial class m_uo_dw
    {
        private IContainer components = null;
        public ToolStripMenuItem m_ordenar;
        public ToolStripMenuItem m_filtrar;
        public ToolStripMenuItem m_preview;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            m_ordenar = new ToolStripMenuItem();
            m_filtrar = new ToolStripMenuItem();
            m_preview = new ToolStripMenuItem();

            // m_ordenar
            m_ordenar.Name = "m_ordenar";
            m_ordenar.Text = "Ordenar";
            m_ordenar.Click += m_ordenar_Click;

            // m_filtrar
            m_filtrar.Name = "m_filtrar";
            m_filtrar.Text = "Filtrar";
            m_filtrar.Click += m_filtrar_Click;

            // m_preview
            m_preview.Name = "m_preview";
            m_preview.Text = "Preview";
            m_preview.Click += m_preview_Click;

            // m_uo_dw (MenuStrip)
            SuspendLayout();
            Items.AddRange(new ToolStripItem[] { m_ordenar, m_filtrar, m_preview });
            Name = "m_uo_dw";
            TabIndex = 0;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
