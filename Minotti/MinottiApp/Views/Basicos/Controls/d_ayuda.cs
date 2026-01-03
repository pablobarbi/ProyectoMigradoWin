using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Basicos.Controls
{
    public partial class d_ayuda : UserControl
    {
        public d_ayuda()
        {
            InitializeComponent();
            ConfigurarComoDataWindow();
        }

        // Para bindear lo que antes era el DataWindow buffer (DataTable/BindingList/etc.)
        [Browsable(false)]
        public object? DataSource
        {
            get => dgv_d_ayuda.DataSource;
            set => dgv_d_ayuda.DataSource = value;
        }

        private void ConfigurarComoDataWindow()
        {
            // Emulación general del DW
            dgv_d_ayuda.AutoGenerateColumns = true;
            dgv_d_ayuda.AllowUserToAddRows = false;
            dgv_d_ayuda.AllowUserToDeleteRows = false;
            dgv_d_ayuda.AllowUserToResizeRows = true;
            dgv_d_ayuda.ReadOnly = true;

            dgv_d_ayuda.MultiSelect = false;
            dgv_d_ayuda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv_d_ayuda.RowHeadersVisible = false;
            dgv_d_ayuda.ColumnHeadersVisible = false; // el DW usa un "text" en header band

            // detail(height.autosize=yes) + descripcion(height.autosize=yes)
            dgv_d_ayuda.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_d_ayuda.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // anchos grandes como el DW (width=1939/1943)
            dgv_d_ayuda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Colores aproximados (PB usa long ARGB distinto; WinForms usa Color)
            dgv_d_ayuda.BackgroundColor = Color.WhiteSmoke;
            dgv_d_ayuda.BorderStyle = BorderStyle.None;
            dgv_d_ayuda.CellBorderStyle = DataGridViewCellBorderStyle.None;

            dgv_d_ayuda.CellFormatting += dgv_d_ayuda_CellFormatting;
        }

        private void dgv_d_ayuda_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dgv_d_ayuda.Columns[e.ColumnIndex];
            var name = col.DataPropertyName;
            if (string.IsNullOrWhiteSpace(name)) name = col.Name;

            // column name=titulo (rojo + bold + fondo gris)
            if (string.Equals(name, "titulo", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                e.CellStyle.ForeColor = Color.Red;               // color="16711680"
                e.CellStyle.BackColor = Color.Gainsboro;         // cercano a background.color="536870912"
                e.CellStyle.Font = new Font("MS Sans Serif", 8.25f, FontStyle.Bold);
            }
            // column name=descripcion (negro + normal + autosize/wrap)
            else if (string.Equals(name, "descripcion", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                e.CellStyle.ForeColor = Color.Black;             // color="0"
                e.CellStyle.BackColor = Color.WhiteSmoke;        // cercano a "553648127"
                e.CellStyle.Font = new Font("MS Sans Serif", 8.0f, FontStyle.Regular);
                e.CellStyle.WrapMode = DataGridViewTriState.True;
            }
        }
    }
}
