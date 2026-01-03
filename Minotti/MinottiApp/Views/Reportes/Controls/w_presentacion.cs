using Minotti.Data;
using Minotti.Views.Basicos; // SQLCA
using Minotti.Views.Basicos.Controls;
using System;
using System.Windows.Forms;
// using Minotti.Framework; // si tenés helpers comunes

namespace Minotti.Views.Reportes.Controls
{
    public partial class w_presentacion : w_response
    {
        // PB: uo_dw dwAux
        private uo_dw? dwAux;

        public w_presentacion()
        {
            InitializeComponent();

            // Window events
            this.Load += w_presentacion_Load;
            this.Resize += w_presentacion_Resize;
            this.FormClosed += w_presentacion_FormClosed;
            this.CancelButton = pb_1;  // ← correcto

            // Control events (PB clicked/modified)
            pb_1.Click += pb_1_Clicked;
            pb_2.Click += pb_2_Clicked;
            pb_4.Click += pb_4_Clicked;
            pb_5.Click += pb_5_Clicked;

            pb_primer.Click += pb_primer_Clicked;
            pb_anterior.Click += pb_anterior_Clicked;
            pb_siguiente.Click += pb_siguiente_Clicked;
            pb_ultimo.Click += pb_ultimo_Clicked;

            em_zoom.TextChanged += em_zoom_Modified; // PB: modified
            cbx_1.Click += cbx_1_Clicked;            // PB: clicked
        }

        // =========================
        // PB: event open
        // =========================
        private void w_presentacion_Load(object? sender, EventArgs e)
        {
            // dwAux = Message.PowerObjectParm
            // En .NET lo recibimos en Tag
            dwAux = this.Tag as uo_dw;
            if (dwAux == null)
                return;

            // dw_1.uof_setdataobject(dwAux.uof_GetdwImpresion())
            dw_1.uof_setdwimpresion(dwAux.uof_getdwimpresion());
            dw_1.uof_setdwimpresion(dwAux.uof_getdwimpresion());

            // dw_1.SetTransObject(SQLCA)
            dw_1.SetTransObject(SQLCA.Instance);

            // Para que cargue las dddw
            if (dw_1.InsertRow(0) > 0)
                dw_1.DeleteRow(0);

            // dwAux.RowsCopy(1, dwAux.RowCount(), Primary!, dw_1, 1, Primary!)
            dwAux.RowsCopy(1, dwAux.RowCount(), DataWindowBuffer.Primary, dw_1, 1, DataWindowBuffer.Primary);

            // PB: ue_iniciar
            ue_iniciar();

            // ajustar tamaño inicial según resize PB
            w_presentacion_Resize(null, EventArgs.Empty);
        }

        // =========================
        // PB: event resize
        // =========================
        private void w_presentacion_Resize(object? sender, EventArgs e)
        {
            // dw_1.X = 50
            // dw_1.Y = ln_2.beginy + 30
            // dw_1.Height = This.Height - ln_2.beginy - 70
            // dw_1.Width  = This.Width - 150

            dw_1.Left = 50;
            dw_1.Top = ln_2.Top + 30;
            dw_1.Height = this.Height - ln_2.Top - 70;
            dw_1.Width = this.Width - 150;
        }

        // =========================
        // PB: event close (no tenía lógica activa, solo comentarios)
        // =========================
        private void w_presentacion_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // En PB estaba comentado ShareDataOff; no lo ejecuto porque sería inventar.
        }

        // =========================
        // PB: event ue_iniciar
        // =========================
        private void ue_iniciar()
        {
            // em_Zoom.Text = "100"
            // dw_1.Modify("datawindow.print.preview = yes datawindow.print.preview.zoom = 100")
            em_zoom.Text = "100";
            dw_1.Modify("datawindow.print.preview = yes datawindow.print.preview.zoom = 100");
        }

