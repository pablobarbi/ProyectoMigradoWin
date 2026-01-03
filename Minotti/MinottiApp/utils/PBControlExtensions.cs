using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minotti.utils
{
    public static class PBControlExtensions
    {
        // PB: control.X
        public static int X(this Control c) => c.Left;

        // PB: control.Y
        public static int Y(this Control c) => c.Top;

        // PB: control.X = ...
        public static void X(this Control c, int value) => c.Left = value;

        // PB: control.Y = ...
        public static void Y(this Control c, int value) => c.Top = value;
    }
}
