using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Structures
{
    public class st_at_det
    {
        public string Accion { get; set; } = "";
        public bool Alta { get; set; }
        public bool Baja { get; set; }
        public bool Modificacion { get; set; }

        // En PB: string array
        public string[] s_det { get; set; } = Array.Empty<string>();
    }

}
