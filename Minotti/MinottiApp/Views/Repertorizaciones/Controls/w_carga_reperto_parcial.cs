using Minotti.Data;
using Minotti.Repositories;
using Minotti.utils;
using Minotti.Views.Basicos;
using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti.Views.Repertorizaciones.Controls
{
    /// <summary>
    /// Migrado desde PowerBuilder Window 'w_carga_reperto_parcial' (deriva de w_carga).
    /// Se preservan nombres de controles y eventos. LÓGICA integrada únicamente donde está explícita en SRW.
    /// </summary>
    public partial class w_carga_reperto_parcial : w_carga
    {
        public w_carga_reperto_parcial()
        {
            InitializeComponent();
        }

        // PB: event ue_continuar
        public override void ue_continuar()
        {
            /*
                ATENCION !!! ANCESTOR SCRIPT OVERRIDE
            */

            long ll_capitulo;
            long ll_rubrica;
            long ll_subrubrica;
            long ll_valor;
            string ls_medicamento;

            if (dw_1.AcceptText() < 0)
                return;

            ll_capitulo = (long)dw_1.GetItemNumber(1, "capitulo");
            ll_rubrica = (long)dw_1.GetItemNumber(1, "rubrica");
            ll_subrubrica = (long)dw_1.GetItemNumber(1, "subrubrica");
            ls_medicamento = dw_1.GetItemString(1, "medicamento");
            ll_valor = (long)dw_1.GetItemNumber(1, "valor");

            if (PBUtils.IsNull(ll_capitulo) ||
                PBUtils.IsNull(ll_rubrica) ||
                PBUtils.IsNull(ll_subrubrica) ||
                PBUtils.IsNull(ls_medicamento) ||
                PBUtils.IsNull(ll_valor))
            {
                MessageBox.Show(
                    "Es obligatorio completar todos los datos",
                    "Carga",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return;
            }

            w_carga_reperto_parcial_dal.InsertRepertoParcial(
                ll_capitulo,
                ll_rubrica,
                ll_subrubrica,
                ls_medicamento,
                ll_valor
            );

            if (SQLCA.SqlCode < 0)
            {
                MessageBox.Show(
                    "Error grabando el repertorio parcial",
                    "Carga",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return;
            }

            Close();
        }
    }
}