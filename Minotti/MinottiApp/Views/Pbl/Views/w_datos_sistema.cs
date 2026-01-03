using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Models;
using System;
using System.Drawing;
using System.IO;


namespace Minotti.Views.Pbl.Views
{
    public partial class w_datos_sistema : w_principal
    {
        // Equivalente a Message.PowerObjectParm
        public cat_app PowerObjectParm { get; set; }

        public w_datos_sistema()
        {
            InitializeComponent();
        }

        private void w_datos_sistema_Load(object sender, EventArgs e)
        {
            // PB: at_app = Message.PowerObjectParm
            cat_app at_app = this.PowerObjectParm;

            // PB: st_nombre.Text = at_app.Nombre
            st_nombre.Text = at_app.Nombre;

            // PB: st_version.Text = "Versión " + at_app.Version
            st_version.Text = "Versión " + at_app.Version;

            // PB: p_logo.PictureName = at_app.Logo
            // (WinForms: PictureBox.Image)
            if (!string.IsNullOrWhiteSpace(at_app.Logo) && File.Exists(at_app.Logo))
            {
                p_logo.Image = Image.FromFile(at_app.Logo);
            }

            // PB: st_copyright.Text = at_app.Copyright
            st_copyright.Text = at_app.Copyright;

            // PB: gb_borde.SetPosition(ToBottom!)
            gb_borde.SendToBack();
        }

        private void cb_1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}