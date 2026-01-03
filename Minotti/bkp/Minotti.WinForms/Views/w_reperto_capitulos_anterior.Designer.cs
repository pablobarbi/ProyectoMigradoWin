namespace Minotti
{
    partial class w_reperto_capitulos_anterior
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.DataGridView dw_buscar;
        public System.Windows.Forms.Button cb_reperto_parcial;
        public System.Windows.Forms.Button cb_reperto_total;
        protected override void Dispose(bool disposing){ if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dw_buscar = new System.Windows.Forms.DataGridView();
            this.cb_reperto_parcial = new System.Windows.Forms.Button();
            this.cb_reperto_total = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dw_buscar)).BeginInit();
            this.SuspendLayout();
            this.dw_buscar.AllowUserToAddRows = false;
            this.dw_buscar.AllowUserToDeleteRows = false;
            this.dw_buscar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dw_buscar.AutoGenerateColumns = true;
            this.dw_buscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.dw_buscar.Height = 300;
            this.dw_buscar.Name = "dw_buscar";
            this.dw_buscar.TabIndex = 0;
            this.cb_reperto_parcial.Name = "cb_reperto_parcial";
            this.cb_reperto_parcial.Text = "_Repertorizar Parcial";
            this.cb_reperto_parcial.Width = 180;
            this.cb_reperto_parcial.Height = 36;
            this.cb_reperto_parcial.Top = 320;
            this.cb_reperto_parcial.Left = 20;
            this.cb_reperto_total.Name = "cb_reperto_total";
            this.cb_reperto_total.Text = "_Repertorizar Total";
            this.cb_reperto_total.Width = 180;
            this.cb_reperto_total.Height = 36;
            this.cb_reperto_total.Top = 320;
            this.cb_reperto_total.Left = 220;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.cb_reperto_total);
            this.Controls.Add(this.cb_reperto_parcial);
            this.Controls.Add(this.dw_buscar);
            this.Name = "w_reperto_capitulos_anterior";
            this.Text = "w_reperto_capitulos_anterior";
            this.Width = 900;
            this.Height = 600;
            ((System.ComponentModel.ISupportInitialize)(this.dw_buscar)).EndInit();
            this.ResumeLayout(false);
        }
    }
}