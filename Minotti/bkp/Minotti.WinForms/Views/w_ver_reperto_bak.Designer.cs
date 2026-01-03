namespace Minotti
{
    partial class w_ver_reperto_bak
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.DataGridView dw_medicamentos;
        public System.Windows.Forms.DataGridView dw_sintomas;
        public System.Windows.Forms.DataGridView dw_1;
        protected override void Dispose(bool disposing){ if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dw_medicamentos = new System.Windows.Forms.DataGridView();
            this.dw_sintomas = new System.Windows.Forms.DataGridView();
            this.dw_1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dw_medicamentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dw_sintomas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dw_1)).BeginInit();
            this.SuspendLayout();
            this.dw_medicamentos.AllowUserToAddRows = false;
            this.dw_medicamentos.AllowUserToDeleteRows = false;
            this.dw_medicamentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dw_medicamentos.AutoGenerateColumns = true;
            this.dw_medicamentos.Location = new System.Drawing.Point(24, 24);
            this.dw_medicamentos.Name = "dw_medicamentos";
            this.dw_medicamentos.Size = new System.Drawing.Size(700, 180);
            this.dw_medicamentos.TabIndex = 0;
            this.dw_sintomas.AllowUserToAddRows = false;
            this.dw_sintomas.AllowUserToDeleteRows = false;
            this.dw_sintomas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dw_sintomas.AutoGenerateColumns = true;
            this.dw_sintomas.Location = new System.Drawing.Point(24, 224);
            this.dw_sintomas.Name = "dw_sintomas";
            this.dw_sintomas.Size = new System.Drawing.Size(700, 180);
            this.dw_sintomas.TabIndex = 1;
            this.dw_1.AllowUserToAddRows = false;
            this.dw_1.AllowUserToDeleteRows = false;
            this.dw_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dw_1.AutoGenerateColumns = true;
            this.dw_1.Location = new System.Drawing.Point(24, 424);
            this.dw_1.Name = "dw_1";
            this.dw_1.Size = new System.Drawing.Size(700, 180);
            this.dw_1.TabIndex = 2;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dw_1);
            this.Controls.Add(this.dw_sintomas);
            this.Controls.Add(this.dw_medicamentos);
            this.Name = "w_ver_reperto_bak";
            this.Text = "w_ver_reperto_bak";
            this.Width = 760;
            this.Height = 650;
            ((System.ComponentModel.ISupportInitialize)(this.dw_medicamentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dw_sintomas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dw_1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}