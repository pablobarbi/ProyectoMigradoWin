using MinottiApp.utils;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Capitulos.Controls
{
    partial class w_abm_lista_subrubricas
    {
        private IContainer components = null;

        private Button cb_medicamentos;
        private Button cb_menos_subrubrica;
        private Button cb_mas_subrubrica;
        private Label st_capitulo;
        private Label st_rubrica;
        private Button cb_modif_subrubrica;

        // PB button (exists also as PB boolean flag ib_grabar)
        private Button ib_Grabar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();

            cb_medicamentos = new Button();
            cb_menos_subrubrica = new Button();
            cb_mas_subrubrica = new Button();
            st_capitulo = new Label();
            st_rubrica = new Label();
            cb_modif_subrubrica = new Button();

            SuspendLayout();

            // ======================
            // st_capitulo
            // ======================
            st_capitulo.AutoSize = false;
            st_capitulo.Location = new Point(709, 92);
            st_capitulo.Size = new Size(1074, 72);
            st_capitulo.Font = new Font("Arial", 10f, FontStyle.Bold);
            st_capitulo.Text = "none";

            // ======================
            // st_rubrica
            // ======================
            st_rubrica.AutoSize = false;
            st_rubrica.Location = new Point(718, 256);
            st_rubrica.Size = new Size(1038, 64);
            st_rubrica.Font = new Font("Arial", 10f, FontStyle.Bold);
            st_rubrica.Text = "none";

            // ======================
            // cb_mas_subrubrica
            // ======================
            cb_mas_subrubrica.Location = new Point(32, 112);
            cb_mas_subrubrica.Size = new Size(603, 112);
            cb_mas_subrubrica.TabIndex = 10;
            cb_mas_subrubrica.Text = "&Agregar Subrubrica";
            cb_mas_subrubrica.UseVisualStyleBackColor = true;

            // ======================
            // cb_menos_subrubrica
            // ======================
            cb_menos_subrubrica.Location = new Point(32, 256);
            cb_menos_subrubrica.Size = new Size(603, 112);
            cb_menos_subrubrica.TabIndex = 11;
            cb_menos_subrubrica.Text = "&Borrar Sububrica";
            cb_menos_subrubrica.UseVisualStyleBackColor = true;

            // ======================
            // cb_medicamentos
            // ======================
            cb_medicamentos.Location = new Point(32, 400);
            cb_medicamentos.Size = new Size(603, 112);
            cb_medicamentos.TabIndex = 12;
            cb_medicamentos.Text = "&Medicamentos";
            cb_medicamentos.UseVisualStyleBackColor = true;

            // ======================
            // cb_modif_subrubrica
            // ======================
            cb_modif_subrubrica.Location = new Point(32, 556);
            cb_modif_subrubrica.Size = new Size(603, 112);
            cb_modif_subrubrica.TabIndex = 13;
            cb_modif_subrubrica.Text = "m&Odificar Subrubrica";
            cb_modif_subrubrica.UseVisualStyleBackColor = true;

            // ======================
            // ib_Grabar (PB image button)
            // ======================
            this.ib_Grabar = new Button();
            this.ib_Grabar.Name = "ib_Grabar";
            this.ib_Grabar.Text = "Grabar";
            this.ib_Grabar.Location = new Point(32, 700);
            this.ib_Grabar.Click += (s, e) => DynamicEventInvoker.Trigger(this, "ue_grabar");
            this.Controls.Add(this.ib_Grabar);

            // ====================== FORM ======================
            AutoScaleMode = AutoScaleMode.Font;
            Text = "w_abm_lista_subrubricas";

            Controls.Add(st_capitulo);
            Controls.Add(st_rubrica);
            Controls.Add(cb_mas_subrubrica);
            Controls.Add(cb_menos_subrubrica);
            Controls.Add(cb_modif_subrubrica);
            Controls.Add(cb_medicamentos);

            ResumeLayout(false);
        }
    }
}
