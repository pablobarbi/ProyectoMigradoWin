using System;
using System.Windows.Forms;
using Minotti.Controls;

namespace Minotti.Views
{
    // Migración de PowerBuilder: w_tab.srw
    // En PB: global type w_tab from w_operacion
    public partial class w_tab : w_operacion
    {
        public w_tab()
        {
            InitializeComponent();
        }

        // Eventos PB presentes en el SRW
        public override void ue_leer_parametros() { /* cuerpo según SRW */ }
        public override void ue_iniciar() { /* cuerpo según SRW */ }

        // En el SRW: ue_imprimir => tab_1.Event Trigger ue_imprimir()
        public override void ue_imprimir()
        {
            try { tab_1?.ue_imprimir(); } catch { /* si uo_tab aún es stub */ }
        }

        // En el SRW: ue_preview => tab_1.Event Trigger ue_preview()
        public override void ue_preview()
        {
            try { tab_1?.ue_preview(); } catch { /* si uo_tab aún es stub */ }
        }

        // Función PB detectada: integer f_pagina_o_tab(string evento)
        public int f_pagina_o_tab(string evento)
        {
            // Stub: devolver página/tab seleccionada según 'evento' si aplica.
            // Ajusto la lógica cuando me pases el cuerpo PB.
            return 1;
        }

        // Mapear activate/deactivate si hay lógica de menús en PB
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            // En PB: m_mdi.m_operaciones.m_imprimir.Enabled = TRUE (si aplica)
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            // En PB: m_mdi.m_operaciones.m_imprimir.Enabled = FALSE
        }
    }
}
