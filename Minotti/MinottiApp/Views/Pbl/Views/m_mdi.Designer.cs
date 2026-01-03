using System.Windows.Forms;

namespace Minotti.Views.Pbl.Views
{
    partial class m_mdi
    {
        private MenuStrip menuStrip1;

        public ToolStripMenuItem m_operaciones;
        public ToolStripMenuItem m_confirmar;
        public ToolStripMenuItem m_cancelar;
        private ToolStripSeparator m_sep1;
        public ToolStripMenuItem m_insertar;
        public ToolStripMenuItem m_borrar;
        public ToolStripSeparator m_sep2;
        public ToolStripMenuItem m_iniciarconsulta;
        public ToolStripMenuItem m_procesar;
        public ToolStripSeparator m_sep3;
        public ToolStripMenuItem m_preliminar;
        public ToolStripMenuItem m_imprimir;
        public ToolStripMenuItem m_salvarcomo;
        public ToolStripSeparator m_sep4;
        public ToolStripMenuItem m_salir;

        public ToolStripMenuItem m_navegacion;
        public ToolStripMenuItem m_primerregistro;
        public ToolStripMenuItem m_siguienteregistro;
        public ToolStripMenuItem m_anteriorregistro;
        public ToolStripMenuItem m_ultimoregistro;

        public ToolStripMenuItem m_ventanas;
        public ToolStripMenuItem m_layer;
        public ToolStripMenuItem m_mosaico;
        public ToolStripMenuItem m_casacada;

        public ToolStripMenuItem m_ayuda;
        public ToolStripMenuItem m_acercade;

        private void InitializeComponent()
        {
            this.menuStrip1 = new MenuStrip();

            // =======================
            //  MENÚ OPERACIONES
            // =======================
            this.m_operaciones = new ToolStripMenuItem("&Operaciones");
            this.m_confirmar = new ToolStripMenuItem("&Confirmar", null, null, Keys.Control | Keys.C);
            this.m_cancelar = new ToolStripMenuItem("Cance&lar", null, null, Keys.Control | Keys.L);
            this.m_sep1 = new ToolStripSeparator();
            this.m_insertar = new ToolStripMenuItem("&Agregar", null, null, Keys.Control | Keys.A);
            this.m_borrar = new ToolStripMenuItem("&Borrar", null, null, Keys.Control | Keys.B);
            this.m_sep2 = new ToolStripSeparator();
            this.m_iniciarconsulta = new ToolStripMenuItem("&Iniciar Consulta", null, null, Keys.Control | Keys.I);
            this.m_procesar = new ToolStripMenuItem("P&rocesar", null, null, Keys.Control | Keys.R);
            this.m_sep3 = new ToolStripSeparator();
            this.m_preliminar = new ToolStripMenuItem("Preliminar", null, null, Keys.Control | Keys.V);
            this.m_imprimir = new ToolStripMenuItem("Im&primir", null, null, Keys.Control | Keys.P);
            this.m_salvarcomo = new ToolStripMenuItem("Salvar como ...");
            this.m_sep4 = new ToolStripSeparator();
            this.m_salir = new ToolStripMenuItem("&Salir");

            this.m_operaciones.DropDownItems.AddRange(new ToolStripItem[] {
                m_confirmar,
                m_cancelar,
                m_sep1,
                m_insertar,
                m_borrar,
                m_sep2,
                m_iniciarconsulta,
                m_procesar,
                m_sep3,
                m_preliminar,
                m_imprimir,
                m_salvarcomo,
                m_sep4,
                m_salir
            });

            // =======================
            //  MENÚ NAVEGACIÓN
            // =======================
            this.m_navegacion = new ToolStripMenuItem("&Navegacion");
            this.m_primerregistro = new ToolStripMenuItem("&primer Registro");
            this.m_siguienteregistro = new ToolStripMenuItem("&siguiente Registro");
            this.m_anteriorregistro = new ToolStripMenuItem("&anterior Registro");
            this.m_ultimoregistro = new ToolStripMenuItem("&ultimo Registro");

            this.m_navegacion.DropDownItems.AddRange(new ToolStripItem[] {
                m_primerregistro,
                m_siguienteregistro,
                m_anteriorregistro,
                m_ultimoregistro
            });

            // =======================
            //  MENÚ VENTANAS
            // =======================
            this.m_ventanas = new ToolStripMenuItem("&Ventanas");
            this.m_layer = new ToolStripMenuItem("Layer");
            this.m_mosaico = new ToolStripMenuItem("Mosaico");
            this.m_casacada = new ToolStripMenuItem("Cascada");

            this.m_ventanas.DropDownItems.AddRange(new ToolStripItem[] {
                m_layer,
                m_mosaico,
                m_casacada
            });

            // =======================
            //  MENÚ AYUDA
            // =======================
            this.m_ayuda = new ToolStripMenuItem("&Ayuda");
            this.m_acercade = new ToolStripMenuItem("Acerca de ...");

            this.m_ayuda.DropDownItems.Add(m_acercade);

            // =======================
            //  MENUSTRIP ROOT
            // =======================
            this.menuStrip1.Items.AddRange(new ToolStripItem[] {
                m_operaciones,
                m_navegacion,
                m_ventanas,
                m_ayuda
            });

            this.MainMenuStrip = this.menuStrip1;
            this.Controls.Add(this.menuStrip1);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.TabIndex = 0;

            this.Text = "m_mdi_uno";
        }
    }
}
