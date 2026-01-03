using System;
using System.Drawing;
using System.Windows.Forms;
using Minotti.Models;
using Minotti.Controls;

namespace Minotti.Views1
{
    // Migración de PowerBuilder: w_operacion.srw (window base) desde w_sheet
    // Mantiene el nombre del tipo: w_operacion
    public partial class w_operacion : Form
    {
        // ===== Variables base habituales en PB (mismos nombres) =====
        public bool ib_grabar = true;              // flag de grabación
        public bool ib_cerrar_al_grabar = true;    // cierra al confirmar
        public st_espacios s_esp = new st_espacios(); // márgenes/bordes
        public cat_operacion at_op = new cat_operacion(); // operación actual

        public w_operacion()
        {
            InitializeComponent();
            this.KeyPreview = true; // para mapear ESC como en PB (event key)
        }

        // ===== Eventos PB visibles como métodos con mismo nombre =====
        public virtual void ue_iniciar() { }
        public virtual void ue_leer_parametros() { }
        public virtual void ue_optar() { }
        public virtual void ue_ajustar_tamaño() { }
        public virtual void ue_acomodar_objetos() { }
        public virtual void ue_borrar() { }
        public virtual void ue_confirmar() { }
        public virtual void ue_validar_datos() { }
        public virtual void ue_completar_claves() { }
        public virtual void ue_aceptar_datos() { }
        public virtual void ue_reiniciar() { }

        // Del SRW: eventos adicionales
        public virtual void ue_actualizar() { }
        public virtual void ue_abrir_siguiente() { }
        public virtual bool ue_preparar_siguiente(ref cat_operacion at_det) { return true; }

        // Común en ventanas PB
        public virtual void ue_cancelar() { this.Close(); }

        // ===== Helpers equivalentes a funciones PB usadas por herencias =====
        // Anchura/altura disponible dentro de la hoja
        public virtual int wf_Ancho_Disponible() => this.ClientSize.Width - (s_esp?.ancho ?? 0);
        public virtual int wf_Largo_Disponible() => this.ClientSize.Height - (s_esp?.largo ?? 0);

        // Centrar un control dentro del área disponible
        public virtual void wf_CentrarObjeto(Control ctrl)
        {
            if (ctrl == null) return;
            int x = Math.Max((this.ClientSize.Width - ctrl.Width) / 2, 0);
            ctrl.Location = new Point(x, ctrl.Location.Y);
        }

        // Obtener el próximo parámetro de una cadena y avanzar (equivalente a wf_ProxParam)
        public virtual string wf_ProxParam(ref string parametros)
        {
            if (parametros == null) return string.Empty;
            char[] seps = new[] { ';', ',', '|' };
            int idx = parametros.IndexOfAny(seps);
            string token;
            if (idx < 0) { token = parametros.Trim(); parametros = string.Empty; }
            else { token = parametros.Substring(0, idx).Trim(); parametros = parametros.Substring(idx + 1); }
            return token;
        }

        // ===== Mapeo de teclas (event key en PB) =====
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                // This.PostEvent("ue_cancelar")
                ue_cancelar();
                e.Handled = true;
            }
        }
    }
}
