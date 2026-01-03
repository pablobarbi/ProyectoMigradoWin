using Minotti.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minotti.Views.Basicos.Controls
{
    /// <summary>
    /// Equivalente a uo_boton_iz (picturebutton PB).
    /// </summary>
    public class uo_boton_iz : Button
    {
        private Image? _imgEnabled;
        private Image? _imgDisabled;

        public uo_boton_iz()
        {
            // Tamaño y tab
            this.Width = 270;
            this.Height = 221;
            this.TabIndex = 1;

            // Alineación texto/imagen (HTextAlign = Left!)
            this.TextAlign = ContentAlignment.MiddleLeft;
            this.ImageAlign = ContentAlignment.MiddleLeft;

            // Fuente Comic Sans MS, tamaño aprox 10 pt
            this.Font = new Font("Comic Sans MS", 10f, FontStyle.Regular);

            // Estilo del botón (podés ajustarlo)
            this.FlatStyle = FlatStyle.Standard;

            // Cargar las imágenes
            // Opción 1: Resources
            // _imgEnabled  = Properties.Resources.izq;   // izq.bmp
            // _imgDisabled = Properties.Resources.dizq;  // dizq.bmp

            // Opción 2: desde disco
            try
            {
                _imgEnabled = Image.FromFile(FileUtils.GetAppFile("Pictures", "izq.bmp"));
                _imgDisabled = Image.FromFile(FileUtils.GetAppFile("Pictures", "dizq.bmp"));
            }
            catch
            {
                _imgEnabled = null;
                _imgDisabled = null;
            }

            ActualizarImagen();
            this.EnabledChanged += (_, __) => ActualizarImagen();
        }

        private void ActualizarImagen()
        {
            if (!this.Enabled && _imgDisabled != null)
            {
                this.Image = _imgDisabled;
            }
            else
            {
                this.Image = _imgEnabled;
            }
        }
    }
}
