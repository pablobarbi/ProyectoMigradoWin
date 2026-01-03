namespace Minotti
{
    partial class w_reperto_anterior_multiple_lista
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Button pb_total;
        public System.Windows.Forms.Button pb_parcial;
        public System.Windows.Forms.Button pb_ver;

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
            this.pb_total = new System.Windows.Forms.Button();
            this.pb_parcial = new System.Windows.Forms.Button();
            this.pb_ver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pb_total
            // 
            this.pb_total.Name = "pb_total";
            this.pb_total.Text = "pb_total";
            this.pb_total.Width = 120;
            this.pb_total.Height = 32;
            this.pb_total.Left = 24;
            this.pb_total.Top = 24;
            // 
            // pb_parcial
            // 
            this.pb_parcial.Name = "pb_parcial";
            this.pb_parcial.Text = "pb_parcial";
            this.pb_parcial.Width = 120;
            this.pb_parcial.Height = 32;
            this.pb_parcial.Left = 160;
            this.pb_parcial.Top = 24;
            // 
            // pb_ver
            // 
            this.pb_ver.Name = "pb_ver";
            this.pb_ver.Text = "pb_ver";
            this.pb_ver.Width = 120;
            this.pb_ver.Height = 32;
            this.pb_ver.Left = 296;
            this.pb_ver.Top = 24;
            // 
            // w_reperto_anterior_multiple_lista
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pb_ver);
            this.Controls.Add(this.pb_parcial);
            this.Controls.Add(this.pb_total);
            this.Name = "w_reperto_anterior_multiple_lista";
            this.Text = "w_reperto_anterior_multiple_lista";
            this.Width = 1000;
            this.Height = 700;
            this.ResumeLayout(false);
        }
    }
}