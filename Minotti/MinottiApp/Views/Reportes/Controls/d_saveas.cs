using Minotti.Views.Basicos.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Views.Reportes.Controls
{
    // DataObject PB: d_saveas
    public class d_saveas : uo_dw
    {
        public d_saveas()
        {
            // DataWindow sin retrieve SQL
            uof_setdataobject("d_saveas");
        }
    }
}
