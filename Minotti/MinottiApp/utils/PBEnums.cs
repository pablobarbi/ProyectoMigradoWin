using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.utils
{
    public enum RowMoveType
    {
        Begin,
        End,
        Next,
        Prior,
        Same,
        Delete,   // ← requerido ahora
        Insert,   // ← PB lo usa en RowFocus
        First,    // ← opcional PB
        Last      // ← opcional PB
    }

}
