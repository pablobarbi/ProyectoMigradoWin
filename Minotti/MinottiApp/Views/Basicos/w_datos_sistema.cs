using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{


    public partial class w_datos_sistema : w_principal
    {
        // cat_app at_app  (en PB se recibía por Message.PowerObjectParm)
        private readonly cat_app _at_app;

        public w_datos_sistema(cat_app at_app)
        {
            _at_app = at_app ?? throw new ArgumentNullException(nameof(at_app));

            InitializeComponent();

            // Simula el evento OPEN de PB
            this.Load += w_datos_sistema_Load;

            // botón "&Cerrar"
            cb_1.Click += cb_1_clicked;
        }

        /// <summary>
        /// Evento "open" de PowerBuilder.
        /// </summary>
        private void w_datos_sistema_Load(object? sender, EventArgs e)
        {
            // /* Carga el Nombre de la Aplicación, la Versión, el Logo, el Copyright */
            st_nombre.Text = _at_app.Nombre ?? string.Empty;
            st_version.Text = "Versión " + (_at_app.Version ?? string.Empty);
            st_copyright.Text = _at_app.Copyright ?? string.Empty;

            // PB: p_logo.PictureName = at_app.Logo
            // En WinForms lo interpretamos como ruta de archivo (si querés otro mecanismo, lo cambiás acá)
            if (!string.IsNullOrWhiteSpace(_at_app.Logo))
            {
                try
                {
                    if (File.Exists(_at_app.Logo))
                    {
                        p_logo.Image = Image.FromFile(_at_app.Logo);
                        p_logo.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                catch
                {
                    // Si hay error cargando la imagen, no rompemos la ventana
                }
            }

            // /* Posiciona la ventana el borde atrás de todos los objetos de la ventrana */
            // gb_borde.SetPosition(ToBottom!)
            gb_borde.SendToBack();
        }

        /// <summary>
        /// Evento clicked de cb_1: Close(Parent) en PB.  
        /// Acá simplemente cerramos la ventana.
        /// </summary>
        private void cb_1_clicked(object? sender, EventArgs e)
        {
            this.Close();
        }
    }


}