using Minotti.Data;
using Minotti.Views.Basicos;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Repertorizaciones.Controls
{
    /// <summary>
    /// Migrado desde PB Window 'w_ver_reperto_multiple' (deriva de w_carga).
    /// Se preservan nombres y el patrón transaccional/mensajes visibles sin inventar SQL.
    /// </summary>
    public partial class w_ver_reperto_multiple : w_operacion
    {
        public w_ver_reperto_multiple()
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
             * DataObject según w_ver_reperto_multiple.srw
             */
            dw_1.uof_setdataobject("dk_ver_reperto_multiple");
            dw_1.SetTransObject(SQLCA.Instance);

            dw_1.uof_marcar_seleccion(1);

            dw_1.Border = true;
            dw_1.BorderStyle = BorderStyle.Fixed3D;

            dw_1.cant_filas = 10;
        }

        // =================================================
        // PB: ue_iniciar
        // =================================================
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            // Retrieve sin parámetros (igual PB)
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