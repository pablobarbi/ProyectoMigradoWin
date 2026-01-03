using Minotti.Data;
using Minotti.Views.Basicos.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Views.Reportes.Controls
{
    public class r_summary : uo_dw
    {
        public r_summary()
        {
            // Carga definición del reporte
            uof_setdataobject("r_summary");

            // Si el reporte tiene retrieve SQL, debe usar SQLCA
            SetTransObject(SQLCA.Instance);
        }
    }
}
