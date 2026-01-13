using System.Windows.Forms;

namespace Minotti.Views.Pbl.Views
{
    partial class w_coneccion_sepad
    {
        private System.ComponentModel.IContainer components = null;

        private Label st_serial;
        private Label st_1;
        private Label st_4;
        private Label st_2;
        private Label st_3;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            st_serial = new Label();
            st_1 = new Label();
            st_4 = new Label();
            st_2 = new Label();
            st_3 = new Label();
            gb_base.SuspendLayout();
            gb_aplicacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)p_1).BeginInit();
            SuspendLayout();
            // 
            // gb_base
            // 
            gb_base.Location = new Point(35, 150);
            gb_base.Margin = new Padding(3, 2, 3, 2);
            gb_base.Padding = new Padding(3, 2, 3, 2);
            gb_base.Size = new Size(315, 128);
            // 
            // gb_aplicacion
            // 
            gb_aplicacion.Location = new Point(499, 30);
            gb_aplicacion.Margin = new Padding(3, 2, 3, 2);
            gb_aplicacion.Padding = new Padding(3, 2, 3, 2);
            gb_aplicacion.Size = new Size(508, 116);
            // 
            // sle_usuario_base
            // 
            sle_usuario_base.Location = new Point(96, 30);
            sle_usuario_base.Margin = new Padding(3, 2, 3, 2);
            sle_usuario_base.Size = new Size(184, 23);
            // 
            // sle_clave_base
            // 
            sle_clave_base.Location = new Point(96, 64);
            sle_clave_base.Margin = new Padding(3, 2, 3, 2);
            sle_clave_base.Size = new Size(184, 23);
            // 
            // st_usuario_base
            // 
            st_usuario_base.Location = new Point(18, 30);
            st_usuario_base.Size = new Size(70, 17);
            // 
            // st_clave_base
            // 
            st_clave_base.Location = new Point(18, 64);
            st_clave_base.Size = new Size(70, 17);
            // 
            // sle_usuario_aplicacion
            // 
            sle_usuario_aplicacion.Location = new Point(134, 30);
            sle_usuario_aplicacion.Margin = new Padding(3, 2, 3, 2);
            sle_usuario_aplicacion.Size = new Size(184, 23);
            // 
            // sle_clave_aplicacion
            // 
            sle_clave_aplicacion.Location = new Point(134, 64);
            sle_clave_aplicacion.Margin = new Padding(3, 2, 3, 2);
            sle_clave_aplicacion.Size = new Size(184, 23);
            // 
            // st_usuario_aplicacion
            // 
            st_usuario_aplicacion.Location = new Point(56, 30);
            st_usuario_aplicacion.Size = new Size(70, 17);
            // 
            // st_clave_aplicacion
            // 
            st_clave_aplicacion.Location = new Point(56, 64);
            st_clave_aplicacion.Size = new Size(70, 17);
            // 
            // p_1
            // 
            p_1.Location = new Point(18, 15);
            p_1.Margin = new Padding(3, 2, 3, 2);
            p_1.Size = new Size(455, 333);
            // 
            // st_serial
            // 
            st_serial.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            st_serial.Location = new Point(499, 240);
            st_serial.Name = "st_serial";
            st_serial.Size = new Size(508, 18);
            st_serial.TabIndex = 26;
            st_serial.Text = "Registro Nro. :";
            // 
            // st_1
            // 
            st_1.Location = new Point(499, 262);
            st_1.Name = "st_1";
            st_1.Size = new Size(508, 18);
            st_1.TabIndex = 27;
            st_1.Text = "Visite: www.minottimaster.com";
            // 
            // st_4
            // 
            st_4.Location = new Point(499, 285);
            st_4.Name = "st_4";
            st_4.Size = new Size(508, 18);
            st_4.TabIndex = 28;
            st_4.Text = "Programa Protegido";
            // 
            // st_2
            // 
            st_2.Location = new Point(499, 308);
            st_2.Name = "st_2";
            st_2.Size = new Size(508, 18);
            st_2.TabIndex = 29;
            st_2.Text = "Copyright: Angel Oscar Minotti";
            // 
            // st_3
            // 
            st_3.Location = new Point(499, 330);
            st_3.Name = "st_3";
            st_3.Size = new Size(508, 18);
            st_3.TabIndex = 30;
            //st_3.Text = "Diseño y programación: www.ilconsulting.com.ar";
            st_3.Text = "Diseño y programación: Vartix Group";
            // 
            // w_coneccion_sepad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            ClientSize = new Size(1050, 361);
            Controls.Add(st_serial);
            Controls.Add(st_1);
            Controls.Add(st_4);
            Controls.Add(st_2);
            Controls.Add(st_3);
            Location = new Point(0, 0);
            Margin = new Padding(3, 2, 3, 2);
            Name = "w_coneccion_sepad";
            Text = "Minotti 2026";
            Controls.SetChildIndex(pb_cancelar, 0);
            Controls.SetChildIndex(pb_continuar, 0);
            Controls.SetChildIndex(st_3, 0);
            Controls.SetChildIndex(st_2, 0);
            Controls.SetChildIndex(st_4, 0);
            Controls.SetChildIndex(st_1, 0);
            Controls.SetChildIndex(st_serial, 0);
            Controls.SetChildIndex(gb_base, 0);
            Controls.SetChildIndex(p_1, 0);
            Controls.SetChildIndex(gb_aplicacion, 0);
            gb_base.ResumeLayout(false);
            gb_base.PerformLayout();
            gb_aplicacion.ResumeLayout(false);
            gb_aplicacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)p_1).EndInit();
            ResumeLayout(false);
        }
    }
}
