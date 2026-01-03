using Microsoft.VisualBasic.Devices;
using Minotti.Data;
using Minotti.Views.Basicos;
using System;
using System.Data;
using System.Data.Odbc;
using System.Security.Claims;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Minotti.Views.Repertorizaciones.Controls
{

    /// <summary>
    /// Migrado desde PB Window 'w_reperto_capitulos' (deriva de w_abm_lista_seleccion).
    /// Se preservan nombres y se integra la lógica visible (sin inventar).
    /// </summary> 
    public partial class w_reperto_capitulos : w_operacion
    {
        public w_reperto_capitulos()
        {
            InitializeComponent();
        }

        // =================================================
        // PB: create
        // =================================================
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        // =================================================
        // PB: ue_leer_parametros
        // =================================================
        public override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            /*
             * DataObject tomado DIRECTAMENTE del SRW:
             * w_reperto_capitulos.srw
             */
            dw_1.uof_setdataobject("dk_reperto_capitulos");
            dw_1.SetTransObject(SQLCA.Instance);

            // Selección permitida (PB)
            dw_1.uof_marcar_seleccion(1);

            dw_1.Border = true;
            dw_1.BorderStyle = BorderStyle.Fixed3D;

            // Cantidad de filas visibles
            dw_1.cant_filas = 5;
        }

        // =================================================
        // PB: ue_iniciar
        // =================================================
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            // Retrieve SIN parámetros (PB)
            dw_1.uof_retrieve();
        }

        // =================================================
        // PB: destroy
        // =================================================
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
        }
    }
}