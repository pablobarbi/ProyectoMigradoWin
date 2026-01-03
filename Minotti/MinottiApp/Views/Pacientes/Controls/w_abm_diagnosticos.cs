using Minotti.Data;
using Minotti.Views.Abm.Controls;
using Minotti.Views.Basicos.Controls;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Pacientes.Controls
{
    public partial class w_abm_diagnosticos : w_abm_detalle
    {
        public w_abm_diagnosticos()
        {
            InitializeComponent();
        }

        // =====================================================
        // PB: event ue_validar_datos (ANCESTOR SCRIPT OVERRIDE)
        // =====================================================
        public override void ue_validar_datos()
        {
            // PB: Long ll_Datos
            long ll_Datos;

            ll_Datos = (long)dw_1.GetItemNumber(1, "paciente");
            if (dw_1.IsNull(1, "paciente"))
            {
                MessageBox.Show(
                    "Debe ingresar un paciente para el diagnóstico.",
                    "Validar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                ib_grabar = false;
                return;
            }

            // Comentado en PB -> lo dejo comentado igual, no invento:
            // ls_Datos = dw_1.GetItemString( 1, 'descripcion')
            // IF IsNull(ls_Datos) OR ls_Datos = '' THEN ...
        }

        // =====================================================
        // PB: event ue_dw_itemchanged
        // =====================================================
        public override int ue_dw_itemchanged(uo_dw dwo, long row, int column, string data)

        {
            long cnt;
            long paciente;

            if ((string?)dwo.Name == "paciente")
            {
                // paciente = Long(data)
                paciente = Convert.ToInt64(data);

                // PB:
                // SELECT count(*)
                //   INTO :cnt
                //   FROM diagnosticos
                //  WHERE paciente = :paciente
                //  USING SQLCA;

                const string sql = @"
SELECT count(*)
  FROM diagnosticos
 WHERE paciente = ?";

                cnt = SQLCA.ExecuteScalarLong(sql, cmd =>
                {
                    SQLCA.AddParam(cmd, paciente);
                });

                if (cnt == 0)
                    cnt = 1;
                else
                    cnt++;

                dw_1.SetItem(1, "diagnostico", cnt);
            }

            // PB: RETURN 0
            return 0;
        }

        // =====================================================
        // PB: event ue_iniciar
        // =====================================================
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            // PB: Date ld_hoy
            if (at_op.Accion == "A")
            {
                var ld_hoy = DateTime.Today;
                dw_1.SetItem(1, "fecha_visita", ld_hoy);
            }
        }
    }
}