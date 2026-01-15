// w_menu_arbol_lista.cs
// Migración PB -> C# WinForms (.NET) | SOLO lógica (sin designer)
// NOTA: Mantengo nombres y llamadas tal cual PB (s_nvl[], tv_1.GetItem, lv_1.AddColumn, etc.)
//       Asumo que w_menu_arbol, uo_link, uo_calendar, TreeViewItem, ListViewItem, cat_operacion,
//       Message, guo_app, f_cortar_string, f_cargar_datos_operacion, etc. YA EXISTEN migrados.

using Minotti.Data;
using Minotti.Functions;
using Minotti.Structures;
using Minotti.utils;
using Minotti.Views.Basicos.Models;
using System.Runtime.InteropServices;

namespace Minotti.Views.Menues.Controls
{
    public partial class w_menu_arbol_lista : w_menu_arbol
    {
         
       

        // ====== PB: prototypes ======
        [DllImport("shell32.dll", CharSet = CharSet.Ansi, EntryPoint = "ShellExecuteA")]
        private static extern long ShellExecuteA(long HWND, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);

        // ====== PB: variables ======
        private bool puede_ejecutar = false;

        public w_menu_arbol_lista()
        {
            InitializeComponent();

            // ListView events (PB: clicked / doubleclicked)
            lv_1.Click += lv_1_Clicked;
            lv_1.DoubleClick += lv_1_DoubleClicked;

            // Links (PB: link event)
            lnk_mail.Link += lnk_mail_Link;
            lnk_web.Link += lnk_web_Link;
            lnk_manual.Link += lnk_manual_Link;

            // PictureButtons (PB: clicked)
            pb_confirmar.Click += pb_confirmar_Clicked;
            pb_borrar.Click += pb_borrar_Clicked;
            pb_agregar.Click += pb_agregar_Clicked;
            pb_imprimir.Click += pb_imprimir_Clicked;

            // Form events (PB: closequery / deactivate)
            this.FormClosing += w_menu_arbol_lista_FormClosing;
            this.Deactivate += w_menu_arbol_lista_Deactivate;

            // Tree events (PB: tv_1::selectionchanged / itempopulate)
            // Asumo que el tv_1 migrado expone estos eventos/firmas.
            //tv_1.SelectionChanged += tv_1_SelectionChanged;
            //tv_1.ItemPopulate += tv_1_ItemPopulate;
            this.tv_1.AfterSelect += tv_1_AfterSelect;
            this.tv_1.BeforeExpand += tv_1_BeforeExpand;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // PB: ultimo_nivel = FALSE
            ultimo_nivel = false;
        }


        public void ue_open_menu()
        {
            ue_leer_parametros();

            // Carga SOLO nivel raíz
            this.ue_cargar_nivel(0);
        }


