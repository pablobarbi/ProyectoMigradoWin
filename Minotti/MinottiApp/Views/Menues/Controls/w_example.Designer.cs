

using Minotti.Views.Menues.Controls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Menues.Controls
{
    partial class w_example
    {
        private IContainer components = null!;

        private uo_link lnk_mail;
        private Button cb_2;
        private Button cb_1;
        private uo_link lnk_7;
        private Label st_7;
        private Label st_5;
        private Label st_4;
        private Label st_3;
        private uo_link lnk_6;
        private uo_link lnk_5;
        private uo_link lnk_4;
        private uo_link lnk_3;
        private uo_link lnk_2;
        private uo_link lnk_1;
        private GroupBox gb_6;
        private GroupBox gb_5;
        private GroupBox gb_4;
        private GroupBox gb_3;
        private GroupBox gb_2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();

            this.lnk_mail = new uo_link();
            this.cb_2 = new Button();
            this.cb_1 = new Button();
            this.lnk_7 = new uo_link();
            this.st_7 = new Label();
            this.st_5 = new Label();
            this.st_4 = new Label();
            this.st_3 = new Label();
            this.lnk_6 = new uo_link();
            this.lnk_5 = new uo_link();
            this.lnk_4 = new uo_link();
            this.lnk_3 = new uo_link();
            this.lnk_2 = new uo_link();
            this.lnk_1 = new uo_link();
            this.gb_6 = new GroupBox();
            this.gb_5 = new GroupBox();
            this.gb_4 = new GroupBox();
            this.gb_3 = new GroupBox();
            this.gb_2 = new GroupBox();

            // === FORM ===
            this.ClientSize = new Size(1513, 1416);
            this.Text = "HiperLink object sample";
            this.BackColor = Color.FromArgb(unchecked((int)80269524));
            this.MinimizeBox = true;

            // === cb_1 ===
            cb_1.Text = "&Close";
            cb_1.Location = new Point(1134, 1188);
            cb_1.Size = new Size(315, 96);
            cb_1.Click += cb_1_Click;

            // === cb_2 ===
            cb_2.Text = "&?";
            cb_2.Location = new Point(987, 1188);
            cb_2.Size = new Size(114, 96);
            cb_2.Click += cb_2_Click;

            // === lnk_mail ===
            lnk_mail.Location = new Point(41, 1200);
            lnk_mail.Size = new Size(448, 64);
            lnk_mail.Text = "Source by JoseMan";
            lnk_mail.Link += lnk_mail_Link;

            // === Labels ===
            st_4.Text = "Open Window:";
            st_4.Location = new Point(23, 28);

            st_5.Text = "Execute a program:";
            st_5.Location = new Point(23, 208);

            st_3.Text = "Events:";
            st_3.Location = new Point(23, 388);

            st_7.Text = "Custom:";
            st_7.Location = new Point(23, 840);

            // === Controls ===
            Controls.AddRange(new Control[]
            {
                lnk_mail, cb_2, cb_1,
                lnk_7, st_7, st_5, st_4, st_3,
                lnk_6, lnk_5, lnk_4, lnk_3, lnk_2, lnk_1,
                gb_6, gb_5, gb_4, gb_3, gb_2
            });
        }
    }
}
