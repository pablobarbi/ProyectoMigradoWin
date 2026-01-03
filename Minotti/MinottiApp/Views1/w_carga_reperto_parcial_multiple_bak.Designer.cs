namespace Minotti
{
    partial class w_carga_reperto_parcial_multiple_bak
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.DataGridView dw_1;
        public System.Windows.Forms.DataGridView dw_2;
        public System.Windows.Forms.DataGridView dw_3;
        public System.Windows.Forms.Button cb_borrar;
        public System.Windows.Forms.Button cb_grabar;

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
            this.dw_2 = new System.Windows.Forms.DataGridView();
            this.dw_3 = new System.Windows.Forms.DataGridView();
            this.cb_borrar = new System.Windows.Forms.Button();
            this.cb_grabar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dw_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dw_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dw_3)).BeginInit();
            this.SuspendLayout();
            // 
            // dw_1
            // 
            this.dw_1.AllowUserToAddRows = false;
            this.dw_1.AllowUserToDeleteRows = false;
            this.dw_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dw_1.AutoGenerateColumns = true;
            this.dw_1.Location = new System.Drawing.Point(20, 20);
            this.dw_1.Name = "dw_1";
            this.dw_1.Size = new System.Drawing.Size(800, 220);
            this.dw_1.TabIndex = 0;
            // 
            // dw_2
            // 
            this.dw_2.AllowUserToAddRows = false;
            this.dw_2.AllowUserToDeleteRows = false;
            this.dw_2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dw_2.AutoGenerateColumns = true;
            this.dw_2.Location = new System.Drawing.Point(20, 260);
            this.dw_2.Name = "dw_2";
            this.dw_2.Size = new System.Drawing.Size(800, 220);
            this.dw_2.TabIndex = 1;
            // 
            // dw_3
            // 
            this.dw_3.AllowUserToAddRows = false;
            this.dw_3.AllowUserToDeleteRows = false;
            this.dw_3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dw_3.AutoGenerateColumns = true;
            this.dw_3.Location = new System.Drawing.Point(20, 500);
            this.dw_3.Name = "dw_3";
            this.dw_3.Size = new System.Drawing.Size(800, 200);
            this.dw_3.TabIndex = 2;
            // 
            // cb_borrar
            // 
            this.cb_borrar.Location = new System.Drawing.Point(850, 260);
            this.cb_borrar.Name = "cb_borrar";
            this.cb_borrar.Size = new System.Drawing.Size(120, 32);
            this.cb_borrar.TabIndex = 3;
            this.cb_borrar.Text = "_Borrar";
            this.cb_borrar.UseVisualStyleBackColor = true;
            // 
            // cb_grabar
            // 
            this.cb_grabar.Location = new System.Drawing.Point(850, 300);
            this.cb_grabar.Name = "cb_grabar";
            this.cb_grabar.Size = new System.Drawing.Size(120, 32);
            this.cb_grabar.TabIndex = 4;
            this.cb_grabar.Text = "_Guardar";
            this.cb_grabar.UseVisualStyleBackColor = true;
            // 
            // w_carga_reperto_parcial_multiple_bak
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.cb_grabar);
            this.Controls.Add(this.cb_borrar);
            this.Controls.Add(this.dw_3);
            this.Controls.Add(this.dw_2);
            this.Controls.Add(this.dw_1);
            this.Name = "w_carga_reperto_parcial_multiple_bak";
            this.Text = "w_carga_reperto_parcial_multiple_bak";
            this.Width = 1000;
            this.Height = 750;
            ((System.ComponentModel.ISupportInitialize)(this.dw_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dw_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dw_3)).EndInit();
            this.ResumeLayout(false);
        }
    }
}