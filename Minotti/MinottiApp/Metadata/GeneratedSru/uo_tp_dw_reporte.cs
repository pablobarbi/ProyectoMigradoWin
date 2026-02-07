namespace Minotti.Metadata.GeneratedSru
{
    public partial class uo_tp_dw_reporte : uo_tp_dw
    {
        // PB: long backcolor = 81324524
        public long backcolor = 81324524;

        // Constructor .NET (equivalente al create implícito)
        public uo_tp_dw_reporte()
        {
            InitializeComponent();
        }

        // on uo_tp_dw_reporte.create
        public override void create()
        {
            base.create();
        }

        // on uo_tp_dw_reporte.destroy
        public override void Destroy()
        {
            base.Destroy();
        }

        // event ue_leer_parametros
        public override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            // Como se va a usar para reportes, le saco la seleccion de filas.
            dw_1.uof_marcar_seleccion(0);
        }
    }
}
