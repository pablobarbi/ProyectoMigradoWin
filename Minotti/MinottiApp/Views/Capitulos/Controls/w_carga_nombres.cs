using Minotti.Views.Basicos;
using System.Windows.Forms;

namespace Minotti.Views.Capitulos.Controls
{
    public partial class w_carga_nombres : w_carga
    {
        public w_carga_nombres()
        {
            InitializeComponent();
        }

        // =====================================================
        // PB: event ue_continuar  (ANCESTOR SCRIPT OVERRIDE)
        // =====================================================
        public override void ue_continuar()
        {
            // IF dw_1.AcceptText() < 0 THEN RETURN
            if (dw_1.AcceptText() < 0)
                return;

            // ls_nombre = dw_1.GetItemString(1, 'nombre')
            string ls_nombre = dw_1.GetItemString(1, "nombre");

            // IF Trim(ls_nombre) = '' OR IsNull(ls_nombre) THEN ...
            if (ls_nombre == null || string.IsNullOrWhiteSpace(ls_nombre.Trim()))
            {
                // MessageBox("Carga", "Es obligatorio ingresar la descripción", StopSign!,Ok!)
                MessageBox.Show(
                    "Es obligatorio ingresar la descripción",
                    "Carga",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                return;
            }

            // astr_w_seleccion.opcion = 1
            astr_w_seleccion.opcion = 1;

            /*
               Obtengo los valores de:
               1) si es un objeto uo_dw devuelve los valores de los campos clave
               2) si es un objeto uo_dw_filtro devuelve los valores de todos los campos
            */
            dw_1.uof_getargumentos(astr_w_seleccion.s_det, dw_1.GetRow());

            // Close(This)
            Close();
        }
    }
}
