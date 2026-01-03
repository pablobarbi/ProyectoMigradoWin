using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Basicos.Controls
{
    partial class d_ayuda
    {
        private Label st_descripcion_datos_de_la_ventana;
        private DataGridView dgv_d_ayuda;

        private void InitializeComponent()
        {
            st_descripcion_datos_de_la_ventana = new Label();
            dgv_d_ayuda = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgv_d_ayuda).BeginInit();
            SuspendLayout();

            // Header band: text "Descripción de los datos de la Ventana"
            st_descripcion_datos_de_la_ventana.Dock = DockStyle.Top;
            st_descripcion_datos_de_la_ventana.Height = 97; // header(height=97)
            st_descripcion_datos_de_la_ventana.Text = "Descripción de los datos de la Ventana";
            st_descripcion_datos_de_la_ventana.TextAlign = ContentAlignment.MiddleLeft;
            st_descripcion_datos_de_la_ventana.Font = new Font("MS Sans Serif", 9.0f, FontStyle.Bold | FontStyle.Underline);
            st_descripcion_datos_de_la_ventana.ForeColor = Color.Black;
            st_descripcion_datos_de_la_ventana.BackColor = Color.WhiteSmoke; // cercano a "553648127"
            st_descripcion_datos_de_la_ventana.Padding = new Padding(10, 0, 0, 0);

            // Detail band (grid)
            dgv_d_ayuda.Dock = DockStyle.Fill;
            dgv_d_ayuda.BackgroundColor = Color.WhiteSmoke;

            // Control
            Controls.Add(dgv_d_ayuda);
            Controls.Add(st_descripcion_datos_de_la_ventana);

            Name = "d_ayuda";
            BackColor = Color.WhiteSmoke;

            ((System.ComponentModel.ISupportInitialize)dgv_d_ayuda).EndInit();
            ResumeLayout(false);
        }
    }
}
