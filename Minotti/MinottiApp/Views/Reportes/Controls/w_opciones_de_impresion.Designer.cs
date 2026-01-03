using Minotti.utils;
using System.ComponentModel;

namespace Minotti.Views.Reportes.Controls
{
    partial class w_opciones_de_impresion
    {
        private IContainer components = null;

        private System.Windows.Forms.PictureBox p_1;
        private System.Windows.Forms.Label st_2;
        private System.Windows.Forms.TextBox sle_documento;
        private System.Windows.Forms.Button cb_1;
        private System.Windows.Forms.Label st_5;
        private System.Windows.Forms.TextBox sle_impresora;
        private System.Windows.Forms.ComboBox ddlb_incluir;
        private System.Windows.Forms.Label st_4;
        private System.Windows.Forms.Button cb_printer;
        private System.Windows.Forms.Button cb_cancel;
        private System.Windows.Forms.CheckBox cbx_intercalar;
        private System.Windows.Forms.Label st_3;
        private System.Windows.Forms.TextBox sle_rango;
        private System.Windows.Forms.RadioButton rb_rango;
        private System.Windows.Forms.RadioButton rb_actual;
        private System.Windows.Forms.RadioButton rb_todas;
        private System.Windows.Forms.Button cb_ok;
        private System.Windows.Forms.GroupBox gb_paginas;
        private System.Windows.Forms.GroupBox gb_impresora;
        private System.Windows.Forms.GroupBox gb_copias;
        private System.Windows.Forms.MaskedTextBox em_copias;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.p_1 = new System.Windows.Forms.PictureBox();
            this.p_1.Name = "p_1";
            this.p_1.Location = new System.Drawing.Point(1430, 740);
            this.p_1.Size = new System.Drawing.Size(562, 276);
            this.p_1.ImageLocation = FileUtils.GetAppFile("Pictures", "no intercalado.bmp");
            this.p_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            this.st_2 = new System.Windows.Forms.Label();
            this.st_2.Name = "st_2";
            this.st_2.Location = new System.Drawing.Point(246, 164);
            this.st_2.Size = new System.Drawing.Size(308, 63);
            this.st_2.Text = "Documento:";
            this.st_2.ForeColor = System.Drawing.ColorTranslator.FromOle(unchecked((int)33554432));
            this.st_2.TabIndex = 0;

            this.sle_documento = new System.Windows.Forms.TextBox();
            this.sle_documento.Name = "sle_documento";
            this.sle_documento.Location = new System.Drawing.Point(606, 164);
            this.sle_documento.Size = new System.Drawing.Size(1221, 87);
            this.sle_documento.TabIndex = 1;

            this.cb_1 = new System.Windows.Forms.Button();
            this.cb_1.Name = "cb_1";
            this.cb_1.Location = new System.Drawing.Point(2053, 148);
            this.cb_1.Size = new System.Drawing.Size(392, 93);
            this.cb_1.Text = "&Propiedades";
            this.cb_1.ForeColor = System.Drawing.ColorTranslator.FromOle(unchecked((int)33554432));
            this.cb_1.TabIndex = 4;

            this.st_5 = new System.Windows.Forms.Label();
            this.st_5.Name = "st_5";
            this.st_5.Location = new System.Drawing.Point(284, 296);
            this.st_5.Size = new System.Drawing.Size(270, 63);
            this.st_5.Text = "Impresora:";
            this.st_5.ForeColor = System.Drawing.ColorTranslator.FromOle(unchecked((int)33554432));

            this.sle_impresora = new System.Windows.Forms.TextBox();
            this.sle_impresora.Name = "sle_impresora";
            this.sle_impresora.Location = new System.Drawing.Point(606, 296);
            this.sle_impresora.Size = new System.Drawing.Size(1221, 87);
            this.sle_impresora.Enabled = false;
            this.sle_impresora.TabIndex = 2;

            this.ddlb_incluir = new System.Windows.Forms.ComboBox();
            this.ddlb_incluir.Name = "ddlb_incluir";
            this.ddlb_incluir.Location = new System.Drawing.Point(978, 740);
            this.ddlb_incluir.Size = new System.Drawing.Size(384, 87);
            this.ddlb_incluir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlb_incluir.TabIndex = 10;

            this.st_4 = new System.Windows.Forms.Label();
            this.st_4.Name = "st_4";
            this.st_4.Location = new System.Drawing.Point(744, 740);
            this.st_4.Size = new System.Drawing.Size(221, 63);
            this.st_4.Text = "Incluir:";
            this.st_4.ForeColor = System.Drawing.ColorTranslator.FromOle(unchecked((int)33554432));

            this.cb_printer = new System.Windows.Forms.Button();
            this.cb_printer.Name = "cb_printer";
            this.cb_printer.Location = new System.Drawing.Point(1837, 296);
            this.cb_printer.Size = new System.Drawing.Size(194, 93);
            this.cb_printer.Text = "...";
            this.cb_printer.ForeColor = System.Drawing.ColorTranslator.FromOle(unchecked((int)33554432));
            this.cb_printer.TabIndex = 3;

            this.cb_cancel = new System.Windows.Forms.Button();
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Location = new System.Drawing.Point(2139, 1111);
            this.cb_cancel.Size = new System.Drawing.Size(392, 93);
            this.cb_cancel.Text = "&Cancelar";
            this.cb_cancel.ForeColor = System.Drawing.ColorTranslator.FromOle(unchecked((int)33554432));
            this.cb_cancel.TabIndex = 14;

