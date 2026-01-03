using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.conect_anywhere.Controls
{
    partial class w_coneccion_anywhere
    {
        private void InitializeComponent()
        {
            // =========================================================
            // Ajustes de propiedades para controles heredados (PB within)
            // =========================================================

            // pb_continuar / pb_cancelar
            // boolean BringToTop=true
            this.pb_continuar?.BringToFront();
            this.pb_cancelar?.BringToFront();

            // gb_base Visible=false
            if (this.gb_base != null) this.gb_base.Visible = false;

            // gb_aplicacion X/Y
            if (this.gb_aplicacion != null)
            {
                this.gb_aplicacion.Left = 631;
                this.gb_aplicacion.Top = 809;
            }

            // sle_usuario_base Visible=false Text="dba"
            if (this.sle_usuario_base != null)
            {
                this.sle_usuario_base.Visible = false;
                this.sle_usuario_base.Text = "dba";
                this.sle_usuario_base.BringToFront();
            }

            // sle_clave_base Visible=false Text="sql"
            if (this.sle_clave_base != null)
            {
                this.sle_clave_base.Visible = false;
                this.sle_clave_base.Text = "sql";
                this.sle_clave_base.BringToFront();
            }

            // st_usuario_base Visible=false
            if (this.st_usuario_base != null)
            {
                this.st_usuario_base.Visible = false;
                this.st_usuario_base.BringToFront();
            }

            // st_clave_base Visible=false
            if (this.st_clave_base != null)
            {
                this.st_clave_base.Visible = false;
                this.st_clave_base.BringToFront();
            }

            // st_usuario_aplicacion X/Y
            if (this.st_usuario_aplicacion != null)
            {
                this.st_usuario_aplicacion.Left = 782;
                this.st_usuario_aplicacion.Top = 909;
                this.st_usuario_aplicacion.BringToFront();
            }

            // st_clave_aplicacion X/Y
            if (this.st_clave_aplicacion != null)
            {
                this.st_clave_aplicacion.Left = 782;
                this.st_clave_aplicacion.Top = 1009;
                this.st_clave_aplicacion.BringToFront();
            }

            // sle_usuario_aplicacion X/Y
            if (this.sle_usuario_aplicacion != null)
            {
                this.sle_usuario_aplicacion.Left = 1047;
                this.sle_usuario_aplicacion.Top = 909;
                this.sle_usuario_aplicacion.BringToFront();
            }

            // sle_clave_aplicacion X/Y
            if (this.sle_clave_aplicacion != null)
            {
                this.sle_clave_aplicacion.Left = 1047;
                this.sle_clave_aplicacion.Top = 1009;
                this.sle_clave_aplicacion.BringToFront();
            }

            // p_1 BringToTop=true
            this.p_1?.BringToFront();
        }
    }
}
