using Minotti.Data;
using Minotti.utils;
using Minotti.Views.Basicos.Controls;
using Minotti.Views.Basicos.Models;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Reportes.Controls
{
    public partial class w_opciones_de_impresion : Form
    {
        // type variables
        // datastore idw_dw
        private datastore? idw_dw;

        // Para emular CloseWithReturn(This, x)
        public int ReturnValue { get; private set; } = 0;

        public w_opciones_de_impresion()
        {
            InitializeComponent();

            // Enganche de eventos (equivalente a PB events clicked)
            this.Load += w_opciones_de_impresion_Load;
            this.FormClosed += w_opciones_de_impresion_FormClosed;

            cb_printer.Click += cb_printer_Click;
            cb_cancel.Click += cb_cancel_Click;
            cbx_intercalar.Click += cbx_intercalar_Click;
            rb_rango.Click += rb_rango_Click;
            rb_actual.Click += rb_actual_Click;
            rb_todas.Click += rb_todas_Click;
            cb_ok.Click += cb_ok_Click;

            // (cb_1 = propiedades) -> si en PB no tiene lógica acá, no lo invento.
            // Si después pegás el evento PB de cb_1.clicked lo agrego 1:1.
        }

        // =========================
        // PB: event open
        // =========================
        private void w_opciones_de_impresion_Load(object? sender, EventArgs e)
        {
            string sRango, sIncluir, doi;
            bool original;
            uo_dw dw_orig;

            // dw_orig = Message.PowerObjectParm
            // En .NET lo recibimos en Tag (como venimos haciendo en otras migraciones)
            dw_orig = this.Tag as uo_dw
                ?? throw new InvalidOperationException("w_opciones_de_impresion requiere uo_dw en Tag (PowerObjectParm).");

            idw_dw = new datastore();

            // doi = dw_orig.uof_GetdwImpresion()
            doi = dw_orig.uof_getdwimpresion();

            if (dw_orig.DataObject == doi)
            {
                // Viene del Preview
                idw_dw.DataObject = dw_orig.DataObject;
                original = true;
            }
            else
            {
                // Viene desde la Ventana de Reporte
                idw_dw.DataObject = doi;
                original = false;
            }

            // idw_dw.SetTransObject(SQLCA)
            idw_dw.SetTransObject(SQLCA.Instance);

            // Cargar dddw
            if (idw_dw.InsertRow(0) > 0)
                idw_dw.DeleteRow(0);

            // RowsCopy reemplaza ShareData
            if (dw_orig.RowsCopy(1, dw_orig.RowCount(), DataWindowBuffer.Primary, idw_dw, 1, DataWindowBuffer.Primary) < 1)
            {
                idw_dw.DataObject = dw_orig.DataObject;

                if (dw_orig.RowsCopy(1, dw_orig.RowCount(), DataWindowBuffer.Primary, idw_dw, 1, DataWindowBuffer.Primary) < 1)
                {
                    MessageBox.Show("No se puede imprimir el reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
            }

            sle_documento.Text = dw_orig.Describe("DataWindow.Print.DocumentName");
            sle_impresora.Text = dw_orig.Describe("DataWindow.Printer");

            if ((dw_orig.Describe("DataWindow.Print.Collate") ?? string.Empty).ToUpperInvariant() == "NO")
                cbx_intercalar.Checked = false;

            sRango = dw_orig.Describe("DataWindow.Print.Page.Range");
            sIncluir = Left(dw_orig.Describe("DataWindow.Print.Page.RangeInclude"), 1);

            // Captura márgenes si es original (viene del Preview)
            if (original)
            {
                idw_dw.Modify("Datawindow.Print.Margin.Bottom='" + dw_orig.Describe("DataWindow.Print.Margin.Bottom") + "'");
                idw_dw.Modify("Datawindow.Print.Margin.Top='" + dw_orig.Describe("DataWindow.Print.Margin.Top") + "'");
                idw_dw.Modify("Datawindow.Print.Margin.Left='" + dw_orig.Describe("DataWindow.Print.Margin.Left") + "'");
                idw_dw.Modify("Datawindow.Print.Margin.Right='" + dw_orig.Describe("DataWindow.Print.Margin.Right") + "'");
            }

            em_copias.Text = "1";

            // rango
            if (string.IsNullOrEmpty(sRango))
            {
                rb_todas.Checked = true;
            }
            else
            {
                rb_rango.Checked = true;
                sle_rango.Text = sRango;
                sle_rango.Enabled = true;
            }

            // incluir
            // PB: SelectItem(2/3/1) con items {Todas, Pares, Impares}
            switch (sIncluir)
            {
                case "1": // Pares
                    ddlb_incluir.SelectedIndex = 1;
                    break;
                case "2": // Impares
                    ddlb_incluir.SelectedIndex = 2;
                    break;
                default: // Todas
                    ddlb_incluir.SelectedIndex = 0;
                    break;
            }

            // Ajuste inicial de imagen según estado de intercalar (PB lo hace por evento)
            ue_intercalar();
        }

        // =========================
        // PB: event close
        // =========================
        private void w_opciones_de_impresion_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (idw_dw != null)
            {
                idw_dw.ShareDataOff();
                idw_dw.Dispose();
                idw_dw = null;
            }
        }

        // =========================
        // PB: event ue_intercalar
        // =========================
        private void ue_intercalar()
        {
            if (cbx_intercalar.Checked)
                p_1.ImageLocation = FileUtils.GetAppFile("Pictures", "Intercalado.bmp");
            else
                p_1.ImageLocation = FileUtils.GetAppFile("Pictures", "No Intercalado.bmp");
        }

        // =========================
        // PB: event ue_imprimir
        // =========================
        private void ue_imprimir()
        {
            if (idw_dw == null) return;

            string comando, sAux;
            int iAux;

            // Documento
            comando = "DataWindow.Print.DocumentName='" + sle_documento.Text + "'";

            // Copias
            iAux = ToInt(em_copias.Text);
            if (iAux < 1) iAux = 1;
            comando = comando + " DataWindow.Print.Copies='" + iAux.ToString() + "'";

            // Intercalar
            if (cbx_intercalar.Checked)
                comando = comando + " DataWindow.Print.Collate = yes";
            else
                comando = comando + " DataWindow.Print.Collate = no";

            // RangeInclude
            switch (Left(ddlb_incluir.Text ?? string.Empty, 9))
            {
                case "Páginas P": // Pares
                    comando = comando + " DataWindow.Print.Page.RangeInclude = 1";
                    break;
                case "Páginas I": // Impares
                    comando = comando + " DataWindow.Print.Page.RangeInclude = 2";
                    break;
                default: // Todas
                    comando = comando + " DataWindow.Print.Page.RangeInclude = 0";
                    break;
            }

            // Page.Range
            if (rb_actual.Checked)
            {
                iAux = ToInt(idw_dw.Describe("DataWindow.FirstRowOnPage"));
                if (iAux == 0)
                {
                    MessageBox.Show("No hay páginas seleccionadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // evaluate('page()', iAux)
                string page = idw_dw.Describe("evaluate('page()', " + iAux.ToString() + ")");
                comando = comando + " DataWindow.Print.Page.Range = '" + page + "'";
            }
            else if (rb_rango.Checked)
            {
                comando = comando + " DataWindow.Print.Page.Range = '" + sle_rango.Text + "'";
            }
            else
            {
                comando = comando + " DataWindow.Print.Page.Range = ''";
            }

            // Modify del DataWindow
            sAux = idw_dw.Modify(comando).ToString();
            if (!string.IsNullOrEmpty(sAux))
            {
                MessageBox.Show(
                    "Mensaje de error: " + sAux + "\r\nComando: " + comando,
                    "Error al cargar las opciones",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            idw_dw.Print();

            // CloseWithReturn(This, 1)
            ReturnValue = 1;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // =========================
        // PB: wf_enable_printfile / wf_disable_printfile
        // (en PB están vacías/comentadas)
        // =========================
        public void wf_enable_printfile()
        {
            // No-op (PB comentado)
        }

        public void wf_disable_printfile()
        {
            // No-op (PB comentado)
        }

        // =========================
        // Handlers PB clicked
        // =========================
        private void cb_printer_Click(object? sender, EventArgs e)
        {
            // PB: PrintSetup()
            // sle_Impresora.Text = idw_dw.Describe('DataWindow.Printer')
            PrintSetup();

            if (idw_dw != null)
                sle_impresora.Text = idw_dw.Describe("DataWindow.Printer");
        }

        private void cb_cancel_Click(object? sender, EventArgs e)
        {
            // PB: closewithreturn(parent,-1)
            ReturnValue = -1;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cbx_intercalar_Click(object? sender, EventArgs e)
        {
            // PB: Parent.PostEvent('ue_intercalar')
            // En WinForms lo emulo con BeginInvoke (post al message loop)
            this.BeginInvoke((Action)(() => ue_intercalar()));
        }

        private void rb_rango_Click(object? sender, EventArgs e)
        {
            // PB: sle_Rango.Enabled = TRUE
            sle_rango.Enabled = true;
        }

        private void rb_actual_Click(object? sender, EventArgs e)
        {
            // PB:
            // sle_Rango.Text = ''
            // sle_Rango.Enabled = FALSE
            sle_rango.Text = "";
            sle_rango.Enabled = false;
        }

        private void rb_todas_Click(object? sender, EventArgs e)
        {
            // PB:
            // sle_Rango.Text = ''
            // sle_Rango.Enabled = FALSE
            sle_rango.Text = "";
            sle_rango.Enabled = false;
        }

        private void cb_ok_Click(object? sender, EventArgs e)
        {
            // PB: Parent.TriggerEvent('ue_imprimir')
            ue_imprimir();
        }

        // =========================
        // Equivalente PB PrintSetup()
        // =========================
        private void PrintSetup()
        {
            // PB llama PrintSetup() y eso ajusta impresora del DW.
            // En .NET mostramos un PrintDialog y seteamos DataWindow.Printer.
            if (idw_dw == null) return;

            using var dlg = new PrintDialog
            {
                AllowSomePages = true,
                UseEXDialog = true
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                // Ajusta impresora en el DataWindow
                // (en PB el Describe('DataWindow.Printer') se actualiza luego del PrintSetup)
                idw_dw.Modify("DataWindow.Printer='" + dlg.PrinterSettings.PrinterName + "'");
            }
        }

        // =========================
        // Helpers PB-like
        // =========================
        private static string Left(string? s, int n)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            if (n <= 0) return string.Empty;
            return s.Length <= n ? s : s.Substring(0, n);
        }

        private static int ToInt(string? s)
        {
            if (int.TryParse(s?.Trim(), out int v))
                return v;
            return 0;
        }
    }

    // Si ya lo tenés en tu migración, eliminá esto y usá el tuyo.
    // Lo dejo acá solo como enum de apoyo para no cambiar lógica de RowsCopy.
    public enum DataWindowBuffer
    {
        Primary = 0
    }
}