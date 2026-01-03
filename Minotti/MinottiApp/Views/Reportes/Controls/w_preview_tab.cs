using Minotti.Data;
using Minotti.Views.Basicos;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Reportes.Controls
{
    // global type w_preview_tab from w_presentacion
    public partial class w_preview_tab : w_presentacion
    {
        // boolean controlmenu = false
        public bool controlmenu = false;

        public w_preview_tab()
        {
            InitializeComponent();

            // PB: event ue_open (lo engancho en Load porque PB lo dispara al abrir)
            this.Load += w_preview_tab_Load;

            // PB: pb_2::clicked override
            // En C# se logra desenganchando el handler base y enganchando el propio.
            // Si en w_presentacion el pb_2 handler es privado, no se puede desenganchar;
            // entonces simplemente agrego el handler acá (va a ejecutarse junto al base).
            // Para mantener 1:1, lo ideal es que el base use un método virtual.
            this.pb_2.Click += pb_2_Clicked_Preview;
        }

        private void w_preview_tab_Load(object? sender, EventArgs e)
        {
            ue_open();
        }

        // =========================
        // PB: event ue_open
        // =========================
        public void ue_open()
        {
            // Integer columna, maximo, rtn  (no se usan)
            // Cat_Preview_Tab lcat_Preview
            // lcat_Preview = Message.PowerObjectParm

            // En .NET lo recibimos por Tag
            cat_preview_tab? lcat_Preview = this.Tag as cat_preview_tab;
            if (lcat_Preview == null)
                return;

            // cargo la DW.
            dw_1.uof_setdataobject(lcat_Preview.is_impresion);
            dw_1.uof_setdwimpresion(lcat_Preview.is_impresion);
            dw_1.SetTransObject(SQLCA.Instance);
            dw_1.uof_retrieve(lcat_Preview.is_parametros);

            /* Fija el tamaño y la posición */
            // This.X = 1; This.Y = 1
            // This.Width = guo_app.uof_GetMdi().Width
            // This.Height = guo_app.uof_GetMdi().Height
            // En WinForms:
            this.Left = 1;
            this.Top = 1;

            // guo_app.uof_GetMdi() debe existir en tu migración (no lo invento)
            var mdi = guo_app.Instance.uof_getmdi();
            if (mdi != null)
            {
                this.Width = mdi.Width;
                this.Height = mdi.Height;
            }
        }

        // =========================
        // PB: event pb_2::clicked
        // If dw_1.Print(FALSE) <> 1 Then CloseWithReturn(Parent,-1) Else CloseWithReturn(Parent,1)
        // =========================
        private void pb_2_Clicked_Preview(object? sender, EventArgs e)
        {
            int r = dw_1.Print(false);

            // CloseWithReturn(Parent, X)
            // En .NET: DialogResult + ReturnValue (si lo venís usando)
            if (r != 1)
            {
                if (this is w_response wr) wr.ReturnValue = -1;
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
            {
                if (this is w_response wr) wr.ReturnValue = 1;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}