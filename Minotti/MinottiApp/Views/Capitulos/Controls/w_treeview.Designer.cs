
namespace Minotti.Views.Capitulos.Controls
{
    partial class w_treeview
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tv_1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tv_1
            // 
            this.tv_1.Location = new System.Drawing.Point(78, 52);
            this.tv_1.Name = "tv_1";
            this.tv_1.Size = new System.Drawing.Size(1733, 1248);
            this.tv_1.TabIndex = 10;

            // Fuente PB:
            // textsize=-10, weight=400, facename="Arial", textcolor=33554432
            this.tv_1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tv_1.ForeColor = System.Drawing.Color.FromArgb(unchecked((int)0xFF200000)); // 33554432 (aprox)

            // PB borderstyle=stylelowered! (equivalente aproximado)
            this.tv_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            // picturemaskcolor/statepicturemaskcolor se aplican via ImageList en WinForms.
            // No invento ImageList porque en PB no pasaste recursos. Si tenés, se agrega y se setea ImageList.
            // 
            // w_treeview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2199, 1516);
            this.Controls.Add(this.tv_1);
            this.Name = "w_treeview";
            this.Text = "w_treeview";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TreeView tv_1;
    }
}
