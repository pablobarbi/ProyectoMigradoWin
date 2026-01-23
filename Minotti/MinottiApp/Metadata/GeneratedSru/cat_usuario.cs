using System;
using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    /// <summary>
    /// PB:
    /// $PBExportComments$
    /// Clase con los datos de un usuario.
    /// </summary>
    public class cat_usuario : nonvisualobject
    {
        // === VARIABLES (type variables) ===
        // Public:

        public string Usuario;
        public string Nombre;
        public string Perfil;
        public DateTime Fecha_Coneccion;

        // ==== CONSTRUCTOR (event constructor) ====
        public override void constructor()
        {
            // PB: sin lógica
        }

        // ==== DESTRUCTOR (event destructor) ====
        public override void destructor()
        {
            // PB: sin lógica
        }

        // ==== PB: on create ====
        public cat_usuario()
        {
            // PB:
            // TriggerEvent( this, "constructor" )
            constructor();
        }

        // ==== PB: on destroy ====
        public void destroy()
        {
            // PB:
            // TriggerEvent( this, "destructor" )
            destructor();
        }
    }
}
