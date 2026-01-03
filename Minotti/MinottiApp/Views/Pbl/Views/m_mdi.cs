using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Models;
using MinottiApp.utils;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Minotti.Views.Pbl.Views
{
    // PowerBuilder: global type m_mdi from menu
    // WinForms: MenuStrip.
    public partial class m_mdi : Form
    {
        public m_mdi()
        {
            InitializeComponent();
            WireEvents();
            PBGlobals.m_mdi = this;
        }

        private void WireEvents()
        {
            // Operaciones
            m_confirmar.Click += (s, e) => TriggerActiveSheet("ue_grabar");
            m_cancelar.Click += (s, e) => TriggerActiveSheet("ue_cancelar");
            m_insertar.Click += (s, e) => TriggerActiveSheet("ue_insertar");
            m_borrar.Click += m_borrar_Click;
            m_iniciarconsulta.Click += (s, e) => TriggerActiveSheet("ue_buscar");
            m_procesar.Click += (s, e) => TriggerActiveSheet("ue_procesar");
            m_preliminar.Click += (s, e) => TriggerActiveSheet("ue_preview");
            m_imprimir.Click += (s, e) => TriggerActiveSheet("ue_imprimir");
            m_salvarcomo.Click += (s, e) => TriggerActiveSheet("ue_salvar");
            m_salir.Click += m_salir_Click;

            // Navegación
            m_primerregistro.Click += (s, e) => TriggerActiveSheet("ue_primero");
            m_siguienteregistro.Click += (s, e) => TriggerActiveSheet("ue_siguiente");
            m_anteriorregistro.Click += (s, e) => TriggerActiveSheet("ue_anterior");
            m_ultimoregistro.Click += (s, e) => TriggerActiveSheet("ue_ultimo");

            // Ventanas
            m_layer.Click += (s, e) => ArrangeSheets(MdiLayout.TileVertical);
            m_mosaico.Click += (s, e) => ArrangeSheets(MdiLayout.TileHorizontal);
            m_casacada.Click += (s, e) => ArrangeSheets(MdiLayout.Cascade);

            // Ayuda
            m_acercade.Click += (s, e) => uo_app.Instance.uof_mostrar_datos_sistema();
        }

        // ========================================================
        //  Helpers PB -> C#
        // ========================================================
        private w_sheet? GetActiveSheet()
        {
            return this.MdiParent?.ActiveMdiChild as w_sheet;
        }

        private void TriggerActiveSheet(string eventName)
        {
            var wAux = GetActiveSheet();
            if (wAux != null)
                DynamicEventInvoker.Trigger(wAux, eventName);
        }

        private void ArrangeSheets(MdiLayout layout)
        {
            this.MdiParent?.LayoutMdi(layout);
        }

        // ========================================================
        //  Eventos especiales
        // ========================================================
        private void m_borrar_Click(object sender, EventArgs e)
        {
            var wAux = GetActiveSheet();
            if (wAux == null) return;

            var result = MessageBox.Show("¿Está seguro que desea borrar el registro?",
                "Minotti", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                DynamicEventInvoker.Trigger(wAux, "ue_eliminar");
        }

        private void m_salir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea salir del sistema?",
                "Minotti", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                this.MdiParent?.Close(); // igual que PB: Close(ParentWindow)
        }

        
    }
}
