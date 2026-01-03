using System;

namespace Minotti.Views.Basicos.Models
{
    // Migración de PowerBuilder: cat_columna.sru (nonvisualobject, autoinstantiate)
    // Se mantienen los nombres de tipo y miembros tal cual.
    public class cat_columna 
    {
        public string Nombre { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public bool Filtro { get; set; } = false;
        public bool Requerido { get; set; } = false;
        public string Estilo { get; set; } = string.Empty;
        public string TabOrder { get; set; } = string.Empty;
        public string Objeto_seleccion { get; set; } = string.Empty;
        public string Operacion { get; set; } = string.Empty;
        public string Nivel_operacion { get; set; } = string.Empty;

       
    }
}