        public override void ue_cargar_nivel(int incremento)
        {
            int cantidad, nuevo_nivel, i_Aux, nuevo_item;
            TreeViewItem tvi_Actual;
            TreeViewItem tvi_Nuevo;
            string sAux = "";

            // Obtener el ítem actual (desde handle → TreeViewItem)
            tv_1_GetItem(incremento, out tvi_Actual);

            if (tvi_Actual.Level >= UpperBound(s_nvl) ||
                (!ultimo_nivel && tvi_Actual.Level == UpperBound(s_nvl) - 1))
                return;

            nuevo_nivel = tvi_Actual.Level + 1;

            // Filtrar siguiente nivel si corresponde
            if (nuevo_nivel > 1)
            {
                var dw = s_nvl[nuevo_nivel].dw;
                dw.SetFilter(string.Empty);
                dw.Filter();

                string colPadre = dw.Describe("#3.Name");
                string valorPadre = Convert.ToString(tvi_Actual.Data) ?? "";
                valorPadre = valorPadre.Replace("'", "''");

                dw.SetFilter($"{colPadre} = '{valorPadre}'");
                dw.Filter();
            }

            var dw_nivel = s_nvl[nuevo_nivel].dw;
            string colClave = dw_nivel.Describe("#1.Name");
            string colNombre = dw_nivel.Describe("#2.Name");

            cantidad = dw_nivel.RowCount();

            for (i_Aux = 1; i_Aux <= cantidad; i_Aux++)
            {
                string clave = dw_nivel.GetItemString(i_Aux, colClave);
                string nombre = dw_nivel.GetItemString(i_Aux, colNombre);

                tvi_Nuevo = new TreeViewItem
                {
                    Data = clave,
                    Label = nombre,
                    PictureIndex = nuevo_nivel,
                    SelectedPictureIndex = (nuevo_nivel == 1) ? 1 : 4,
                    Children = !(nuevo_nivel == UpperBound(s_nvl) ||
                                 (!ultimo_nivel && nuevo_nivel == UpperBound(s_nvl) - 1))
                };

                nuevo_item = tv_1_InsertItemLast(incremento, tvi_Nuevo);

                if (nuevo_item < 1)
                {
                    MessageBox.Show("Error insertando item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (nuevo_item == 1)
                {
                    tv_1_ExpandItem(nuevo_item);
                    tv_1_SelectItem(nuevo_item);
                }
            }

            // 🔁 En w_menu_arbol_lista podés extender esto con lógica para el ListView si estás en último nivel.
        }


        // ========== PB event: ue_cargar_lista ( integer handle ) ==========
        public virtual void ue_cargar_lista(int handle)
        {
            TreeViewItem tvi_Actual;
            int nuevo_nivel;
            string colPadre, colKey, colDesc;
            string valorPadre;
            int cantidad;

            // 1. Obtener el nodo del árbol
            tv_1_GetItem(handle, out tvi_Actual);

            // 2. Nivel siguiente (en PB es Level + 1)
            if (tvi_Actual.Level >= UpperBound(s_nvl)) return;
            nuevo_nivel = tvi_Actual.Level + 1;

            // 3. Validar objectparam definido
            if (nuevo_nivel >= s_nvl.Length) return;
            string nombreDataObject = s_nvl[nuevo_nivel].objectparam;
            if (string.IsNullOrWhiteSpace(nombreDataObject)) return;

            // 4. Cast a datastore (para acceder a DataObject y métodos)
            var dw = s_nvl[nuevo_nivel].dw as datastore;
            if (dw == null) return;

            dw.DataObject = nombreDataObject;
            dw.SetTransObject(SQLCA.Instance);
            dw.Retrieve(uo_app.Instance.at_usuario.Perfil);

            // 5. Filtrar por valor padre
            colPadre = dw.Describe("#3.Name");
            valorPadre = Convert.ToString(tvi_Actual.Data) ?? "";
            valorPadre = valorPadre.Replace("'", "''");

            dw.SetFilter($"{colPadre} = '{valorPadre}'");
            dw.Filter();

            cantidad = dw.RowCount();

            // 6. Obtener columnas visibles
            colKey = dw.Describe("#1.Name");   // operacion
            colDesc = dw.Describe("#2.Name"); // titulo / descripción visible

            // 7. Limpiar y llenar el ListView
            lv_1.Items.Clear();

            for (int i = 1; i <= cantidad; i++)
            {
                string operacion = dw.GetItemString(i, colKey);
                string nombre = dw.GetItemString(i, colDesc);

                var item = new ListViewItem(nombre)
                {
                    Tag = operacion
                };

                lv_1.Items.Add(item);
            }
        }




        public virtual void ue_cargar_lista()
        {
            lv_1.Items.Clear();

            if (dw_param == null) return;

            var nodo = tv_1.SelectedNode;
            if (nodo == null) return;

            string? submodulo = (string?)(((Minotti.Structures.NodeTag)nodo.Tag).Data ?? "");
            if (string.IsNullOrEmpty(submodulo)) return;

            dw_param.SetFilter($"submodulo = '{submodulo}'");
            dw_param.Filter();

            int rowCount = dw_param.RowCount();
            if (rowCount == 0) return;

            // PB: columna visible es #2
            string colDesc = dw_param.Describe("#3.Name");

            // PB: operacion suele ser #1
            string colOperacion = dw_param.Describe("#1.Name");

            for (int i = 1; i <= rowCount; i++)
            {
                string nombre = dw_param.GetItemString(i, colDesc);
                string operacion = dw_param.GetItemString(i, colOperacion);

                lv_1.Items.Add(new ListViewItem(nombre)
                {
                    Tag = operacion
                });
            }
        }





        // ========== PB event: ue_descripcion ( string modulo,  string operacion ) ==========
        public void ue_descripcion(string modulo, string operacion)
        {
            cat_operacion at_op;

            // Lee los datos de la operación que va a ejecutar
            at_op = new cat_operacion();
            at_op.Modulo = modulo;
            at_op.Operacion = operacion;

            f_cargar_datos_operacion.fcargar_datos_operacion(ref at_op);

            // Agrega la descripcion de las operaciones en el microhelp.
            ParentWindow().SetMicroHelp(at_op.Descripcion);
        }

        // ========== PB event: ue_leer_parametros ==========
        protected override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            // Indica que el último nivel no será mostrado en el árbol
            ultimo_nivel = false;

            // Define las columnas de la lista
            lv_1.AddColumn(s_nvl[2].titulo, ListViewColumnAlignment.Left, 1400);
            lv_1.AddColumn("Código", ListViewColumnAlignment.Left, 545);
        }

        // ========== PB event: ue_acomodar_objetos ==========
        public override void ue_acomodar_objetos()
        {
            base.ue_acomodar_objetos();

            int margen_x = 40;
            int margen_y = 40;
            long ll_AnchoRestante, ll_AltoRestante, ll_AnchoInferior;

            tv_1.Left = margen_x;
            tv_1.Width = (int)(this.Width * 0.35);

            ll_AnchoRestante = this.Width;
            ll_AnchoRestante = ll_AnchoRestante - tv_1.Width - 2 * pb_confirmar.Width - 7 * margen_x;
            ll_AltoRestante = (this.Height / 2) - 4 * margen_x;

            lv_1.Left = tv_1.Width + 2 * margen_x;
            lv_1.Width = (int)ll_AnchoRestante;

            tv_1.Top = margen_y;
            tv_1.Height = this.Height - 5 * margen_y;

            lv_1.Top = margen_y;
            lv_1.Height = (int)ll_AltoRestante;

            ll_AnchoInferior = this.Width - tv_1.Width - (5 * margen_x) - dw_calendario.Width;
            ll_AnchoInferior = ll_AnchoInferior / 2;

            ll_AltoRestante = ll_AltoRestante - lnk_mail.Height;

            p_menu.Left = lv_1.Left;
            p_menu.Top = lv_1.Top + lv_1.Height + margen_y;
            p_menu.Width = (int)ll_AnchoInferior;
            p_menu.Height = (int)ll_AltoRestante;

            lnk_mail.Left = p_menu.Left;
            lnk_mail.Top = p_menu.Top + p_menu.Height;

            rte_1.Left = p_menu.Left + p_menu.Width + margen_y;
            rte_1.Top = p_menu.Top;
            rte_1.Width = (int)ll_AnchoInferior;
            rte_1.Height = (int)ll_AltoRestante;

            lnk_web.Left = rte_1.Left;
            lnk_web.Top = rte_1.Top + rte_1.Height;

            dw_calendario.Left = rte_1.Left + rte_1.Width + margen_x;
            dw_calendario.Top = p_menu.Top;

            lnk_manual.Left = dw_calendario.Left;
            lnk_manual.Top = lnk_web.Top;

            pb_confirmar.Left = lv_1.Left + lv_1.Width + margen_x;
            pb_confirmar.Top = lv_1.Top;

            pb_borrar.Left = pb_confirmar.Left + pb_confirmar.Width + margen_x;
            pb_borrar.Top = pb_confirmar.Top;

            pb_agregar.Left = pb_confirmar.Left;
            pb_agregar.Top = pb_confirmar.Top + pb_confirmar.Height + margen_y;

            pb_imprimir.Left = pb_borrar.Left;
            pb_imprimir.Top = pb_agregar.Top;

            st_acceso.Left = pb_agregar.Left;
            st_acceso.Top  = pb_agregar.Top + pb_agregar.Height + margen_y;
        }

        // ========== PB event: ue_optar ==========
        public override void ue_optar()
        {
            base.ue_optar();

            ContextInformation lci_ContextInformation;
            int li_majver;

            this.GetContextService("ContextInformation", out lci_ContextInformation);
            lci_ContextInformation.GetMajorVersion(out li_majver);

            if (lv_1 == null)
                return;


            // PB: carga de iconos en lv_1
            lv_1.AddSmallPicture(FileUtils.GetAppFile("Pictures", "Close_file.GIF"));
            lv_1.AddSmallPicture(FileUtils.GetAppFile("Pictures", "Close_file.GIF"));
            lv_1.AddSmallPicture(FileUtils.GetAppFile("Pictures", "Close_file.GIF"));
            lv_1.AddSmallPicture(FileUtils.GetAppFile("Pictures", "Close_file.GIF"));
            lv_1.AddSmallPicture(FileUtils.GetAppFile("Pictures", "Operacion.bmp"));
        }

        // ========== PB event: ue_iniciar ==========
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            long ll_tvi;

            // muestro el menu expandido.
            //ll_tvi = tv_1.FindItem(TreeViewFindRoot.RootTreeItem, 0);
            ll_tvi = tv_1.TreeViewFindRoot();
            tv_1.ExpandAll();
        }

