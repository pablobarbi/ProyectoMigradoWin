using Minotti.Data;
using Minotti.Functions;
using Minotti.utils;
using Minotti.Views.Basicos.Controls;
using Minotti.Views.Basicos.Models;
using System;
using System.Windows.Forms;


namespace Minotti.Views.Basicos
{


    // PB: global type w_sheet from w_principal
    public partial class w_sheet : w_principal
    {
        // =====================================================
        // Variables (public ) – mismas que en PB
        // =====================================================

        // boolean ib_pasar_por_closequery = TRUE
        public  bool ib_pasar_por_closequery = true;

        // boolean ib_grabar
        public  bool ib_grabar;

        // Boolean ib_AutoCommit
        public  bool ib_AutoCommit;

        // =====================================================
        // Ctor
        // =====================================================

        public w_sheet()
        {
            InitializeComponent();

            // Activar / desactivar botón Cancelar del menú cuando se activa/desactiva
            this.Activated += w_sheet_Activated;
            this.Deactivate += w_sheet_Deactivate;
            this.FormClosing += w_sheet_FormClosing;

            // En PB se ejecuta ue_optar en el ciclo de vida; lo llamamos aquí
            ue_optar();
        }

        // =====================================================
        // Eventos PB → métodos protegidos
        // =====================================================

        /// <summary>
        /// PB: event ue_insertar()
        /// (Base vacío: lo sobreescriben las herencias si lo necesitan)
        /// </summary>
        public  virtual void ue_insertar() { }        
        public  virtual void ue_borrar() { }
        public  virtual void ue_cancelar()
        {
            // PB: Close(This)
            this.Close();
        }

        public  virtual void ue_primero() { }
        public  virtual void ue_anterior() { }
        public  virtual void ue_siguiente() { }
        public  virtual void ue_ultimo() { }
        public  virtual void ue_procesar() { }
        public  virtual void ue_imprimir() { }
        public  virtual void ue_preview() { }
        public  virtual void ue_refresh()
        {
            // PB:
            // Datawindow ldw
            // objeto = GetFocus()
            // If TypeOf(objeto) = datawindow! Then ldw = objeto; ldw.TriggerEvent("ue_refresh")

            var objeto = this.ActiveControl;
            if (objeto is uo_dw dw)
            {
                dw.TriggerEvent("ue_refresh");
            }
        }

        public  virtual void ue_grabar()
        {
            // PB:
            // SetPointer(HourGlass!)
            // SetRedraw(FALSE)
            Cursor = Cursors.WaitCursor;
            this.SuspendLayout();

            // Inicia variable de control
            ib_grabar = true;

            // Pipeline de validaciones previas
            ue_aceptar_datos();
            if (ib_grabar) ue_completar_claves();
            if (ib_grabar) ue_validar_datos();
            if (ib_grabar) ue_preconfirmar();

            // Si algo falló, salir sin tocar transacción
            if (!ib_grabar)
            {
                this.ResumeLayout();
                Cursor = Cursors.Default;
                return;
            }

            // Transacción
            ue_abrir_transaccion();
            if (ib_grabar) ue_confirmar();
            ue_cerrar_transaccion();

            if (ib_grabar)
                ue_posconfirmar();

            ue_finalizar();

            if (this.IsHandleCreated && !this.IsDisposed)
                this.ResumeLayout();

            Cursor = Cursors.Default;
        }

        public  virtual void ue_completar_claves() { }
        public  virtual void ue_validar_datos() { }
        public  virtual void ue_preconfirmar() { }

        public  virtual void ue_abrir_transaccion()
        {
            // PB:
            // SetNull(guo_app.at_error_db.SqlDbCode) ...
            // SQLCA.AutoCommit = FALSE

            if (guo_app.at_error_db != null)
            {
                guo_app.at_error_db.SqlDbCode = null;
                guo_app.at_error_db.SqlErrText = null;
                guo_app.at_error_db.UserErrorCode = null;
                guo_app.at_error_db.UserErrorText = null;
            }

            ib_AutoCommit = SQLCA.AutoCommit;
            SQLCA.AutoCommit = false;
        }

        public  virtual void ue_confirmar()
        {
            // Las herencias hacen el Update/Insert/Delete.
            // Si algo falla, deberían poner ib_grabar = false.
        }

