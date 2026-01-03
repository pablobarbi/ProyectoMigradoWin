using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Views.Basicos.Models
{
    /// <summary>
    /// Equivalente PowerBuilder: cat_valor_inicial (nonvisualobject autoinstantiate)
    /// </summary>
    public class cat_valor_inicial
    {
        // String campo
        public string campo { get; set; } = string.Empty;

        // String valor_inicial
        public string valor_inicial { get; set; } = string.Empty;

        public cat_valor_inicial()
        {
        }
    }
}
