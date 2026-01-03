namespace Minotti
{
    partial class w_borra_reperto_parc
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.DataGridView dw_1;
        public System.Windows.Forms.DataGridView dw_buscar;
        private System.Windows.Forms.BindingSource bindingSource1;

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
            this.dw_1 = new System.Windows.Forms.DataGridView();
            this.dw_buscar = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dw_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dw_buscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dw_1
            // 
            this.dw_1.AllowUserToAddRows = false;
            this.dw_1.AllowUserToDeleteRows = true;
            this.dw_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dw_1.AutoGenerateColumns = true;
            this.dw_1.DataSource = this.bindingSource1;
            this.dw_1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dw_1.Height = 300;
            this.dw_1.Name = "dw_1";
            this.dw_1.TabIndex = 0;
            // 
            // dw_buscar
            // 
            this.dw_buscar.AllowUserToAddRows = false;
            this.dw_buscar.AllowUserToDeleteRows = false;
            this.dw_buscar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dw_buscar.AutoGenerateColumns = true;
            this.dw_buscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw_buscar.Name = "dw_buscar";
            this.dw_buscar.TabIndex = 1;
            // 
            // w_borra_reperto_parc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dw_buscar);
            this.Controls.Add(this.dw_1);
            this.Name = "w_borra_reperto_parc";
            this.Text = "w_borra_reperto_parc";
            this.Width = 900;
            this.Height = 600;
            ((System.ComponentModel.ISupportInitialize)(this.dw_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dw_buscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}