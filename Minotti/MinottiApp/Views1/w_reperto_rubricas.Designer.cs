namespace Minotti
{
    partial class w_reperto_rubricas
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.DataGridView dw_buscar;
        public System.Windows.Forms.Label st_capitulo;
        public System.Windows.Forms.Button cb_reperto_parcial;
        public System.Windows.Forms.Button cb_reperto_total;

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
            this.components = new System.ComponentModel.Container();
            this.dw_buscar = new System.Windows.Forms.DataGridView();
            this.st_capitulo = new System.Windows.Forms.Label();
            this.cb_reperto_parcial = new System.Windows.Forms.Button();
            this.cb_reperto_total = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dw_buscar)).BeginInit();
            this.SuspendLayout();
            // 
            // dw_buscar
            // 
            this.dw_buscar.AllowUserToAddRows = false;
            this.dw_buscar.AllowUserToDeleteRows = false;
            this.dw_buscar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dw_buscar.AutoGenerateColumns = true;
            this.dw_buscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.dw_buscar.Height = 320;
            this.dw_buscar.Name = "dw_buscar";
            this.dw_buscar.TabIndex = 0;
            // 
            // st_capitulo
            // 
            this.st_capitulo.Name = "st_capitulo";
            this.st_capitulo.Text = "st_capitulo";
            this.st_capitulo.AutoSize = true;
            this.st_capitulo.Top = 340;
            this.st_capitulo.Left = 20;
            // 
            // cb_reperto_parcial
            // 
            this.cb_reperto_parcial.Name = "cb_reperto_parcial";
            this.cb_reperto_parcial.Text = "_Repertorizar Parcial";
            this.cb_reperto_parcial.Width = 180;
            this.cb_reperto_parcial.Height = 36;
            this.cb_reperto_parcial.Top = 380;
            this.cb_reperto_parcial.Left = 20;
            // 
            // cb_reperto_total
            // 
            this.cb_reperto_total.Name = "cb_reperto_total";
            this.cb_reperto_total.Text = "_Repertorizar Total";
            this.cb_reperto_total.Width = 180;
            this.cb_reperto_total.Height = 36;
            this.cb_reperto_total.Top = 380;
            this.cb_reperto_total.Left = 220;
            // 
            // w_reperto_rubricas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.cb_reperto_total);
            this.Controls.Add(this.cb_reperto_parcial);
            this.Controls.Add(this.st_capitulo);
            this.Controls.Add(this.dw_buscar);
            this.Name = "w_reperto_rubricas";
            this.Text = "w_reperto_rubricas";
            this.Width = 1000;
            this.Height = 700;
            ((System.ComponentModel.ISupportInitialize)(this.dw_buscar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}