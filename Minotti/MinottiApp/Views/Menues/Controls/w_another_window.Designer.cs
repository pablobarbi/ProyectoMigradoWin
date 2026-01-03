using System.ComponentModel;
using System.Windows.Forms;

namespace Minotti.Views.Menues.Controls
{
    partial class w_another_window
    {
        private IContainer? components = null;

        private Button cb_1;
        private Label st_1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cb_1 = new System.Windows.Forms.Button();
            this.st_1 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // w_another_window (Form)
            // PB:
            // int X=1056, int Y=484, int Width=1413, int Height=456
            // boolean TitleBar=true, Title="Helloooo...."
            // long BackColor=80269524
            // boolean ControlMenu=true
            // WindowType=response!
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 456);
            this.Location = new System.Drawing.Point(1056, 484);
            this.Text = "Helloooo....";

            // TitleBar=true + ControlMenu=true
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable; // titlebar visible
            this.ControlBox = true;

            // BackColor=80269524 (PB long ARGB-like). No asumo formato.
            // WinForms usa Color ARGB. Si tu app tiene conversor PBColor->Color, usalo acá.
            // Para no inventar, lo dejo como FromArgb(int).
            this.BackColor = System.Drawing.Color.FromArgb(unchecked((int)80269524));

            // WindowType=response! (en PB suele ser no resizable + no min/max)
            // No lo pusiste en este window PB salvo response!. Mantengo comportamiento "response".
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = true;

            // 
            // cb_1
            // PB:
            // int X=535, Y=236, Width=311, Height=92, TabOrder=10
            // Text="Close", Default=true, Cancel=true
            // Font: Tahoma, TextSize=-8, Weight=400
            //
            this.cb_1.Location = new System.Drawing.Point(535, 236);
            this.cb_1.Name = "cb_1";
            this.cb_1.Size = new System.Drawing.Size(311, 92);
            this.cb_1.TabIndex = 10;
            this.cb_1.Text = "Close";
            this.cb_1.UseVisualStyleBackColor = true;
            this.cb_1.Click += new System.EventHandler(this.cb_1_Click);

            // Default=true / Cancel=true
            this.AcceptButton = this.cb_1;
            this.CancelButton = this.cb_1;

            this.cb_1.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 
            // st_1
            // PB:
            // int Y=88, Width=1381, Height=76
            // Enabled=false
            // Text="Another window"
            // Alignment=Center!
            // FocusRectangle=false
            // TextColor=33554432
            // BackColor=67108864
            // Font: Tahoma, TextSize=-10, Weight=400
            //
            this.st_1.Location = new System.Drawing.Point(0, 88);
            this.st_1.Name = "st_1";
            this.st_1.Size = new System.Drawing.Size(1381, 76);
            this.st_1.TabIndex = 0;
            this.st_1.Text = "Another window";
            this.st_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.st_1.Enabled = false;

            this.st_1.ForeColor = System.Drawing.Color.FromArgb(unchecked((int)33554432));
            this.st_1.BackColor = System.Drawing.Color.FromArgb(unchecked((int)67108864));
            this.st_1.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 
            // Controls
            //
            this.Controls.Add(this.cb_1);
            this.Controls.Add(this.st_1);

            this.ResumeLayout(false);
        }
    }
}
