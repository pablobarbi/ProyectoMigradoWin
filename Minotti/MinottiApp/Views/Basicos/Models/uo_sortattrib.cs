using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Views.Basicos.Models
{
    /// <summary>
    /// Equivalente a uo_sortattrib (nonvisualobject autoinstantiate).
    /// Guarda atributos de ordenamiento de una DW.
    /// </summary>
    public class uo_sortattrib
    {
        // is_sort
        public string is_sort { get; set; } = string.Empty;

        // is_sortcolumns[]
        public string[] is_sortcolumns { get; set; } = System.Array.Empty<string>();

        // is_colnamedisplay[]
        public string[] is_colnamedisplay { get; set; } = System.Array.Empty<string>();

        // ib_usedisplay[]
        public bool[] ib_usedisplay { get; set; } = System.Array.Empty<bool>();

        // is_origcolumns[]
        public string[] is_origcolumns { get; set; } = System.Array.Empty<string>();

        // is_origorder[]
        public string[] is_origorder { get; set; } = System.Array.Empty<string>();

        // En PB tenía constructor/destructor, acá no hace falta nada especial.
        public uo_sortattrib()
        {
        }
    }
}
