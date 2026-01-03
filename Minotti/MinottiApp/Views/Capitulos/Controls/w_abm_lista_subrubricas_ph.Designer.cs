
using Minotti.Views.Basicos.Controls;
using System.Windows.Forms;

namespace Minotti.Views.Capitulos.Controls
{
    partial class w_abm_lista_subrubricas_ph
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dw_1 = new uo_dw();
            this.dw_buscar = new uo_dw();

            this.cb_mas_subrubrica = new System.Windows.Forms.Button();
            this.cb_menos_subrubrica = new System.Windows.Forms.Button();
            this.cb_modif_subrubrica = new System.Windows.Forms.Button();
            this.cb_medicamentos = new System.Windows.Forms.Button();

            this.st_capitulo = new System.Windows.Forms.Label();
            this.st_rubrica = new System.Windows.Forms.Label();

            this.st_subrubrica1 = new System.Windows.Forms.Label();
            this.st_subrubrica2 = new System.Windows.Forms.Label();
            this.st_subrubrica3 = new System.Windows.Forms.Label();
            this.st_subrubrica4 = new System.Windows.Forms.Label();
            this.st_subrubrica5 = new System.Windows.Forms.Label();
            this.st_subrubrica6 = new System.Windows.Forms.Label();
            this.st_subrubrica7 = new System.Windows.Forms.Label();
            this.st_subrubrica8 = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // 
            // dw_1
            // 
            this.dw_1.Location = new System.Drawing.Point(12, 160);
            this.dw_1.Name = "dw_1";
            this.dw_1.Size = new System.Drawing.Size(760, 300);
            this.dw_1.TabIndex = 0;

            // 
            // dw_buscar
            // 
            this.dw_buscar.Location = new System.Drawing.Point(12, 120);
            this.dw_buscar.Name = "dw_buscar";
            this.dw_buscar.Size = new System.Drawing.Size(760, 30);
            this.dw_buscar.TabIndex = 1;

            // 
            // cb_mas_subrubrica
            // 
            this.cb_mas_subrubrica.Location = new System.Drawing.Point(790, 160);
            this.cb_mas_subrubrica.Name = "cb_mas_subrubrica";
            this.cb_mas_subrubrica.Size = new System.Drawing.Size(140, 30);
            this.cb_mas_subrubrica.TabIndex = 2;
            this.cb_mas_subrubrica.Text = "Agregar";
            this.cb_mas_subrubrica.UseVisualStyleBackColor = true;

            // 
            // cb_menos_subrubrica
            // 
            this.cb_menos_subrubrica.Location = new System.Drawing.Point(790, 200);
            this.cb_menos_subrubrica.Name = "cb_menos_subrubrica";
            this.cb_menos_subrubrica.Size = new System.Drawing.Size(140, 30);
            this.cb_menos_subrubrica.TabIndex = 3;
            this.cb_menos_subrubrica.Text = "Eliminar";
            this.cb_menos_subrubrica.UseVisualStyleBackColor = true;

            // 
            // cb_modif_subrubrica
            // 
            this.cb_modif_subrubrica.Location = new System.Drawing.Point(790, 240);
            this.cb_modif_subrubrica.Name = "cb_modif_subrubrica";
            this.cb_modif_subrubrica.Size = new System.Drawing.Size(140, 30);
            this.cb_modif_subrubrica.TabIndex = 4;
            this.cb_modif_subrubrica.Text = "Modificar";
            this.cb_modif_subrubrica.UseVisualStyleBackColor = true;

            // 
            // cb_medicamentos
            // 
            this.cb_medicamentos.Location = new System.Drawing.Point(790, 280);
            this.cb_medicamentos.Name = "cb_medicamentos";
            this.cb_medicamentos.Size = new System.Drawing.Size(140, 30);
            this.cb_medicamentos.TabIndex = 5;
            this.cb_medicamentos.Text = "Medicamentos";
            this.cb_medicamentos.UseVisualStyleBackColor = true;

            // 
            // st_capitulo
            // 
            this.st_capitulo.AutoSize = true;
            this.st_capitulo.Location = new System.Drawing.Point(12, 9);
            this.st_capitulo.Name = "st_capitulo";
            this.st_capitulo.Size = new System.Drawing.Size(54, 15);
            this.st_capitulo.TabIndex = 6;
            this.st_capitulo.Text = "Capitulo";

            // 
            // st_rubrica
            // 
            this.st_rubrica.AutoSize = true;
            this.st_rubrica.Location = new System.Drawing.Point(12, 30);
            this.st_rubrica.Name = "st_rubrica";
            this.st_rubrica.Size = new System.Drawing.Size(53, 15);
            this.st_rubrica.TabIndex = 7;
            this.st_rubrica.Text = "Rubrica";

            // === Subrubricas ===
            Label[] subs = {
                st_subrubrica1 = new Label(),
                st_subrubrica2 = new Label(),
                st_subrubrica3 = new Label(),
                st_subrubrica4 = new Label(),
                st_subrubrica5 = new Label(),
                st_subrubrica6 = new Label(),
                st_subrubrica7 = new Label(),
                st_subrubrica8 = new Label()
            };

            int y = 55;
            for (int i = 0; i < subs.Length; i++)
            {
                subs[i].AutoSize = true;
                subs[i].Location = new System.Drawing.Point(12 + (i * 95), y);
                subs[i].Name = $"st_subrubrica{i + 1}";
                subs[i].Size = new System.Drawing.Size(80, 15);
                subs[i].Visible = false;
                this.Controls.Add(subs[i]);
            }

            // 
            // w_abm_lista_subrubricas_ph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 480);
            this.Controls.Add(this.dw_1);
            this.Controls.Add(this.dw_buscar);
            this.Controls.Add(this.cb_mas_subrubrica);
            this.Controls.Add(this.cb_menos_subrubrica);
            this.Controls.Add(this.cb_modif_subrubrica);
            this.Controls.Add(this.cb_medicamentos);
            this.Controls.Add(this.st_capitulo);
            this.Controls.Add(this.st_rubrica);
            this.Name = "w_abm_lista_subrubricas_ph";
            this.Text = "Subrubricas";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private uo_dw dw_1;
        private uo_dw dw_buscar;

        private System.Windows.Forms.Button cb_mas_subrubrica;
        private System.Windows.Forms.Button cb_menos_subrubrica;
        private System.Windows.Forms.Button cb_modif_subrubrica;
        private System.Windows.Forms.Button cb_medicamentos;

        private System.Windows.Forms.Label st_capitulo;
        private System.Windows.Forms.Label st_rubrica;

        private System.Windows.Forms.Label st_subrubrica1;
        private System.Windows.Forms.Label st_subrubrica2;
        private System.Windows.Forms.Label st_subrubrica3;
        private System.Windows.Forms.Label st_subrubrica4;
        private System.Windows.Forms.Label st_subrubrica5;
        private System.Windows.Forms.Label st_subrubrica6;
        private System.Windows.Forms.Label st_subrubrica7;
        private System.Windows.Forms.Label st_subrubrica8;
    }
}
