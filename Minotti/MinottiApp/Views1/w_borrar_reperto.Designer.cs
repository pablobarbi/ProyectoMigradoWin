namespace Minotti
{
    partial class w_borrar_reperto
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.DataGridView dw_buscar;

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
            ((System.ComponentModel.ISupportInitialize)(this.dw_buscar)).BeginInit();
            this.SuspendLayout();
            // 
            // dw_buscar
            // 
            this.dw_buscar.AllowUserToAddRows = false;
            this.dw_buscar.AllowUserToDeleteRows = false;
            this.dw_buscar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dw_buscar.AutoGenerateColumns = true;
            this.dw_buscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw_buscar.Name = "dw_buscar";
            this.dw_buscar.TabIndex = 0;
            // 
            // w_borrar_reperto
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dw_buscar);
            this.Name = "w_borrar_reperto";
            this.Text = "w_borrar_reperto";
            this.Width = 900;
            this.Height = 600;
            ((System.ComponentModel.ISupportInitialize)(this.dw_buscar)).EndInit();
            this.ResumeLayout(false);
        }
    }
}