
using Minotti.Data;
using Minotti.Functions;
using Minotti.Repositories;
using Minotti.Views.Abm.Controls;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Capitulos.Controls
{
    public partial class w_abm_lista_rubricas : w_abm_lista_seleccion
    {

        // PB: boolean ib_Grabar / ib_grabar
        protected bool ib_Grabar = false;
        protected bool ib_grabar = false;



        protected long il_Capitulo;
        // PB: ib_Grabar (ImageButton)
        
        public w_abm_lista_rubricas()
        {
            InitializeComponent();
        }

        public override void ue_optar()
        {
            base.ue_optar();
            ib_cerrar_al_grabar = false;
        }

        public override void ue_iniciar()
        {
            base.ue_iniciar();

            il_Capitulo = Convert.ToInt64(at_op.s_det[1]);

            if (string.IsNullOrEmpty(Globales.gs_Capitulo))
                st_capitulo.Text = "sin capitulo seleccionado";
            else
                st_capitulo.Text = Globales.gs_Capitulo;

            dw_1.Focus();
            if (dw_1.RowCount() > 1)
                dw_1.SetRow(1);

            dw_buscar.Focus();
        }

        public override void ue_ajustar_tamaño()
        {
            base.ue_ajustar_tamaño();
            Height = dw_1.uof_largo()
                   + s_esp.largo
                   + st_capitulo.Height
                   + 5 * s_esp.borde
                   + dw_buscar.uof_largo()
                   + 80;
        }

        public override void ue_acomodar_objetos()
        {
            int largo_dw1 = wf_largo_disponible()
                          - 5 * s_esp.borde
                          - dw_buscar.uof_largo()
                          - st_capitulo.Height
                          - cb_mas_rubrica.Height;

            int ancho_dw1 = wf_ancho_disponible() - 2 * s_esp.borde;

            dw_1.Width = Math.Min(dw_1.uof_ancho(), ancho_dw1);
            dw_1.Height = largo_dw1;
            dw_1.Y = s_esp.borde + st_capitulo.Height + s_esp.borde + cb_mas_rubrica.Height + s_esp.borde;
            wf_centrarobjeto(dw_1);

            st_capitulo.Left = dw_1.Left;
            st_capitulo.Top = s_esp.borde;

            dw_buscar.Width = dw_1.Width;
            dw_buscar.Height = dw_buscar.uof_largo();
            dw_buscar.Left = dw_1.Left;
            dw_buscar.Top = dw_1.Top + dw_1.Height + 2 * s_esp.borde;

            cb_mas_rubrica.Left = dw_1.Left;
            cb_mas_rubrica.Top = s_esp.borde + st_capitulo.Height + s_esp.borde;

            cb_menos_rubrica.Left = cb_mas_rubrica.Left + cb_mas_rubrica.Width + s_esp.borde;
            cb_menos_rubrica.Top = cb_mas_rubrica.Top;

            cb_modif_rubrica.Left = cb_menos_rubrica.Left + cb_menos_rubrica.Width + s_esp.borde;
            cb_modif_rubrica.Top = cb_mas_rubrica.Top;

            cb_medicamentos.Left = cb_modif_rubrica.Left + cb_modif_rubrica.Width + s_esp.borde;
            cb_medicamentos.Top = cb_mas_rubrica.Top;
        }

        public override void ue_cerrar_transaccion()
        {
            if (ib_Grabar)
            {
                SQLCA.Commit();
                if (SQLCA.SqlCode != 0)
                {
                    ib_grabar = false;
                    guo_app.at_error_db.SqlDbCode = SQLCA.SqlDbCode;
                    guo_app.at_error_db.SqlErrText = SQLCA.SqlErrText;
                }
            }

            if (!ib_grabar)
            {
                SQLCA.Rollback();
                f_error_base_de_datos.ferror_base_de_datos();
            }

            SQLCA.AutoCommit = ib_AutoCommit;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Globales.gs_Rubrica = null;
        }
    }
}
