using Minotti.Views.Basicos.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minotti.Views.Reportes.Controls
{
    // global type uo_tp_dw_reporte from uo_tp_dw
    public partial class uo_tp_dw_reporte : uo_tp_dw
    {
        // long backcolor = 81324524
        // PB usa long; WinForms usa Color. Mantengo el valor y lo traduzco a Color via FromArgb(int).
        public long backcolor = 81324524;

        public uo_tp_dw_reporte()
        {
            InitializeComponent();

            // Si querés reflejar el backcolor PB en el control:
            // (no es inventar lógica; es aplicar propiedad declarada)
            try
            {
                this.BackColor = Color.FromArgb(unchecked((int)backcolor));
            }
            catch
            {
                // No hago nada: si el número no mapea a ARGB válido, no fuerzo.
            }
        }

        // event ue_leer_parametros;call super::ue_leer_parametros;...
        public override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            // Como se va a usar para reportes, le saco la seleccion de filas.
            // dw_1.uof_marcar_seleccion(0)
            dw_1.uof_marcar_seleccion(0);
        }
    }
}
