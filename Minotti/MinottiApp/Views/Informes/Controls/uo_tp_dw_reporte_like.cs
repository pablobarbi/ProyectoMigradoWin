using Minotti.Views.Reportes.Controls;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Informes.Controls
{
    // Migrado desde PowerBuilder UserObject: uo_tp_dw_reporte_like.sru
    // Se conserva el nombre exacto y se adjunta el contenido original como comentario.
    public partial class uo_tp_dw_reporte_like : uo_tp_dw_reporte
    {
        public uo_tp_dw_reporte_like()
        {
            InitializeComponent();
        }

        // =====================================================
        // PB: on create
        // =====================================================
        public virtual void OnCreate() { }

        // =====================================================
        // PB: on destroy
        // =====================================================
        public virtual void OnDestroy() { }


        // =====================================================
        // PB: event ue_leer_parametros
        // =====================================================
        public override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            /*
             PB:
             // Como se va a usar para reportes, le saco la seleccion de filas.
             dw_1.uof_marcar_seleccion(0)
            */

            dw_1.uof_marcar_seleccion(0);
        }
    }

}