using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.Views.Basicos.Models
{
    /// <summary>
    /// Equivalente PowerBuilder: cat_rw_seleccion (nonvisualobject autoinstantiate)
    /// </summary>
    public class cat_rw_seleccion
    {
        /*
         * Var usada para setear la forma en que salió de la ventana
         *   1  -- Se cerró aceptando
         *  -1  -- Se canceló la selección
         */
        public int opcion { get; set; } = -1;

        /*
         * Estructura que contiene las n filas seleccionadas en la dw
         */
        //public cat_s_det[] atr { get; set; } = Array.Empty<cat_s_det>();
        public List<cat_rw_seleccion_det> atr { get; set; } = new();

        public cat_rw_seleccion()
        {
        } 

        // PB: at_nvl[1..n]
        private readonly List<cat_rw_seleccion_nvl> _at_nvl = new();

        public cat_rw_seleccion_nvl GetAtNvl(int index1Based)
        {
            if (index1Based <= 0) throw new ArgumentOutOfRangeException(nameof(index1Based));

            while (_at_nvl.Count < index1Based)
                _at_nvl.Add(new cat_rw_seleccion_nvl());

            return _at_nvl[index1Based - 1];
        }

        public void SetAtNvl(int index1Based, cat_rw_seleccion_nvl value)
        {
            if (index1Based <= 0) throw new ArgumentOutOfRangeException(nameof(index1Based));

            while (_at_nvl.Count < index1Based)
                _at_nvl.Add(new cat_rw_seleccion_nvl());

            _at_nvl[index1Based - 1] = value;
        }


        public class cat_rw_seleccion_nvl
        {
            public string? Objeto { get; set; }
            public string? Titulo { get; set; }
            public string? Parametros { get; set; }
            public string? Cierra { get; set; }
        }







    }

    public class cat_rw_seleccion_det
    {
        // PB: s_det[]
        public string[]? s_det { get; set; }
    }
}
