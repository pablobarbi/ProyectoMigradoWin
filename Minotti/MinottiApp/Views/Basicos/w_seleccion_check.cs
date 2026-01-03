using Minotti.Views.Basicos.Models;
using System;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Minotti.Views.Basicos
{
    // Migración de PowerBuilder: w_seleccion_check.srw (window) desde w_seleccionar
    // Mantiene el nombre del tipo: w_seleccion_check
    // PB: global type w_seleccion_check from w_seleccionar
    public partial class w_seleccion_check : w_seleccionar
    {
        // Guardo las filas seleccionadas para retornarlas a la ventana
        private cat_rw_seleccion atrw = new cat_rw_seleccion();

        // identificador de cual es la columna de la DW con el Check
        private string is_ColumnaCheck;
        private string is_ValorOn;
        private string is_ValorOff;

        private object? _initParam;

        public w_seleccion_check()
        {
            InitializeComponent();

            // Eventos de los botones nuevos
            pb_seleccionar.Click += pb_seleccionar_Click;
            pb_deseleccionar.Click += pb_deseleccionar_Click;

            // Botones heredados
            pb_continuar.Click += pb_continuar_Click;
            pb_cancelar.Click += pb_cancelar_Click;

            this.FormClosed += w_seleccion_check_FormClosed;
        }

        // =========================
        // Eventos equivalentes PB
        // =========================

        /// <summary>
        /// PB: event ue_seleccionar
        /// </summary>
        public virtual void ue_seleccionar()
        {
            if (dw_1 == null || string.IsNullOrEmpty(is_ColumnaCheck))
                return;

            for (int fila = 1; fila <= dw_1.RowCount(); fila++)
            {
                dw_1.SetItem(fila, is_ColumnaCheck, is_ValorOn);
            }
        }

        /// <summary>
        /// PB: event ue_deseleccionar
        /// </summary>
        public  virtual void ue_deseleccionar()
        {
            if (dw_1 == null || string.IsNullOrEmpty(is_ColumnaCheck))
                return;

            for (int fila = 1; fila <= dw_1.RowCount(); fila++)
            {
                dw_1.SetItem(fila, is_ColumnaCheck, is_ValorOff);
            }
        }

        /// <summary>
        /// PB: event ue_cancelar; atrw.opcion = -1; Close(This)
        /// </summary>
        public  override void ue_cancelar()
        {
            atrw.opcion = -1;
            this.Tag = atrw;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// PB: event ue_continuar
        /// </summary>
        public  override void ue_continuar()
        {
            if (dw_1 == null)
                return;

            int rowCount = dw_1.RowCount();
            atrw.opcion = 1;

            // IMPORTANTE: acá asumo que atrw.atr está inicializado y con tamaño suficiente
            // o que lo inicializás como lista. Ajustalo a tu definición real de cat_rw_seleccion.
            int i = 0;
            for (int fila = 1; fila <= rowCount; fila++)
            {
                string[] param = dw_1.uof_getargumentos(fila);
                if (param == null)
                    continue;

                if (atrw.atr == null || i >= atrw.atr.Count)
                {
                    // Si tu implementación usa lista, acá usarías atrw.atr.Add(...)
                    break;
                }

                atrw.atr[i].s_det = param;
                i++;
            }

            this.Tag = atrw;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// PB: event ue_iniciar (override del ancestor)
        /// </summary>
        public  override void ue_iniciar()
        {
            base.ue_iniciar();

            // seteo la devolucion.
            if (this != null)
            {
                atrw.opcion = -1;
            }

            // Marco cual es la fila default.
            // PB: IF NOT IsNull(stp.fila_default) THEN SetItem(...)
            if (dw_1 != null && stp != null && stp.fila_default.HasValue &&
                !string.IsNullOrEmpty(is_ColumnaCheck))
            {
                int filaDefault = stp.fila_default.Value;
                if (filaDefault >= 1 && filaDefault <= dw_1.RowCount())
                {
                    dw_1.SetItem(filaDefault, is_ColumnaCheck, is_ValorOn);
                }
            }
        }

        /// <summary>
        /// PB: event ue_leer_parametros (override)
        /// </summary>
        public  override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            if (dw_1 == null)
                return;

            // Permito seleccionar mas de una Fila
            dw_1.uof_marcar_seleccion(0);

            // Busca cual es el campo CHECKBOX DE LA DW
            // Tiene que haber un solo CHECKBOX; si hay más toma el primero.
            is_ColumnaCheck = null;
            is_ValorOn = null;
            is_ValorOff = null;

            int colCount = int.Parse(dw_1.Describe("DataWindow.Column.Count"));

            for (int iAux = 1; iAux <= colCount; iAux++)
            {
                string snro_col = "#" + iAux.ToString();

                string editStyle = dw_1.Describe(snro_col + ".Edit.Style");
                if (string.Equals(editStyle, "CHECKBOX", StringComparison.OrdinalIgnoreCase))
                {
                    is_ColumnaCheck = dw_1.Describe(snro_col + ".Name");
                    is_ValorOff = dw_1.Describe(snro_col + ".CheckBox.Off");
                    is_ValorOn = dw_1.Describe(snro_col + ".CheckBox.On");
                    break;
                }
            }
        }

        /// <summary>
        /// PB: ue_acomodar_objetos (override con 4 botones)
        /// </summary>
        public  override void ue_acomodar_objetos()
        {
            // ANCESTOR SCRIPT OVERRIDE
            // SE SOBREESCRIBIO EL EVENTO YA QUE AL AGREGAR DOS BOTONES MAS 
            // HAY QUE REHACER EL DIBUJO DE LA VENTANA.

            if (dw_1 == null)
                return;

            int espacio_botones, borde_boton;

            // Para que no se vuelva a ejecutar este evento cuando modifico las dimensiones
            ib_acomodar = false;

            // Le doy tamaño a la datawindow y a la ventana
            int largoDw = dw_1.uof_largo();
            int anchoDw = dw_1.uof_ancho();

            dw_1.Height = largoDw;
            dw_1.Width = anchoDw;
            dw_1.Top = s_esp.borde;
            dw_1.Left = s_esp.borde;

            this.Height = largoDw + 3 * s_esp.borde + pb_cancelar.Height + s_esp.largo;
            this.Width = Math.Max(anchoDw, pb_cancelar.Width * 4 + s_esp.borde)
                          + 4 * s_esp.borde + s_esp.ancho;

            // Acomodo los botones (misma fila Y)
            int yBotones = dw_1.Top + dw_1.Height + s_esp.borde;
            pb_cancelar.Top = yBotones;
            pb_continuar.Top = yBotones;
            pb_seleccionar.Top = yBotones;
            pb_deseleccionar.Top = yBotones;

            espacio_botones = (int)((this.Width - pb_cancelar.Width * 4 - s_esp.borde) / 4.0);
            borde_boton = (int)(espacio_botones * 0.6);

            pb_continuar.Left = borde_boton;
            pb_cancelar.Left = pb_continuar.Left + pb_cancelar.Width + espacio_botones;
            pb_seleccionar.Left = pb_cancelar.Left + pb_cancelar.Width + espacio_botones;
            pb_deseleccionar.Left = pb_seleccionar.Left + pb_seleccionar.Width + espacio_botones;

            // Centro la ventana
            this.wf_centrar_response();
        }

        // =========================
        // Hooks de cierre (PB: close)
        // =========================

        private void w_seleccion_check_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // This.ib_acomodar = False
            ib_acomodar = false;

            if (dw_1 != null)
            {
                dw_1.Dispose();
            }

            if (this.Tag == null)
                this.Tag = atrw;
        }

        // =========================
        // Handlers de botones UI
        // =========================

        private void pb_seleccionar_Click(object? sender, EventArgs e)
        {
            ue_seleccionar();
        }

        private void pb_deseleccionar_Click(object? sender, EventArgs e)
        {
            ue_deseleccionar();
        }

        private void pb_continuar_Click(object? sender, EventArgs e)
        {
            ue_continuar();
        }

        private void pb_cancelar_Click(object? sender, EventArgs e)
        {
            ue_cancelar();
        }

        /// <summary>
        /// Helper tipo "ventana response" para usar desde el llamador.
        /// </summary>
        public static cat_rw_seleccion ShowSeleccionCheck(IWin32Window owner, stp_w_seleccion parametros)
        {
            using (var frm = new w_seleccion_check())
            {
                // base w_seleccionar debería tener algo como InitializeWithParam(stp)
                frm.InitializeWithParam(parametros);
                frm.ShowDialog(owner);
                return (cat_rw_seleccion)frm.Tag!;
            }
        }

        public virtual void InitializeWithParam(object? param)
        {
            // PB: OpenWithParm → guardar parámetro para usar en Load/Shown
            _initParam = param;

            // TODO(PB): si en el SRW había lógica de lectura de parámetros, migrarla acá
            // o llamarla desde Load/Shown.
        }

        // Si querés exponerlo como en PB (Message.PowerObjectParm), opcional:
        protected object? GetInitParam() => _initParam;
    }
}
