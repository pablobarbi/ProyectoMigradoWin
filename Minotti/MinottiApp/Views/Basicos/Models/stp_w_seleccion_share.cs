using Minotti.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Views.Basicos.Models
{
    public class stp_w_seleccion_share
    {
        // string  titulo
        public string titulo { get; set; } = string.Empty;

        // string  objeto
        public string objeto { get; set; } = string.Empty;

        // string  dataobject
        public string dataobject { get; set; } = string.Empty;

        // integer cant_filas
        public int cant_filas { get; set; }

        // powerobject dw_share  -> lo dejamos como object genérico
        public datawindow? dw_share { get; set; }

        // string  mensaje
        public string mensaje { get; set; } = string.Empty;

    }
}
