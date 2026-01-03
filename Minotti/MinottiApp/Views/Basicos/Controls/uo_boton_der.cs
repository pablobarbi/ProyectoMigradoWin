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
    /// Equivalente al uo_boton_der (picturebutton PB).
    /// </summary>
    public class uo_boton_der : Button
    {
        // Rutas / recursos para las imágenes (ajustá según cómo manejes las imágenes)
        private Image _imgEnabled;
        private Image _imgDisabled;

        public uo_boton_der()
        {
            // Tamaño y tab
            Width = 270;
            Height = 221;
            TabIndex = 1;

            // Alineación del texto (HTextAlign=Left!)
            TextAlign = ContentAlignment.MiddleLeft;
            ImageAlign = ContentAlignment.MiddleLeft;   // para que imagen y texto vayan alineados

            // Fuente (TextSize=-10 ⇒ aprox 10pt, Comic Sans MS, Weight=400)
            Font = new Font("Comic Sans MS", 10f, FontStyle.Regular);

            // Opcional: estilo visual del botón
            FlatStyle = FlatStyle.Standard;

            // Cargar las imágenes
            // Opción 1: desde Resources
            // _imgEnabled = Properties.Resources.derecha;   // derecha.bmp
            // _imgDisabled = Properties.Resources.dderecha; // dderecha.bmp

            // Opción 2: desde disco (ajustar rutas)
            try
            {
                _imgEnabled = Image.FromFile(FileUtils.GetAppFile("Pictures", "derecha.bmp"));
                _imgDisabled = Image.FromFile(FileUtils.GetAppFile("Pictures", "dderecha.bmp"));
            }
            catch
            {
                // Si falla la carga, las dejamos en null
                _imgEnabled = null;
                _imgDisabled = null;
            }

            ActualizarImagen();
            EnabledChanged += (_, __) => ActualizarImagen();
        }

        private void ActualizarImagen()
        {
            if (!Enabled && _imgDisabled != null)
            {
                Image = _imgDisabled;
            }
            else
            {
                Image = _imgEnabled;
            }
        }
    }
}
