using System.Windows.Forms;
using System.Drawing;

namespace Minotti.Controls
{
    partial class d_agregar_rubricas
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label nombre_t;
        private TextBox nombre;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.nombre_t = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nombre_t
            // 
            this.nombre_t.AutoSize = true;
            this.nombre_t.Name = "nombre_t";
            this.nombre_t.Text = "Rubrica:";
            this.nombre_t.Location = new System.Drawing.Point(16, 20);
            // 
            // nombre
            // 
            this.nombre.Name = "nombre";
            this.nombre.Location = new System.Drawing.Point(80, 16);
            this.nombre.Size = new System.Drawing.Size(260, 23);
            this.nombre.MaxLength = 255;
            // 
            // d_agregar_rubricas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.nombre_t);
            this.Name = "d_agregar_rubricas";
            this.Size = new System.Drawing.Size(360, 60);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
