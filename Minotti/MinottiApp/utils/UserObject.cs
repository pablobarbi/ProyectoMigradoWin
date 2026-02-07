using System.Collections.Generic;
using System.Windows.Forms;

namespace Minotti.utils
{
    /// <summary>
    /// Runtime base PB-like para todos los objetos
    /// </summary>
    public abstract class UserObject
    {
        protected bool _isDestroyed;

        // PB: this.Parent
        public UserObject? Parent { get; internal set; }

        // PB: this (control visual asociado)
        protected Control? VisualControl { get; private set; }

        // PB: this.Control[]
        protected List<UserObject> Controls { get; } = new();


        // -------------------------------------------------
        // PB: propiedades visuales
        // -------------------------------------------------
        protected int Height
        {
            get => VisualControl?.Height ?? 0;
            set
            {
                if (VisualControl != null)
                    VisualControl.Height = value;
            }
        }

        protected int Width
        {
            get => VisualControl?.Width ?? 0;
            set
            {
                if (VisualControl != null)
                    VisualControl.Width = value;
            }
        }

        protected int X
        {
            get => VisualControl?.Left ?? 0;
            set
            {
                if (VisualControl != null)
                    VisualControl.Left = value;
            }
        }

        protected int Y
        {
            get => VisualControl?.Top ?? 0;
            set
            {
                if (VisualControl != null)
                    VisualControl.Top = value;
            }
        }

        public bool IsDestroyed => _isDestroyed;

        // -------------------------------------------------
        // Asociación visual
        // -------------------------------------------------
        protected void AttachControl(Control control)
        {
            VisualControl = control;
        }

        // -------------------------------------------------
        // PB: agregar hijo
        // -------------------------------------------------
        protected void AddControl(UserObject child)
        {
            child.Parent = this;
            Controls.Add(child);

            // Si ambos tienen visual, se agrega al contenedor real
            if (VisualControl != null && child.VisualControl != null)
            {
                VisualControl.Controls.Add(child.VisualControl);
            }
        }

        // -------------------------------------------------
        // PB: Destroy
        // -------------------------------------------------
        public virtual void Destroy()
        {
            if (_isDestroyed)
                return;

            _isDestroyed = true;

            foreach (var c in Controls)
            {
                c.Destroy();
            }

            Controls.Clear();

            if (VisualControl != null)
            {
                if (!VisualControl.IsDisposed)
                    VisualControl.Dispose();

                VisualControl = null;
            }
        }
    }
}
