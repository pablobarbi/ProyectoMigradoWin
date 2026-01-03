using Minotti.Views.Abm.Controls;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Pacientes.Controls
{

    public partial class w_medicamentos : w_abm_detalle
    {
        public w_medicamentos()
        {
            InitializeComponent();
        }

        // =====================================================
        // PB: event ue_dw_button_clicked
        // =====================================================
        public override void ue_dw_button_clicked()
        {
            base.ue_dw_button_clicked();

            // PB: string docname, named; integer value
            string docname = string.Empty;

            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = "Seleccionar la imagen asociada al medicamento";
                dlg.Filter =
                    "Archivos de Imagenes (*.JPG)|*.JPG|Archivos de Imagenes (*.BMP)|*.BMP";
                dlg.FilterIndex = 1;
                dlg.Multiselect = false;

                // PB: value = GetFileOpenName(...)
                var result = dlg.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    docname = dlg.FileName;

                    // PB:
                    // dw_1.SetItem(1, "imagen_asociada", docname)
                    // dw_1.object.p_1.Filename = docname
                    dw_1.SetItem(1, "imagen_asociada", docname);

                    // Mantengo el mismo concepto: setear Filename del objeto p_1
                    // (Tu wrapper lo tiene que soportar; si no existe, lo conectamos)
                    SetPictureFilename("p_1", docname);

                    this.SetFocus();
                }
                else
                {
                    this.SetFocus();
                }
            }

            // PB: recupero el foco en la ventana.
            this.SetFocus();
        }

        // =====================================================
        // PB: event ue_iniciar
        // =====================================================
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            // PB: String imagen
            string imagen = dw_1.GetItemString(1, "imagen_asociada");

            // PB: dw_1.object.p_1.Filename = imagen
            SetPictureFilename("p_1", imagen);

            dw_1.SetFocus();
        }

        // =====================================================
        // PB: event ue_validar_datos (ANCESTOR SCRIPT OVERRIDE)
        // =====================================================
        public override void ue_validar_datos()
        {
            string ls_Datos;

            ls_Datos = dw_1.GetItemString(1, "medicamento");
            if (dw_1.IsNull(1, "medicamento") || string.IsNullOrEmpty(ls_Datos))
            {
                MessageBox.Show(
                    "El campo medicamento no puede estar vacio.",
                    "Validar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                ib_grabar = false;
                return;
            }

            ls_Datos = dw_1.GetItemString(1, "descripcion");
            if (dw_1.IsNull(1, "descripcion") || string.IsNullOrEmpty(ls_Datos))
            {
                MessageBox.Show(
                    "El campo descripcion no puede estar vacio.",
                    "Validar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                ib_grabar = false;
                return;
            }
        }

        /// <summary>
        /// Emulación 1:1 de "dw_1.object.<obj>.Filename = value".
        /// Acá NO invento cómo lo hacés: te dejo el punto único para mapear
        /// a tu wrapper (Modify/Describe/prop directa).
        /// </summary>
        private void SetPictureFilename(string pictureObjectName, string filename)
        {
            // Opción típica si tu uo_dw soporta Modify (PowerBuilder-like):
            // dw_1.Modify($"{pictureObjectName}.Filename='{filename.Replace("'", "''")}'");

            // Si tu wrapper expone object.p_1.Filename, reemplazás esta línea
            // por tu acceso real y listo.
            dw_1.SetObjectProperty(pictureObjectName, "Filename", filename);
        }
    }
}