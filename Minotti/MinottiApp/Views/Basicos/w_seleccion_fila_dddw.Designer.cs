using Minotti.utils;
using Minotti.Views.Basicos.Controls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
 

namespace Minotti.Views.Basicos
{
    public partial class w_seleccion_fila_dddw: w_sheet
    {
        private System.ComponentModel.IContainer components = null;

        // PB controls:
        private uo_dw dw_seleccion;
        private Button cb_cancelar;
        private Button cb_ok;
        private datawindow dw_buscar;

        /// <inheritdoc />
        protected  override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dw_seleccion = new uo_dw();
            this.cb_cancelar = new Button();
            this.cb_ok = new Button();
            this.dw_buscar = new uo_dw();

            this.SuspendLayout();

            // 
            // w_seleccion_fila_dddw
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1783, 1177);
            this.Name = "w_seleccion_fila_dddw";
            this.Text = "w_seleccion_fila_dddw";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // 
            // dw_buscar  (PB: X=51, Y=25, Width=1381, Height=89)
            // 
            this.dw_buscar.Name = "dw_buscar";
            this.dw_buscar.Location = new Point(51, 25);
            this.dw_buscar.Size = new Size(1381, 89);
            this.dw_buscar.TabIndex = 0;

            // 
            // dw_seleccion (PB: X=60, Y=129, Width=1578, Height=733)
            // 
            this.dw_seleccion.Name = "dw_seleccion";
            this.dw_seleccion.Location = new Point(60, 129);
            this.dw_seleccion.Size = new Size(1578, 733);
            this.dw_seleccion.TabIndex = 1;

            // 
            // cb_cancelar (PB: X=65, Y=885, Width=339, Height=109)
            // 
            this.cb_cancelar.Name = "cb_cancelar";
            this.cb_cancelar.Text = "&Cancelar";
            this.cb_cancelar.Location = new Point(65, 885);
            this.cb_cancelar.Size = new Size(339, 109);
            this.cb_cancelar.TabIndex = 2;

            // 
            // cb_ok (PB: X=1322, Y=885, Width=316, Height=109)
            // 
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Text = "&Aceptar";
            this.cb_ok.Location = new Point(1322, 885);
            this.cb_ok.Size = new Size(316, 109);
            this.cb_ok.TabIndex = 3;

            // 
            // Controls
            // 
            this.Controls.Add(this.dw_buscar);
            this.Controls.Add(this.dw_seleccion);
            this.Controls.Add(this.cb_cancelar);
            this.Controls.Add(this.cb_ok);

            this.ResumeLayout(false);
        }
    }
}
