
using Minotti.Views.Basicos.Models;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    // Migración de PowerBuilder: w_carga_observaciones.srw (window) desde w_principal
    // Mantiene el nombre del tipo: w_carga_observaciones
    // global type w_carga_observaciones from w_principal
    public partial class w_carga_observaciones : w_principal
    {
        // ========================
        // Variables PB
        // ========================
        // cat_string at_string
        private cat_string at_string = new cat_string();

        public w_carga_observaciones()
        {
            InitializeComponent();

            // Mapear eventos de los botones a la lógica PB
            cb_aceptar.Click += cb_aceptar_clicked;
            cb_cancelar.Click += cb_cancelar_clicked;
        }

        /// <summary>
        /// Constructor que simula el OPEN con parámetro (Message.PowerObjectParm = cat_string).
        /// </summary>
        public w_carga_observaciones(cat_string parametro) : this()
        {
            CargarDesdeParametro(parametro);
        }

        /// <summary>
        /// Equivalente al evento OPEN de PB:
        /// at_string = Message.PowerObjectParm
        /// </summary>
        public void CargarDesdeParametro(cat_string parametro)
        {
            at_string = parametro ?? new cat_string();

            // mle_campo.Text = at_string.string
            mle_campo.Text = at_string.@string ?? string.Empty;

            // mle_campo.limit = at_string.longitud
            mle_campo.MaxLength = at_string.longitud;

            // this.Title = at_string.texto_titulo
            this.Text = at_string.texto_titulo ?? string.Empty;

            // SetFocus
            this.Shown += (s, e) => mle_campo.Focus();
        }

        /// <summary>
        /// Para leer el resultado (equivalente a CloseWithReturn(parent,at_string)).
        /// </summary>
        public cat_string Resultado => at_string;

        // ======================================================
        //  ue_validar_string()  (event type integer ue_validar_string)
        // ======================================================
        public  override int ue_validar_string()
        {
            base.ue_validar_string();

            string texto = mle_campo.Text ?? string.Empty;
            int char_nro;

            string motor = (guo_app.motor_db ?? string.Empty).Trim().ToUpperInvariant();

            switch (motor)
            {
                case "INFORMIX":
                    if (at_string.longitud <= 255)
                    {
                        // TAB
                        char_nro = texto.IndexOf('\t');
                        if (char_nro >= 0)
                        {
                            MessageBox.Show(
                                "No se puede ingresar un caracter TAB!",
                                "Atención",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);

                            mle_campo.Select(char_nro, 1);
                            mle_campo.Focus();
                            return -1;
                        }

                        // ENTER (LF)
                        char_nro = texto.IndexOf('\n');
                        if (char_nro >= 0)
                        {
                            MessageBox.Show(
                                "No se puede ingresar un caracter ENTER!",
                                "Atención",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);

                            // en PB usaban char_nro - 1 para seleccionar antes del ENTER
                            mle_campo.Select(Math.Max(0, char_nro - 1), 1);
                            mle_campo.Focus();
                            return -1;
                        }

                        // CR
                        char_nro = texto.IndexOf('\r');
                        if (char_nro >= 0)
                        {
                            MessageBox.Show(
                                "No se puede ingresar un caracter CR!",
                                "Atención",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);

                            mle_campo.Select(char_nro, 1);
                            mle_campo.Focus();
                            return -1;
                        }

                        // BackSpace
                        char_nro = texto.IndexOf('\b');
                        if (char_nro >= 0)
                        {
                            MessageBox.Show(
                                "No se puede ingresar un caracter BackSpace!",
                                "Atención",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);

                            mle_campo.Select(char_nro, 1);
                            mle_campo.Focus();
                            return -1;
                        }

                        // TAB Vertical (\v)
                        char_nro = texto.IndexOf('\v');
                        if (char_nro >= 0)
                        {
                            MessageBox.Show(
                                "No se puede ingresar un caracter TAB Vertical!",
                                "Atención",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);

                            mle_campo.Select(char_nro, 1);
                            mle_campo.Focus();
                            return -1;
                        }
                    }
                    break;

                case "ANYWHERE":
                case "ORACLE":
                    // No hace nada en PB
                    break;
            }

            return 1;
        }

        // ======================================================
        //  Eventos de botones (equivalentes a clicked)
        // ======================================================

        private void cb_aceptar_clicked(object? sender, EventArgs e)
        {
            // PB:
            // If Parent.Event ue_validar_string() = -1 Then Return
            if (ue_validar_string() == -1)
                return;

            // Cierro la ventana de carga, devuelvo string
            at_string.@string = mle_campo.Text ?? string.Empty;
            at_string.retorno = 1;

            // CloseWithReturn(parent, at_string)
            this.Tag = at_string;     // para que el caller pueda leerlo
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cb_cancelar_clicked(object? sender, EventArgs e)
        {
            // Cierro sin devolver el string (retorno = -1)
            at_string.retorno = -1;

            this.Tag = at_string;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
