using Minotti.Data;
using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Models;
using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Minotti.Views.Repertorizaciones.Controls
{
    /// <summary>
    /// Migrado desde PB Window 'w_carga_reperto_parcial_multiple_bak' (deriva de w_carga).
    /// Se preservan nombres y se integra lógica visible (sin inventar).
    /// </summary>
    public partial class w_carga_reperto_parcial_multiple_bak : w_carga
    {
        // ====== PB variables ======
        // uo_ds ds_reperto_total
        private uo_ds? ds_reperto_total;

        // string is_Pasada
        private string? is_Pasada;

        // integer il_Modo
        private int il_Modo = 1;

        public w_carga_reperto_parcial_multiple_bak()
        {
            InitializeComponent();

            // Wiring de eventos (WinForms)
            this.Load += (_, __) =>
            {
                // En PB normalmente se ejecutan eventos del framework (ue_leer_parametros / ue_iniciar)
                // Acá los dejamos explícitos para que lo llames desde tu flujo (OpenWithParm / etc.)
            };

            cb_borrar.Click += cb_borrar_Click;
            cb_grabar.Click += cb_grabar_Click;
            cb_reperto_parcial.Click += cb_reperto_parcial_Click;

            // pb_cancelar viene del ancestro w_carga
            if (pb_cancelar != null)
                pb_cancelar.Click += (_, __) => ue_cancelar();
        }

        // ==========================
        // PB: event ue_leer_parametros (ANCESTOR SCRIPT OVERRIDE)
        // ==========================
        public override void ue_leer_parametros()
        {
            /*
                  ATENCION!!!  ANCESTOR SCRIPT OVERRIDE
            */
            // string param
            // astp_w_seleccion = Message.PowerObjectParm
            astp_w_seleccion = (stp_w_seleccion)utils.Message.PowerObjectParm;

            /*
            Parámetros de param :
              TITULO        titulo de la ventana
              OBJETO        dw control
              DATAOBJECT    dw_lista
              CANT_FILAS    cantidad de lineas en lista que se mostrara
              PARAMETROS[]  parametros de Retrieve de la dw
              MENSAJE       Mensaje a mostrar...
            */
            this.Text = astp_w_seleccion.titulo;

            // dw_1.uof_setdataobject('dk_repertos_parciales')
            dw_1.uof_setdataobject("dk_repertos_parciales");
            dw_1.SetTransObject(SQLCA.Instance);
            dw_1.cant_filas = 5;
            dw_1.uof_marcar_seleccion(1);

            dw_2.uof_setdataobject("dk_reperto_total_tabla_med");
            dw_2.SetTransObject(SQLCA.Instance);
            dw_2.cant_filas = 10;

            dw_3.uof_setdataobject("d_reperto_total_diagnosticos");
            dw_3.SetTransObject(SQLCA.Instance);
            dw_3.cant_filas = 1;

            // Seteo el valor de retorno por defecto en falso
            astr_w_seleccion.opcion = -1;

            // Bordes
            dw_1.Border = true;
            dw_1.BorderStyle = BorderStyle.Fixed3D; // StyleLowered!

            dw_2.Border = true;
            dw_2.BorderStyle = BorderStyle.Fixed3D;

            // ds_reperto_total = CREATE USING 'uo_ds'
            ds_reperto_total = new uo_ds();
            ds_reperto_total.uof_setdataobject("d_reperto_total");
            ds_reperto_total.SetTransObject(SQLCA.Instance);
        }

        // ==========================
        // PB: event ue_iniciar
        // ==========================
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            // Long i (no usado)
            // String ls_Argumentos[]
            // astp_w_seleccion = Message.PowerObjectParm
            astp_w_seleccion = (stp_w_seleccion)utils.Message.PowerObjectParm;

            // recupero las repertorizaciones parciales.
            string[] ls_Argumentos = astp_w_seleccion.parametros;
            dw_1.uof_retrieve(ls_Argumentos);

            // armo el cuadrito de abajo.
            wf_dibujar_detalle();

            if (dw_1.RowCount() > 0)
            {
                dw_1.SelectRow(1, true);
            }
        }

        // ==========================
        // PB: event ue_acomodar_objetos
        // ==========================
        public override void ue_acomodar_objetos()
        {
            // integer borde_boton (comentado en PB)

            if (il_Modo == 1)
            {
                dw_1.Visible = true;
                dw_2.Visible = true;
                dw_3.Visible = false;
                pb_continuar.Visible = false;
                pb_cancelar.Visible = true;
                cb_borrar.Visible = false;
                cb_grabar.Visible = true;
                cb_reperto_parcial.Visible = true;

                // dw_1 size
                dw_1.Height = dw_1.uof_largo();
                dw_1.Width = dw_1.uof_ancho();
                dw_1.Top = s_esp.borde;
                dw_1.Left = s_esp.borde;

                // ventana size
                this.Height = dw_1.uof_largo() + dw_2.uof_largo() + 6 * s_esp.borde + pb_cancelar.Height + s_esp.largo;
                this.Width = Math.Max(dw_1.Width, pb_cancelar.Width * 4 + s_esp.borde) + 2 * s_esp.borde + s_esp.ancho;

                // dw_2
                dw_2.Height = dw_2.uof_largo();
                dw_2.Width = dw_1.Width;
                dw_2.Top = dw_1.Height + (2 * s_esp.borde);
                dw_2.Left = s_esp.borde;

                pb_cancelar.Left = s_esp.borde;
                pb_cancelar.Top = dw_2.Top + dw_2.Height + s_esp.borde;

                cb_grabar.Left = pb_cancelar.Left + pb_cancelar.Width + s_esp.borde;
                cb_grabar.Top = pb_cancelar.Top;

                cb_reperto_parcial.Left = cb_grabar.Left + cb_grabar.Width + s_esp.borde;
                cb_reperto_parcial.Top = pb_cancelar.Top;
            }
            else if (il_Modo == 2)
            {
                dw_1.Visible = true;
                dw_2.Visible = false;
                dw_3.Visible = true;
                pb_continuar.Visible = false;
                pb_cancelar.Visible = true;
                cb_borrar.Visible = false;
                cb_grabar.Visible = true;
                cb_reperto_parcial.Visible = true;

                // dw_1
                dw_1.Height = dw_1.uof_largo();
                dw_1.Width = dw_1.uof_ancho();
                dw_1.Top = s_esp.borde;
                dw_1.Left = s_esp.borde;

                // ventana
                this.Height = dw_1.uof_largo() + dw_3.uof_largo() + 6 * s_esp.borde + pb_cancelar.Height + s_esp.largo;
                this.Width = Math.Max(dw_1.Width, pb_cancelar.Width * 4 + s_esp.borde) + 2 * s_esp.borde + s_esp.ancho;

                // dw_3
                dw_3.Height = dw_3.uof_largo();
                dw_3.Width = dw_3.uof_ancho();
                dw_3.Left = s_esp.borde;
                dw_3.Top = dw_1.Height + (2 * s_esp.borde);

                pb_cancelar.Left = s_esp.borde;
                pb_cancelar.Top = dw_3.Top + dw_3.Height + s_esp.borde;

                cb_grabar.Left = pb_cancelar.Left + pb_cancelar.Width + s_esp.borde;
                cb_grabar.Top = pb_cancelar.Top;

                cb_reperto_parcial.Left = cb_grabar.Left + cb_grabar.Width + s_esp.borde;
                cb_reperto_parcial.Top = pb_cancelar.Top;
            }

            this.wf_centrar_response();
        }

        // ==========================
        // PB: event ue_cancelar (ANCESTOR SCRIPT OVERRIDE)
        // ==========================
        public override void ue_cancelar()
        {
            if (il_Modo == 1)
            {
                this.Close();
            }
            else if (il_Modo == 2)
            {
                il_Modo = 1;
                this.ue_acomodar_objetos();
            }
        }

        // ==========================
        // PB: event close
        // ==========================
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (dw_2 != null) CloseUserObject(dw_2);
            if (dw_3 != null) CloseUserObject(dw_3);
        }

        // ==========================
        // PB: function wf_dibujar_detalle() returns long
        // ==========================
        public long wf_dibujar_detalle()
        {
            long ll_Fila;
            long ll_Fila2;
            long ll_Cnt;
            long ll_TotalRemedios;
            decimal ldec_Orden;
            string ls_Columna;
            string ls_Puntuacion;
            long ll_Valor;
            long ll_Suma;

            // integer i
            int i;

            // uo_ds ds_medicacion, ds_consulta
            uo_ds ds_medicacion;
            uo_ds ds_consulta;

            // long ll_RepertoParcial
            long ll_RepertoParcial;

            // long ll_Orden
            long ll_Orden;

            // long ll_Puntaje
            long ll_Puntaje;

            // long ll_RepertoTotal
            long ll_RepertoTotal;

            // boolean lb_Existe
            bool lb_Existe = false;

            // dw_2.Reset()
            dw_2.Reset();
            dw_3.Reset();

            ds_medicacion = new uo_ds();
            ds_medicacion.uof_setdataobject("dsto_medicamentos_reperto_parc");
            ds_medicacion.SetTransObject(SQLCA.Instance);
            ds_medicacion.cant_filas = 10;

            // RECUPERO EL REPERTO TOTAL
            ll_RepertoTotal = 1;
            ds_medicacion.uof_retrieve(new[] { ll_RepertoTotal.ToString() });

            // COPIO LA ESTRUCTURA DE ds_medicacion a dw_2
            //ds_medicacion.ShareData(dw_2);
            ds_medicacion.share_data(dw_2);

            // RECORRO LOS SINTOMAS (dw_1)
            for (ll_Fila = 1; ll_Fila <= dw_1.RowCount(); ll_Fila++)
            {
                ll_RepertoParcial = (long)dw_1.GetItemNumber(ll_Fila, "reperto_parcial");
                ll_Orden = (long)dw_1.GetItemNumber(ll_Fila, "orden");

                // RECUPERO LOS DATOS DEL REPERTO PARCIAL
                ds_consulta = new uo_ds();
                ds_consulta.uof_setdataobject("d_reperto_total");
                ds_consulta.SetTransObject(SQLCA.Instance);

                string[] ls_Argumentos = new string[2];
                ls_Argumentos[0] = ll_RepertoParcial.ToString();
                ls_Argumentos[1] = ll_Orden.ToString();

                ds_consulta.uof_retrieve(ls_Argumentos);

                // RECORRO LOS MEDICAMENTOS Y SUMO VALORES
                for (ll_Fila2 = 1; ll_Fila2 <= ds_consulta.RowCount(); ll_Fila2++)
                {
                    ll_Cnt = (long)ds_consulta.GetItemNumber(ll_Fila2, "medicamento_codigo");
                    ll_Puntaje = (long)ds_consulta.GetItemNumber(ll_Fila2, "valor");

                    if (ll_Puntaje > 0)
                    {
                        lb_Existe = false;
                        for (ll_Cnt = 1; ll_Cnt <= dw_2.RowCount(); ll_Cnt++)
                        {
                            if (dw_2.GetItemNumber(ll_Cnt, "medicamento_codigo") ==
                                ds_consulta.GetItemNumber(ll_Fila2, "medicamento_codigo"))
                            {
                                lb_Existe = true;
                                break;
                            }
                        }

                        if (lb_Existe)
                        {
                            ls_Columna = "valor" + ll_Fila.ToString();
                            dw_2.SetItem(ll_Cnt, ls_Columna, ll_Puntaje);
                            dw_2.SetItem(ll_Cnt, "nombre", ds_consulta.GetItemString(ll_Fila2, "nombre"));
                        }
                    }
                }

                // recupero el total de la repertorizacion para el diagnostico
                if (ll_Fila == 1)
                {
                    dw_3.uof_retrieve(new[] { ll_RepertoParcial.ToString(), ll_Orden.ToString() });
                }
                else
                {
                    ll_Orden = 1;
                    dw_3.uof_retrieve(new[] { ll_RepertoParcial.ToString(), ll_Orden.ToString() });
                }

                ds_consulta.Reset();
                ds_consulta.Dispose();
            }

            // Ahora saco la puntuacion.
            ll_TotalRemedios = dw_2.RowCount();
            for (ll_Fila = 1; ll_Fila <= ll_TotalRemedios; ll_Fila++)
            {
                i = 0;
                ll_Suma = 0;
                for (ll_Fila2 = 1; ll_Fila2 <= 31; ll_Fila2++)
                {
                    ls_Columna = "valor" + ll_Fila2.ToString();
                    ll_Valor = (long)dw_2.GetItemNumber(ll_Fila, ls_Columna);
                    if (ll_Valor > 0)
                    {
                        i++;
                        ll_Suma = ll_Suma + ll_Valor;
                    }
                }

                ls_Puntuacion = i.ToString() + "/" + ll_TotalRemedios.ToString();
                dw_2.SetItem(ll_Fila, "puntuacion", ls_Puntuacion);

                // ldec_Orden = i + (i / ll_Suma)
                // Nota: en PB es decimal; acá lo mantenemos como decimal
                ldec_Orden = (decimal)i + (ll_Suma == 0 ? 0 : ((decimal)i / (decimal)ll_Suma));
                dw_2.SetItem(ll_Fila, "orden", ldec_Orden);
            }

            dw_2.SetSort("orden D");
            dw_2.Sort();
            dw_2.SetRedraw(true);

            ds_medicacion.Reset();
            ds_medicacion.Dispose();

            return 1;
        }

        // ==========================
        // PB: cb_borrar clicked
        // ==========================
        private void cb_borrar_Click(object? sender, EventArgs e)
        {
            long ll_Orden = dw_1.GetRow();
            if (ll_Orden > 0)
            {
                long ll_Rtn = MessageBoxPB.MessageBox("Borrar Síntoma",
                    "Esta seguro que desea borrar el síntoma de orden: " + ll_Orden,
                    MessageBoxIcon.Question,
                    MessageBoxButtons.YesNo);

                if (ll_Rtn == 1)
                {
                    dw_1.DeleteRow(ll_Orden);
                    wf_dibujar_detalle();
                }
            }
        }

        // ==========================
        // PB: cb_grabar clicked
        // ==========================
        private void cb_grabar_Click(object? sender, EventArgs e)
        {
            long ll_Fila, ll_FilaNueva, ll_RepertoTotal, ll_Paciente;
            DateTime ld_Fecha;

            // HAY QUE GRABAR LA REPERTO TOTAL.
            if (il_Modo == 2)
            {
                // Controlo antes de grabar que estén los datos obligatorios de dw_3.
                ll_Paciente = (long)dw_3.GetItemNumber(1, "paciente");
                if (IsNull(ll_Paciente))
                {
                    MessageBoxPB.MessageBox("Validar", "Debe ingresar el paciente para el que esta realizando la repertorización.",
                        MessageBoxIcon.Stop, MessageBoxButtons.OK);
                    return;
                }

                // NUEVO CODIGO DE REPERTO TOTAL
                ll_RepertoTotal = f_reperto_tot_codigo_nuevo();

                // CARGO REPERTO TOTAL
                if (ds_reperto_total == null)
                    return;

                for (ll_Fila = 1; ll_Fila <= dw_1.RowCount(); ll_Fila++)
                {
                    ll_FilaNueva = ds_reperto_total.InsertRow(0);
                    ds_reperto_total.SetItem(ll_FilaNueva, "reperto_total", ll_RepertoTotal);
                    ds_reperto_total.SetItem(ll_FilaNueva, "reperto_parcial", dw_1.GetItemNumber(ll_Fila, "reperto_parcial"));
                    ds_reperto_total.SetItem(ll_FilaNueva, "orden", ll_FilaNueva);
                }

                // CARGO CODIGO REPERTO EN LOS MEDICAMENTOS.
                for (ll_Fila = 1; ll_Fila <= dw_2.RowCount(); ll_Fila++)
                {
                    dw_2.SetItem(ll_Fila, "reperto_total", ll_RepertoTotal);
                }

                // CARGO CODIGO REPERTO EN EL DIAGNOSTICO.
                dw_3.SetItem(1, "reperto_total", ll_RepertoTotal);

                // GRABO LAS 3 DATAWINDOWS.
                ds_reperto_total.Update();
                dw_2.Update();
                dw_3.Update();
            }
            else if (il_Modo == 1)
            {
                // HAY QUE REDIBUJAR LA VENTANA Y MOSTRAR LA NUEVA DATAWINDOW.
                il_Modo = 2;

                ll_Fila = dw_3.InsertRow(0);
                ld_Fecha = DateTime.Today;
                dw_3.SetItem(ll_Fila, "fecha", ld_Fecha);

                // Parent.TriggerEvent("ue_acomodar_objetos")
                // En WinForms: llamamos directamente
                this.ue_acomodar_objetos();
            }
        }

        // ==========================
        // PB: cb_reperto_parcial clicked
        // ==========================
        private void cb_reperto_parcial_Click(object? sender, EventArgs e)
        {
            is_Pasada = "PARCIAL";
            wf_dibujar_detalle();
        }

        // ==========================
        // Helpers PB
        // ==========================
        private static bool IsNull(long value) => false; // en tu framework PB suele haber IsNull real; acá no invento lógica de negocio.
                                                         // Si ya tenés IsNull(...) global, borrá este helper y usá el tuyo.

        // En PB existe f_reperto_tot_codigo_nuevo(). Acá lo invoco tal cual.
        // Si lo tenés global/static en otro lado, ajustá el call.
        private static long f_reperto_tot_codigo_nuevo()
        {
            // NO invento implementación: si vos ya lo tenés migrado, eliminá este throw y llamá al tuyo.
            throw new NotImplementedException("f_reperto_tot_codigo_nuevo() debe existir en tu migración (PB).");
        }
    }
}