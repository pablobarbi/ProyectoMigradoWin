namespace Minotti
{
    partial class w_ver_medicamentos
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Button pb_continuar;
        public System.Windows.Forms.Button pb_cancelar;
        public System.Windows.Forms.DataGridView dw_1;
        protected override void Dispose(bool disposing){ if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pb_continuar = new System.Windows.Forms.Button();
            this.pb_cancelar = new System.Windows.Forms.Button();
            this.dw_1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dw_1)).BeginInit();
            this.SuspendLayout();
            this.pb_continuar.Name = "pb_continuar";
            this.pb_continuar.Text = "_Guardar Medicamentos";
            this.pb_continuar.Width = 147;
            this.pb_continuar.Height = 32;
            this.pb_continuar.Left = 151;
            this.pb_continuar.Top = 776;
            this.pb_cancelar.Name = "pb_cancelar";
            this.pb_cancelar.Text = "_Cancelar";
            this.pb_cancelar.Width = 147;
            this.pb_cancelar.Height = 32;
            this.pb_cancelar.Left = 1065;
            this.pb_cancelar.Top = 780;
            this.dw_1.AllowUserToAddRows = false;
            this.dw_1.AllowUserToDeleteRows = false;
            this.dw_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dw_1.AutoGenerateColumns = true;
            this.dw_1.Location = new System.Drawing.Point(20, 20);
            this.dw_1.Name = "dw_1";
            this.dw_1.Size = new System.Drawing.Size(1200, 730);
            this.dw_1.TabIndex = 0;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dw_1);
            this.Controls.Add(this.pb_cancelar);
            this.Controls.Add(this.pb_continuar);
            this.Name = "w_ver_medicamentos";
            this.Text = "w_ver_medicamentos";
            this.Width = 1300;
            this.Height = 860;
            ((System.ComponentModel.ISupportInitialize)(this.dw_1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}