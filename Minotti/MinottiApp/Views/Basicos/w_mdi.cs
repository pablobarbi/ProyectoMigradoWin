using Minotti.utils;
using Minotti.Views.Pbl.Views;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Minotti.Views.Basicos
{
    public partial class w_mdi : w_principal
    {
        public string menuname = "m_mdi";
        public m_mdi MenuID { get; private set; }

        public int WorkSpaceWidth
        {
            get
            {
                return mdi_1?.ClientSize.Width ?? this.ClientSize.Width;
            }
        }

        public int WorkSpaceHeight
        {
            get
            {
                return mdi_1?.ClientSize.Height ?? this.ClientSize.Height;
            }
        }


        public w_mdi()
        {
            InitializeComponent();

            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            //if (_menu != null)
            //    return; // 🔒 evita triple creación

            // PB: MenuID = create m_mdi
            this.MenuID = new m_mdi(this);
            this.MainMenuStrip = this.MenuID;
            this.Controls.Add(this.MenuID);
        }

        // =====================================================
        // PB: EVENT ue_mandar_menu_fondo (window w_actual)
        // =====================================================
        protected virtual void ue_mandar_menu_fondo(Form w_actual)
        {
            // call super::ue_mandar_menu_fondo;
            // (si w_principal tiene implementación, se respeta)
            base.ue_mandar_menu_fondo(w_actual);

            this.SuspendLayout();

            // PB: vector de ventanas MDI (excepto el menú)
            var ventanas = this.MdiChildren
                .Where(w => w != w_actual)
                .ToArray();

            // PB: foco en orden inverso
            for (int i = ventanas.Length - 1; i >= 0; i--)
            {
                ventanas[i].Activate();
            }

            this.ResumeLayout();
        }

        // =====================================================
        // PB: EVENT POST ue_mandar_menu_fondo
        // =====================================================
        public void PostEvent_ue_mandar_menu_fondo(Form w_actual)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() =>
                {
                    ue_mandar_menu_fondo(w_actual);
                }));
            }
            else
            {
                ue_mandar_menu_fondo(w_actual);
            }
        }

        // =====================================================
        // PB: public subroutine wf_getareatrabajo
        // =====================================================
        public void wf_getareatrabajo(out int ancho, out int largo)
        {
            // PB:
            // ancho = guo_app.uof_GetMdi().Width - 55
            // largo = guo_app.uof_GetMdi().Height - 272

            ancho = this.Width - 55;
            largo = this.Height - 272;

            // Toolbar (equivalente PB)
            if (this.MainMenuStrip != null)
            {
                largo -= this.MainMenuStrip.Height;
            }

            if (this.Controls.OfType<ToolStrip>().Any())
            {
                var tb = this.Controls.OfType<ToolStrip>().First();
                if (tb.Visible)
                {
                    if (tb.Dock == DockStyle.Top || tb.Dock == DockStyle.Bottom)
                        largo -= tb.Height;
                    else
                        ancho -= tb.Width;
                }
            }
        }

        // =====================================================
        // PB: public function integer wf_getsheetcant()
        // =====================================================
        public int wf_getsheetcant()
        {
            return this.MdiChildren.Length;
        }

        // =====================================================
        // PB: closequery
        // =====================================================
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // PB: Message.StringParm = 'Aplicación esta cerrando'
            this.Tag = "Aplicación esta cerrando";
        }
    }

}
