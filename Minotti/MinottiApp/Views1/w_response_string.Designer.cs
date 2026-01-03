using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views
{
    partial class w_response_string
    {
        private IContainer components = null;

        // Control con el mismo nombre que en PB
        public TextBox editor; // singlelineedit "editor"

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
            this.components = new Container();
            this.editor = new TextBox();

            this.SuspendLayout();

            // editor (singlelineedit)
            this.editor.Name = "editor";
            this.editor.Location = new Point(12, 12);
            this.editor.Size = new Size(560, 23);
            this.editor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // w_response_string
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(584, 111);
            this.Controls.Add(this.editor);
            this.Name = "w_response_string";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "w_response_string";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
