using MinottiApp.utils;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Minotti.utils
{
    /// <summary>
    /// Emulación PB-like de PictureButton / CommandButton
    /// Usa DynamicEventInvoker para disparar eventos PB.
    /// </summary>
    public abstract class PbActionButton : UserObject
    {
        /// <summary>
        /// Nombre del evento PB a disparar (ej: ue_insertar, ue_borrar)
        /// </summary>
        protected abstract string EventName { get; }

        /// <summary>
        /// Control visual WinForms interno
        /// </summary>
        protected Button Button { get; }

        protected PbActionButton()
        {
            Button = new Button();
            AttachControl(Button);

            Button.Click += OnClick;
        }

        private void OnClick(object? sender, EventArgs e)
        {
            if (Parent == null)
                return;

            // PB: Parent.TriggerEvent("ue_xxx")
            // Usamos el runtime centralizado
            DynamicEventInvoker.Post(
                Parent,
                EventName
            );
        }

        public override void Destroy()
        {
            Button.Click -= OnClick;
            Button.Dispose();

            base.Destroy();
        }
    }

    // ---------------------------------------------------------------------
    // PB: picturebutton pb_insertar
    // ---------------------------------------------------------------------
    public class pb_insertar : PbActionButton
    {
        protected override string EventName => "ue_insertar";

        public pb_insertar()
        {
            Button.Text = "&Insertar";
        }
    }

    // ---------------------------------------------------------------------
    // PB: picturebutton pb_borrar
    // ---------------------------------------------------------------------
    public class pb_borrar : PbActionButton
    {
        protected override string EventName => "ue_borrar";

        public pb_borrar()
        {
            Button.Text = "&Borrar";
        }
    }
}