        // ========== PB: tv_1::selectionchanged ==========
        //private void tv_1_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        //{
        //    // Parent.Event Trigger ue_cargar_lista(newhandle)
        //    ue_cargar_lista(e.NewHandle);
        //}

        protected virtual void ue_cargar_basicas_root()
        {
            // Limpio lista
            lv_1.Items.Clear();

            // PB: dw_param.SetFilter("")
            dw_param.SetFilter(string.Empty);
            dw_param.Filter();

            // En PB, “Básicas” es un submódulo válido global
            int rows = dw_param.RowCount();

            for (int i = 1; i <= rows; i++)
            {
                // En PB suele filtrar por submodulo = 'BASICAS'
                string? submodulo = dw_param.GetItemString(i, "submodulo");

                if (!submodulo.Equals("BASICAS", StringComparison.OrdinalIgnoreCase))
                    continue;

                var item = new ListViewItem(
                    dw_param.GetItemString(i, "descripcion")
                );

                item.Tag = dw_param.GetItemString(i, "operacion");
                lv_1.Items.Add(item);
            }
        }


        private void tv_1_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;

            int handle = GetHandleFromNode(e.Node); // método interno que recupera el int handle
            ue_cargar_lista(handle);
        }


        protected int tv_1_SelectedItem()
        {
            if (tv_1.SelectedNode == null)
                return 0;

            return GetHandleFromNode(tv_1.SelectedNode);
        }


