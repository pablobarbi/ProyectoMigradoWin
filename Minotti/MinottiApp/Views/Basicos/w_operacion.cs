using Minotti.Structures;
using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Controls;
using Minotti.Views.Basicos.Models;
using Message = Minotti.utils.Message;

namespace Minotti.Views.Pbl.Views
{
    public partial class w_operacion : w_sheet, IFormularioConOperacion
    {
        // ====================
        // Variables
        // ====================
        public cat_operacion at_op { get; set; } = null!;
        public string is_Accion = "M"; // usada por ventana siguiente
        private uo_dw dw_dato;

        // Flags servicios
        public bool ib_cerrar_al_grabar = true;
        public bool ib_actualizar_anterior = true;
        public bool ib_volver_anterior = true;


        public cat_operacion Operacion
        {
            get => at_op;
            set => at_op = value;
        }

        public void SetOperacion(cat_operacion op)
        {
            at_op = op;
        }


        // ====================
        // Constructor
        // ====================
        public w_operacion()
        {
            InitializeComponent();
        }

        protected virtual void ue_retrieve()
        {
            if (dw_dato != null)
            {
                dw_dato.Retrieve(uo_app.Instance.at_usuario.Perfil); // o los args necesarios
            }
        }

        // ====================
        // Eventos
        // ====================
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            PBGlobals.m_mdi.m_insertar.Enabled = at_op?.Alta ?? false;
            PBGlobals.m_mdi.m_borrar.Enabled = at_op?.Baja ?? false;
            PBGlobals.m_mdi.m_confirmar.Enabled = at_op?.Modificacion ?? false;
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            PBGlobals.m_mdi.m_insertar.Enabled = false;
            PBGlobals.m_mdi.m_borrar.Enabled = false;
            PBGlobals.m_mdi.m_confirmar.Enabled = false;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            // Regresa a ventana anterior salvo que esté llamando a la siguiente
            if (at_op != null && at_op.Orden > 1 && ib_volver_anterior && at_op.w_anterior is not null)
            {
                at_op.w_anterior.Focus();
            }
        }

        // ====================
        // Métodos PB migrados
        // ====================

        public virtual void ue_abrir_siguiente()
        {
            base.ue_abrir_siguiente();

            if (!at_op.uof_nivelvalido(at_op.Orden + 1))
                return;

            PBUtils.SetPointer(Pointer.HourGlass);// Cursors.WaitCursor);
            var at_detalle = new cat_operacion();

            if (ue_preparar_siguiente(ref at_detalle))
            {
                at_detalle.w_anterior = at_op.uof_getcierra()?.ToUpper() == "S"
                    ? at_op.w_anterior
                    : this;

                wf_abrir_detalle(at_detalle);

                if (at_detalle.w_anterior == at_op.w_anterior)
                {
                    ib_pasar_por_closequery = false;
                    ib_volver_anterior = false;
                    Close();
                }
            }

            PBUtils.SetPointer(Pointer.Arrow);// SetCursor(Cursors.Default);
        }

        public virtual bool ue_preparar_siguiente(ref cat_operacion at_det)
        {
            base.ue_preparar_siguiente(ref at_det);
            at_op.uof_copiaren(at_det);
            at_det.Orden = at_op.Orden + 1;
            return true;
        }

        public override void ue_insertar()
        {
            base.ue_insertar();
            is_Accion = "A";
        }

        public override void ue_borrar()
        {
            base.ue_borrar();
            is_Accion = "B";
        }

        public override void ue_optar()
        {
            base.ue_optar();

            // En las bajas, si se graba bien, se cierra
            if (at_op.Accion == "B")
                ib_cerrar_al_grabar = true;
        }

        public override void ue_grabar()
        {
            base.ue_grabar();

            if (ib_grabar)
            {
                if (ib_actualizar_anterior && at_op.Orden != 1 && at_op.w_anterior is not null)
                    at_op.w_anterior.TriggerEvent("ue_iniciar");

                if (ib_cerrar_al_grabar)
                {
                    ib_pasar_por_closequery = false;
                    Close();
                }
                else
                {
                    TriggerEvent("ue_reiniciar");
                }
            }
        }

        public override void ue_eliminar()
        {
            base.ue_eliminar();

            if (ib_grabar)
            {
                if (ib_actualizar_anterior && at_op.w_anterior is not null)
                    at_op.w_anterior.TriggerEvent("ue_iniciar");

                if (ib_cerrar_al_grabar)
                {
                    ib_pasar_por_closequery = false;
                    Close();
                }
                else
                {
                    TriggerEvent("ue_reiniciar");
                }
            }
        }

        protected override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            //at_op = (cat_operacion)this.PowerObjectParm!;

            // ya no hace falta, at_op ya está asignado en la propiedad Operacion
            // solo validás que esté
            if (at_op == null)
            {
                MessageBox.Show("No se pasó información de la operación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            this.Text = at_op.Nombre;

            var titulo = at_op.uof_gettitulo();
            if (!string.IsNullOrEmpty(titulo))
                this.Text += " - " + titulo;
        }

        // Inserta un nuevo ítem en la grilla principal (detalle)
        public virtual void ue_insertar_item()
        {
            if (dw_dato != null)
            {
                dw_dato.InsertRow(0);
                dw_dato.ScrollToRow(dw_dato.RowCount());
                dw_dato.SetFocus();
            }
        }

        // Deshabilita las columnas clave (en general, después de insertar)
        public virtual void ue_deshabilitar_clave()
        {
            if (dw_dato == null) return;

            string colClave = dw_dato.Describe("#1.Name");
            dw_dato.Modify($"{colClave}.Protect=1"); // 1: protegido
        }

        // Borra el ítem actual del detalle
        public virtual void ue_borrar_item()
        {
            if (dw_dato == null || dw_dato.RowCount() < 1)
                return;

            int currentRow = dw_dato.GetRow();
            if (currentRow > 0)
                dw_dato.DeleteRow(currentRow);
        }

        // Inserta un userobject visual en esta ventana
        public virtual void OpenUserObject(object? uo, object? parent)
        {
            if (uo is Control ctrl)
            {
                Control? parentCtrl = null;

                if (parent is Form f)
                    parentCtrl = f;
                else if (parent is Control c)
                    parentCtrl = c;
                else
                    parentCtrl = this;

                parentCtrl.Controls.Add(ctrl);
                ctrl.Visible = true;
            }
        }

        // Elimina un userobject visual embebido
        public virtual void CloseUserObject(object? uo)
        {
            if (uo == null) return;

            if (uo is Control ctrl)
            {
                if (this.Controls.Contains(ctrl))
                    this.Controls.Remove(ctrl);

                ctrl.Dispose();
            }
        }

    }
}
