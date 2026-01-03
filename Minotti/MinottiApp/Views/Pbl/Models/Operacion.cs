using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Views.Pbl.Models
{
    public class Operacion
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Alta { get; set; }
        public bool Baja { get; set; }
        public bool Modificacion { get; set; }
        public string Modulo { get; set; }
        public string TipoOperacion { get; set; } // Renamed from Operacion to TipoOperacion to avoid CS0542
    }
}
