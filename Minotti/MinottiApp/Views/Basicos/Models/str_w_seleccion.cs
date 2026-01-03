using System;

namespace Minotti.Views.Basicos.Models
{
    public class str_w_seleccion
    {
        public int opcion;
        public string titulo;
        public string[] parametros = Array.Empty<string>();
        public string[] s_det = Array.Empty<string>();
        // PB compatibility (PB was case-insensitive)
        public int Opcion
        {
            get => opcion;
            set => opcion = value;
        }
        public string Titulo
        {
            get => titulo;
            set => titulo = value;
        }

        
    }
}
