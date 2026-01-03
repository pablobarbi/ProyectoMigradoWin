using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    public partial class w_response_string
    {
        private System.ComponentModel.IContainer components = null;

        // PB: editor from singlelineedit within w_response_string
        private TextBox editor;

        /// <inheritdoc />
        protected  override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.editor = new System.Windows.Forms.TextBox();

            this.SuspendLayout();

            // 
            // w_response_string (form)
            // PB:
            // X=1281 Y=577 Width=1404 Height=445
            // WindowType=response!, sin min/max box, no resizable (heredado de w_response)
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1404, 445);
            this.Name = "w_response_string";
            this.Text = "w_response_string";

            // Posicionamiento de los botones (según PB)
            // pb_continuar: X=115 Y=221
            // pb_cancelar : X=878 Y=221
            // Tomo Y como 221, mismo alto que en base.
            this.pb_continuar.Location = new Point(115, 221);
            this.pb_cancelar.Location = new Point(878, 221);

            // 
            // editor
            // PB:
            // X=202 Y=69 Width=993 Height=101
            // singlelineedit, sin scroll horiz, Arial 10, fondo blanco
            // 
            this.editor.Location = new Point(202, 69);
            this.editor.Size = new Size(993, 23);
            this.editor.Name = "editor";
            this.editor.TabIndex = 1;
            this.editor.BorderStyle = BorderStyle.FixedSingle;
            this.editor.BackColor = Color.White;
            this.editor.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);

            // Al ser SingleLineEdit, no uso Multiline
            this.editor.Multiline = false;

            // 
            // Controls
            // 
            this.Controls.Add(this.editor);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
