using System.Drawing;

namespace Minotti.Views.Menues.Controls
{
    partial class uo_link
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();

            // PB defaults
            this.Width = 416;
            this.Height = 72;
            this.Text = " none";
            this.ForeColor = ColorTranslator.FromOle(16711680);
            this.BackColor = ColorTranslator.FromOle(79741120);

            this.Font = new Font(
                "Tahoma",
                8,
                FontStyle.Underline,
                GraphicsUnit.Point);

            this.TextAlign = ContentAlignment.MiddleLeft;
            this.AutoSize = false;

            this.ResumeLayout(false);
        }
    }
}
