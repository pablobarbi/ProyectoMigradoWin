using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Views.Basicos.Models
{

    /// <summary>
    /// Equivalente PowerBuilder: cat_app (nonvisualobject autoinstantiate)
    /// </summary>
    public class cat_app
    {
        // string Nombre
        public string Nombre { get; set; } = string.Empty;

        // string Version
        public string Version { get; set; } = string.Empty;

        // string Logo
        public string Logo { get; set; } = string.Empty;

        // string Copyright
        public string Copyright { get; set; } = string.Empty;

        // En PB había constructor/destructor con TriggerEvent,
        // acá no hacemos nada extra porque no hay lógica asociada.
        public cat_app()
        {
        }

    }
}
