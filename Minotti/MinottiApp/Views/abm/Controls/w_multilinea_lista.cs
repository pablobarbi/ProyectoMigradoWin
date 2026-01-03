using Minotti.Data;
using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Controls;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Abm.Controls
{
    public partial class w_multilinea_lista : w_operacion
    {
        /* Variables */
        public uo_dw dw_1;
        public uo_seleccion uo_lista;
        public string[] is_claves;

        /* DataStore que contendrá las filas de la lista */
        public datastore ds_lista;

        /* Indica si seteo o no el campo descripción */
        public bool ib_descripcion = false;

        public w_multilinea_lista()
        {
            InitializeComponent();

            this.Load += (_, __) => OnCreatePB();
            this.FormClosing += (_, __) => close();
        }

        // -------------------------------------------------
        // PB: on create / destroy
        // -------------------------------------------------
        private void OnCreatePB()
        {
            // call w_operacion::create ya ejecutado por la base
        }

        // -------------------------------------------------
        // prototypes
        // -------------------------------------------------
        public bool wf_cambios_pendientes()
        {
            if (dw_1.AcceptText() == -1 ||
                dw_1.ModifiedCount() > 0 ||
                uo_lista.uof_cambios_pendientes())
                return true;

            return false;
        }

        // -------------------------------------------------
        // events
        // -------------------------------------------------

        public void ue_retrieve()
        {
            base.ue_retrieve();

            bool lb_no_tiene_nulos;

            if (dw_1.RowCount() <= 0)
                return;

            /* obtengo los valores de los campos clave de la dw convertidos a string */
            lb_no_tiene_nulos = dw_1.uof_getclaves(out is_claves, 1);

            /* Recupero los datos de la lista solo si tienen valor los campos clave */
            if (lb_no_tiene_nulos)
                uo_lista.ue_retrieve(is_claves);
        }

        public void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            string param = at_op.uof_getparametros();

            /******************************************************************************
            Parámetros:
              dw_control(cabecera), dw_cabecera
              dw_control(lista seleccion), dw_lista
              dw_control(detalle), dw_detalle
              cantidad de lineas detalle
            ******************************************************************************/

            /* Cabecera */
            OpenUserObject(dw_1, this.wf_proxparam(param));
            dw_1.uof_setdataobject(this.wf_proxparam( param));
            dw_1.SetTransObject(SQLCA.Instance);
            dw_1.cant_filas = 1;

            /* Lista / selección */
            OpenUserObject(uo_lista, "uo_seleccion");
            uo_lista.ue_leer_parametros(param);
        }

        public void ue_iniciar()
        {
            base.ue_iniciar();

            if (at_op.Accion == "A")
            {
                /* INSERT */
                dw_1.InsertRow(0);
                dw_1.uof_edicion("K", "E");

                /* Obtengo la clave aunque sea nula */
                dw_1.uof_getclaves(out is_claves, 1);
            }
            else
            {
                /* UPDATE */
                dw_1.uof_edicion("K", "N");
                dw_1.uof_retrieve(at_op.s_det);
                is_claves = at_op.s_det;
            }

            /* Inicializa el objeto uo_lista */
            uo_lista.ue_iniciar(is_claves);
        }

        public void ue_confirmar()
        {
            base.ue_confirmar();

            /* Actualiza cabecera */
            if (dw_1.Update(true, false) != 1)
                ib_grabar = false;

            /* Actualiza cuerpo */
            if (ib_grabar)
            {
                if (uo_lista.uof_update(true, false) != 1)
                    ib_grabar = false;
            }

            if (ib_grabar)
                dw_1.ResetUpdate();

            uo_lista.ue_habilitar_botones();
        }

        public void ue_ajustar_tamaño()
        {
            base.ue_ajustar_tamaño();

            /* Ancho ventana */
            this.Width =
                Math.Max(dw_1.uof_ancho(), uo_lista.uof_ancho())
                + s_esp.ancho + 2 * s_esp.borde;

            /* Alto ventana */
            this.Height =
                dw_1.uof_largo()
                + uo_lista.uof_largo()
                + s_esp.largo
                + 2 * s_esp.borde;
        }

        public void ue_borrar()
        {
            base.ue_borrar();

            if (dw_1.DeleteRow(0) != 1)
                ib_grabar = false;

            if (ib_grabar)
            {
                if (dw_1.Update(true, true) != 1)
                    ib_grabar = false;
            }
        }

        public void ue_acomodar_objetos()
        {
            base.ue_acomodar_objetos();

            int ancho_para_dw =
                this.Width - s_esp.ancho - 2 * s_esp.borde;

            int largo_para_dw =
                this.Height - s_esp.largo - 2 * s_esp.borde;

            /* Cabecera */
            dw_1.Width = Math.Min(dw_1.uof_ancho(), ancho_para_dw);
            this.wf_centrarobjeto(dw_1);
            dw_1.Height = Math.Min(dw_1.uof_largo(), largo_para_dw / 2);
            dw_1.Top = s_esp.borde;

            /* Lista */
            int altura_lista =
                largo_para_dw - s_esp.borde - dw_1.Height;

            int ancho_lista =
                Math.Min(uo_lista.uof_ancho(), ancho_para_dw);

            uo_lista.ue_resize(ancho_lista, altura_lista);

            uo_lista.Top = dw_1.Top + dw_1.Height + s_esp.borde;
            this.wf_centrarobjeto(uo_lista);
        }

        public void ue_validar_datos()
        {
            base.ue_validar_datos();

            long fila;
            int columna;

            if (dw_1.uof_datoscompletos(out fila, out columna))
                return;

            if (fila > 0)
            {
                dw_1.SetRow((int)fila);
                dw_1.SetColumn(columna);
            }

            ib_grabar = false;
        }

        public void ue_completar_claves()
        {
            base.ue_completar_claves();

            /* Si estaba en alta, seteo nuevamente las claves en la lista */
            if (at_op.Accion == "A")
            {
                dw_1.uof_getclaves(out is_claves, 1);
                uo_lista.uof_setclaves(is_claves);
            }
        }

        public void ue_aceptar_datos()
        {
            base.ue_aceptar_datos();

            /* Acepta datos de la cabecera */
            if (dw_1.AcceptText() != 1)
                ib_grabar = false;

            /* Acepta datos del uo_seleccion */
            if (ib_grabar)
                ib_grabar = uo_lista.ue_aceptar_datos();
        }

        public void close()
        {
            base.close();

            if (dw_1 != null && !dw_1.IsDisposed)
                CloseUserObject(dw_1);

            if (uo_lista != null && !uo_lista.IsDisposed)
                CloseUserObject(uo_lista);
        }
    }
}
