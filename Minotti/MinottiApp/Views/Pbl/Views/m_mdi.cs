using Minotti.Views.Basicos;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Pbl.Views
{
    // PB: m_mdi from menu
    public partial class m_mdi : MenuStrip
    {
        private w_mdi? _mdi;

        // 🔹 Constructor PB-style
        public m_mdi(w_mdi mdi) : this()
        {
            _mdi = mdi;
            // Asociar menú al MDI (el Add al Controls lo hace w_mdi)
            _mdi.MainMenuStrip = this;
        }
        public m_mdi()
        {
            InitializeComponent();

            // PB: propiedades visuales generales del menú
            this.Name = "m_mdi";
            this.Dock = DockStyle.Top;
        }


        // (No necesitamos enganchar Load aquí: w_mdi ya asegura que se agregue una sola vez)


        // ===============================
        // Helpers PB
        // ===============================
        private w_principal? GetActiveSheet()
        {
            var mdi = this.FindForm() as w_mdi;
            return mdi?.ActiveMdiChild as w_principal;
        }

        // ===============================
        // m_confirmar
        // ===============================
        private void m_confirmar_Click(object? sender, EventArgs e)
        {
            GetActiveSheet()?.TriggerEvent("ue_grabar");
        }

        private void m_cancelar_Click(object? sender, EventArgs e)
        {
            GetActiveSheet()?.TriggerEvent("ue_cancelar");
        }

        private void m_insertar_Click(object? sender, EventArgs e)
        {
            GetActiveSheet()?.TriggerEvent("ue_insertar");
        }

        private void m_borrar_Click(object? sender, EventArgs e)
        {
            var sheet = GetActiveSheet();
            if (sheet == null) return;

            var r = MessageBox.Show(
                "¿Esta seguro que desea borrar el registro?",
                "Minotti 2020",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
                sheet.TriggerEvent("ue_eliminar");
        }

        private void m_iniciarconsulta_Click(object? sender, EventArgs e)
        {
            GetActiveSheet()?.TriggerEvent("ue_buscar");
        }

        private void m_procesar_Click(object? sender, EventArgs e)
        {
            GetActiveSheet()?.TriggerEvent("ue_procesar");
        }

        private void m_preliminar_Click(object? sender, EventArgs e)
        {
            GetActiveSheet()?.TriggerEvent("ue_preview");
        }

        private void m_imprimir_Click(object? sender, EventArgs e)
        {
            GetActiveSheet()?.TriggerEvent("ue_imprimir");
        }

        private void m_salvarcomo_Click(object? sender, EventArgs e)
        {
            GetActiveSheet()?.TriggerEvent("ue_salvar");
        }

        private void m_salir_Click(object? sender, EventArgs e)
        {
            var r = MessageBox.Show(
                "¿Esta seguro que desea salir del sistema?",
                "Minotti 2020",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
                this.FindForm()?.Close();
        }

        // ===============================
        // Navegación
        // ===============================
        private void m_primerregistro_Click(object? sender, EventArgs e)
            => GetActiveSheet()?.TriggerEvent("ue_primero");

        private void m_siguienteregistro_Click(object? sender, EventArgs e)
            => GetActiveSheet()?.TriggerEvent("ue_siguiente");

        private void m_anteriorregistro_Click(object? sender, EventArgs e)
            => GetActiveSheet()?.TriggerEvent("ue_anterior");

        private void m_ultimoregistro_Click(object? sender, EventArgs e)
            => GetActiveSheet()?.TriggerEvent("ue_ultimo");

        // ===============================
        // Ventanas
        // ===============================
        private void m_layer_Click(object? sender, EventArgs e)
            => (this.FindForm() as w_mdi)?.LayoutMdi(MdiLayout.ArrangeIcons);

        private void m_mosaico_Click(object? sender, EventArgs e)
            => (this.FindForm() as w_mdi)?.LayoutMdi(MdiLayout.TileVertical);

        private void m_cascada_Click(object? sender, EventArgs e)
            => (this.FindForm() as w_mdi)?.LayoutMdi(MdiLayout.Cascade);

        // ===============================
        // Ayuda
        // ===============================
        private void m_acercade_Click(object? sender, EventArgs e)
        {
            guo_app.uof_mostrar_datos_sistema();
        }

        public int Colgar()
        {
            MessageBox.Show("Colgar desde menu principal", "Colgar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return 1;
        }
    }
}
