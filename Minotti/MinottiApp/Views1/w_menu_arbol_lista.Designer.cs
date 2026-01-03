namespace Minotti
{
    partial class w_menu_arbol_lista
    {
        private System.ComponentModel.IContainer components = null;

        // Controles declarados en SRW (mismos nombres)
        private System.Windows.Forms.SplitContainer sc_main;
        private System.Windows.Forms.ListView lv_1;
        private Minotti.uo_link lnk_mail;
        private Minotti.uo_calendar dw_calendario;
        private System.Windows.Forms.PictureBox p_menu;
        private Minotti.uo_link lnk_web;
        private System.Windows.Forms.Button pb_confirmar;
        private System.Windows.Forms.Button pb_borrar;
        private System.Windows.Forms.Button pb_agregar;
        private System.Windows.Forms.Button pb_imprimir;
        private System.Windows.Forms.TextBox rte_1;
        private System.Windows.Forms.Label st_acceso;
        private Minotti.uo_link lnk_manual;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.sc_main = new System.Windows.Forms.SplitContainer();
            this.lv_1 = new System.Windows.Forms.ListView();
            this.lnk_mail = new Minotti.uo_link();
            this.dw_calendario = new Minotti.uo_calendar();
            this.p_menu = new System.Windows.Forms.PictureBox();
            this.lnk_web = new Minotti.uo_link();
            this.pb_confirmar = new System.Windows.Forms.Button();
            this.pb_borrar = new System.Windows.Forms.Button();
            this.pb_agregar = new System.Windows.Forms.Button();
            this.pb_imprimir = new System.Windows.Forms.Button();
            this.rte_1 = new System.Windows.Forms.TextBox();
            this.st_acceso = new System.Windows.Forms.Label();
            this.lnk_manual = new Minotti.uo_link();
            ((System.ComponentModel.ISupportInitialize)(this.sc_main)).BeginInit();
            this.sc_main.Panel1.SuspendLayout();
            this.sc_main.Panel2.SuspendLayout();
            this.sc_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p_menu)).BeginInit();
            this.SuspendLayout();
            // 
            // sc_main
            // 
            this.sc_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_main.Name = "sc_main";
            this.sc_main.SplitterDistance = 260;
            this.sc_main.TabIndex = 0;
            // Panel1: se insertará tv_1 heredado
            // 
            this.sc_main.Panel1.Name = "panelTree";
            // 
            // Panel2 (derecha): lista y demás controles
            // 
            this.sc_main.Panel2.Name = "panelRight";
            this.sc_main.Panel2.Controls.Add(this.lv_1);
            this.sc_main.Panel2.Controls.Add(this.dw_calendario);
            this.sc_main.Panel2.Controls.Add(this.p_menu);
            this.sc_main.Panel2.Controls.Add(this.lnk_web);
            this.sc_main.Panel2.Controls.Add(this.pb_imprimir);
            this.sc_main.Panel2.Controls.Add(this.pb_confirmar);
            this.sc_main.Panel2.Controls.Add(this.pb_borrar);
            this.sc_main.Panel2.Controls.Add(this.pb_agregar);
            this.sc_main.Panel2.Controls.Add(this.rte_1);
            this.sc_main.Panel2.Controls.Add(this.st_acceso);
            this.sc_main.Panel2.Controls.Add(this.lnk_manual);
            // 
            // lv_1 (ListView)
            // 
            this.lv_1.Name = "lv_1";
            this.lv_1.Location = new System.Drawing.Point(12, 56);
            this.lv_1.Size = new System.Drawing.Size(520, 220);
            this.lv_1.View = System.Windows.Forms.View.Details;
            this.lv_1.FullRowSelect = true;
            this.lv_1.HideSelection = false;
            this.lv_1.TabIndex = 1;
            // 
            // dw_calendario (uo_calendar)
            // 
            this.dw_calendario.Name = "dw_calendario";
            this.dw_calendario.Location = new System.Drawing.Point(12, 284);
            this.dw_calendario.Size = new System.Drawing.Size(260, 160);
            this.dw_calendario.TabIndex = 6;
            // 
            // p_menu (Picture)
            // 
            this.p_menu.Name = "p_menu";
            this.p_menu.Location = new System.Drawing.Point(12, 12);
            this.p_menu.Size = new System.Drawing.Size(32, 32);
            this.p_menu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.p_menu.TabStop = false;
            // 
            // lnk_web (uo_link)
            // 
            this.lnk_web.Name = "lnk_web";
            this.lnk_web.Location = new System.Drawing.Point(56, 18);
            this.lnk_web.AutoSize = true;
            this.lnk_web.settext(" web");
            // 
            // Botones PictureButton -> Button
            // 
            this.pb_agregar.Name = "pb_agregar";
            this.pb_agregar.Text = "Agregar";
            this.pb_agregar.Location = new System.Drawing.Point(12, 452);
            this.pb_agregar.Size = new System.Drawing.Size(90, 28);
            this.pb_agregar.Click += new System.EventHandler(this.pb_agregar_Click);

            this.pb_borrar.Name = "pb_borrar";
            this.pb_borrar.Text = "Borrar";
            this.pb_borrar.Location = new System.Drawing.Point(108, 452);
            this.pb_borrar.Size = new System.Drawing.Size(90, 28);
            this.pb_borrar.Click += new System.EventHandler(this.pb_borrar_Click);

            this.pb_confirmar.Name = "pb_confirmar";
            this.pb_confirmar.Text = "Confirmar";
            this.pb_confirmar.Location = new System.Drawing.Point(204, 452);
            this.pb_confirmar.Size = new System.Drawing.Size(90, 28);
            this.pb_confirmar.Click += new System.EventHandler(this.pb_confirmar_Click);

            this.pb_imprimir.Name = "pb_imprimir";
            this.pb_imprimir.Text = "Imprimir";
            this.pb_imprimir.Location = new System.Drawing.Point(300, 452);
            this.pb_imprimir.Size = new System.Drawing.Size(90, 28);
            this.pb_imprimir.Click += new System.EventHandler(this.pb_imprimir_Click);
            // 
            // rte_1 (MultiLineEdit)
            // 
            this.rte_1.Name = "rte_1";
            this.rte_1.Location = new System.Drawing.Point(280, 284);
            this.rte_1.Size = new System.Drawing.Size(252, 160);
            this.rte_1.Multiline = true;
            this.rte_1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rte_1.TabIndex = 7;
            // 
            // st_acceso (StaticText)
            // 
            this.st_acceso.Name = "st_acceso";
            this.st_acceso.Location = new System.Drawing.Point(12, 520);
            this.st_acceso.Size = new System.Drawing.Size(200, 20);
            this.st_acceso.Text = "Acceso:";
            // 
            // lnk_manual (uo_link)
            // 
            this.lnk_manual.Name = "lnk_manual";
            this.lnk_manual.Location = new System.Drawing.Point(220, 520);
            this.lnk_manual.AutoSize = true;
            this.lnk_manual.settext(" manual");
            // 
            // lnk_mail (uo_link) - en borde inferior derecha
            // 
            this.lnk_mail.Name = "lnk_mail";
            this.lnk_mail.AutoSize = true;
            this.lnk_mail.settext(" Source by JoseMan");
            this.lnk_mail.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.lnk_mail.Location = new System.Drawing.Point(380, 560);
            // 
            // w_menu_arbol_lista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sc_main);
            this.Controls.Add(this.lnk_mail);
            this.Name = "w_menu_arbol_lista";
            this.Text = "w_menu_arbol_lista";
            this.ClientSize = new System.Drawing.Size(820, 600);
            this.sc_main.Panel1.ResumeLayout(false);
            this.sc_main.Panel2.ResumeLayout(false);
            this.sc_main.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_main)).EndInit();
            this.sc_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p_menu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
