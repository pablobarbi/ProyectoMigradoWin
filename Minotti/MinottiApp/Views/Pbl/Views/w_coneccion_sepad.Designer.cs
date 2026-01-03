using System.Windows.Forms;

namespace Minotti.Views.Pbl.Views
{
    partial class w_coneccion_sepad
    {
        private System.ComponentModel.IContainer components = null;

        private Label st_1;
        private Label st_4;
        private Label st_2;
        private Label st_3;
        private Label st_serial;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            st_1 = new Label();
            st_4 = new Label();
            st_2 = new Label();
            st_3 = new Label();
            st_serial = new Label();
            gb_base.SuspendLayout();
            gb_aplicacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)p_1).BeginInit();
            SuspendLayout();
            // 
            // gb_base
            // 
            gb_base.Location = new System.Drawing.Point(41, 200);
            // 
            // st_1
            // 
            st_1.Location = new System.Drawing.Point(20, 240);
            st_1.Name = "st_1";
            st_1.Size = new System.Drawing.Size(400, 24);
            st_1.TabIndex = 27;
            st_1.Text = "Visite: www.minottimaster.com";
            // 
            // st_4
            // 
            st_4.Location = new System.Drawing.Point(20, 270);
            st_4.Name = "st_4";
            st_4.Size = new System.Drawing.Size(400, 24);
            st_4.TabIndex = 28;
            st_4.Text = "Programa Protegido";
            // 
            // st_2
            // 
            st_2.Location = new System.Drawing.Point(20, 300);
            st_2.Name = "st_2";
            st_2.Size = new System.Drawing.Size(400, 24);
            st_2.TabIndex = 29;
            st_2.Text = "Copyright: Angel Oscar Minotti";
            // 
            // st_3
            // 
            st_3.Location = new System.Drawing.Point(20, 330);
            st_3.Name = "st_3";
            st_3.Size = new System.Drawing.Size(400, 24);
            st_3.TabIndex = 30;
            st_3.Text = "Diseño y programación: www.ilconsulting.com.ar";
            // 
            // st_serial
            // 
            st_serial.Location = new System.Drawing.Point(20, 200);
            st_serial.Name = "st_serial";
            st_serial.Size = new System.Drawing.Size(400, 24);
            st_serial.TabIndex = 26;
            st_serial.Text = "Registro Nro. :  ";
            // 
            // w_coneccion_sepad
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            ClientSize = new System.Drawing.Size(900, 550);
            Controls.Add(st_serial);
            Controls.Add(st_1);
            Controls.Add(st_4);
            Controls.Add(st_2);
            Controls.Add(st_3);
            Location = new System.Drawing.Point(0, 0);
            Name = "w_coneccion_sepad";
            Controls.SetChildIndex(st_3, 0);
            Controls.SetChildIndex(st_2, 0);
            Controls.SetChildIndex(st_4, 0);
            Controls.SetChildIndex(st_1, 0);
            Controls.SetChildIndex(st_serial, 0);
            Controls.SetChildIndex(gb_aplicacion, 0);
            Controls.SetChildIndex(gb_base, 0);
            Controls.SetChildIndex(p_1, 0);
            Controls.SetChildIndex(pb_cancelar, 0);
            Controls.SetChildIndex(pb_continuar, 0);
            gb_base.ResumeLayout(false);
            gb_base.PerformLayout();
            gb_aplicacion.ResumeLayout(false);
            gb_aplicacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)p_1).EndInit();
            ResumeLayout(false);
        }
    }
}