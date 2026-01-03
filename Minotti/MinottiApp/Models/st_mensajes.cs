using System;

namespace Minotti.Models
{
    // Migración de PowerBuilder: st_mensajes.srs (structure)
    // Se mantienen los nombres de los campos tal cual.
    public class st_mensajes
    {
        public string confirmar { get; set; } = string.Empty;
        public string borrar { get; set; } = string.Empty;
        public string cancelar { get; set; } = string.Empty;
    }
}
