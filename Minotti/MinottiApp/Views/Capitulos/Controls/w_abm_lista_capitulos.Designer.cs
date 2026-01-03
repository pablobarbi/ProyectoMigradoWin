
using System.ComponentModel;
using System.Windows.Forms;

namespace Minotti.Views.Capitulos.Controls
{
    partial class w_abm_lista_capitulos
    {
        private IContainer? components = null;

        // Controles PB
        protected Button cb_mas_capitulos = null!;
        protected Button cb_menos_capitulos = null!;
        protected Button cb_modif_capitulos = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();

            cb_mas_capitulos = new Button();
            cb_menos_capitulos = new Button();
            cb_modif_capitulos = new Button();

            // === cb_mas_capitulos ===
            cb_mas_capitulos.Name = "cb_mas_capitulos";
            cb_mas_capitulos.Text = "&Agregar Capitulos";
            cb_mas_capitulos.TabIndex = 10;

            // === cb_menos_capitulos ===
            cb_menos_capitulos.Name = "cb_menos_capitulos";
            cb_menos_capitulos.Text = "&Borrar Capitulos";
            cb_menos_capitulos.TabIndex = 20;

            // === cb_modif_capitulos ===
            cb_modif_capitulos.Name = "cb_modif_capitulos";
            cb_modif_capitulos.Text = "&Modificar Capítulos";
            cb_modif_capitulos.TabIndex = 30;

            this.Controls.Add(cb_mas_capitulos);
            this.Controls.Add(cb_menos_capitulos);
            this.Controls.Add(cb_modif_capitulos);

            this.Name = "w_abm_lista_capitulos";
            this.Text = "w_abm_lista_capitulos";
        }
    }
}
