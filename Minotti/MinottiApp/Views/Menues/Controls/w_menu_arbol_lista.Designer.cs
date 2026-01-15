// w_menu_arbol_lista.Designer.cs
// Migración PB -> C# WinForms (.NET) | SOLO designer

using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using Minotti.utils;

namespace Minotti.Views.Menues.Controls
{
    partial class w_menu_arbol_lista
    {
        private IContainer components = null;

        public ListView lv_1;
        public uo_link lnk_mail;
        public MonthCalendar dw_calendario;
        public PictureBox p_menu;
        public uo_link lnk_web;
        public Button pb_confirmar;
        public Button pb_borrar;
        public Button pb_agregar;
        public Button pb_imprimir;
        public TextBox rte_1;
        public Label st_acceso;
        public uo_link lnk_manual;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();

            // ================= FORM =================
            this.AutoScaleMode = AutoScaleMode.None;
            this.ClientSize = new Size(3899, 1792);
            this.Name = "w_menu_arbol_lista";

            // ================= lv_1 =================
            this.lv_1 = new ListView();
            this.lv_1.Location = new Point(1143, 36);
            this.lv_1.Size = new Size(2149, 700);
            this.lv_1.View = View.Details;
            this.lv_1.FullRowSelect = true;
            this.lv_1.HideSelection = false;
            this.lv_1.MultiSelect = true;
            this.lv_1.TabIndex = 20;

            // ================= lnk_mail =================
            this.lnk_mail = new uo_link();
            this.lnk_mail.Location = new Point(1134, 1328);
            this.lnk_mail.Size = new Size(704, 92);
            this.lnk_mail.Text = "Contactarse con Minotti...";
            this.lnk_mail.TabIndex = 21;

            // ================= dw_calendario =================
            this.dw_calendario = new MonthCalendar();
            this.dw_calendario.Location = new Point(1207, 460);
            this.dw_calendario.TabIndex = 30;

            // ================= p_menu =================
            this.p_menu = new PictureBox();
            this.p_menu.Location = new Point(2030, 508);
            this.p_menu.Size = new Size(1070, 1068);
            this.p_menu.SizeMode = PictureBoxSizeMode.StretchImage;
            this.p_menu.BorderStyle = BorderStyle.FixedSingle;

            // ================= lnk_web =================
            this.lnk_web = new uo_link();
            this.lnk_web.Location = new Point(1138, 1460);
            this.lnk_web.Size = new Size(718, 92);
            this.lnk_web.Text = "Ir a la pagina de Minotti...";
            this.lnk_web.TabIndex = 22;

            // ================= pb_confirmar =================
            this.pb_confirmar = new Button();
            this.pb_confirmar.Location = new Point(3145, 4);
            this.pb_confirmar.Size = new Size(150, 150);
            this.pb_confirmar.Text = "Medicamentos";
            this.pb_confirmar.TabIndex = 40;
            this.pb_confirmar.Image = Image.FromFile(FileUtils.GetAppFile("Pictures", "medicamento.gif"));

            // ================= pb_borrar =================
            this.pb_borrar = new Button();
            this.pb_borrar.Location = new Point(3447, 12);
            this.pb_borrar.Size = new Size(150, 150);
            this.pb_borrar.Text = "Pacientes";
            this.pb_borrar.TabIndex = 41;
            this.pb_borrar.Image = Image.FromFile(FileUtils.GetAppFile("Pictures", "paciente2.jpg"));

            // ================= pb_agregar =================
            this.pb_agregar = new Button();
            this.pb_agregar.Location = new Point(3150, 268);
            this.pb_agregar.Size = new Size(150, 150);
            this.pb_agregar.Text = "Capítulos";
            this.pb_agregar.TabIndex = 42;
            this.pb_agregar.Image = Image.FromFile(FileUtils.GetAppFile("Pictures", "capitulo.jpg"));

            // ================= pb_imprimir =================
            this.pb_imprimir = new Button();
            this.pb_imprimir.Location = new Point(3447, 264);
            this.pb_imprimir.Size = new Size(150, 150);
            this.pb_imprimir.Text = "Repertorizaciones";
            this.pb_imprimir.TabIndex = 43;
            this.pb_imprimir.Image = Image.FromFile(FileUtils.GetAppFile("Pictures", "reperto.jpg"));
            

            // ================= rte_1 =================
            this.rte_1 = new TextBox();
            this.rte_1.Location = new Point(1929, 276);
            this.rte_1.Size = new Size(480, 400);
            this.rte_1.Multiline = true;
            this.rte_1.ScrollBars = ScrollBars.Both;
            this.rte_1.BackColor = utils.PBColor.FromPB(15793151);
            this.rte_1.TabIndex = 70;

            // ================= st_acceso =================
            this.st_acceso = new Label();
            this.st_acceso.Location = new Point(3154, 512);
            this.st_acceso.Size = new Size(562, 88);
            this.st_acceso.Text = "Accesos Directos";
            this.st_acceso.TextAlign = ContentAlignment.MiddleCenter;
            this.st_acceso.BackColor = utils.PBColor.FromPB(67108864);
            this.st_acceso.ForeColor = Color.FromArgb(128);

            // ================= lnk_manual =================
            this.lnk_manual = new uo_link();
            this.lnk_manual.Location = new Point(274, 1448);
            this.lnk_manual.Size = new Size(741, 92);
            this.lnk_manual.Text = "Abrir el Manual del Usuario.";
            this.lnk_manual.TabIndex = 23;

            // ================= ADD CONTROLS =================
            // tv_1 viene heredado de w_menu_arbol (NO se crea acá)
            this.Controls.Add(this.lv_1);
            this.Controls.Add(this.lnk_mail);
            this.Controls.Add(this.dw_calendario);
            this.Controls.Add(this.p_menu);
            this.Controls.Add(this.lnk_web);
            this.Controls.Add(this.pb_confirmar);
            this.Controls.Add(this.pb_borrar);
            this.Controls.Add(this.pb_agregar);
            this.Controls.Add(this.pb_imprimir);
            this.Controls.Add(this.rte_1);
            this.Controls.Add(this.st_acceso);
            this.Controls.Add(this.lnk_manual);
        }
    }
}