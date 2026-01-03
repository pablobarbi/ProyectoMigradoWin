using System;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    // Migración de PowerBuilder: w_response.srw (window) desde w_principal
    // Mantiene el nombre del tipo: w_response
    // PB: global type w_response from w_principal
    // global type w_response from w_principal
    public partial class w_response : w_principal
    {
        // WindowType=response! (WinForms: Form normal; si tu framework tiene WindowType, dejalo ahí)
        public bool MinBox { get; set; } = false;
        public bool MaxBox { get; set; } = false;
        public bool Resizable { get; set; } = false;
        /// <summary>
        /// PB: ReturnValue
        /// Valor de retorno de la ventana
        /// </summary>
        public long ReturnValue { get; set; } = 0;
        // event ue_continuar ( )
        public  virtual void ue_continuar()
        {
            // vacío en PB
        }

        // event ue_cancelar ( )
        public  virtual void ue_cancelar()
        {
            // vacío en PB
        }

        // event ue_acomodar_objetos ( )
        public  virtual void ue_acomodar_objetos()
        {
            // vacío en PB
        }

        public w_response()
        {
            InitializeComponent();

            // PB: MinBox=false MaxBox=false Resizable=false
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Resizable=false equivalente
        }

        // forward prototypes
        // public subroutine wf_centrar_response ()
        // end prototypes

        // public subroutine wf_centrar_response ()
        public  virtual void wf_centrar_response()
        {
            /* Centra la ventana de response */
            // PB:
            // environment env
            // real Y_desviacion = 0.6
            // real X_desviacion = 1
            // If GetEnvironment(env) = 1 Then
            //   this.x = int ((PixelsToUnits(env.ScreenWidth, XPixelsToUnits!) - this.Width) / 2 * X_desviacion)
            //   this.y = int ((PixelsToUnits(env.ScreenHeight, YPixelsToUnits!) - this.Height) / 2 * Y_desviacion)
            // End If

            float Y_desviacion = 0.6f; // porcentaje desviación de la pantalla en y
            float X_desviacion = 1.0f; // porcentaje desviación de la pantalla en X

            // WinForms trabaja en pixeles: env.ScreenWidth/Height ya están en pixeles.
            // Equivalente a PixelsToUnits(...): acá ya estamos en pixeles, así que no convertimos.
            var screenW = Screen.PrimaryScreen.Bounds.Width;
            var screenH = Screen.PrimaryScreen.Bounds.Height;

            int x = (int)(((screenW - this.Width) / 2f) * X_desviacion);
            int y = (int)(((screenH - this.Height) / 2f) * Y_desviacion);

            this.Left = x;
            this.Top = y;
        }

        // PB on create/destroy equivalentes
        protected  override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            // si querés centrar al abrir, PB no lo llama automático, pero usualmente sí.
            // NO lo asumo. No llamo wf_centrar_response() acá.
        }

        // Eventos de botones (PB picturebutton clicked -> ue_continuar/ue_cancelar normalmente)
        public  virtual void pb_continuar_Clicked(object? sender, EventArgs e)
        {
            // PB no tiene script en el botón en este objeto; solo existe el evento en ventana.
            // Mantengo el evento de la ventana:
            this.ue_continuar();
        }

        public  virtual void pb_cancelar_Clicked(object? sender, EventArgs e)
        {
            this.ue_cancelar();
        }

        // PB event ue_validar_string()
        public  virtual int ue_validar_string()
        {
            return 1; // default PB-like: OK
        }

        public virtual void ue_cargar_usuario()
        {
            // PB: evento vacío por defecto (ancestro)
        }

        public virtual void close()
        {
            // PB: close(this)
            this.Close();
        }

        /// <summary>
        /// PB: open()
        /// </summary>
        public virtual void open()
        {
            // PB Open → ventana no modal
            this.Show();
        }
        /// <summary>
        /// PB: user event ue_conectar
        /// </summary>
        public virtual void ue_conectar()
        {
            // Stub PB
            // La lógica real puede estar en hijas o no existir
             
        }

        /// <summary>
        /// PB: user event ue_leer
        /// </summary>
        public virtual void ue_leer()
        {
            // Stub PB
            // Se implementa en ventanas hijas si corresponde
        }
    }
}
