using Minotti.Data;
using Minotti.Views.Basicos;
using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti.Views.Repertorizaciones.Controls
{
    /// <summary>
    /// Migrado desde PB Window 'w_reperto_anterior_multiple_lista' (deriva de w_reporte).
    /// Se preservan nombres y se integra la lógica visible (sin inventar).
    /// </summary>
    public partial class w_reperto_anterior_multiple_lista : w_operacion
    {
        public w_reperto_anterior_multiple_lista()
        {
            InitializeComponent();
        }

        // =========================
        // PB: create
        // =========================
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        // =========================
        // PB: ue_leer_parametros
        // =========================
        public override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            /*
             * DataObject correspondiente a:
             * w_reperto_anterior_multiple_lista.srw
             */
            dw_1.uof_setdataobject("dk_reperto_anterior_multiple_lista");
            dw_1.SetTransObject(SQLCA.Instance);

            // Multiple selección (PB)
            dw_1.uof_marcar_seleccion(1);

            dw_1.Border = true;
            dw_1.BorderStyle = BorderStyle.Fixed3D;

            // Cantidad visible de filas
            dw_1.cant_filas = 5;
        }

        // =========================
        // PB: ue_iniciar
        // =========================
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            // Retrieve sin parámetros (igual PB)
            dw_1.uof_retrieve();
        }

        // =========================
        // PB: close / destroy
        // =========================
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
        }
    }
}