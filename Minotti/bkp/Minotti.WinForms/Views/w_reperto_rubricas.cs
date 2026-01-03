using System;
using System.Windows.Forms;
namespace Minotti
{
    public partial class w_reperto_rubricas : Form
    {
        public string Dsn { get; set; } = string.Empty;
        public bool ib_grabar { get; set; } = true;
        public w_reperto_rubricas()
        {
            InitializeComponent();
            this.cb_reperto_parcial.Click += (s, e) => cb_reperto_parcial_clicked();
            this.cb_reperto_total.Click += (s, e) => cb_reperto_total_clicked();
        }
        public void cb_reperto_parcial_clicked() { }
        public void cb_reperto_total_clicked() { }
        public void uo_rollback_si_error() { if (!this.ib_grabar) { } }
    }
}