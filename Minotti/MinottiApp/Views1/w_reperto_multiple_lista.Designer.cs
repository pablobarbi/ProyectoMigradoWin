namespace Minotti
{
    partial class w_reperto_multiple_lista
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Button pb_reperto;

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
            this.pb_reperto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pb_reperto
            // 
            this.pb_reperto.Name = "pb_reperto";
            this.pb_reperto.Text = "pb_reperto";
            this.pb_reperto.Width = 140;
            this.pb_reperto.Height = 36;
            this.pb_reperto.Left = 24;
            this.pb_reperto.Top = 24;
            // 
            // w_reperto_multiple_lista
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pb_reperto);
            this.Name = "w_reperto_multiple_lista";
            this.Text = "w_reperto_multiple_lista";
            this.Width = 900;
            this.Height = 600;
            this.ResumeLayout(false);
        }
    }
}