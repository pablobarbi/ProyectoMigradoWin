using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Views.Basicos.Models
{
    /// <summary>
    /// Equivalente PowerBuilder: cat_response (nonvisualobject autoinstantiate)
    /// </summary>
    public class cat_response
    {
        // integer retorno  
        // valor de retorno a la ventana que la llamó 
        // (1 eligió algo, -1 si no eligió nada)
        public int retorno { get; set; }

        public cat_response()
        {
        }
    }
}
