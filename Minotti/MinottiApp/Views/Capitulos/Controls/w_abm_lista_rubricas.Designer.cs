
using Minotti.Views.Basicos.Controls;
using System.ComponentModel;
using System.Windows.Forms;

namespace Minotti.Views.Capitulos.Controls
{
    partial class w_abm_lista_rubricas
    {
        private IContainer? components = null;

        // Controles (PB)
        protected Button cb_mas_rubrica = null!;
        protected Button cb_menos_rubrica = null!;
        protected Button cb_modif_rubrica = null!;
        protected Button cb_medicamentos = null!;
        protected Label st_capitulo = null!;

        // DataWindows (tu wrapper)
        protected uo_dw dw_1 = null!;
        protected uo_dw dw_buscar = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();

            cb_mas_rubrica = new Button();
            cb_menos_rubrica = new Button();
            cb_modif_rubrica = new Button();
            cb_medicamentos = new Button();
            st_capitulo = new Label();

            dw_1 = new uo_dw();
            dw_buscar = new uo_dw();

            // =========================
            // st_capitulo (StaticText PB)
            // =========================
            st_capitulo.Name = "st_capitulo";
            st_capitulo.AutoSize = false;
            st_capitulo.Text = "";
            st_capitulo.TabIndex = 0;

            // =========================
            // cb_mas_rubrica
            // =========================
            cb_mas_rubrica.Name = "cb_mas_rubrica";
            cb_mas_rubrica.Text = "&Agregar Rúbrica";
            cb_mas_rubrica.TabIndex = 10;
            cb_mas_rubrica.UseVisualStyleBackColor = true;

            // =========================
            // cb_menos_rubrica
            // =========================
            cb_menos_rubrica.Name = "cb_menos_rubrica";
            cb_menos_rubrica.Text = "&Borrar Rúbrica";
            cb_menos_rubrica.TabIndex = 20;
            cb_menos_rubrica.UseVisualStyleBackColor = true;

            // =========================
            // cb_modif_rubrica
            // =========================
            cb_modif_rubrica.Name = "cb_modif_rubrica";
            cb_modif_rubrica.Text = "&Modificar Rúbrica";
            cb_modif_rubrica.TabIndex = 30;
            cb_modif_rubrica.UseVisualStyleBackColor = true;

            // =========================
            // cb_medicamentos
            // =========================
            cb_medicamentos.Name = "cb_medicamentos";
            cb_medicamentos.Text = "&Medicamentos";
            cb_medicamentos.TabIndex = 40;
            cb_medicamentos.UseVisualStyleBackColor = true;

            // =========================
            // dw_1
            // =========================
            dw_1.Name = "dw_1";
            dw_1.TabIndex = 50;

            // =========================
            // dw_buscar
            // =========================
            dw_buscar.Name = "dw_buscar";
            dw_buscar.TabIndex = 60;

            // Form
            this.Name = "w_abm_lista_rubricas";
            this.Text = "w_abm_lista_rubricas";

            // Agrega controles
            this.Controls.Add(st_capitulo);
            this.Controls.Add(cb_mas_rubrica);
            this.Controls.Add(cb_menos_rubrica);
            this.Controls.Add(cb_modif_rubrica);
            this.Controls.Add(cb_medicamentos);
            this.Controls.Add(dw_1);
            this.Controls.Add(dw_buscar);
        }
    }
}