            this.cbx_intercalar = new System.Windows.Forms.CheckBox();
            this.cbx_intercalar.Name = "cbx_intercalar";
            this.cbx_intercalar.Location = new System.Drawing.Point(600, 867);
            this.cbx_intercalar.Size = new System.Drawing.Size(600, 64);
            this.cbx_intercalar.Text = "Intercalar";
            this.cbx_intercalar.ForeColor = System.Drawing.ColorTranslator.FromOle(unchecked((int)33554432));
            this.cbx_intercalar.TabIndex = 12;

            this.st_3 = new System.Windows.Forms.Label();
            this.st_3.Name = "st_3";
            this.st_3.Location = new System.Drawing.Point(276, 612);
            this.st_3.Size = new System.Drawing.Size(278, 63);
            this.st_3.Text = "Copias:";
            this.st_3.ForeColor = System.Drawing.ColorTranslator.FromOle(unchecked((int)33554432));

            this.sle_rango = new System.Windows.Forms.TextBox();
            this.sle_rango.Name = "sle_rango";
            this.sle_rango.Location = new System.Drawing.Point(744, 872);
            this.sle_rango.Size = new System.Drawing.Size(490, 87);
            this.sle_rango.TabIndex = 9;

            this.rb_rango = new System.Windows.Forms.RadioButton();
            this.rb_rango.Name = "rb_rango";
            this.rb_rango.Location = new System.Drawing.Point(246, 872);
            this.rb_rango.Size = new System.Drawing.Size(450, 64);
            this.rb_rango.Text = "Rango";
            this.rb_rango.ForeColor = System.Drawing.ColorTranslator.FromOle(unchecked((int)33554432));
            this.rb_rango.TabIndex = 7;

            this.rb_actual = new System.Windows.Forms.RadioButton();
            this.rb_actual.Name = "rb_actual";
            this.rb_actual.Location = new System.Drawing.Point(246, 780);
            this.rb_actual.Size = new System.Drawing.Size(450, 64);
            this.rb_actual.Text = "Página actual";
            this.rb_actual.ForeColor = System.Drawing.ColorTranslator.FromOle(unchecked((int)33554432));
            this.rb_actual.TabIndex = 6;

            this.rb_todas = new System.Windows.Forms.RadioButton();
            this.rb_todas.Name = "rb_todas";
            this.rb_todas.Location = new System.Drawing.Point(246, 689);
            this.rb_todas.Size = new System.Drawing.Size(450, 64);
            this.rb_todas.Text = "Todas";
            this.rb_todas.ForeColor = System.Drawing.ColorTranslator.FromOle(unchecked((int)33554432));
            this.rb_todas.TabIndex = 5;

            this.cb_ok = new System.Windows.Forms.Button();
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Location = new System.Drawing.Point(1665, 1111);
            this.cb_ok.Size = new System.Drawing.Size(392, 93);
            this.cb_ok.Text = "&Aceptar";
            this.cb_ok.ForeColor = System.Drawing.ColorTranslator.FromOle(unchecked((int)33554432));
            this.cb_ok.TabIndex = 13;

            this.gb_paginas = new System.Windows.Forms.GroupBox();
            this.gb_paginas.Name = "gb_paginas";
            this.gb_paginas.Location = new System.Drawing.Point(143, 526);
            this.gb_paginas.Size = new System.Drawing.Size(1396, 543);
            this.gb_paginas.Text = "Páginas";
            this.gb_paginas.ForeColor = System.Drawing.ColorTranslator.FromOle(unchecked((int)33554432));
            this.gb_paginas.TabIndex = 8;

            this.gb_impresora = new System.Windows.Forms.GroupBox();
            this.gb_impresora.Name = "gb_impresora";
            this.gb_impresora.Location = new System.Drawing.Point(143, 80);
            this.gb_impresora.Size = new System.Drawing.Size(2455, 408);
            this.gb_impresora.Text = "Impresora";
            this.gb_impresora.ForeColor = System.Drawing.ColorTranslator.FromOle(unchecked((int)33554432));
            this.gb_impresora.TabIndex = 0;

            this.gb_copias = new System.Windows.Forms.GroupBox();
            this.gb_copias.Name = "gb_copias";
            this.gb_copias.Location = new System.Drawing.Point(1563, 526);
            this.gb_copias.Size = new System.Drawing.Size(1035, 543);
            this.gb_copias.Text = "Copias";
            this.gb_copias.ForeColor = System.Drawing.ColorTranslator.FromOle(unchecked((int)33554432));

            this.em_copias = new System.Windows.Forms.MaskedTextBox();
            this.em_copias.Name = "em_copias";
            this.em_copias.Location = new System.Drawing.Point(2105, 615);
            this.em_copias.Size = new System.Drawing.Size(246, 87);
            this.em_copias.Mask = "0000"; // PB Mask=####
            this.em_copias.Text = "1";
            this.em_copias.ForeColor = System.Drawing.ColorTranslator.FromOle(unchecked((int)33554432));
            this.em_copias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.em_copias.TabIndex = 11;

            // Form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Location = new System.Drawing.Point(143, 234);
            this.ClientSize = new System.Drawing.Size(2635, 1351);
            this.Name = "w_opciones_de_impresion";
            this.Text = "Imprimir";
            this.BackColor = System.Drawing.ColorTranslator.FromOle(unchecked((int)12632256));

            // Add controls
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.p_1,
                this.st_2,
                this.sle_documento,
                this.cb_1,
                this.st_5,
                this.sle_impresora,
                this.ddlb_incluir,
                this.st_4,
                this.cb_printer,
                this.cb_cancel,
                this.cbx_intercalar,
                this.st_3,
                this.sle_rango,
                this.rb_rango,
                this.rb_actual,
                this.rb_todas,
                this.cb_ok,
                this.gb_paginas,
                this.gb_impresora,
                this.gb_copias,
                this.em_copias,
            });

            this.ResumeLayout(false);
        }
    }
}