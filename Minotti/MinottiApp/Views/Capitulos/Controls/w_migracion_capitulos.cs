
using Minotti.Data;
using Minotti.Views.Basicos;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Capitulos.Controls
{

    public partial class w_migracion_capitulos : w_operacion
    {
        // PB: integer nivel_actual
        private int nivel_actual;

        public w_migracion_capitulos()
        {
            InitializeComponent();

            // En PB: create llama a super::create y luego crea dw_1..dw_3
            // En WinForms, InitializeComponent ya instancia los controles del designer.
            // Solo dejamos el ciclo de vida equivalente.
            this.Load += (_, _) =>
            {
                // Si tu framework llama ue_leer_parametros/ue_iniciar desde w_operacion, esto no hace falta.
                // Pero no invento: dejo solo wiring suave.
            };

            this.FormClosed += (_, _) =>
            {
                // PB: destroy -> destroy(dw_3/dw_2/dw_1)
                // En WinForms, Dispose lo maneja el designer.
            };
        }

        // =====================================================
        // PB: event ue_leer_parametros
        // =====================================================
        public override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            /* CAPITULOS */
            dw_1.uof_setdataobject("dk_capitulos");
            dw_1.SetTransObject(SQLCA.Instance);
            dw_1.uof_marcar_seleccion(1);
            dw_1.Border = true;
            dw_1.BorderStyle = BorderStyle.Fixed3D; // PB: StyleLowered!
            dw_1.cant_filas = 5;

            /* CAPITULACIONES */
            dw_2.uof_setdataobject("dk_rubricas_del_capitulo");
            dw_2.SetTransObject(SQLCA.Instance);
            dw_2.uof_marcar_seleccion(1);
            dw_2.Border = true;
            dw_2.BorderStyle = BorderStyle.Fixed3D;
            dw_2.cant_filas = 5;

            /* RUBRICACIONES */
            dw_3.uof_setdataobject("dk_subrubricas_de_la_rubrica");
            dw_3.SetTransObject(SQLCA.Instance);
            dw_3.uof_marcar_seleccion(1);
            dw_3.Border = true;
            dw_3.BorderStyle = BorderStyle.Fixed3D;
            dw_3.cant_filas = 3;
        }

        // =====================================================
        // PB: event ue_iniciar
        // =====================================================
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            // PB: String ls_Param[]
            // PB: dw_1.uof_retrieve(ls_Param)
            string[] ls_Param = Array.Empty<string>();
            dw_1.uof_retrieve(ls_Param);
        }

        // PB declara eventos ue_cargar_nivel / ue_ejecutar pero no hay script en lo que pegaste.
        // No invento implementaciones. Si me pasás el cuerpo, los migro 1:1.
        protected virtual void ue_cargar_nivel()
        {
            // SIN SCRIPT EN FUENTE PEGADO -> no se implementa.
        }

        protected virtual void ue_ejecutar()
        {
            // SIN SCRIPT EN FUENTE PEGADO -> no se implementa.
        }
    }
}
