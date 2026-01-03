using Minotti.utils;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Pbl.Views
{
    partial class w_informacion
    {
        private IContainer? components = null;

        // Controles (mantengo nombres)
        private Label st_4;
        private Label st_1;
        private Label st_2;
        private Label st_3;
        private PictureBox p_logo;
        private Panel r_1;
        private Button cb_1;

        protected  override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private static Color Ole(long oleColor)
        {
            // PowerBuilder usa colores OLE (long)
            return ColorTranslator.FromOle(unchecked((int)oleColor));
        }

        private void InitializeComponent()
        {
            this.components = new Container();

            this.st_4 = new Label();
            this.st_1 = new Label();
            this.st_2 = new Label();
            this.st_3 = new Label();
            this.p_logo = new PictureBox();
            this.r_1 = new Panel();
            this.cb_1 = new Button();

            ((ISupportInitialize)(this.p_logo)).BeginInit();
            this.SuspendLayout();

            // ===== Form (w_informacion) =====
            // integer width = 2496 / height = 2476
            this.AutoScaleMode = AutoScaleMode.None;
            this.ClientSize = new Size(2496, 2476);
            this.Name = "w_informacion";

            // ===== r_1 (rectangle) =====
            // rectangle fillcolor=81324524 x=55 y=28 width=2363 height=2180 linethickness=1
            this.r_1.BackColor = Ole(81324524);
            this.r_1.Location = new Point(55, 28);
            this.r_1.Name = "r_1";
            this.r_1.Size = new Size(2363, 2180);
            this.r_1.BorderStyle = BorderStyle.FixedSingle;

            // ===== p_logo (picture) =====
            // picture x=210 y=36 width=2053 height=1940 picturename="tapa1.bmp" bringtotop=true
            this.p_logo.Location = new Point(210, 36);
            this.p_logo.Name = "p_logo";
            this.p_logo.Size = new Size(2053, 1940);
            this.p_logo.TabStop = false;
            this.p_logo.BringToFront();
            this.p_logo.SizeMode = PictureBoxSizeMode.StretchImage; // PB: no explicit, pero width/height definidos
            this.p_logo.ImageLocation = FileUtils.GetAppFile("Pictures", "tapa1.bmp");

            // ===== st_1 =====
            // st_1 x=105 y=1996 width=960 height=76 text="Visite: www.minottimaster.com"
            this.st_1.Location = new Point(105, 1996);
            this.st_1.Name = "st_1";
            this.st_1.Size = new Size(960, 76);
            this.st_1.Text = "Visite: www.minottimaster.com";
            this.st_1.TextAlign = ContentAlignment.MiddleCenter;
            this.st_1.BorderStyle = BorderStyle.FixedSingle;
            this.st_1.BackColor = Ole(81324524);
            this.st_1.ForeColor = Ole(8388608);
            this.st_1.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point);

            // ===== st_4 =====
            // st_4 x=105 y=2088 width=960 height=76 text="Programa Protegido"
            this.st_4.Location = new Point(105, 2088);
            this.st_4.Name = "st_4";
            this.st_4.Size = new Size(960, 76);
            this.st_4.Text = "Programa Protegido";
            this.st_4.TextAlign = ContentAlignment.MiddleCenter;
            this.st_4.BorderStyle = BorderStyle.FixedSingle;
            this.st_4.BackColor = Ole(81324524);
            this.st_4.ForeColor = Ole(8388608);
            this.st_4.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point);

            // ===== st_2 =====
            // st_2 x=1079 y=1996 width=1303 height=76 text="Copyright: Angel Oscar Minotti"
            this.st_2.Location = new Point(1079, 1996);
            this.st_2.Name = "st_2";
            this.st_2.Size = new Size(1303, 76);
            this.st_2.Text = "Copyright: Angel Oscar Minotti";
            this.st_2.TextAlign = ContentAlignment.MiddleCenter;
            this.st_2.BorderStyle = BorderStyle.FixedSingle;
            this.st_2.BackColor = Ole(81324524);
            this.st_2.ForeColor = Ole(8388608);
            this.st_2.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point);

            // ===== st_3 =====
            // st_3 x=1079 y=2088 width=1303 height=76 text="Diseño y programación: www.ilconsulting.com.ar"
            this.st_3.Location = new Point(1079, 2088);
            this.st_3.Name = "st_3";
            this.st_3.Size = new Size(1303, 76);
            this.st_3.Text = "Diseño y programación: www.ilconsulting.com.ar";
            this.st_3.TextAlign = ContentAlignment.MiddleCenter;
            this.st_3.BorderStyle = BorderStyle.FixedSingle;
            this.st_3.BackColor = Ole(81324524);
            this.st_3.ForeColor = Ole(8388608);
            this.st_3.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point);

            // ===== cb_1 =====
            // cb_1 x=2153 y=2220 width=256 height=108 text="&Cerrar"
            this.cb_1.Location = new Point(2153, 2220);
            this.cb_1.Name = "cb_1";
            this.cb_1.Size = new Size(256, 108);
            this.cb_1.Text = "&Cerrar";
            this.cb_1.UseVisualStyleBackColor = true;
            this.cb_1.Click += new System.EventHandler(this.cb_1_Click);

            // ===== Orden de Z (BringToTop) =====
            // r_1 atrás, p_logo arriba
            this.Controls.Add(this.r_1);
            this.Controls.Add(this.p_logo);
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.st_4);
            this.Controls.Add(this.st_2);
            this.Controls.Add(this.st_3);
            this.Controls.Add(this.cb_1);

            this.r_1.SendToBack();

            ((ISupportInitialize)(this.p_logo)).EndInit();
            this.ResumeLayout(false);
        }
    }
}