        public  virtual void ue_cerrar_transaccion()
        {
            if (ib_grabar)
            {
                SQLCA.Commit();

                if (SQLCA.SqlCode == 0)
                {
                    MessageBox.Show("Los datos se grabaron correctamente.",
                        "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    // Fallo en commit
                    ib_grabar = false;
                    if (guo_app.at_error_db != null)
                    {
                        guo_app.at_error_db.SqlDbCode = SQLCA.SqlCode;
                        guo_app.at_error_db.SqlErrText = SQLCA.SqlErrText;
                    }
                }
            }

            // Si no se grabó, rollback y mensaje
            if (!ib_grabar)
            {
                SQLCA.Rollback();
                f_error_base_de_datos.ferror_base_de_datos();
            }

            SQLCA.AutoCommit = ib_AutoCommit;
        }

        public  virtual void ue_posconfirmar() { }

        public  virtual void ue_mensaje_error()
        {
            // PB: f_error_base_de_datos()
            f_error_base_de_datos.ferror_base_de_datos();
        }

        public  virtual void ue_finalizar()
        {
            // En PB estaba comentado:
            // ib_pasar_por_closequery = FALSE
            // Lo dejamos igual (no tocamos el flag por ahora).
        }

        public  virtual void ue_aceptar_datos() { }
        public  virtual void ue_preborrar() { }
        public  virtual void ue_posborrar() { }

        public  virtual void ue_eliminar()
        {
            Cursor = Cursors.WaitCursor;
            this.SuspendLayout();

            ib_grabar = true;

            // Eventos previos
            ue_aceptar_datos();
            if (ib_grabar) ue_preborrar();

            if (!ib_grabar)
            {
                this.ResumeLayout();
                Cursor = Cursors.Default;
                return;
            }

            // Transacción
            ue_abrir_transaccion();
            if (ib_grabar) ue_borrar();
            ue_cerrar_transaccion();

            if (ib_grabar) ue_posborrar();
            ue_finalizar();

            if (this.IsHandleCreated && !this.IsDisposed)
                this.ResumeLayout();

            Cursor = Cursors.Default;
        }

        public  virtual void ue_reiniciar() { }
        public  virtual void ue_salvar() { }

        /// <summary>
        /// PB: ue_optar – define espacios de trabajo s_esp y mínimos s_min
        /// </summary>
        public  virtual void ue_optar()
        {
            // s_esp y s_min son estructuras en el ancestro (w_principal / guo_app)
            s_esp.ancho = 30;
            s_esp.largo = 108;
            s_esp.borde = 20;
            s_min.ancho = 30; // 50 // 80
            s_min.largo = 30; // 50 // 80
        }

        /// <summary>
        /// PB: ue_ajustar_posicion
        /// </summary>
        public  virtual void ue_ajustar_posicion()
        {
            // Si no tiene parent MDI, no hace nada
            if (this.MdiParent == null)
                return;

            int ancho_max;
            int largo_max;

            // guo_app.uof_GetMdi().wf_GetAreaTrabajo(ancho_max, largo_max)
            guo_app.Instance.uof_getmdi().wf_GetAreaTrabajo(out ancho_max, out largo_max);

            // Impide que se vaya de pantalla
            if (this.Width > ancho_max) this.Width = ancho_max;
            if (this.Height > largo_max) this.Height = largo_max;

            if (this.Left + this.Width > ancho_max)
                this.Left = Math.Max(0, ancho_max - this.Width);
            if (this.Top + this.Height > largo_max)
                this.Top = Math.Max(0, largo_max - this.Height);
        }

        /// <summary>
        /// PB: ue_llevar_al_minimo
        /// </summary>
        public  virtual void ue_llevar_al_minimo()
        {
            if (this.MdiParent == null)
                return;

            int ancho_max;
            int largo_max;
            guo_app.Instance.uof_getmdi().wf_GetAreaTrabajo(out ancho_max, out largo_max);

            int iAux = (int)(ancho_max * s_min.ancho / 100.0);
            if (this.Width < iAux) this.Width = iAux;

            iAux = (int)(largo_max * s_min.largo / 100.0);
            if (this.Height < iAux) this.Height = iAux;
        }

        /// <summary>
        /// PB: ue_dw_detalle (documentado, vacío en el ancestro)
        /// </summary>
        public  virtual void ue_dw_detalle()
        {
            // Herencias lo implementan si necesitan abrir detalles.
        }

        // =====================================================
        // Funciones wf_* (métodos públicos)
        // =====================================================

        public void wf_alargar(Control objeto)
        {
            objeto.Height = this.Height - (2 * objeto.Top);
        }

        public void wf_centrarobjeto(Control objeto)
        {
            objeto.Left = (this.Width - objeto.Width) / 2 - 10;
        }

        public void wf_centrarobjetohoriz(Control objeto)
        {
            objeto.Top = (this.Height - s_esp.largo - objeto.Height) / 2;
        }

        public int wf_cantparam(string param)
        {
            if (param == null) return 0;

            int contador = 0;
            int iAux = param.IndexOf(',');

            while (iAux >= 0)
            {
                contador++;
                iAux = param.IndexOf(',', iAux + 1);
            }

            // Si hay algo después de la última coma
            var tail = iAux < 0 ? param : param.Substring(iAux + 1);
            if (!string.IsNullOrWhiteSpace(tail))
                contador++;

            return contador;
        }

        public int wf_ancho_disponible()
        {
            // This.Width - s_esp.ancho - 2 * s_esp.borde
            return this.Width - s_esp.ancho - 2 * s_esp.borde;
        }

        public int wf_largo_disponible()
        {
            // This.Height - s_esp.largo - 2 * s_esp.borde
            return this.Height - s_esp.largo - 2 * s_esp.borde;
        }

        public virtual bool wf_cambios_pendientes()
        {
            // Ancestro devuelve False, herencias pueden override
            return false;
        }

        public int wf_abrir_detalle(cat_operacion at_det)
        {
            // PB:
            // w_operacion wAux
            // Retorno = OpenSheetWithParm (wAux, at_det, at_det.uof_GetObjeto(), ParentWindow(), guo_app.Menu.Colgar, Original!)
            var wAux = new w_operacion();
            string objeto = at_det.uof_getobjeto();

            int retorno = OpenSheetWithParm(
                wAux,
                at_det,
                objeto,
                this.MdiParent,
                guo_app.Menu.Colgar,
                "Original"
            );

            return retorno;
        }

        // =====================================================
        // Mapeo de eventos de WinForms a lógica PB
        // =====================================================

        private void w_sheet_Activated(object? sender, EventArgs e)
        {
            // PB: m_mdi.m_operaciones.m_cancelar.Enabled = TRUE
            if (PBGlobals.m_mdi.m_cancelar != null)
                PBGlobals.m_mdi.m_cancelar.Enabled = true;
        }

        private void w_sheet_Deactivate(object? sender, EventArgs e)
        {
            // PB: m_mdi.m_operaciones.m_cancelar.Enabled = FALSE
            if (PBGlobals.m_mdi?.m_cancelar != null)
                PBGlobals.m_mdi.m_cancelar.Enabled = false;
        }

        /// <summary>
        /// Emula el closequery PB.
        /// </summary>
        private void w_sheet_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!ib_pasar_por_closequery)
                return;

