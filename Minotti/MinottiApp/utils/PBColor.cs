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
        /// Convierte un color PB (OLE_COLOR / int) a System.Drawing.Color
        /// </summary>
        public static Color FromPB(int pbColor)
        {
            int b = (pbColor >> 16) & 0xFF;
            int g = (pbColor >> 8) & 0xFF;
            int r = pbColor & 0xFF;

            return Color.FromArgb(r, g, b);
        }
    }

}
