using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{

    // Enum equivalente a ToolBarAlignment de PB
    public enum ToolBarAlignment
    {
        AlignAtTop,
        AlignAtBottom,
        AlignAtLeft,
        AlignAtRight
    }


    // Migración de PowerBuilder: w_mdi.srw (MDI Frame) desde w_principal
    // Mantiene el nombre del tipo: w_mdi
    // w_mdi from w_principal
    public partial class w_mdi : w_principal
    {
        // PB: mdi_1 mdi_1  (área cliente MDI)
        // En WinForms usamos el MdiClient interno; no necesitamos un campo separado

        

        public w_mdi()
        {
            InitializeComponent();
            

            // Fondo del cliente MDI (mdi_1.BackColor = 82899184)
            var mdiClient = this.Controls.OfType<MdiClient>().FirstOrDefault();
            if (mdiClient != null)
            {
                mdiClient.BackColor = ColorTranslator.FromWin32(unchecked((int)82899184));
            }
        }

        
        // =====================================================
        // Evento ue_mandar_menu_fondo(window w_actual)
        // =====================================================
        // PB:
        // * Junta todas las sheets (excepto la actual) en un vector
        // * Les da foco en orden inverso
        public virtual void ue_mandar_menu_fondo(Form w_actual)
        {
            // call super::ue_mandar_menu_fondo
            // (w_principal no tiene implementación concreta, así que no llamamos)

            this.SuspendLayout();

            // Meto todas las ventanas MDI en un vector menos la actual
            var vector = this.MdiChildren
                .Where(f => f != null && f != w_actual)
                .ToArray();

            int cant = vector.Length;

            // Doy foco en orden inverso al de aparición
            for (int j = cant - 1; j >= 0; j--)
            {
                try
                {
                    vector[j].Activate();
                }
                catch
                {
                    // Si alguna está disposed, la salteamos
                }
            }

            this.ResumeLayout(true);
        }

        // =====================================================
        // wf_getareatrabajo(ref integer ancho, ref integer largo)
        // =====================================================
        // PB:
        //  ancho = guo_app.uof_GetMdi().Width - 55
        //  largo = guo_app.uof_GetMdi().Height - 272
        //  GetToolbar(1, tb_visible, tb_alignment)
        //  ... ajusta según toolbar y ToolBarText
        public void wf_GetAreaTrabajo(out int ancho, out int largo)
        {
            /* Lee el ancho y el largo del área de trabajo de la ventana */
            ancho = this.Width - 55;
            largo = this.Height - 272;

            /* Captura los datos del Toolbar */
            bool tb_visible;
            ToolBarAlignment tb_alignment;
            GetToolbar(1, out tb_visible, out tb_alignment);

            /* Si está visible, reduce el área de trabajo de acuerdo a su posición */
            if (tb_visible)
            {
                if (tb_alignment == ToolBarAlignment.AlignAtTop ||
                    tb_alignment == ToolBarAlignment.AlignAtBottom)
                {
                    /* Si está visible el texto del menú */
                    if (uo_app.Instance != null && guo_app.Instance.App.ToolBarText)
                    {
                        largo = largo - 152;
                    }
                    else
                    {
                        // largo = largo - 120
                        largo = largo - 90;
                    }
                }
                else if (tb_alignment == ToolBarAlignment.AlignAtLeft ||
                         tb_alignment == ToolBarAlignment.AlignAtRight)
                {
                    if (uo_app.Instance != null && guo_app.Instance.App.ToolBarText)
                    {
                        ancho = ancho - 224;
                    }
                    else
                    {
                        ancho = ancho - 155;
                    }
                }
            }
        }

        // Stub equivalente a GetToolbar(1, ...) de PB.
        // Acá solo devolvemos "no visible" para no alterar el layout
        // hasta que vos lo enlaces a tu ToolStrip real.
        public  virtual void GetToolbar(int index, out bool visible, out ToolBarAlignment alignment)
        {
            visible = false;
            alignment = ToolBarAlignment.AlignAtTop;
            // TODO: mapear tu ToolStrip real si querés replicar exactamente el comportamiento.
        }

        // =====================================================
        // wf_getsheetcant()
        // =====================================================
        // PB:
        //  wAux = GetFirstSheet()
        //  count mientras IsValid(...)
        public int wf_GetSheetCant()
        {
            /* Lee la cantidad de sheet windows abiertas en esta ventana */
            return this.MdiChildren?.Length ?? 0;
        }

        // =====================================================
        // Ciclo de vida (create / destroy / closequery)
        // =====================================================

        // on w_mdi.create
        // PB hacía:
        //   if this.MenuName = "m_mdi" then this.MenuID = create m_mdi
        //   this.mdi_1=create mdi_1
        //   this.Control[iCurrent+1]=this.mdi_1
        //
        // En WinForms:
        // - el menú "m_mdi" lo vas a crear como MenuStrip / MainMenu en el Designer.
        // - el MdiClient lo maneja automáticamente el framework cuando IsMdiContainer = true.
        // Eso ya lo configuramos en InitializeComponent, así que no necesitamos override extra.

        // on w_mdi.destroy
        // el GC/Dispose se encarga en .NET, no hacemos nada especial.

        // event closequery; Message.StringParm = 'Aplicación esta cerrando'
        // En WinForms lo análogo es OnFormClosing; dejamos un hook por si usás algún logger.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // call super::closequery
            base.OnFormClosing(e);

            // PB: Message.StringParm = 'Aplicación esta cerrando'
            // Podés mapear esto a algún mecanismo propio si querés.
            // Acá dejamos el comentario para que no se pierda el sentido.
            // Ejemplo (si tuvieras algo así):
            // guo_app.MessageStringParm = "Aplicación esta cerrando";

            MessageBox.Show(
       $"MDI CERRANDO - Reason: {e.CloseReason}",
       "DEBUG"
   );
        }



        public virtual int WorkSpaceHeight()
        {
            // PB: alto del área de trabajo del MDI (sin title/menu/barras externas).
            // WinForms: usamos el MdiClient si existe; si no, caemos al ClientSize.
            var mdiClient = this.Controls.OfType<MdiClient>().FirstOrDefault();
            return mdiClient?.ClientSize.Height ?? this.ClientSize.Height;
        }

        public virtual int WorkSpaceWidth()
        {
            var mdiClient = this.Controls.OfType<MdiClient>().FirstOrDefault();
            return mdiClient?.ClientSize.Width ?? this.ClientSize.Width;
        }

    }
}
