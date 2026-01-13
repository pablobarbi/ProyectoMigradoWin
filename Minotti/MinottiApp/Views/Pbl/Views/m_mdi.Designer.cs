using System.Windows.Forms;

namespace Minotti.Views.Pbl.Views
{
    partial class m_mdi
    {
        public ToolStripMenuItem m_operaciones;
        public ToolStripMenuItem m_confirmar;
        public ToolStripMenuItem m_cancelar;
        public ToolStripSeparator m_sep1;
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
        public ToolStripMenuItem m_cascada;

        public ToolStripMenuItem m_ayuda;
        private ToolStripMenuItem m_acercade;

        private void InitializeComponent()
        {
            m_operaciones = new ToolStripMenuItem("&Operaciones");
            m_confirmar = new ToolStripMenuItem("&Confirmar", null, m_confirmar_Click);
            m_cancelar = new ToolStripMenuItem("Cance&lar", null, m_cancelar_Click);
            m_sep1 = new ToolStripSeparator();
            m_insertar = new ToolStripMenuItem("&Agregar", null, m_insertar_Click);
            m_borrar = new ToolStripMenuItem("&Borrar", null, m_borrar_Click);
            m_sep2 = new ToolStripSeparator();
            m_iniciarconsulta = new ToolStripMenuItem("&Iniciar Consulta", null, m_iniciarconsulta_Click);
            m_procesar = new ToolStripMenuItem("P&rocesar", null, m_procesar_Click);
            m_sep3 = new ToolStripSeparator();
            m_preliminar = new ToolStripMenuItem("Preliminar", null, m_preliminar_Click);
            m_imprimir = new ToolStripMenuItem("Im&primir", null, m_imprimir_Click);
            m_salvarcomo = new ToolStripMenuItem("Salvar como ...", null, m_salvarcomo_Click);
            m_sep4 = new ToolStripSeparator();
            m_salir = new ToolStripMenuItem("&Salir", null, m_salir_Click);

            m_operaciones.DropDownItems.AddRange(new ToolStripItem[]
            {
                m_confirmar, m_cancelar, m_sep1,
                m_insertar, m_borrar, m_sep2,
                m_iniciarconsulta, m_procesar, m_sep3,
                m_preliminar, m_imprimir, m_salvarcomo,
                m_sep4, m_salir
            });

            m_navegacion = new ToolStripMenuItem("&Navegacion");
            m_primerregistro = new ToolStripMenuItem("Primer Registro", null, m_primerregistro_Click);
            m_siguienteregistro = new ToolStripMenuItem("Siguiente Registro", null, m_siguienteregistro_Click);
            m_anteriorregistro = new ToolStripMenuItem("Anterior Registro", null, m_anteriorregistro_Click);
            m_ultimoregistro = new ToolStripMenuItem("Ultimo Registro", null, m_ultimoregistro_Click);

            m_navegacion.DropDownItems.AddRange(new ToolStripItem[]
            {
                m_primerregistro, m_siguienteregistro, m_anteriorregistro, m_ultimoregistro
            });

            m_ventanas = new ToolStripMenuItem("&Ventanas");
            m_layer = new ToolStripMenuItem("Layer", null, m_layer_Click);
            m_mosaico = new ToolStripMenuItem("Mosaico", null, m_mosaico_Click);
            m_cascada = new ToolStripMenuItem("Cascada", null, m_cascada_Click);

            m_ventanas.DropDownItems.AddRange(new ToolStripItem[]
            {
                m_layer, m_mosaico, m_cascada
            });

            m_ayuda = new ToolStripMenuItem("&Ayuda");
            m_acercade = new ToolStripMenuItem("Acerca de ...", null, m_acercade_Click);
            m_ayuda.DropDownItems.Add(m_acercade);

            this.Items.AddRange(new ToolStripItem[]
            {
                m_operaciones,
                m_navegacion,
                m_ventanas,
                m_ayuda
            });
        }
    }
}
