using Minotti.Data;
using Minotti.Functions;
using Minotti.Structures;
using Minotti.utils;
using Minotti.Views.Basicos.Models;
using MinottiApp.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Minotti.Views.Basicos.Controls
{
    /// <summary>
    /// Equivalente PB: global type uo_tab from tab.
    /// Heredamos de TabControl para mapear el tab de PowerBuilder.
    /// </summary>
    public class uo_tab : TabControl
    {
        // =========================
        // Campos PB -> C#
        // =========================

        // st_espacios s_esp  (ya deberías tenerlo migrado como clase st_espacios)
        public st_espacios s_esp { get; set; } = new st_espacios();

        // uo_tp tp[]
        // En PB es un array; en C# usamos List para simplificar.
        private readonly List<uo_tp> tp = new List<uo_tp>();

        // String is_parametros[]
        private string[] is_parametros = Array.Empty<string>();

        // Integer i_borde = 40
        private int i_borde = 40;

        // Integer i_Cabecera = 250
        private int i_Cabecera = 250;

        // boolean continuar_grabando = True
        private bool continuar_grabando = true;

        private bool _boldSelectedText;
        private Font? _normalFont;
        private Font? _boldFont;

        // =========================
        // Constructor
        // =========================

        public uo_tab()
        {
            _normalFont = this.Font;
            _boldFont = new Font(this.Font, FontStyle.Bold);

            // Para poder dibujar texto custom
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.DrawItem += Uo_tab_DrawItem;


            // PB: propiedades visuales default
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Multiline = true;
            this.SizeMode = TabSizeMode.Fixed;
            // Puedes ajustar ItemSize si querés algo más parecido visualmente.
        }

        // =========================
        // Gestión de páginas (tp[])
        // =========================

        /// <summary>
        /// Agrega una página (equivalente a tp[pagina] en PB).
        /// uo_tp debería ser un UserControl que representa la lógica de cada página.
        /// </summary>
        public void AddPage(string titulo, uo_tp page, string? bitmapPath = null)
        {
            if (page == null) throw new ArgumentNullException(nameof(page));

            tp.Add(page);

            var tabPage = new TabPage(titulo)
            {
                Tag = page
            };

            page.Dock = DockStyle.Fill;
            tabPage.Controls.Add(page);

            if (!string.IsNullOrEmpty(bitmapPath))
            {
                try
                {
                    tabPage.ImageKey = bitmapPath;
                    // El ImageList de la TabControl lo configurás afuera si querés usar íconos reales.
                }
                catch
                {
                    // Si el bitmap no se puede cargar, no rompemos la app.
                }
            }

            this.TabPages.Add(tabPage);
        }

        /// <summary>
        /// Devuelve la lista de páginas (solo lectura).
        /// </summary>
        public IReadOnlyList<uo_tp> Pages => tp.AsReadOnly();

        // =========================
        // Port de los métodos PB
        // =========================

        /// <summary>
        /// PB: public function integer uof_largo ()
        /// Toma el mayor de los largos de las páginas que contiene + i_cabecera.
        /// </summary>
        public int uof_largo()
        {
            int max = 0;

            foreach (var page in tp)
            {
                if (page == null) continue;
                max = Math.Max(max, page.uof_largo());
            }

            return max + i_Cabecera;
        }

        /// <summary>
        /// PB: public function integer uof_ancho ()
        /// Toma el mayor de los anchos de las páginas que contiene.
        /// </summary>
        public int uof_ancho()
        {
            int max = 0;

            foreach (var page in tp)
            {
                if (page == null) continue;
                max = Math.Max(max, page.uof_ancho());
            }

            return max;
        }

        /// <summary>
        /// PB: public function boolean uof_cambios_pendientes ()
        /// Pregunta a cada página si tiene cambios pendientes.
        /// </summary>
        public bool uof_cambios_pendientes()
        {
            foreach (var page in tp)
            {
                if (page == null) continue;
                if (page.uof_cambios_pendientes())
                    return true;
            }

            return false;
        }

        // =========================
        // Port de eventos ue_* clave
        // =========================

        /// <summary>
        /// PB: event ue_resize (integer ancho_total, integer largo_total)
        /// Ajusta tamaño del tab y llama a ue_acomodar_objetos().
        /// </summary>
        public void ue_resize(int ancho_total, int largo_total)
        {
            this.Width = ancho_total;
            this.Height = largo_total;
            this.ue_acomodar_objetos();
        }

        /// <summary>
        /// PB: event ue_acomodar_objetos
        /// Pasa el evento a cada una de las páginas.
        /// </summary>
        public void ue_acomodar_objetos()
        {
            foreach (var page in tp)
            {
                page?.ue_acomodar_objetos();
            }
        }

        /// <summary>
        /// PB: event ue_iniciar (string arg_accion, string arg_param[])
        /// Guarda los parámetros y llama a ue_iniciar en cada página.
        /// </summary>
        public void ue_iniciar(string arg_accion, string[] arg_param)
        {
            is_parametros = arg_param ?? Array.Empty<string>();

            if (tp.Count > 0)
            {
                foreach (var page in tp)
                {
                    page?.ue_iniciar(arg_accion, is_parametros);
                }

                // Selecciono el primer tab
                if (this.TabPages.Count > 0)
                    this.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// PB: event ue_procesar
        /// Transfiere el evento a todas las páginas.
        /// </summary>
        public void ue_procesar()
        {
            foreach (var page in tp)
            {
                page?.ue_procesar();
            }
        }

        /// <summary>
        /// PB: event ue_reset
        /// </summary>
        public void ue_reset()
        {
            foreach (var page in tp)
            {
                page?.ue_reset();
            }
        }

        /// <summary>
        /// PB: event ue_reiniciar
        /// </summary>
        public void ue_reiniciar()
        {
            if (tp.Count > 0)
            {
                foreach (var page in tp)
                {
                    page?.ue_reiniciar();
                }

                if (this.TabPages.Count > 0)
                    this.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// PB: event ue_aceptar_datos (retorna boolean).
        /// Si alguna página devuelve false, selecciona el tab y corta.
        /// </summary>
        public bool ue_aceptar_datos()
        {
            for (int i = 0; i < tp.Count; i++)
            {
                var page = tp[i];
                if (page == null) continue;

                if (!page.ue_aceptar_datos())
                {
                    // Selecciona el tab donde falló.
                    if (i < this.TabPages.Count)
                        this.SelectedIndex = i;

                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// PB: event ue_validar_datos (retorna boolean).
        /// </summary>
        public bool ue_validar_datos()
        {
            for (int i = 0; i < tp.Count; i++)
            {
                var page = tp[i];
                if (page == null) continue;

                if (!page.ue_validar_datos())
                {
                    if (i < this.TabPages.Count)
                        this.SelectedIndex = i;

                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// PB: event ue_preconfirmar (retorna boolean).
        /// </summary>
        public bool ue_preconfirmar()
        {
            foreach (var page in tp)
            {
                if (page == null) continue;
                if (!page.ue_preconfirmar())
                    return false;
            }

            return true;
        }

        /// <summary>
        /// PB: event ue_confirmar (boolean barg_accept, boolean barg_limpiar) retorna boolean.
        /// En PB: actualiza cada página, la última decide si limpia o no.
        /// </summary>
        public bool ue_confirmar(bool barg_accept, bool barg_limpiar)
        {
            int cantidad = tp.Count;
            if (cantidad == 0)
                return true;

            // Todas menos la última, con barg_limpiar = false
            for (int i = 0; i < cantidad - 1; i++)
            {
                var page = tp[i];
                if (page == null) continue;

                if (!page.ue_confirmar(barg_accept, false))
                    return false;
            }

            // Última página con barg_limpiar real
            var lastPage = tp[cantidad - 1];
            if (lastPage == null) return true;

            if (lastPage.ue_confirmar(barg_accept, barg_limpiar))
            {
                // En PB: "Debe resetear las flags de los tp anteriores" – acá lo podrías implementar
                // si en uo_tp mantenés algún flag interno.
                return true;
            }

            return false;
        }

        /// <summary>
        /// PB: event ue_posconfirmar
        /// </summary>
        public void ue_posconfirmar()
        {
            foreach (var page in tp)
            {
                page?.ue_posconfirmar();
            }
        }

        // =========================
        // ue_completar_claves (más delicado)
        // =========================

        /// <summary>
        /// PB: event ue_completar_claves (string sarg_param[]) returns boolean
        /// 
        /// - Usa una copia de is_parametros.
        /// - En la primer página:
        ///   - ue_completar_claves(sAux[])
        ///   - ue_leer_claves(sAux[])
        /// - En las demás páginas:
        ///   - ue_completar_claves(sAux[])
        /// </summary>
        public bool ue_completar_claves(string[] sarg_param)
        {
            // Copiamos el array original
            var sAux = (string[])is_parametros.Clone();

            int cantidad = tp.Count;
            if (cantidad < 1)
                return false;

            var first = tp[0];
            if (first == null)
                return false;

            // En la primer página: parte fija + leer claves completas
            if (!first.ue_completar_claves(sAux))
                return false;

            if (!first.ue_leer_claves(sAux))
                return false;

            // En las siguientes: solo completar claves con la clave completa
            for (int i = 1; i < cantidad; i++)
            {
                var page = tp[i];
                if (page == null) continue;

                if (!page.ue_completar_claves(sAux))
                    return false;
            }

            return true;
        }

        // =========================
        // ue_leer_parametros
        // =========================
        //
        // En PB:
        // - Usa un DataStore "d_carpetas" para leer las páginas y hacer OpenTab(tp[pagina], objeto...).
        // - Acá lo dejamos como "hook" para que vos le inyectes la lógica de carga desde DB.
        //
        // Podés, por ejemplo, pasarle una lista de uost_tab_info ya cargada.

        /// <summary>
        /// PB: event ue_leer_parametros (ref string parametros)
        /// Traducción fiel del SRU:
        /// - Carga d_carpetas
        /// - Para cada fila crea una página
        /// - Construye st_pagina_carpeta
        /// - Llama ue_leer_parametros(s_pag) en cada página
        /// </summary>
        public void ue_leer_parametros(string parametros)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.BoldSelectedText = true;

            // ===== PB: Crear datastore d_carpetas =====
            var ds_carpetas = new DataStoreWrapper("d_carpetas");            
            ds_carpetas.SetTransObject(SQLCA.Instance);
            

            // PB: Retrieve(f_ProxParam(parametros))
            string parametrosLocal = parametros;
            string retrieveParam = f_proxparam.fproxparam(parametrosLocal);// PBParamHelper.f_ProxParam(parametrosLocal);
            ds_carpetas.Retrieve(retrieveParam);

            // ===== PB: recorrer filas =====
            for (int pagina = 1; pagina <= ds_carpetas.RowCount; pagina++)
            {
                string objeto = ds_carpetas.GetItemString(pagina, "Objeto");

                // PB: OpenTab(tp[pagina], Objeto, 0)
                var page = CrearPaginaDesdeInfo(new uost_tab_info
                {
                    titulo = ds_carpetas.GetItemString(pagina, "Titulo"),
                    bitmap = ds_carpetas.GetItemString(pagina, "Bitmap"),
                    parametros = ds_carpetas.GetItemString(pagina, "Parametros"),
                    dw = objeto
                });

                if (page != null)
                {
                    AddPage(ds_carpetas.GetItemString(pagina, "Titulo"), page,
                        ds_carpetas.GetItemString(pagina, "Bitmap"));

                    // ===== PB: s_pag = st_pagina_carpeta =====
                    var s_pag = new st_pagina_carpeta
                    {
                        titulo = ds_carpetas.GetItemString(pagina, "Titulo"),
                        bitmap = ds_carpetas.GetItemString(pagina, "Bitmap"),
                        parametros = ds_carpetas.GetItemString(pagina, "Parametros")
                    };

                    // PB: tp[pagina].Event Trigger ue_leer_parametros(s_pag)
                    DynamicEventInvoker.Trigger(page, "ue_leer_parametros", s_pag);
                }
            }

            ds_carpetas.Destroy();
            Cursor.Current = Cursors.Default;
        }



        private static IEnumerable<(T item, int index)> EnumerateWithIndex<T>(IEnumerable<T> source)
        {
            int i = 0;
            foreach (var item in source)
            {
                yield return (item, i);
                i++;
            }
        }

        /// <summary>
        /// Hook para crear una página a partir de la info de carpeta.
        /// Acá podés instanciar distintos tipos de uo_tp según info.dw.
        /// </summary>
        private uo_tp? CrearPaginaDesdeInfo(uost_tab_info info)
        {
            // De momento devolvemos null para que no rompa;
            // vos podés implementar un factory real:
            //   switch(info.dw) { case "d_clientes": return new uo_tp_clientes(); ... }

            return null;
        }


        // ===============================================================
        // PB Event: ue_imprimir
        // PB permite redefinir este evento en cualquier UserObject.
        // En C# debemos declararlo virtual para que las subclases lo overrideen.
        // ===============================================================
        public virtual void ue_imprimir()
        {
            // PB default: no hace nada
        }

        public virtual void ue_preview()
        {
            // PB default: no hace nada
        }

        private void Uo_tab_DrawItem(object? sender, DrawItemEventArgs e)
        {
            var tab = this.TabPages[e.Index];
            bool selected = (e.Index == this.SelectedIndex);

            var font = (_boldSelectedText && selected) ? _boldFont! : _normalFont!;

            e.Graphics.DrawString(
                tab.Text,
                font,
                Brushes.Black,
                e.Bounds.X + 3,
                e.Bounds.Y + 3);
        }

        /// <summary>
        /// PB: BoldSelectedText = TRUE/FALSE
        /// </summary>
        public bool BoldSelectedText
        {
            get => _boldSelectedText;
            set
            {
                _boldSelectedText = value;
                this.Invalidate();
            }
        }


        /// <summary>
        /// PB: TriggerEvent("ue_xxx", args...)
        /// Emulado vía reflection
        /// </summary>
        public virtual int TriggerEvent(string eventName, params object?[] args)
        {
            if (string.IsNullOrWhiteSpace(eventName))
                return -1;

            // Buscar método en la instancia (case-insensitive, como PB)
            MethodInfo? mi = this.GetType().GetMethod(
                eventName,
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.IgnoreCase
            );

            if (mi == null)
                return 0; // PB: evento inexistente → no hace nada

            try
            {
                mi.Invoke(this, args);
                return 1;
            }
            catch (TargetParameterCountException)
            {
                // PB permitía TriggerEvent aun si no coincidían parámetros
                return -1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
