using Minotti.Structures;
using Minotti.utils;
using Minotti.Views.Basicos.Models;
using Minotti.Views.Pbl.Views;
using System;
using System.Windows.Forms;



namespace Minotti.Views.Basicos
{
    // Migración de PowerBuilder: w_operacion.srw (window base) desde w_sheet
    // Mantiene el nombre del tipo: w_operacion
    // Ajustá el namespace si corresponde
    public partial class w_operacion : w_sheet
    {
        // ================== variables ==================
        // PB: cat_operacion at_op
        public cat_operacion at_op;

        // PB: string is_Accion = 'M'
        public string is_Accion = "M";
        /* Esta variable se utiliza solo para con la ventana siguiente. 
           La Accion en curso está en at_op.Accion */

        /* Flags para servicios */
        // Boolean ib_cerrar_al_grabar = TRUE
        public bool ib_cerrar_al_grabar = true; /* Indica si debe cerrar o no la ventana al finallizar de grabar */

        // Boolean ib_actualizar_anterior = TRUE
        public bool ib_actualizar_anterior = true; /* Indica si después de grabar debe actualizar o no a la ventana que lo llamó */

        // Boolean ib_volver_anterior = TRUE
        public bool ib_volver_anterior = true; /* Le indica al evento de cerrar si debe o no volver a la ventana que lo llamó */


        /// <summary>
        /// PB: SetPointer(HourGlass!/Arrow!/Busy!)
        /// Alias de instancia que delega a PBUtils
        /// </summary>
        public void SetPointer(Pointer p)
        {
            PBUtils.SetPointer(p);
        }


        // Propiedad para setear at_op desde afuera (equivalente a Message.PowerObjectParm)
        public cat_operacion Operacion
        {
            get => at_op;
            set => at_op = value;
        }

        public w_operacion()
        {
            InitializeComponent();
            // Para poder capturar ESC
            this.KeyPreview = true;
        }

        // ================== ue_abrir_siguiente ==================

        // PB: event ue_abrir_siguiente; call super::ue_abrir_siguiente; ...
        public virtual void ue_abrir_siguiente()
        {
            // call super::ue_abrir_siguiente
            base.ue_abrir_siguiente();

            cat_operacion at_detalle;

            /* Si no hay ventana siguiente, no hace nada */
            if (!at_op.uof_nivelvalido(at_op.Orden + 1))
                return;

            Cursor.Current = Cursors.WaitCursor; // SetPointer(HourGlass!)

            /* Carga los parámetros para llamar a la siguiente ventana */
            at_detalle = new cat_operacion();
            if (this.ue_preparar_siguiente(at_detalle))
            {
                /* Le indica a la siguiente ventana a cuál debe volver al cerrarse */
                if (string.Equals(at_op.uof_getcierra(), "S", StringComparison.OrdinalIgnoreCase))
                {
                    at_detalle.w_anterior = at_op.w_anterior;
                    // volver_anterior = False (comentado en PB)
                }
                else
                {
                    at_detalle.w_anterior = this;
                }

                /* Abre la ventana siguiente con los parámetros cargados */
                // PB: wf_abrir_detalle(at_detalle)
                // Asumimos que existe este método en alguna parte de tu código.
                wf_abrir_detalle(at_detalle);

                /* Si los parámetros indican que la ventana se debe cerrar después de abrir a la siguiente, se cierra */
                if (at_detalle.w_anterior == at_op.w_anterior)
                {
                    // ib_pasar_por_closequery = FALSE
                    this.ib_pasar_por_closequery = false;
                    ib_volver_anterior = false;
                    this.Close();

                    /* Sacamos el PostEvent que no funcionaba y en su lugar pusimos un Close(this) */
                    // If at_detalle.w_anterior = at_op.w_anterior Then This.PostEvent("close")
                }
            }

            Cursor.Current = Cursors.Default;
        }

        // ================== ue_preparar_siguiente ==================

        // PB: event ue_preparar_siguiente; call super::ue_preparar_siguiente; ...
        // event type boolean ue_preparar_siguiente ( ref cat_operacion at_det )
        public virtual bool ue_preparar_siguiente(cat_operacion at_det)
        {
            // call super::ue_preparar_siguiente
            base.ue_preparar_siguiente(at_det);

            /* Carga los datos necesarios en la estructura que pasará como argumento */
            at_op.uof_copiaren(at_det);
            at_det.Orden = at_op.Orden + 1;

            return true;
        }

