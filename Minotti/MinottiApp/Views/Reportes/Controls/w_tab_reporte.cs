using Minotti.Views.Basicos;

namespace Minotti.Views.Reportes.Controls
{
    // global type w_tab_reporte from w_tab
    public partial class w_tab_reporte : w_tab
    {
        // long backcolor = 81324524
        public long backcolor = 81324524;

        public w_tab_reporte()
        {
            InitializeComponent();
        }

        // event ue_leer_parametros(); call super::ue_leer_parametros;
        // /* La unica accion permitida para esta ventana es la consulta de datos */
        // is_Accion = 'C'
        public override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            // En PB es char 'C'. Mantengo el mismo valor.
            is_Accion = "C";
        }
    }
}