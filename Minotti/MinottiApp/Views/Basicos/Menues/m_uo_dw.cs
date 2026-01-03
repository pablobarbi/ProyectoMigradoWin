using Minotti.Views.Basicos.Controls;
using MinottiApp.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minotti.Views.Basicos.Menues
{
    /// <summary>
    /// Equivalente al menu m_uo_dw de PowerBuilder.
    /// Se engancha a un uo_dw y dispara eventos del DW.
    /// </summary>
     // global type m_uo_dw from menu
    public class m_uo_dw : ContextMenuStrip
    {
        // type variables: private datawindow llamador
        // En PB tipa como datawindow, pero se le pasa uo_dw.
        private uo_dw? llamador;

        // m_ordenar m_ordenar
        public ToolStripMenuItem m_ordenar { get; private set; }

        // m_filtrar m_filtrar
        public ToolStripMenuItem m_filtrar { get; private set; }

        // m_preview m_preview
        public ToolStripMenuItem m_preview { get; private set; }

        public m_uo_dw()
        {
            // on m_uo_dw.create
            m_ordenar = new ToolStripMenuItem();
            m_filtrar = new ToolStripMenuItem();
            m_preview = new ToolStripMenuItem();

            // on m_ordenar.create
            m_ordenar.Text = "Ordenar";
            // on m_filtrar.create
            m_filtrar.Text = "Filtrar";
            // on m_preview.create
            m_preview.Text = "Preview";

            // events clicked
            m_ordenar.Click += m_ordenar_clicked;
            m_filtrar.Click += m_filtrar_clicked;
            m_preview.Click += m_preview_clicked;

            // this.Item[]={...}
            this.Items.AddRange(new ToolStripItem[]
            {
                m_ordenar,
                m_filtrar,
                m_preview
            });
        }

        // public subroutine instanciar (uo_dw dw)
        public void instanciar(uo_dw dw)
        {
            llamador = dw;
        }

        private void m_ordenar_clicked(object? sender, EventArgs e)
        {
            if (llamador == null) return;

            // PB: Llamador.TriggerEvent('Ordenar')
            // Si tu uo_dw tiene TriggerEvent(string), usarlo:
            // llamador.TriggerEvent("Ordenar");

            DynamicEventInvoker.Trigger(llamador, "Ordenar");
        }

        private void m_filtrar_clicked(object? sender, EventArgs e)
        {
            if (llamador == null) return;

            // PB: Llamador.TriggerEvent('Filtrar')
            DynamicEventInvoker.Trigger(llamador, "Filtrar");
        }

        private void m_preview_clicked(object? sender, EventArgs e)
        {
            if (llamador == null) return;

            // PB: Llamador.TriggerEvent('Preview')
            DynamicEventInvoker.Trigger(llamador, "Preview");
        }

        protected  override void Dispose(bool disposing)
        {
            // on m_uo_dw.destroy
            if (disposing)
            {
                m_ordenar.Click -= m_ordenar_clicked;
                m_filtrar.Click -= m_filtrar_clicked;
                m_preview.Click -= m_preview_clicked;
            }

            base.Dispose(disposing);
        }
    }
}
