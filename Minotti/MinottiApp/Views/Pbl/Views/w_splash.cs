using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Pbl.Views
{
    public partial class w_splash : Form
    {
        public cat_splash at_splash { get; set; }

        public w_splash()
        {
            InitializeComponent();

            // ===== SPLASH FIJO Y CHICO =====
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;

            // Tamaño splash (AJUSTADO)
            this.ClientSize = new Size(520, 320);

            // Evita escalado DPI raro
            this.AutoScaleMode = AutoScaleMode.None;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // === Cargar datos ===
            if (at_splash != null)
            {
                st_nombre.Text = at_splash.Nombre ?? "";
                st_version.Text = $"Versión: {at_splash.Version}";
                st_copyright.Text = at_splash.Copyright ?? "";

                if (!string.IsNullOrWhiteSpace(at_splash.Logo))
                {
                    try
                    {
                        p_logo.ImageLocation = at_splash.Logo;
                    }
                    catch { }
                }
            }

            // === Timer seguro ===
            int segundos = at_splash?.segundos ?? 2;
            timer1.Interval = segundos * 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Close();
        }
    }
}