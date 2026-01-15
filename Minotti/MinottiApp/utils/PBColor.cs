using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.utils
{
    public static class PBColor
    {
        /// <summary>
        /// Convierte un color PowerBuilder (OLE_COLOR / long) a System.Drawing.Color.
        ///
        /// En PB es común encontrar LONGs con alpha/flags (ej: 0x40FFFFFF) que en WinForms
        /// pueden disparar "transparent background" si se usan directo con FromArgb(int).
        /// Para mantener compatibilidad, ignoramos el byte alto y tomamos solo RGB (24 bits).
        /// </summary>
        public static Color FromPB(int pbColor)
        {
            // Fuerza unsigned para no romper con valores negativos.
            uint rgb = (uint)pbColor & 0x00FFFFFFu;

            int r = (int)(rgb & 0xFF);
            int g = (int)((rgb >> 8) & 0xFF);
            int b = (int)((rgb >> 16) & 0xFF);

            return Color.FromArgb(r, g, b);
        }

        public static Color FromPB(long pbColor)
            => FromPB(unchecked((int)pbColor));
    }

}
