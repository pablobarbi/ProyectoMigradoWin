
using Minotti.Views.Basicos.Controls;
using System.Windows.Forms;

namespace Minotti.Views.Reportes.Controls
{
    partial class w_dwsaveas
    {
        private Label st_1;
        private Label st_2;
        private uo_dw dw_sorted;
        private uo_dw dw_sortcolumns;
        private Button cb_ok_;
        private Button cb_cancelar;

        private void InitializeComponent()
        {
            this.st_1 = new Label();
            this.st_2 = new Label();
            this.dw_sorted = new uo_dw();
            this.dw_sortcolumns = new uo_dw();
            this.cb_ok_ = new Button();
            this.cb_cancelar = new Button();

            this.cb_ok_.Text = "&OK";
            this.cb_ok_.Click += (s, e) => ue_ok();

            this.cb_cancelar.Text = "&Cancelar";
            this.cb_cancelar.Click += (s, e) => ue_cancelar();

            this.Controls.AddRange(new Control[]
            {
            st_1, st_2, dw_sorted, dw_sortcolumns, cb_ok_, cb_cancelar
            });

            this.Text = "Exportar...";
            this.ClientSize = new System.Drawing.Size(1541, 768);
        }
    }

}