        // ================== ciclo de vida: create/destroy ==================

        // PB: on w_operacion.create call super::create
        // En WinForms el constructor ya llama InitializeComponent() y
        // la inicialización del base se maneja por .NET, así que no hace falta nada extra.

        // PB: on w_operacion.destroy call super::destroy
        // En .NET el Dispose/GC se encargan; no agregamos nada aquí.

        // ================== ue_leer_parametros ==================

        // PB: event ue_leer_parametros; call super::ue_leer_parametros; at_op = Message.PowerObjectParm ...
        public virtual void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            // PB: at_op = Message.PowerObjectParm
            // En .NET asumimos que at_op ya fue seteado vía Operacion antes de mostrar la ventana.

            int iAux;

            /* Captura el título de la ventana */
            this.Text = at_op.Nombre;

            iAux = at_op.uof_gettitulo()?.Length ?? 0;
            if (iAux > 0)
            {
                this.Text = this.Text + " - " + at_op.uof_gettitulo();
            }
        }

        // ================== deactivate / activate ==================

        // PB: event deactivate; ... m_mdi.m_operaciones.m_insertar.Enabled = FALSE ...
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);

            PBGlobals.m_mdi.m_insertar.Enabled = false;
            PBGlobals.m_mdi.m_borrar.Enabled = false;
            PBGlobals.m_mdi.m_confirmar.Enabled = false;
        }

        // PB: event activate; ... Enabled = at_op.Alta/Baja/Modificacion
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            PBGlobals.m_mdi.m_insertar.Enabled = at_op.Alta;
            PBGlobals.m_mdi.m_borrar.Enabled = at_op.Baja;
            PBGlobals.m_mdi.m_confirmar.Enabled = at_op.Modificacion;
        }

        // ================== close ==================

        // PB: event close; call super::close; ...
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            /* Al cerrarse, vuelve a la ventana que la abrió, salvo que esté llamando a la ventana siguiente */
            if (at_op != null &&
                at_op.Orden > 1 &&
                ib_volver_anterior &&
                at_op.w_anterior != null)
            {
                try
                {
                    at_op.w_anterior.Focus();
                }
                catch
                {
                    // igual que PB, si no es válido, no hace nada
                }
            }
        }

        // ================== ue_borrar / ue_insertar ==================

        // PB: event ue_borrar; call super::ue_borrar; is_Accion = "B"
        public virtual void ue_borrar()
        {
            base.ue_borrar();
            is_Accion = "B";
        }

        // PB: event ue_insertar; call super::ue_insertar; is_Accion = "A"
        public virtual void ue_insertar()
        {
            base.ue_insertar();
            is_Accion = "A";
        }

        // ================== ue_optar ==================

        // PB: event ue_optar; call super::ue_optar; ...
        public override void ue_optar()
        {
            base.ue_optar();

            /* En las bajas, si se graba correctamente, la ventana se cerrará. No tiene sentido recomponerla */
            if (at_op.Accion == "B")
            {
                this.ib_cerrar_al_grabar = true;
            }
        }

        // ================== ue_grabar ==================

        // PB: event ue_grabar; call super::ue_grabar; ...
        public override void ue_grabar()
        {
            base.ue_grabar();

            /* Si la grabación terminó bien y la ventana se debía cerrar después de grabar, se cierra */
            if (this.ib_grabar)
            {
                if (this.ib_actualizar_anterior && at_op.Orden != 1)
                {
                    if (at_op.w_anterior != null)
                    {
                        at_op.w_anterior.ue_iniciar();
                    }
                }

                /* Si debe cerrarse después de grabar, lo hace, indicándole al evento closequery
                   que no valide si hay datos pendientes */
                if (this.ib_cerrar_al_grabar)
                {
                    this.ib_pasar_por_closequery = false;
                    this.Close();
                }
                else
                {
                    // This.Event Trigger ue_reiniciar()
                    this.ue_reiniciar();
                }
            }
        }

        // ================== ue_eliminar ==================

        // PB: event ue_eliminar; call super::ue_eliminar; ...
        public override void ue_eliminar()
        {
            base.ue_eliminar();

            /* Si la grabación terminó bien y la ventana se debía cerrar después de grabar, se cierra */
            if (this.ib_grabar)
            {
                if (this.ib_actualizar_anterior)
                {
                    if (at_op.w_anterior != null)
                    {
                        at_op.w_anterior.ue_iniciar();
                    }
                }

                /* Si debe cerrarse después de grabar, lo hace, indicándole al evento closequery
                   que no valide si hay datos pendientes */
                if (this.ib_cerrar_al_grabar)
                {
                    this.ib_pasar_por_closequery = false;
                    this.Close();
                }
                else
                {
                    // This.Event Trigger ue_reiniciar()
                    this.ue_reiniciar();
                }
            }
        }

        // ================== key (ESC -> ue_cancelar) ==================

        // PB: event key; ... If key = KeyEscape! Then This.PostEvent("ue_cancelar")
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Escape)
            {
                // This.PostEvent("ue_cancelar")
                this.BeginInvoke(new Action(() =>
                {
                    this.ue_cancelar();
                }));
            }
        }

        // ================== otros eventos ==================

        // PB: event ue_acomodar_objetos; call super::ue_acomodar_objetos; ...
        public virtual void ue_acomodar_objetos()
        {
            // TODO: PB migration default implementation
        }

        public virtual void ue_ajustar_tamaño()
        {
            // TODO: PB migration default implementation
        }

        public virtual void ue_iniciar()
        {
            // TODO: PB migration default implementation
        }

        // PB event: close()
        // Todas las ventanas PB pueden redefinir este evento.
        // En .NET lo exponemos como método virtual para permitir override.
        public virtual void close()
        {
            // Comportamiento equivalente PB: cerrar la ventana
            this.Close();
        }



        public virtual void activate()
        {
            // Comportamiento equivalente PB: cerrar la ventana
            this.Activate();
        }

        // PB migration: OpenUserObject(uo, parent)
        // En PB inserta un UserObject dentro de la ventana.
        // En WinForms simplemente lo agrega a Controls.
        public virtual void OpenUserObject(object? uo)
        {
            if (uo == null)
                return;

            if (uo is Control ctrl)
            {
                // PB: OpenUserObject lo "embebe" dentro de la ventana
                this.Controls.Add(ctrl);

                // Que se vea
                ctrl.Visible = true;

                // Opcional: dock o layout PB-like
                // ctrl.Dock = DockStyle.None;

                // PB ejecuta open/constructor: en WinForms ya fue instanciado
            }
            else
            {
                // Si algún día aparece un UO no visual, se puede extender aquí.
                // Por ahora, no hacemos nada (PB ignoraría objetos no visuales)
            }
        }

        // PB Migration: OpenUserObject(uo, parent)
        // PB permite especificar el objeto padre contenedor.
        public virtual void OpenUserObject(object? uo, object? parent)
        {
            if (uo is Control ctrl)
            {
                Control? parentCtrl = null;

                // Si parent es otra ventana, uo va dentro de ella.
                if (parent is Form f)
                    parentCtrl = f;

                // Si parent es un UserObject/Control, va dentro de él
                else if (parent is Control c)
                    parentCtrl = c;

                // Si parent no es válido, usar la ventana actual
                else
                    parentCtrl = this;

                parentCtrl.Controls.Add(ctrl);
                ctrl.Visible = true;
            }
        }


        // PB Migration: CloseUserObject(uo)
        //
        // En PB elimina/destruye el UserObject embebido dentro de la ventana.
        // En WinForms hacemos: remove from Controls + dispose.
        //
        public virtual void CloseUserObject(object? uo)
        {
            if (uo == null)
                return;

            if (uo is Control ctrl)
            {
                // Si está dentro de la ventana, lo removemos
                if (this.Controls.Contains(ctrl))
                    this.Controls.Remove(ctrl);

                // PB destruye el objeto: en WinForms → Dispose()
                ctrl.Dispose();
            }
            else
            {
                // Si no es control, PB simplemente lo ignora
                // (PB solo usa CloseUserObject con objetos visuales)
            }
        }


        // ===============================================================
        // PB Event: ue_dw_detalle
        // PB permitía que cualquier ventana redefina este evento,
        // aunque la base no lo tuviera. En C# debemos declararlo.
        // ===============================================================
        public virtual void ue_dw_detalle(object objeto)
        {
            // PB default: no hace nada
        }

        public virtual void ue_deshabilitar_clave()
        {
            // TODO(PB): revisar SRW w_operacion
        }

        public virtual void ue_insertar_item()
        {
            // TODO(PB): revisar SRW w_operacion
        }

        public virtual void ue_borrar_item()
        {
            // TODO(PB): revisar SRW w_operacion
        }

        public virtual void ue_retrieve()
        {
            // Stub PB
            // Se implementa en las ventanas hijas si corresponde
        }
    }
}