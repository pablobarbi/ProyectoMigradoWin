using Minotti.utils;
using Minotti.Views.Basicos.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Reportes.Controls
{
    partial class w_presentacion
    {
        private IContainer? components = null;

        // Controles (mismos nombres PB)
        public Button pb_1 = null!;
        public Button pb_2 = null!;
        public Button pb_4 = null!;
        public Button pb_5 = null!;
        public MaskedTextBox em_zoom = null!;
        public CheckBox cbx_1 = null!;
        public Panel ln_1 = null!;
        public Panel ln_2 = null!;
        public Button pb_primer = null!;
        public Button pb_anterior = null!;
        public Button pb_siguiente = null!;
        public Button pb_ultimo = null!;

        public uo_dw dw_1 = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();

            pb_1 = new Button();
            pb_2 = new Button();
            pb_4 = new Button();
            pb_5 = new Button();
            em_zoom = new MaskedTextBox();
            cbx_1 = new CheckBox();
            ln_1 = new Panel();
            ln_2 = new Panel();
            pb_primer = new Button();
            pb_anterior = new Button();
            pb_siguiente = new Button();
            pb_ultimo = new Button();
            dw_1 = new uo_dw();

            // ---- Form (PB: Width=3397) ----
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Name = "w_presentacion";
            // PB usa units; acá copio el tamaño base sin inventar conversión fina.
            this.ClientSize = new Size(3397, 1000);
            this.Text = "w_presentacion";
            this.StartPosition = FormStartPosition.CenterScreen;

            // ---- pb_1 (Cerrar) ----
            pb_1.Name = "pb_1";
            pb_1.Location = new Point(1779, 25);
            pb_1.Size = new Size(325, 105);
            pb_1.TabIndex = 90;
            pb_1.Text = "&Cerrar";
            this.CancelButton = pb_1; // equivalente práctico
            pb_1.Font = new Font("MS Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point);

            // ---- pb_2 (Imprimir.bmp) ----
            pb_2.Name = "pb_2";
            pb_2.Location = new Point(33, 25);
            pb_2.Size = new Size(119, 105);
            pb_2.TabIndex = 40;
            pb_2.Font = new Font("MS Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point);
            TrySetButtonImage(pb_2, FileUtils.GetAppFile("Pictures", "imprimir.bmp"));

            // ---- pb_5 (ZoomOut) ----
            pb_5.Name = "pb_5";
            pb_5.Location = new Point(577, 25);
            pb_5.Size = new Size(119, 105);
            pb_5.TabIndex = 10;
            pb_5.Font = new Font("MS Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point);
            TrySetButtonImage(pb_5, FileUtils.GetAppFile("Pictures", "zoomout.bmp"));

            // ---- em_zoom (Mask ###, MinMax 25~~250) ----
            em_zoom.Name = "em_zoom";
            em_zoom.Location = new Point(714, 29);
            em_zoom.Size = new Size(270, 101);
            em_zoom.TabIndex = 20;
            em_zoom.Mask = "000"; // PB: "###"
            em_zoom.TextAlign = HorizontalAlignment.Center;
            em_zoom.Font = new Font("Arial Narrow", 11, FontStyle.Bold, GraphicsUnit.Point);

            // ---- pb_4 (ZoomIn) ----
            // En el PB pegado aparece pb_4 con zoomin.bmp (esa parte está completa).
            pb_4.Name = "pb_4";
            pb_4.Location = new Point(1002, 25);
            pb_4.Size = new Size(119, 105);
            pb_4.TabIndex = 30;
            pb_4.Font = new Font("MS Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point);
            TrySetButtonImage(pb_4, FileUtils.GetAppFile("Pictures", "zoomin.bmp"));

            // ---- cbx_1 (Reglas) ----
            cbx_1.Name = "cbx_1";
            cbx_1.Location = new Point(220, 45);
            cbx_1.Size = new Size(311, 73);
            cbx_1.TabIndex = 60;
            cbx_1.Text = "&Reglas";
            cbx_1.Font = new Font("MS Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point);

            // ---- ln_2 (PB BeginY=149 EndX=4170 EndY=149 Thickness=5 Color=16777215) ----
            ln_2.Name = "ln_2";
            ln_2.Enabled = false;
            ln_2.Location = new Point(0, 149);
            ln_2.Size = new Size(4170, 5);
            ln_2.BackColor = ColorTranslator.FromOle(unchecked((int)16777215));

            // ---- ln_1 (PB BeginY=153 EndX=4174 EndY=153 Thickness=5 Color=8421504) ----
            ln_1.Name = "ln_1";
            ln_1.Enabled = false;
            ln_1.Location = new Point(0, 153);
            ln_1.Size = new Size(4174, 5);
            ln_1.BackColor = ColorTranslator.FromOle(unchecked((int)8421504));

            // ---- navegación ----
            // OJO: los bloques PB de estos botones traen PictureName (pripag/botones) pero
            // en el texto pegado aparecen con partes "..." mezcladas. Igual, los nombres de BMP
            // se ven (pripag.bmp/...) así que sólo seteo la imagen por nombre.
            pb_primer.Name = "pb_primer";
            pb_primer.Location = new Point(1217, 25);
            pb_primer.Size = new Size(119, 105);
            pb_primer.TabIndex = 80;
            TrySetButtonImage(pb_primer, FileUtils.GetAppFile("Pictures", "pripag.bmp"));

            pb_anterior.Name = "pb_anterior";
            pb_anterior.Location = new Point(1335, 25);
            pb_anterior.Size = new Size(119, 105);
            pb_anterior.TabIndex = 70;
            TrySetButtonImage(pb_anterior, FileUtils.GetAppFile("Pictures", "anterior.bmp")); // si tu bmp real difiere, lo ajustás al nombre real

            pb_siguiente.Name = "pb_siguiente";
            pb_siguiente.Location = new Point(1454, 25);
            pb_siguiente.Size = new Size(119, 105);
            pb_siguiente.TabIndex = 60;
            TrySetButtonImage(pb_siguiente, FileUtils.GetAppFile("Pictures", "siguiente.bmp")); // idem

            pb_ultimo.Name = "pb_ultimo";
            pb_ultimo.Location = new Point(1573, 25);
            pb_ultimo.Size = new Size(119, 105);
            pb_ultimo.TabIndex = 50;
            TrySetButtonImage(pb_ultimo, FileUtils.GetAppFile("Pictures", "ultpag.bmp"));

            // ---- dw_1 ----
            dw_1.Name = "dw_1";
            dw_1.Location = new Point(74, 229);
            dw_1.Size = new Size(581, 697);
            dw_1.TabIndex = 2;

            // Add
            this.Controls.Add(pb_2);
            this.Controls.Add(pb_5);
            this.Controls.Add(em_zoom);
            this.Controls.Add(pb_4);
            this.Controls.Add(cbx_1);
            this.Controls.Add(pb_primer);
            this.Controls.Add(pb_anterior);
            this.Controls.Add(pb_siguiente);
            this.Controls.Add(pb_ultimo);
            this.Controls.Add(pb_1);
            this.Controls.Add(ln_2);
            this.Controls.Add(ln_1);
            this.Controls.Add(dw_1);
        }

        private static void TrySetButtonImage(Button b, string fileName)
        {
            // No invento rutas: respeta el nombre PB tal cual.
            try
            {
                if (System.IO.File.Exists(fileName))
                {
                    b.Image = Image.FromFile(fileName);
                    b.ImageAlign = ContentAlignment.MiddleCenter;
                    b.Text = ""; // picturebutton PB
                }
            }
            catch
            {
                // si no existe o no puede cargar, lo deja sin imagen (sin romper)
            }
        }
    }
}