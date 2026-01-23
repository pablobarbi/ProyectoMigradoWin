// -----------------------------------------------------------------------------
// AUTO-MIGRADO desde PowerBuilder (.sru)
// Origen: uo_sortattrib
// -----------------------------------------------------------------------------

#nullable enable
using MinottiApp.utils;

namespace Minotti.Metadata.GeneratedSru
{
    public class uo_sortattrib : nonvisualobject
    {
        // ---------------------------------------------------------------------
        // VARIABLES (PB: type variables Public:)
        // ---------------------------------------------------------------------

        public string? is_sort;

        public string[] is_sortcolumns = System.Array.Empty<string>();
        public string[] is_colnamedisplay = System.Array.Empty<string>();
        public bool[] ib_usedisplay = System.Array.Empty<bool>();
        public string[] is_origcolumns = System.Array.Empty<string>();
        public string[] is_origorder = System.Array.Empty<string>();

        // ---------------------------------------------------------------------
        // CREATE / DESTROY (PB compatibility)
        // ---------------------------------------------------------------------

        public override void create()
        {
            // PB:
            // on uo_sortattrib.create
            // TriggerEvent( this, "constructor" )
            TriggerEvent(this, "constructor");
        }

        public override void destroy()
        {
            // PB:
            // on uo_sortattrib.destroy
            // TriggerEvent( this, "destructor" )
            TriggerEvent(this, "destructor");
        }
    }
}
