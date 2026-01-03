namespace Minotti
{
    partial class w_reperto_subrubricas_ph
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.DataGridView dw_buscar;
        public System.Windows.Forms.Label st_capitulo;
        public System.Windows.Forms.Label st_rubrica;
        public System.Windows.Forms.Label st_subrubrica1;
        public System.Windows.Forms.Label st_subrubrica2;
        public System.Windows.Forms.Label st_subrubrica3;
        public System.Windows.Forms.Label st_subrubrica4;
        public System.Windows.Forms.Label st_subrubrica5;
        public System.Windows.Forms.Label st_subrubrica6;
        public System.Windows.Forms.Label st_subrubrica7;
        public System.Windows.Forms.Label st_subrubrica8;
        public System.Windows.Forms.Button cb_reperto_parcial;
        public System.Windows.Forms.Button cb_reperto_total;
        protected override void Dispose(bool disposing){ if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dw_buscar = new System.Windows.Forms.DataGridView();
            this.st_capitulo = new System.Windows.Forms.Label();
            this.st_rubrica = new System.Windows.Forms.Label();
            this.st_subrubrica1 = new System.Windows.Forms.Label();
            this.st_subrubrica2 = new System.Windows.Forms.Label();
            this.st_subrubrica3 = new System.Windows.Forms.Label();
            this.st_subrubrica4 = new System.Windows.Forms.Label();
            this.st_subrubrica5 = new System.Windows.Forms.Label();
            this.st_subrubrica6 = new System.Windows.Forms.Label();
            this.st_subrubrica7 = new System.Windows.Forms.Label();
            this.st_subrubrica8 = new System.Windows.Forms.Label();
            this.cb_reperto_parcial = new System.Windows.Forms.Button();
            this.cb_reperto_total = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dw_buscar)).BeginInit();
            this.SuspendLayout();
            this.dw_buscar.AllowUserToAddRows = false;
            this.dw_buscar.AllowUserToDeleteRows = false;
            this.dw_buscar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dw_buscar.AutoGenerateColumns = true;
            this.dw_buscar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dw_buscar.Height = 320;
            this.dw_buscar.Name = "dw_buscar";
            this.dw_buscar.TabIndex = 0;
            this.st_capitulo.Name = "st_capitulo";
            this.st_capitulo.Text = "st_capitulo";
            this.st_capitulo.AutoSize = true;
            this.st_capitulo.Top = 20;
            this.st_capitulo.Left = 20;
            this.st_rubrica.Name = "st_rubrica";
            this.st_rubrica.Text = "st_rubrica";
            this.st_rubrica.AutoSize = true;
            this.st_rubrica.Top = 50;
            this.st_rubrica.Left = 20;
            System.Windows.Forms.Label[] subs = new System.Windows.Forms.Label[] {
                this.st_subrubrica1,this.st_subrubrica2,this.st_subrubrica3,this.st_subrubrica4,
                this.st_subrubrica5,this.st_subrubrica6,this.st_subrubrica7,this.st_subrubrica8
            };
            int y = 80;
            for (int i = 0; i < subs.Length; i++)
            {
                subs[i].AutoSize = true;
                subs[i].Text = "st_subrubrica" + (i+1).ToString();
                subs[i].Left = 20;
                subs[i].Top = y;
                y += 26;
            }
            this.cb_reperto_parcial.Name = "cb_reperto_parcial";
            this.cb_reperto_parcial.Text = "_Repertorizar Parcial";
            this.cb_reperto_parcial.Width = 180;
            this.cb_reperto_parcial.Height = 36;
            this.cb_reperto_parcial.Top = 20;
            this.cb_reperto_parcial.Left = 600;
            this.cb_reperto_total.Name = "cb_reperto_total";
            this.cb_reperto_total.Text = "_Repertorizar Total";
            this.cb_reperto_total.Width = 180;
            this.cb_reperto_total.Height = 36;
            this.cb_reperto_total.Top = 60;
            this.cb_reperto_total.Left = 600;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.cb_reperto_total);
            this.Controls.Add(this.cb_reperto_parcial);
            this.Controls.Add(this.st_subrubrica8);
            this.Controls.Add(this.st_subrubrica7);
            this.Controls.Add(this.st_subrubrica6);
            this.Controls.Add(this.st_subrubrica5);
            this.Controls.Add(this.st_subrubrica4);
            this.Controls.Add(this.st_subrubrica3);
            this.Controls.Add(this.st_subrubrica2);
            this.Controls.Add(this.st_subrubrica1);
            this.Controls.Add(this.st_rubrica);
            this.Controls.Add(this.st_capitulo);
            this.Controls.Add(this.dw_buscar);
            this.Name = "w_reperto_subrubricas_ph";
            this.Text = "w_reperto_subrubricas_ph";
            this.Width = 1000;
            this.Height = 700;
            ((System.ComponentModel.ISupportInitialize)(this.dw_buscar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}