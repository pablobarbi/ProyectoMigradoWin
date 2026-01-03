using System;

namespace Minotti.Models
{
    // Migración de PowerBuilder: uo_sortattrib.sru (nonvisualobject, autoinstantiate)
    // Se mantienen los nombres de los miembros.
    public class uo_sortattrib
    {
        // Public:
        public string is_sort { get; set; } = string.Empty;
        public string[] is_sortcolumns { get; set; } = Array.Empty<string>();
        public string[] is_colnamedisplay { get; set; } = Array.Empty<string>();
        public bool[] ib_usedisplay { get; set; } = Array.Empty<bool>();
        public string[] is_origcolumns { get; set; } = Array.Empty<string>();
        public string[] is_origorder { get; set; } = Array.Empty<string>();
    }
}
