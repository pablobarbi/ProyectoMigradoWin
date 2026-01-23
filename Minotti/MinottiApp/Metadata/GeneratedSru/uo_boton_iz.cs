using Minotti.utils;
using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Metadata.GeneratedSru
{
    /// <summary>
    /// PB:
    /// $PBExportHeader$uo_boton_iz.sru
    /// </summary>
    public class uo_boton_iz : Button
    {
        public uo_boton_iz()
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
                10f,              // PB permite negativo, WinForms no
                FontStyle.Regular // Weight=400
            );

            // =========================
            // Imagen normal
            // =========================
            try
            {
                this.Image = Image.FromFile(FileUtils.GetAppFile("Pictures", "izq.bmp"));
            }
            catch
            {
                // PB: si no existe, no rompe
            }

            // =========================
            // Imagen deshabilitada
            // =========================
            try
            {
                this.EnabledChanged += (s, e) =>
                {
                    if (this.Enabled)
                        this.Image = Image.FromFile(FileUtils.GetAppFile("Pictures", "izq.bmp"));
                    else
                        this.Image = Image.FromFile(FileUtils.GetAppFile("Pictures", "dizq.bmp"));
                };
            }
            catch
            {
                // comportamiento silencioso como PB
            }
        }
    }
}