        // ========== PB: tv_1::itempopulate ==========
        //private void tv_1_ItemPopulate(object? sender, ItemPopulateEventArgs e)
        //{
        //    // Parent.Event Trigger ue_cargar_lista(handle)
        //    ue_cargar_lista(e.Handle);
        //}

        private void tv_1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            // PB: itempopulate
            int handle = GetHandleFromNode(e.Node);

            // Parent.Event Trigger ue_cargar_lista(handle)
            this.ue_cargar_lista(handle);
        }


        // ========== PB: lv_1 clicked ==========
        private void lv_1_Clicked(object? sender, EventArgs e)
        {
            if (lv_1.SelectedIndex() < 1) return;

            PBListViewItemExtensions lvi_Actual;
            string Modulo, Operacion;
            string sAux;

            lv_1.GetItem(lv_1.SelectedIndex(), out lvi_Actual);

            if (puede_ejecutar)
            {
                sAux = Convert.ToString(lvi_Actual.Data);
                Modulo = f_cortar_string.fcortar_string(sAux, "-");
                Operacion = sAux;

                // Parent.Event Post ue_descripcion(Modulo, Operacion)
                this.PostEvent_ue_descripcion(Modulo, Operacion);
            }
            else
            {
                // PB: acá podría abrir módulo (no retorna)
            }
        }

        // ========== PB: lv_1 doubleclicked ==========
        private void lv_1_DoubleClicked(object? sender, EventArgs e)
        {
            if (lv_1.SelectedItems.Count == 0 || tv_1.SelectedNode == null)
                return;

            // 1. Operación seleccionada desde el ListView
            string operacion = lv_1.SelectedItems[0].Tag?.ToString() ?? "";

            // 2. Módulo actual desde el nodo del TreeView
            string modulo = "";

            if (tv_1.SelectedNode.Tag is NodeTag tag)
            {
                // tag.Data = "modulo*****submodulo"
                var s = tag.Data?.ToString() ?? "";
                modulo = f_cortar_string.fcortar_string(s, "*****");
            }
            else
            {
                // fallback: intentá cortarlo directo del Text
                var s = tv_1.SelectedNode.Text;
                modulo = f_cortar_string.fcortar_string(s, " - ");
            }

            if (string.IsNullOrEmpty(modulo) || string.IsNullOrEmpty(operacion))
                return;

            // 3. Ejecuta la operación (como PB hacía Parent.Event Post ue_ejecutar)
            this.PostEvent_ue_ejecutar(modulo, operacion);
        }


        // ========== PB: lnk_mail constructor/link ==========
        private void lnk_mail_Link(object? sender, EventArgs e)
        {
            const int SW_SHOWNORMAL = 1;
            ShellExecuteA(HandleToLong(this.Handle), "open", "mailto:minottimaster@gmail.com", "", "", SW_SHOWNORMAL);
        }

        // ========== PB: lnk_web constructor/link ==========
        private void lnk_web_Link(object? sender, EventArgs e)
        {
            const int SW_SHOWNORMAL = 1;
            ShellExecuteA(HandleToLong(this.Handle), "open", "http://www.minottimaster.com", "", "", SW_SHOWNORMAL);
        }

        // ========== PB: lnk_manual constructor/link ==========
        private void lnk_manual_Link(object? sender, EventArgs e)
        {
            const int SW_SHOWNORMAL = 1;
            ShellExecuteA(HandleToLong(this.Handle), "open", "http://minottimaster.com", "", "", SW_SHOWNORMAL);
        }

        // ========== PB: pb_confirmar clicked ==========
        private void pb_confirmar_Clicked(object? sender, EventArgs e)
        {
            string Modulo = "00015";
            string Operacion = "00026";
            this.PostEvent_ue_ejecutar(Modulo, Operacion);
        }

        // ========== PB: pb_borrar clicked ==========
        private void pb_borrar_Clicked(object? sender, EventArgs e)
        {
            string Modulo = "00010";
            string Operacion = "00012";
            this.PostEvent_ue_ejecutar(Modulo, Operacion);
        }

        // ========== PB: pb_agregar clicked ==========
        private void pb_agregar_Clicked(object? sender, EventArgs e)
        {
            string Modulo = "00020";
            string Operacion = "00038";
            this.PostEvent_ue_ejecutar(Modulo, Operacion);
        }

        // ========== PB: pb_imprimir clicked ==========
        private void pb_imprimir_Clicked(object? sender, EventArgs e)
        {
            string Modulo = "00005";
            string Operacion = "00002";
            this.PostEvent_ue_ejecutar(Modulo, Operacion);
        }

        // ========== PB: closequery ==========
        private void w_menu_arbol_lista_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // PB: If Message.StringParm <> 'Aplicación esta cerrando' then ...
            if (utils.Message.StringParm != "Aplicación esta cerrando")
            {
                var r = MessageBox.Show(
                    "¿Esta seguro que desea salir del sistema?",
                    "Minotti 2020",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1
                );

                if (r == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                // PB: HALT CLOSE (deja cerrar)
            }
            else
            {
                utils.Message.StringParm = "";
                utils.Message.Processed = true;
                e.Cancel = true;
            }
        }

        // ========== PB: deactivate ==========
        private void w_menu_arbol_lista_Deactivate(object? sender, EventArgs e)
        {
            // guo_app.uof_GetMdi().EVENT POST ue_mandar_menu_fondo(this)
            guo_app.uof_Getmdi().PostEvent_ue_mandar_menu_fondo(this);
        }

        // ===== helpers (sin inventar reglas, solo adaptación de tipos Win32) =====
        private static long HandleToLong(IntPtr h) => IntPtr.Size == 8 ? h.ToInt64() : h.ToInt32();


        //private void tv_1_BeforeExpand(object? sender, TreeViewCancelEventArgs e)
        //{
        //    Cursor.Current = Cursors.WaitCursor;

        //    int handle = GetHandleFromNode(e.Node);
        //    ue_cargar_nivel(handle);

        //    Cursor.Current = Cursors.Default;
        //}

        //private void tv_1_AfterSelect(object? sender, TreeViewEventArgs e)
        //{
        //    // PB: tv_1::selectionchanged
        //    int handle = GetHandleFromNode(e.Node);

        //    // Parent.Event Trigger ue_cargar_lista(newhandle)
        //    ue_cargar_lista(handle);
        //}

        // =====================================================
        // PB: EVENT POST ue_descripcion (string modulo, string operacion)
        // =====================================================
        public void PostEvent_ue_descripcion(string modulo, string operacion)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() =>
                {
                    ue_descripcion(modulo, operacion);
                }));
            }
            else
            {
                ue_descripcion(modulo, operacion);
            }
        }


    }
}