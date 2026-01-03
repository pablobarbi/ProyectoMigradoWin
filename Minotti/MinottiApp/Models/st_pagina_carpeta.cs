using System;

namespace Minotti.Models
{
    // Migración de PowerBuilder: st_pagina_carpeta.srs (structure)
    // Se mantienen los nombres de los campos tal cual.
    public class st_pagina_carpeta
    {
        public string titulo { get; set; } = string.Empty;
        public string bitmap { get; set; } = string.Empty;
        public string parametros { get; set; } = string.Empty;
    }
}
