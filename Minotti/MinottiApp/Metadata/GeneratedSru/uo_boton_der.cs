using Minotti.utils;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Metadata.GeneratedSru
{
    /// <summary>
    /// PB:
    /// $PBExportHeader$uo_boton_der.sru
    /// </summary>
    public class uo_boton_der : Button
    {
        public uo_boton_der()
        {
            // =========================
            // Tamaño y orden
            // =========================
            this.Width = 270;
            this.Height = 221;
            this.TabIndex = 1;

            // =========================
            // Alineación del texto
            // =========================
            this.TextAlign = ContentAlignment.MiddleLeft;

            // =========================
            // Fuente
            // =========================
            // PB:
            // FaceName="Comic Sans MS"
            // TextSize=-10
            // Weight=400
            this.Font = new Font(
                "Comic Sans MS",
                10f,              // PB usa negativo → WinForms no, se usa valor positivo equivalente
                FontStyle.Regular // Weight=400 → Regular
            );

            // =========================
            // Imagen normal
            // =========================
            try
            {
                this.Image = Image.FromFile(FileUtils.GetAppFile("Pictures", "derecha.bmp"));
            }
            catch
            {
                // PB: si no encuentra la imagen, no rompe
            }

            // =========================
            // Imagen deshabilitada
            // =========================
            try
            {
                this.EnabledChanged += (s, e) =>
                {
                    if (this.Enabled)
                        this.Image = Image.FromFile(FileUtils.GetAppFile("Pictures", "derecha.bmp"));
                    else
                        this.Image = Image.FromFile(FileUtils.GetAppFile("Pictures", "dderecha.bmp"));
                };
            }
            catch
            {
                // PB: comportamiento silencioso
            }
        }
    }
}
