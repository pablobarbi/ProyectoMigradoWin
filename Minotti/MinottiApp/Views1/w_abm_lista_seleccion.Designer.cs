namespace Minotti.Views
{
    partial class w_abm_lista_seleccion
    {
        private dw_buscar dw_buscar;

        private void InitializeComponent()
        {
            this.dw_buscar = new dw_buscar();
            this.SuspendLayout();
            // 
            // dw_buscar
            // 
            this.dw_buscar.Name = "dw_buscar";
            this.dw_buscar.TabIndex = 0;
            this.dw_buscar.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // w_abm_lista_seleccion
            // 
            this.Name = "w_abm_lista_seleccion";
            this.Text = "w_abm_lista_seleccion";
            this.Controls.Add(this.dw_buscar);
            this.ResumeLayout(false);
        }
    }
}
