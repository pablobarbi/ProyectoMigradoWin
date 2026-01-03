using System.Drawing;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    public partial class w_mdi
    {
        private MenuStrip menuStrip1;
        private ToolStripMenuItem m_operaciones;
        private ToolStripMenuItem m_navegacion;
        private ToolStripMenuItem m_ventanas;
        private ToolStripMenuItem m_ayuda;

        private void InitializeComponent()
        {
            this.menuStrip1 = new MenuStrip();
            this.m_operaciones = new ToolStripMenuItem();
            this.m_navegacion = new ToolStripMenuItem();
            this.m_ventanas = new ToolStripMenuItem();
            this.m_ayuda = new ToolStripMenuItem();

            this.SuspendLayout();

            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new ToolStripItem[] {
                this.m_operaciones,
                this.m_navegacion,
                this.m_ventanas,
                this.m_ayuda
            });
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";

            // 
            // m_operaciones
            // 
            this.m_operaciones.Name = "m_operaciones";
            this.m_operaciones.Size = new Size(95, 20);
            this.m_operaciones.Text = "Operaciones";

            // 
            // m_navegacion
            // 
            this.m_navegacion.Name = "m_navegacion";
            this.m_navegacion.Size = new Size(88, 20);
            this.m_navegacion.Text = "Navegación";

            // 
            // m_ventanas
            // 
            this.m_ventanas.Name = "m_ventanas";
            this.m_ventanas.Size = new Size(72, 20);
            this.m_ventanas.Text = "Ventanas";

            // 
            // m_ayuda
            // 
            this.m_ayuda.Name = "m_ayuda";
            this.m_ayuda.Size = new Size(53, 20);
            this.m_ayuda.Text = "Ayuda";

            // 
            // w_mdi
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = ColorTranslator.FromWin32(unchecked((int)1090519039));
            this.ClientSize = new Size(800, 600);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "w_mdi";
            this.Text = "w_mdi";
            this.WindowState = FormWindowState.Maximized;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
