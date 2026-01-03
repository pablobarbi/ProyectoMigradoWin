using System;

namespace Minotti.Models
{
    // Migración de PowerBuilder: stp_w_seleccion.srs (structure)
    // Se mantienen los nombres de los campos tal cual.
    public class stp_w_seleccion
    {
        public string titulo { get; set; } = string.Empty;
        public string objeto { get; set; } = string.Empty;
        public string dataobject { get; set; } = string.Empty;
        public int cant_filas { get; set; } = 0;
        public string parametros { get; set; } = string.Empty;
        public string mensaje { get; set; } = string.Empty;
        public int fila_default { get; set; } = 0;
    }
}