        // =========================
        // PB: event ue_zoom
        // =========================
        private void ue_zoom()
        {
            // dw_1.Modify("Datawindow.Print.Preview.Zoom = " + em_Zoom.Text)
            dw_1.Modify("Datawindow.Print.Preview.Zoom = " + em_zoom.Text);
        }

        // =========================
        // pb_1 clicked (Cerrar)
        // PB: Close(Parent)
        // =========================
        private void pb_1_Clicked(object? sender, EventArgs e)
        {
            this.Close();
        }

        // =========================
        // pb_2 clicked (Imprimir)
        // PB:
        // SetPointer(HourGlass!)
        // OpenWithParm(w_opciones_de_impresion, dw_1)
        // =========================
        private void pb_2_Clicked(object? sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                var w = new w_opciones_de_impresion
                {
                    Tag = dw_1 // PowerObjectParm
                };
                w.ShowDialog(this);

                // PB tenía comentado Message.DoubleParm / dw_1.Print()
                // => NO lo ejecuto.
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // =========================
        // pb_4 clicked (Zoom In)
        // PB:
        // em_Zoom.Text = String(Integer(em_Zoom.Text) + 10)
        // Parent.TriggerEvent('ue_zoom')
        // =========================
        private void pb_4_Clicked(object? sender, EventArgs e)
        {
            em_zoom.Text = (ToInt(em_zoom.Text) + 10).ToString();
            ue_zoom();
        }

        // =========================
        // pb_5 clicked (Zoom Out)
        // =========================
        private void pb_5_Clicked(object? sender, EventArgs e)
        {
            em_zoom.Text = (ToInt(em_zoom.Text) - 10).ToString();
            ue_zoom();
        }

        // =========================
        // em_zoom modified
        // PB: Parent.TriggerEvent('ue_zoom')
        // =========================
        private void em_zoom_Modified(object? sender, EventArgs e)
        {
            ue_zoom();
        }

        // =========================
        // cbx_1 clicked (Reglas)
        // PB:
        // if checked -> rulers yes/no
        // =========================
        private void cbx_1_Clicked(object? sender, EventArgs e)
        {
            if (cbx_1.Checked)
                dw_1.Modify("datawindow.print.preview.rulers = yes");
            else
                dw_1.Modify("datawindow.print.preview.rulers = no");
        }

        // =========================
        // pb_primer clicked
        // PB: loop ScrollPriorPage until <=1
        // =========================
        private void pb_primer_Clicked(object? sender, EventArgs e)
        {
            long ll_pag;

            dw_1.SetRedraw(false);

            do
            {
                ll_pag = dw_1.ScrollPriorPage();
            }
            while (ll_pag > 1);

            dw_1.SetRedraw(true);
        }

        // =========================
        // pb_anterior clicked
        // PB: ScrollPriorPage
        // =========================
        private void pb_anterior_Clicked(object? sender, EventArgs e)
        {
            dw_1.SetRedraw(false);
            dw_1.ScrollPriorPage();
            dw_1.SetRedraw(true);
        }

        // =========================
        // pb_siguiente clicked
        // PB: ScrollNextPage
        // =========================
        private void pb_siguiente_Clicked(object? sender, EventArgs e)
        {
            dw_1.SetRedraw(false);
            dw_1.ScrollNextPage();
            dw_1.SetRedraw(true);
        }

        // =========================
        // pb_ultimo clicked
        // PB: loop ScrollNextPage until stable or <=0
        // =========================
        private void pb_ultimo_Clicked(object? sender, EventArgs e)
        {
            long ll_pag = 0, ll_pag_sig;

            dw_1.SetRedraw(false);

            do
            {
                ll_pag_sig = ll_pag;
                ll_pag = dw_1.ScrollNextPage();
            }
            while (ll_pag != ll_pag_sig && ll_pag > 0);

            dw_1.SetRedraw(true);
        }

        private static int ToInt(string? s)
        {
            if (int.TryParse((s ?? "").Trim(), out var v))
                return v;
            return 0;
        }
    }

     
}