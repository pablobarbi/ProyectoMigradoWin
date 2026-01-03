using Minotti.Structures;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minotti.utils
{
    public static class PBUtils
    {
        /// <summary>
        /// Emula IsNull de PowerBuilder.
        /// Retorna true si el valor es null o DBNull.
        /// </summary>
        public static bool IsNull(object? value)
        {
            return value == null || value == DBNull.Value;
        }

        /// <summary>
        /// PowerBuilder compatible: IsNumber()
        /// Retorna true si el string es numérico.
        /// </summary>
        public static bool IsNumber(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            // PB acepta coma o punto según locale
            return double.TryParse(
                value,
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out _
            )
            || double.TryParse(
                value,
                NumberStyles.Any,
                CultureInfo.CurrentCulture,
                out _
            );
        }


        /// <summary>
        /// PowerBuilder: SetPointer(Hourglass!)
        /// </summary>
        public static void SetPointerHourglass()
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        /// <summary>
        /// PowerBuilder: SetPointer(Arrow!)
        /// </summary>
        public static void SetPointerArrow()
        {
            Cursor.Current = Cursors.Default;
        }

        public static void SetPointer(Pointer p)
        {
            switch (p)
            {
                case Pointer.HourGlass:
                    SetPointerHourglass();
                    break;

                case Pointer.Busy:
                    Cursor.Current = Cursors.AppStarting;
                    break;

                case Pointer.Arrow:
                default:
                    SetPointerArrow();
                    break;
            }
        }

        public static int UpperBound(System.Collections.ICollection? col)
        {
            if (col == null)
                return 0;

            return col.Count;
        }

    }
}

