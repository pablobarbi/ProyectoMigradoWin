using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Views.Basicos.Models
{
    /// <summary>
    /// Equivalente PowerBuilder: cat_usuario (nonvisualobject autoinstantiate)
    /// </summary>
    public class cat_usuario
    {
        // string Usuario
        public string Usuario { get; set; } = string.Empty;

        // string Nombre
        public string Nombre { get; set; } = string.Empty;

        // string Perfil
        public string Perfil { get; set; } = string.Empty;

        // datetime Fecha_Coneccion
        public DateTime Fecha_Coneccion { get; set; }

        public cat_usuario()
        {
        }
    }
}
