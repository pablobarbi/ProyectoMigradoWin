using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.utils
{
    public class ContextInformation
    {
        // PB: GetMajorVersion
        public void GetMajorVersion(out int majorVersion)
        {
            // PB usaba esto para diferenciar runtime viejo/nuevo.
            // En .NET siempre usamos íconos modernos (bmp/png).
            majorVersion = 10;
        }
    }
}
