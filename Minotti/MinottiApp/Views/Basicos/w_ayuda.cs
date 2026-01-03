

using Minotti.Views.Basicos.Models;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Basicos
{
    // Migración de PowerBuilder: w_ayuda.srw (window) desde w_response
    // Mantiene el nombre del tipo: w_ayuda
    /// <summary>
    /// Equivalente a: global type w_ayuda from w_response
    /// </summary>
    public partial class w_ayuda : w_response
    {
        // type variables
        private string cadena = string.Empty;
        private int cantidad;
        // end variables

        public w_ayuda()
        {
            InitializeComponent();
            // on w_ayuda.create -> ya queda equivalente por InitializeComponent + Controls.Add
        }

        // event ue_leer_parametros
        public  override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            // cadena = Message.StringParm
            cadena = Minotti.utils.Message.StringParm ?? string.Empty;

            /* Seteo  el titulo de la ventana */
            this.Text = "Ayuda"; // PB: this.Title

            dw_1.uof_setdataobject("d_ayuda");

            dw_1.cant_filas = 1;
        }

        // event ue_iniciar
        public  override void ue_iniciar()
        {
            base.ue_iniciar();

            string titulo, descripcion;
            int i, row, j;

            cantidad = 1;
            i = 1;

            j = PosPB(cadena, "*TIT*", i);
            i = j + 5;

            while (j > 0)
            {
                row = dw_1.InsertRow(0);

                j = PosPB(cadena, "*DES*", i);
                if (j == 0) break;

                titulo = MidPB(cadena, i, j - i);
                dw_1.SetItem(row, "titulo", titulo);

                i = j + 5;

                j = PosPB(cadena, "*TIT*", i);
                if (j == 0)
                {
                    dw_1.SetItem(row, "descripcion", MidPB(cadena, i, LenPB(cadena) - i + 1));
                    break;
                }
                else
                {
                    descripcion = MidPB(cadena, i, j - i);
                    dw_1.SetItem(row, "descripcion", descripcion);
                    i = j + 5;
                }

                cantidad++;
            }
        }

        // event ue_ajustar_tamaño
        public  override void ue_ajustar_tamaño()
        {
            base.ue_ajustar_tamaño();

            int largo, wk_ancho, wk_alto, ancho;

            dw_1.Width = dw_1.uof_ancho() + 80;

            largo = dw_1.uof_largo() + 80;
            ancho = dw_1.uof_ancho() + 80;

            /* Obtengo el Ancho y Alto del Area de trabajo de la ventana MDI */
            // PB: guo_app.uof_Getmdi().wf_GetAreaTrabajo(wk_ancho, wk_alto)
            wk_ancho = 0;
            wk_alto = 0;

            try
            {
                //guo_app.uof_getmdi().wf_GetAreaTrabajo( wk_ancho, wk_alto);
                uo_app.Instance.uof_getmdi().wf_GetAreaTrabajo(out wk_ancho, out wk_alto);

            }
            catch
            {
                // Si en tu migración guo_app todavía no está, esto evita crash.
                // Si NO querés fallback, lo sacamos y dejamos solo guo_app.
                var wa = Screen.FromControl(this).WorkingArea;
                wk_ancho = wa.Width;
                wk_alto = wa.Height;
            }

            /* Abro la ventana al 80 % de la Altura del MDI */
            largo = (int)((wk_alto * 0.8) - (s_esp.borde * 3 + pb_continuar.Height + 200));
            if ((ancho + s_esp.borde * 2) > wk_ancho)
                ancho = wk_ancho - (s_esp.borde * 2) - 120;

            dw_1.Height = largo;
            dw_1.Width = ancho;

            this.Height = largo + s_esp.borde * 3 + pb_continuar.Height + 200;
            this.Width = ancho + s_esp.borde * 2;

            dw_1.Top = s_esp.borde;  // PB: dw_1.y
            dw_1.Left = s_esp.borde; // PB: dw_1.x

            pb_continuar.Top = dw_1.Top + dw_1.Height + s_esp.borde * 2;
            pb_continuar.Left = (int)(this.Width / 2.0) - (int)(pb_continuar.Width / 2.0);
        }

        // event pb_continuar::clicked
        private void pb_continuar_Clicked(object? sender, EventArgs e)
        {
            base.pb_continuar_Clicked(sender, e);
            this.Close(); // PB: Close(Parent) -> en WinForms cerramos esta ventana
        }

        // ===== Helpers para emular PB Pos/Mid/Len (1-based) =====
        private static int PosPB(string source, string find, int startAt1Based)
        {
            if (source == null) return 0;
            if (find == null) return 0;

            int start0 = Math.Max(0, startAt1Based - 1);
            if (start0 >= source.Length) return 0;

            int idx = source.IndexOf(find, start0, StringComparison.Ordinal);
            return idx >= 0 ? idx + 1 : 0; // PB devuelve 1-based, 0 si no encuentra
        }

        private static string MidPB(string source, int startAt1Based, int length)
        {
            if (string.IsNullOrEmpty(source)) return string.Empty;
            if (length <= 0) return string.Empty;

            int start0 = Math.Max(0, startAt1Based - 1);
            if (start0 >= source.Length) return string.Empty;

            int len = Math.Min(length, source.Length - start0);
            return source.Substring(start0, len);
        }

        private static int LenPB(string source) => source?.Length ?? 0;
    }
}
