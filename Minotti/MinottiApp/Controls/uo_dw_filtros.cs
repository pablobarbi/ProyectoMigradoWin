using System.Windows.Forms;

namespace Minotti.Controls
{
    // Migración de PowerBuilder: uo_dw_filtros.sru (deriva de uo_dw)
    // Se mantiene el nombre del tipo: uo_dw_filtros
    public partial class uo_dw_filtros : uo_dw
    {
        public uo_dw_filtros()
        {
            InitializeComponent();
        }

        // Firma original: public function boolean uof_getargumentos (ref string parametros[], integer fila)
        public bool uof_getargumentos(ref string[] parametros, int fila)
        {
            // PB: "Return(uof_GetRegistro(parametros[], fila))"
            return uof_getregistro(ref parametros, fila);
        }
    }
}
