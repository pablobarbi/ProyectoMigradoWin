using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Structures
{
    public class st_detalle
    {
        public string Accion { get; set; } = "";
        public bool Alta { get; set; }
        public bool Modificacion { get; set; }
        public bool Baja { get; set; }

        public string[] s_det { get; set; } = new string[50];  // según PB
    }

}
