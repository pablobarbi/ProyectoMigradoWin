using Minotti.Views.Basicos.Controls;
using System.ComponentModel;
using System.Windows.Forms;

namespace Minotti.Views.Repertorizaciones.Controls
{
    partial class w_carga_reperto_parcial_multiple_bak
    {
        private IContainer? components = null;

        // Controles PB
        private uo_dw dw_1 = null!;
        private uo_dw dw_2 = null!;
        private uo_dw dw_3 = null!;
        private Button cb_borrar = null!;
        private Button cb_grabar = null!;
        private Button cb_reperto_parcial = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dw_1 = new uo_dw();
            this.dw_2 = new uo_dw();
            this.dw_3 = new uo_dw();
            this.cb_borrar = new Button();
            this.cb_grabar = new Button();
            this.cb_reperto_parcial = new Button();

            this.SuspendLayout();

            // 
            // w_carga_reperto_parcial_multiple_bak (Form)
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2199, 1516); // PB width/height referencial (no exact pixels)
            this.Name = "w_carga_reperto_parcial_multiple_bak";
            this.Text = "w_carga_reperto_parcial_multiple_bak";

            // 
            // dw_1 (PB x=32 y=32 w=3392 h=452)
            // 
            this.dw_1.Left = 32;
            this.dw_1.Top = 32;
            this.dw_1.Width = 3392;
            this.dw_1.Height = 452;
            this.dw_1.TabIndex = 10;

            // 
            // dw_2 (PB x=32 y=504 w=3392 h=636)
            // 
            this.dw_2.Left = 32;
            this.dw_2.Top = 504;
            this.dw_2.Width = 3392;
            this.dw_2.Height = 636;
            this.dw_2.TabIndex = 11;

            // 
            // cb_borrar (PB x=933 y=1200 w=494 h=104 text="&Borrar Síntoma")
            // 
            this.cb_borrar.Left = 933;
            this.cb_borrar.Top = 1200;
            this.cb_borrar.Width = 494;
            this.cb_borrar.Height = 104;
            this.cb_borrar.TabIndex = 30;
            this.cb_borrar.Text = "&Borrar Síntoma";
            this.cb_borrar.UseVisualStyleBackColor = true;

            // 
            // cb_grabar (PB x=1454 y=1200 w=402 h=104 text="&Guardar")
            // 
            this.cb_grabar.Left = 1454;
            this.cb_grabar.Top = 1200;
            this.cb_grabar.Width = 402;
            this.cb_grabar.Height = 104;
            this.cb_grabar.TabIndex = 31;
            this.cb_grabar.Text = "&Guardar";
            this.cb_grabar.UseVisualStyleBackColor = true;

            // 
            // dw_3 (PB x=1097 y=88 w=2624 h=428)
            // 
            this.dw_3.Left = 1097;
            this.dw_3.Top = 88;
            this.dw_3.Width = 2624;
            this.dw_3.Height = 428;
            this.dw_3.TabIndex = 12;

            // 
            // cb_reperto_parcial (PB x=1883 y=1204 w=416 h=100 text="&Repertorizar")
            // 
            this.cb_reperto_parcial.Left = 1883;
            this.cb_reperto_parcial.Top = 1204;
            this.cb_reperto_parcial.Width = 416;
            this.cb_reperto_parcial.Height = 100;
            this.cb_reperto_parcial.TabIndex = 40;
            this.cb_reperto_parcial.Text = "&Repertorizar";
            this.cb_reperto_parcial.UseVisualStyleBackColor = true;

            // Add controls
            this.Controls.Add(this.dw_1);
            this.Controls.Add(this.dw_2);
            this.Controls.Add(this.cb_borrar);
            this.Controls.Add(this.cb_grabar);
            this.Controls.Add(this.dw_3);
            this.Controls.Add(this.cb_reperto_parcial);

            this.ResumeLayout(false);
        }
    }
}