            if (wf_cambios_pendientes())
            {
                // PB: MessageBox(..., YesNoCancel!, default Yes)
                var respuesta = MessageBox.Show(
                    "¿Desea guardar los cambios efectuados en " + this.Text + "?",
                    "Atención",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button1);

                switch (respuesta)
                {
                    case DialogResult.Yes:
                        // Graba y NO se va (como PB: PostEvent ue_grabar y Return 1)
                        ue_grabar();
                        e.Cancel = true;
                        break;

                    case DialogResult.Cancel:
                        // Cancela cierre
                        e.Cancel = true;
                        break;

                    case DialogResult.No:
                        // Sale sin grabar
                        break;
                }
            }
        }

        // =====================================================
        // Helper para OpenSheetWithParm (stub)
        // =====================================================

        private int OpenSheetWithParm(
            w_operacion wAux,
            cat_operacion at_det,
            string objeto,
            Form? parentWindow,
            object menuModo,
            string estilo)
        {
            // Simplificación: mostramos la ventana como MDI child o modal
            if (parentWindow is Form mdi && mdi.IsMdiContainer)
            {
                wAux.MdiParent = mdi;
                wAux.Tag = at_det;
                wAux.Show();
            }
            else
            {
                wAux.Tag = at_det;
                wAux.Show();
            }

            // En PB devuelve un código; aquí devolvemos 1 como OK
            return 1;
        }


        // PB event stub: ue_abrir_siguiente
        public virtual void ue_abrir_siguiente()
        {
            // PB: si el script está vacío, no hace nada.
            // No inventamos lógica.
        }

        // PB events (stubs)
        public virtual void ue_preparar_siguiente() { }
        // Overload con parámetro para tu llamada: base.ue_preparar_siguiente(at_det)
        public virtual void ue_preparar_siguiente(object? at_det)
        {
            // En PB, call super::ue_preparar_siguiente no “hace magia” si el super está vacío.
            // No inventamos lógica: por defecto no hace nada.
            // Si querés, podés delegar al sin parámetros:
            ue_preparar_siguiente();
        }


        // PB-like: TriggerEvent("ue_xxx")
        public virtual void TriggerEvent(string eventName)
        {
            if (string.IsNullOrWhiteSpace(eventName)) return;

            switch (eventName.Trim().ToLowerInvariant())
            {
                case "ue_preparar_siguiente":
                    ue_preparar_siguiente();
                    break;

                case "ue_abrir_siguiente":
                    ue_abrir_siguiente();
                    break;

                default:
                    // PB: si no existe, normalmente no hace nada (o error según implementación)
                    break;
            }
        }

        // PB-like: PostEvent -> WinForms BeginInvoke (si lo necesitás)
        public virtual void PostEvent(string eventName)
        {
            if (string.IsNullOrWhiteSpace(eventName)) return;
            if (IsDisposed) return;

            BeginInvoke(new Action(() => TriggerEvent(eventName)));
        }
    }

    // =================================================================
    // STUBS mínimos – si ya existen, BORRAR estas definiciones
    // =================================================================
    /*
    public class cat_operacion
    {
        public string uof_GetObjeto() => string.Empty;
    }

    public class w_operacion : w_sheet
    {
    }

    public static class m_mdi
    {
        public static (ToolStripMenuItem? m_cancelar) m_operaciones;
    }
    */


}
