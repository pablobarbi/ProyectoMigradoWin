using System;
using System.Windows.Forms;
namespace Minotti
{
    public partial class w_ver_medicamentos : Form
    {
        public w_ver_medicamentos()
        {
            InitializeComponent();
            this.pb_continuar.Click += (s, e) => pb_continuar_clicked();
            this.pb_cancelar.Click += (s, e) => pb_cancelar_clicked();
            this.Load += (s, e) => this.dw_1.Focus();
        }
        public void pb_continuar_clicked(){}
        public void pb_cancelar_clicked(){ this.Close(); }
        public void uo_informar_no_existen_datos() => MessageBox.Show("No existen datos!", "Atención!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void uo_informar_mensaje(string mensaje) => MessageBox.Show(mensaje ?? string.Empty, "Atención!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}