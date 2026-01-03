namespace Minotti.Views
{
    partial class w_multilinea_bak
    {
        private System.Windows.Forms.Button pb_1;
        private System.Windows.Forms.Button pb_2;
        private dynamic dw_1;
        private dynamic dw_2;

        private void InitializeComponent()
        {
            this.pb_1 = new System.Windows.Forms.Button();
            this.pb_2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pb_1
            // 
            this.pb_1.Name = "pb_1";
            this.pb_1.Text = "Insertar";
            this.pb_1.UseVisualStyleBackColor = true;
            this.pb_1.Click += (s, e) => ue_insertar_item();
            // 
            // pb_2
            // 
            this.pb_2.Name = "pb_2";
            this.pb_2.Text = "Borrar";
            this.pb_2.UseVisualStyleBackColor = true;
            this.pb_2.Click += (s, e) => ue_borrar_item();
            // 
            // w_multilinea_bak
            // 
            this.Controls.Add(this.pb_1);
            this.Controls.Add(this.pb_2);
            this.Name = "w_multilinea_bak";
            this.Text = "w_multilinea_bak";
            this.ResumeLayout(false);
        }
    }
}
