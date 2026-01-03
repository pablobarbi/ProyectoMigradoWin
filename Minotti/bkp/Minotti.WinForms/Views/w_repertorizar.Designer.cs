namespace Minotti
{
    partial class w_repertorizar
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.DataGridView dw_1;
        public System.Windows.Forms.DataGridView dw_2;
        public System.Windows.Forms.DataGridView dw_3;
        public System.Windows.Forms.Button cb_borrar;
        public System.Windows.Forms.Button cb_grabar;
        public System.Windows.Forms.Button pb_continuar;
        public System.Windows.Forms.Button pb_cancelar;
        protected override void Dispose(bool disposing){ if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dw_1 = new System.Windows.Forms.DataGridView();
            this.dw_2 = new System.Windows.Forms.DataGridView();
            this.dw_3 = new System.Windows.Forms.DataGridView();
            this.cb_borrar = new System.Windows.Forms.Button();
            this.cb_grabar = new System.Windows.Forms.Button();
            this.pb_continuar = new System.Windows.Forms.Button();
            this.pb_cancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dw_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dw_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dw_3)).BeginInit();
            this.SuspendLayout();
            this.dw_1.AllowUserToAddRows = false;
            this.dw_1.AllowUserToDeleteRows = false;
            this.dw_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dw_1.AutoGenerateColumns = true;
            this.dw_1.Location = new System.Drawing.Point(32, 32);
            this.dw_1.Name = "dw_1";
            this.dw_1.Size = new System.Drawing.Size(742, 113);
            this.dw_1.TabIndex = 0;
            this.dw_2.AllowUserToAddRows = false;
            this.dw_2.AllowUserToDeleteRows = false;
            this.dw_2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dw_2.AutoGenerateColumns = true;
            this.dw_2.Location = new System.Drawing.Point(32, 504);
            this.dw_2.Name = "dw_2";
            this.dw_2.Size = new System.Drawing.Size(742, 159);
            this.dw_2.TabIndex = 1;
            this.dw_3.AllowUserToAddRows = false;
            this.dw_3.AllowUserToDeleteRows = false;
            this.dw_3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dw_3.AutoGenerateColumns = true;
            this.dw_3.Location = new System.Drawing.Point(78, 156);
            this.dw_3.Name = "dw_3";
            this.dw_3.Size = new System.Drawing.Size(600, 217);
            this.dw_3.TabIndex = 2;
            this.cb_borrar.Location = new System.Drawing.Point(933, 1204);
            this.cb_borrar.Name = "cb_borrar";
            this.cb_borrar.Size = new System.Drawing.Size(120, 32);
            this.cb_borrar.TabIndex = 3;
            this.cb_borrar.Text = "_Borrar Síntoma";
            this.cb_borrar.UseVisualStyleBackColor = true;
            this.cb_grabar.Location = new System.Drawing.Point(1454, 1208);
            this.cb_grabar.Name = "cb_grabar";
            this.cb_grabar.Size = new System.Drawing.Size(120, 32);
            this.cb_grabar.TabIndex = 4;
            this.cb_grabar.Text = "_Grabar";
            this.cb_grabar.UseVisualStyleBackColor = true;
            this.pb_continuar.Location = new System.Drawing.Point(69, 1196);
            this.pb_continuar.Name = "pb_continuar";
            this.pb_continuar.Size = new System.Drawing.Size(120, 32);
            this.pb_continuar.TabIndex = 5;
            this.pb_continuar.Text = "Continuar";
            this.pb_continuar.UseVisualStyleBackColor = true;
            this.pb_cancelar.Location = new System.Drawing.Point(507, 1200);
            this.pb_cancelar.Name = "pb_cancelar";
            this.pb_cancelar.Size = new System.Drawing.Size(120, 32);
            this.pb_cancelar.TabIndex = 6;
            this.pb_cancelar.Text = "Cancelar";
            this.pb_cancelar.UseVisualStyleBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pb_cancelar);
            this.Controls.Add(this.pb_continuar);
            this.Controls.Add(this.cb_grabar);
            this.Controls.Add(this.cb_borrar);
            this.Controls.Add(this.dw_3);
            this.Controls.Add(this.dw_2);
            this.Controls.Add(this.dw_1);
            this.Name = "w_repertorizar";
            this.Text = "w_repertorizar";
            this.Width = 1800;
            this.Height = 1300;
            ((System.ComponentModel.ISupportInitialize)(this.dw_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dw_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dw_3)).EndInit();
            this.ResumeLayout(false);
        }
    }
}