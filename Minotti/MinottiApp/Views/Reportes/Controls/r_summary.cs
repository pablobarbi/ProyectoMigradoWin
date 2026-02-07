using Minotti.Data;
using Minotti.Metadata.GeneratedSru;

namespace Minotti.Views.Reportes.Controls
{
    public class r_summary : uo_dw
    {
        public r_summary()
        {
            // Carga definición del reporte
            uof_setdataobject("r_summary");

            // Si el reporte tiene retrieve SQL, debe usar SQLCA
            SetTransObject(SQLCA.Instance);
        }
    }
}
