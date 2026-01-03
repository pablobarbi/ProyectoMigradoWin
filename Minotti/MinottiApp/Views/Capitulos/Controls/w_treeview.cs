
using Minotti.Data;
using Minotti.Structures;
using Minotti.utils;
using Minotti.Views.Basicos;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Minotti.Views.Capitulos.Controls
{
    public partial class w_treeview : w_operacion
    {
        // PB variables
        protected st_nivel[] s_nvl = Array.Empty<st_nivel>();
        protected int nivel_actual;
        protected datastore? dw_param;
        protected bool ultimo_nivel = true; // Indica si el último nivel se ve en el árbol

        public w_treeview()
        {
            InitializeComponent();

            // PB: itempopulate -> acá lo emulamos con BeforeExpand
            tv_1.BeforeExpand += tv_1_BeforeExpand;

            // PB: ue_iniciar dispara ue_cargar_nivel(0)
            this.Load += (_, _) => ue_iniciar();

            // PB: close destruye datastores
            this.FormClosing += (_, _) => close();
        }

        // =====================================================
        // PB: event ue_leer_parametros
        // =====================================================
        public override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            // PB: niveles = 4 (pero luego crea 1..3)
            int niveles = 4;
            s_nvl = new st_nivel[niveles + 1]; // indexado 1..niveles

            // ===== NIVEL 1 =====
            s_nvl[1] = new st_nivel();
            s_nvl[1].dw = new datastore();
            s_nvl[1].titulo = "Capitulos";
            s_nvl[1].dw.DataObject = "dk_capitulos";
            s_nvl[1].dw.SetTransObject(SQLCA.Instance);
            s_nvl[1].activo = 1;
            s_nvl[1].dw.Retrieve();

            // ===== NIVEL 2 =====
            s_nvl[2] = new st_nivel();
            s_nvl[2].dw = new datastore();
            s_nvl[2].titulo = "Capitulos";
            s_nvl[2].dw.DataObject = "dk_capitulaciones";
            s_nvl[2].dw.SetTransObject(SQLCA.Instance);
            s_nvl[2].activo = 1;
            s_nvl[2].dw.Retrieve();

            // ===== NIVEL 3 =====
            s_nvl[3] = new st_nivel();
            s_nvl[3].dw = new datastore();
            s_nvl[3].titulo = "Capitulos";
            s_nvl[3].dw.DataObject = "dk_rubricaciones";
            s_nvl[3].dw.SetTransObject(SQLCA.Instance);
            s_nvl[3].activo = 1;
            s_nvl[3].dw.Retrieve();
        }

        // =====================================================
        // PB: event ue_ajustar_posicion
        // =====================================================
        public override void ue_ajustar_posicion()
        {
            base.ue_ajustar_posicion();

            // This.X = 1 / This.Y = 1
            this.Left = 1;
            this.Top = 1;

            // guo_app.uof_GetMdi().wf_GetAreaTrabajo(ancho_mdi, largo_mdi)
            // Mantengo la llamada PB. Si tu guo_app existe, esto queda igual.
            // Si no, lo podés ajustar en tu base.
            try
            {
                int ancho_mdi, largo_mdi;
                guo_app.uof_Getmdi().wf_GetAreaTrabajo(out ancho_mdi, out largo_mdi);
                this.Width = ancho_mdi;
                this.Height = largo_mdi;
            }
            catch
            {
                // No invento lógica funcional PB: esto es solo fallback visual para no romper.
                var wa = Screen.PrimaryScreen?.WorkingArea ?? new Rectangle(0, 0, 1024, 768);
                this.Width = wa.Width;
                this.Height = wa.Height;
            }
        }

        // =====================================================
        // PB: event ue_iniciar
        // =====================================================
        public override void ue_iniciar()
        {
            base.ue_iniciar();

            // PB normalmente ya llama ue_leer_parametros en el flujo de w_operacion.
            // Si tu base NO lo hace, descomentá:
            // ue_leer_parametros();

            // PB: This.Event Trigger ue_cargar_nivel(0)
            ue_cargar_nivel(0);
        }

        // =====================================================
        // PB: event ue_cargar_nivel(integer incremento)
        //  "incremento" = línea actual del árbol (handle)
        // =====================================================
        public virtual void ue_cargar_nivel(int incremento)
        {
            SetPointerHourGlass();

            // En PB: tv_1.GetItem(incremento, tvi_Actual)
            // En WinForms no hay "handle" numérico estable.
            // Emulación:
            // - incremento == 0 => raíz lógica (carga nivel 1)
            // - incremento != 0 => se interpreta como índice lineal (preorden) dentro del árbol
            TreeNode? tvi_Actual = (incremento == 0) ? EnsureRootNode() : FindNodeByLinearIndex(incremento);

            if (tvi_Actual == null)
            {
                SetPointerArrow();
                return;
            }

            int levelPb = (tvi_Actual.Parent == null) ? 0 : tvi_Actual.Level; // raíz lógica nivel 0
            int ub = UpperBound(s_nvl);

            // If tvi_Actual.Level >= UpperBound(s_nvl[]) OR (not(ultimo_nivel) AND tvi_Actual.Level = UpperBound(s_nvl[])-1) Then Return
            if (levelPb >= ub || (!ultimo_nivel && levelPb == ub - 1))
            {
                SetPointerArrow();
                return;
            }

            int nuevo_nivel = levelPb + 1;

            // Filtra datos del nivel a cargar
            if (nuevo_nivel > 1)
            {
                string col3 = s_nvl[nuevo_nivel].dw.Describe("#3.Name");
                string dataActual = Convert.ToString(tvi_Actual.Tag) ?? string.Empty;

                s_nvl[nuevo_nivel].dw.SetFilter(col3 + "=\"" + dataActual + "\"");
                s_nvl[nuevo_nivel].dw.Filter();
            }

            int cantidad = s_nvl[nuevo_nivel].dw.RowCount();

            // Limpio hijos previos (PB itempopulate suele regenerar)
            tvi_Actual.Nodes.Clear();

            // Por cada ítem
            for (int i_Aux = 1; i_Aux <= cantidad; i_Aux++)
            {
                string sAux = string.Empty;

                // Si está en el nivel de operaciones, en el Data pone Modulo - Operacion
                if (nuevo_nivel == ub)
                {
                    sAux = s_nvl[nuevo_nivel].dw.GetItemString(i_Aux, "modulo") + " - ";
                }

                string data = sAux + s_nvl[nuevo_nivel].dw.GetItemString(i_Aux, s_nvl[nuevo_nivel].dw.Describe("#1.Name"));
                string label = s_nvl[nuevo_nivel].dw.GetItemString(i_Aux, s_nvl[nuevo_nivel].dw.Describe("#2.Name"));

                // PB: tvi_Nuevo.Data / Label / PictureIndex...
                TreeNode tvi_Nuevo = new TreeNode(label)
                {
                    Tag = data
                };

                // PictureIndex / SelectedPictureIndex:
                // - Se setean si hay ImageList asignada con índices válidos.
                // - No invento imágenes; solo copio la intención.
                tvi_Nuevo.ImageIndex = nuevo_nivel;

                if (nuevo_nivel == 1)
                    tvi_Nuevo.SelectedImageIndex = 1;
                else
                    tvi_Nuevo.SelectedImageIndex = 4;

                bool esUltimo = (nuevo_nivel == ub) || (!ultimo_nivel && nuevo_nivel == ub - 1);

                // PB: Children = TRUE/FALSE
                // WinForms: si tiene hijos, pongo placeholder para que el expand llame y cargue.
                if (!esUltimo)
                {
                    tvi_Nuevo.Nodes.Add(new TreeNode()); // placeholder
                }

                // PB: InsertItemLast(incremento, tvi_Nuevo)
                // Si incremento==0, se inserta bajo raíz lógica.
                tvi_Actual.Nodes.Add(tvi_Nuevo);

                // PB: si nuevo_item = 1 expande y selecciona (en PB el primer hijo)
                if (i_Aux == 1)
                {
                    tvi_Actual.Expand();
                    tv_1.SelectedNode = tvi_Nuevo;
                }
            }

            SetPointerArrow();
        }

        // =====================================================
        // PB: event close
        // =====================================================
        protected virtual void close()
        {
            base.close();

            // Destruye los Data Stores creados en el Open
            for (int iAux = 1; iAux <= UpperBound(s_nvl); iAux++)
            {
                if (s_nvl[iAux]?.dw != null)
                {
                    s_nvl[iAux].dw.Destroy();
                }
            }

            if (dw_param != null)
            {
                dw_param.Destroy();
            }
        }

        // =====================================================
        // PB: tv_1 itempopulate -> Parent.Event Trigger ue_cargar_nivel(handle)
        // =====================================================
        private void tv_1_BeforeExpand(object? sender, TreeViewCancelEventArgs e)
        {
            SetPointerHourGlass();

            // "handle" PB lo emulamos con índice lineal del nodo
            int handle = GetLinearIndexOfNode(e.Node);

            // PB: Parent.Event Trigger ue_cargar_nivel(handle)
            ue_cargar_nivel(handle);

            SetPointerArrow();
        }

        // ============================
        // Helpers PB-ish
        // ============================

        private int UpperBound(st_nivel[] arr) => (arr == null) ? 0 : arr.Length - 1;

        private void SetPointerHourGlass() => this.Cursor = Cursors.WaitCursor;
        private void SetPointerArrow() => this.Cursor = Cursors.Default;

        private TreeNode EnsureRootNode()
        {
            // raíz lógica: PB suele cargar nivel 1 sin un root visible.
            // En WinForms creamos un nodo raíz contenedor (no inventa datos: usa el título PB).
            if (tv_1.Nodes.Count == 0)
            {
                string titulo = (s_nvl.Length > 1 && s_nvl[1] != null) ? s_nvl[1].titulo : "Root";
                var root = new TreeNode(titulo)
                {
                    Tag = "0"
                };
                // placeholder para expand
                root.Nodes.Add(new TreeNode());
                tv_1.Nodes.Add(root);
                tv_1.SelectedNode = root;
            }
            return tv_1.Nodes[0];
        }

        private int GetLinearIndexOfNode(TreeNode node)
        {
            int idx = 0;
            foreach (TreeNode n in tv_1.Nodes)
            {
                if (TryFindIndex(n, node, ref idx))
                    return idx;
            }
            return 0;

            static bool TryFindIndex(TreeNode current, TreeNode target, ref int idx)
            {
                idx++;
                if (ReferenceEquals(current, target))
                    return true;

                foreach (TreeNode child in current.Nodes)
                {
                    if (TryFindIndex(child, target, ref idx))
                        return true;
                }
                return false;
            }
        }

        private TreeNode? FindNodeByLinearIndex(int index)
        {
            if (index <= 0) return null;

            int idx = 0;
            foreach (TreeNode n in tv_1.Nodes)
            {
                var found = FindByIndexRec(n, index, ref idx);
                if (found != null) return found;
            }
            return null;

            static TreeNode? FindByIndexRec(TreeNode current, int targetIndex, ref int idx)
            {
                idx++;
                if (idx == targetIndex) return current;

                foreach (TreeNode child in current.Nodes)
                {
                    var found = FindByIndexRec(child, targetIndex, ref idx);
                    if (found != null) return found;
                }
                return null;
            }
        }
    } 
}
