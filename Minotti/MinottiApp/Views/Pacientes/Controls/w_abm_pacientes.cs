using Minotti.Data;
using Minotti.utils;
using Minotti.Views.Abm.Controls;
using Minotti.Views.Reportes.Controls;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Pacientes.Controls
{

    public partial class w_abm_pacientes : w_abm_detalle
    {
        public w_abm_pacientes()
        {
            InitializeComponent();
        }

        // =====================================================
        // PB: event ue_confirmar (ANCESTOR SCRIPT OVERRIDE)
        // =====================================================
        public override void ue_confirmar()
        {
            long ll_Paciente;

            // PB: IF dw_1.Update(TRUE, FALSE) <> 1 Then ib_grabar = FALSE
            if (dw_1.Update(true, false) != 1)
            {
                this.ib_grabar = false;
            }

            ll_Paciente = (long)dw_1.GetItemNumber(1, "paciente");
            if (dw_1.IsNull(1, "paciente"))
            {
                MessageBox.Show(
                    "Error Guardando Pacientes",
                    "Guardando",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                this.ib_grabar = false;
                return;
            }

            if (ib_grabar && at_op.Accion == "A")
            {
                // PB:
                // INSERT INTO pacientes_historias ( paciente )
                //       VALUES ( :ll_Paciente )
                //       USING SQLCA;

                SQLCA.ExecuteNonQuery(
                    "INSERT INTO pacientes_historias ( paciente ) VALUES ( ? )",
                    cmd => SQLCA.AddParam(cmd, ll_Paciente)
                );

                if (SQLCA.SqlCode < 0)
                {
                    MessageBox.Show(
                        "Error Guardando Historia Inicial del Paciente",
                        "Guardando",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);

                    this.ib_grabar = false;
                    return;
                }

                // PB:
                // INSERT INTO diagnosticos ( paciente, diagnostico )
                //       VALUES ( :ll_Paciente, 1 )
                //       USING SQLCA;

                SQLCA.ExecuteNonQuery(
                    "INSERT INTO diagnosticos ( paciente, diagnostico ) VALUES ( ?, 1 )",
                    cmd => SQLCA.AddParam(cmd, ll_Paciente)
                );

                if (SQLCA.SqlCode < 0)
                {
                    MessageBox.Show(
                        "Error Guardando Diagnóstico Inicial del Paciente",
                        "Guardando",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);

                    this.ib_grabar = false;
                    return;
                }
            }
        }

        // =====================================================
        // PB: event ue_validar_datos
        // =====================================================
        public override void ue_validar_datos()
        {
            base.ue_validar_datos();

            string? ls_Nombre;
            string? ls_NombreOriginal;
            long ll_Cnt;

            ls_Nombre = dw_1.GetItemString(1, "nombre");
            ls_NombreOriginal = dw_1.GetItemString(1, "nombre", DataWindowBuffer.Primary, true);

            // PB:
            // SELECT COUNT(*)
            //    INTO :ll_Cnt
            //    FROM pacientes
            // WHERE nombre = :ls_Nombre
            // USING SQLCA;

            ll_Cnt = SQLCA.ExecuteScalarLong(
                "SELECT COUNT(*) FROM pacientes WHERE nombre = ?",
                cmd => SQLCA.AddParam(cmd, ls_Nombre)
            );

            if (ll_Cnt > 0 && at_op.Accion == "A")
            {
                MessageBox.Show(
                    "Ya existe un paciente con el mismo nombre.",
                    "Error Insertando",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ib_grabar = false;
                return;
            }
            else
            {
                ib_grabar = true;
            }

            if (ll_Cnt > 0 && at_op.Accion == "M" && (ls_NombreOriginal != ls_Nombre))
            {
                MessageBox.Show(
                    "Ya existe un paciente con el mismo nombre.",
                    "Error Actualizando",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ib_grabar = false;
                return;
            }
            else
            {
                ib_grabar = true;
                return;
            }
        }

        // =====================================================
        // PB: event ue_iniciar
        // =====================================================
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            // PB: Datawindowchild dwchild
            // dw_1.Getchild('nombre', dwchild)
            // dwchild.settransobject(sqlca)
            // dwchild.retrieve()

            datawindowchild dwchild;
            dw_1.GetChild("nombre", out dwchild);
            dwchild.SetTransObject(SQLCA.Instance);
            dwchild.Retrieve();

            dw_1.SetFocus();
            this.SetFocus();
        }

        // =====================================================
        // PB: event ue_reiniciar
        // =====================================================
        public override void ue_reiniciar()
        {
            base.ue_reiniciar();
            this.SetFocus();
        }
    }
}