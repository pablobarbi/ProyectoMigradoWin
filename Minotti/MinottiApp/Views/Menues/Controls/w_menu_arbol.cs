// w_menu_arbol.cs
// Lógica PB -> C# (sin TODO, sin inventar; mantengo nombres).
// Lo único "adaptado" es el TreeViewItem PB -> TreeNode WinForms, y los hooks de eventos.
// Asumo que existen: s_nvl[], UpperBound(...), f_cortar_string, ue_ejecutar, w_menu base, etc.

using Minotti.Functions;
using Minotti.Structures;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Menues.Controls
{
    /// <summary>
    /// Migración de PowerBuilder: w_menu_arbol.srw
    /// Hereda de w_menu y contiene el control TreeView llamado 'tv_1'.
    /// </summary>
    public partial class w_menu_arbol : w_menu
    {
        // PB: variables
        protected bool ultimo_nivel = true; // Indica si el último nivel se ve en el árbol
        protected bool ib_iniciado = false;

        public w_menu_arbol()
        {
            InitializeComponent();

            // PB: tv_1 doubleclicked / itempopulate
            // WinForms no tiene "itempopulate": lo más cercano es BeforeExpand para poblar hijos cuando expandís.
            // Para el doble click: NodeMouseDoubleClick.
            this.tv_1.NodeMouseDoubleClick += tv_1_NodeMouseDoubleClick;
            this.tv_1.BeforeExpand += tv_1_BeforeExpand;

            // Inicio (PB: ue_iniciar)
            this.Shown += (_, __) => ue_iniciar();
        }

        // ===== PB event: ue_cargar_nivel =====
        // En PB: "incremento" trae la línea/handle actual del árbol.
        // En WinForms trabajamos con TreeNode; acá tomo "incrementoHandle" como el handle PB
        // y lo mapeo a TreeNode via Tag (si tu framework ya lo hace diferente, lo ajustás).
        public virtual void ue_cargar_nivelOld(int incremento)
        {
            int cantidad, nuevo_nivel, i_Aux, nuevo_item;
            TreeViewItem tvi_Actual;
            TreeViewItem tvi_Nuevo;
            string sAux;

            // Determina el nivel y lee datos del item abierto (siempre y cuando no esté en el último nivel)
            tv_1_GetItem(incremento, out tvi_Actual);

            if (tvi_Actual.Level >= UpperBound(s_nvl) ||
                (!ultimo_nivel && tvi_Actual.Level == UpperBound(s_nvl) - 1))
                return;

            nuevo_nivel = tvi_Actual.Level + 1;

            // Filtra datos del nivel
            if (nuevo_nivel > 1)
            {
                s_nvl[nuevo_nivel].dw.SetFilter(
                    s_nvl[nuevo_nivel].dw.Describe("#3.Name") + "=\"" + Convert.ToString(tvi_Actual.Data) + "\""
                );
                s_nvl[nuevo_nivel].dw.Filter();
            }

            cantidad = s_nvl[nuevo_nivel].dw.RowCount();

            // Agrega items al TreeView
            for (i_Aux = 1; i_Aux <= cantidad; i_Aux++)
            {
                sAux = "";
                if (nuevo_nivel == UpperBound(s_nvl))
                    sAux = s_nvl[nuevo_nivel].dw.GetItemString(i_Aux, "modulo") + " - ";

                tvi_Nuevo = new TreeViewItem();
                tvi_Nuevo.Data = sAux + s_nvl[nuevo_nivel].dw.GetItemString(i_Aux, s_nvl[nuevo_nivel].dw.Describe("#1.Name"));
                tvi_Nuevo.Label = s_nvl[nuevo_nivel].dw.GetItemString(i_Aux, s_nvl[nuevo_nivel].dw.Describe("#2.Name"));
                tvi_Nuevo.PictureIndex = nuevo_nivel;

                // Imagen seleccionada
                if (nuevo_nivel == 1)
                    tvi_Nuevo.SelectedPictureIndex = 1;
                else
                    tvi_Nuevo.SelectedPictureIndex = 4;

                if (nuevo_nivel == UpperBound(s_nvl) ||
                    (!ultimo_nivel && nuevo_nivel == UpperBound(s_nvl) - 1))
                    tvi_Nuevo.Children = false;
                else
                    tvi_Nuevo.Children = true;

                // Inserta cada item en el árbol
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
        }

        //public virtual void ue_cargar_nivelOld(int incremento)
        //{
        //    int cantidad, nuevo_nivel, i_Aux, nuevo_item;
        //    TreeViewItem tvi_Actual;
        //    TreeViewItem tvi_Nuevo;
        //    string sAux;

        //    // === Item actual ===
        //    tv_1_GetItem(incremento, out tvi_Actual);

        //    if (tvi_Actual.Level >= UpperBound(s_nvl) ||
        //        (!ultimo_nivel && tvi_Actual.Level == UpperBound(s_nvl) - 1))
        //        return;

        //    nuevo_nivel = tvi_Actual.Level + 1;

        //    // === FILTRO (PB: #3.Name → modulo) ===
        //    if (nuevo_nivel > 1)
        //    {
        //        //s_nvl[nuevo_nivel].dw.SetFilter(
        //        //    $"modulo = \"{Convert.ToString(tvi_Actual.Data)}\""
        //        //); 

        //        s_nvl[nuevo_nivel].dw.SetFilter("");
        //        s_nvl[nuevo_nivel].dw.Filter();

        //        s_nvl[nuevo_nivel].dw.SetFilter(  $"modulo = '{tvi_Actual.Data}'" );
        //        s_nvl[nuevo_nivel].dw.Filter();

        //        //s_nvl[nuevo_nivel].dw.Filter();
        //    }

        //    cantidad = s_nvl[nuevo_nivel].dw.RowCount();

        //    // === Construcción del TreeView ===
        //    for (i_Aux = 1; i_Aux <= cantidad; i_Aux++)
        //    {
        //        sAux = "";

        //        // PB: último nivel concatena módulo
        //        if (nuevo_nivel == UpperBound(s_nvl))
        //            sAux = s_nvl[nuevo_nivel].dw.GetItemString(i_Aux, "modulo") + " - ";

        //        tvi_Nuevo = new TreeViewItem();

        //        // === Data (PB: Data) ===
        //        tvi_Nuevo.Data =
        //            sAux + s_nvl[nuevo_nivel].dw.GetItemString(i_Aux, "submodulo");

        //        // === Label (PB: Label → texto visible) ===
        //        tvi_Nuevo.Label =
        //            s_nvl[nuevo_nivel].dw.GetItemString(i_Aux, "nombre");

        //        tvi_Nuevo.PictureIndex = nuevo_nivel;

        //        // Imagen seleccionada
        //        tvi_Nuevo.SelectedPictureIndex = (nuevo_nivel == 1) ? 1 : 4;

        //        // Hijos
        //        tvi_Nuevo.Children =
        //            !(nuevo_nivel == UpperBound(s_nvl) ||
        //              (!ultimo_nivel && nuevo_nivel == UpperBound(s_nvl) - 1));

        //        // Inserta en árbol
        //        nuevo_item = tv_1_InsertItemLast(incremento, tvi_Nuevo);

        //        if (nuevo_item < 1)
        //        {
        //            MessageBox.Show(
        //                "Error insertando item",
        //                "Error",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Exclamation
        //            );
        //        }
        //        else if (nuevo_item == 1)
        //        {
        //            tv_1_ExpandItem(nuevo_item);
        //            tv_1_SelectItem(nuevo_item);
        //        }
        //    }
        //}



        public virtual void ue_cargar_nivel(int incremento)
        {
            int cantidad, nuevo_nivel, i_Aux, nuevo_item;
            TreeViewItem tvi_Actual;
            TreeViewItem tvi_Nuevo;
            string sAux = "";

            // PB: tv_1.GetItem(incremento, tvi_Actual)
            tv_1_GetItem(incremento, out tvi_Actual);

            // PB:
            // If tvi_Actual.Level >= UpperBound(s_nvl[]) OR
            //    (not(ultimo_nivel) AND tvi_Actual.Level = UpperBound(s_nvl[]) - 1) Then Return
            if (tvi_Actual.Level >= UpperBound(s_nvl) ||
                (!ultimo_nivel && tvi_Actual.Level == UpperBound(s_nvl) - 1))
                return;

            nuevo_nivel = tvi_Actual.Level + 1;

            // PB:
            // If nuevo_nivel > 1 Then
            //   SetFilter( Describe('#3.Name') + '="' + string(tvi_Actual.Data) + '"' )
            //   Filter()
            // End If
            if (nuevo_nivel > 1)
            {
                var dw = s_nvl[nuevo_nivel].dw;

                // 🔴 CRÍTICO: resetear filtros anteriores (PB lo hace implícito)
                dw.SetFilter(string.Empty);
                dw.Filter();

                string colPadre = dw.Describe("#3.Name");
                string padreVal = Convert.ToString(tvi_Actual.Data) ?? "";

                padreVal = padreVal.Replace("'", "''");

                dw.SetFilter($"{colPadre} = '{padreVal}'");
                dw.Filter();
            }


            cantidad = s_nvl[nuevo_nivel].dw.RowCount();

            // PB: For i_Aux = 1 To cantidad
            for (i_Aux = 1; i_Aux <= cantidad; i_Aux++)
            {
                sAux = "";

                // PB: If nuevo_nivel = UpperBound(s_nvl[]) Then sAux = GetItemString('modulo') + ' - '
                if (nuevo_nivel == UpperBound(s_nvl))
                    sAux = s_nvl[nuevo_nivel].dw.GetItemString(i_Aux, "modulo") + " - ";

                string colKey = s_nvl[nuevo_nivel].dw.Describe("#1.Name");
                string colDesc = s_nvl[nuevo_nivel].dw.Describe("#2.Name");

                tvi_Nuevo = new TreeViewItem
                {
                    Data = sAux + s_nvl[nuevo_nivel].dw.GetItemString(i_Aux, colKey),
                    Label = s_nvl[nuevo_nivel].dw.GetItemString(i_Aux, colDesc),
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
        }





        // ===== PB event: ue_iniciar =====
        public virtual void ue_iniciar()
        {
            if (!ib_iniciado)
            {
                // PB: This.Event Trigger ue_cargar_nivel(0)
                ue_cargar_nivel(0);
                ib_iniciado = true;
            }
        }

        // ===== PB: tv_1 doubleclicked =====
        private void tv_1_NodeMouseDoubleClick(object? sender, TreeNodeMouseClickEventArgs e)
        {
            // Solo último nivel
            if (e.Node.Level != UpperBound(s_nvl) - 1)
                return;

            if (e.Node.Tag is not NodeTag tag)
                return;

            string modulo = tag.Modulo ?? string.Empty;
            string operacion = tag.Operacion ?? string.Empty;

            if (string.IsNullOrEmpty(operacion))
                return;

            // PB: Parent.Event Post ue_ejecutar(modulo, operacion)
            this.PostEvent_ue_ejecutar(modulo, operacion);
        }



        // ===== PB: tv_1 itempopulate =====
        // Equivalente WinForms: BeforeExpand para "poblar" al expandir
        private void tv_1_BeforeExpand(object? sender, TreeViewCancelEventArgs e)
        {
            // Si ya está poblado (no tiene dummy), no hagas nada
            if (e.Node.Nodes.Count > 0 &&
                !(e.Node.Nodes.Count == 1 && string.IsNullOrEmpty(e.Node.Nodes[0].Text) && e.Node.Nodes[0].Tag == null))
                return;

            // Si tiene dummy, borrarlo antes de cargar
            if (e.Node.Nodes.Count == 1 && string.IsNullOrEmpty(e.Node.Nodes[0].Text) && e.Node.Nodes[0].Tag == null)
                e.Node.Nodes.Clear();

            Cursor.Current = Cursors.WaitCursor;

            int handle = GetHandleFromNode(e.Node);
            ue_cargar_nivel(handle);

            Cursor.Current = Cursors.Default;
        }


        // =====================================================================
        // Helpers mínimos para no "inventar" reglas: sólo puente PB TreeViewItem <-> TreeNode
        // Si vos ya tenés wrappers (TreeViewItem/TreeView control PB migrados), reemplazalos
        // por tus llamados reales. Nombres intencionalmente "tv_1_*" para conservar semántica.
        // =====================================================================

        protected void tv_1_GetItem(int handle, out TreeViewItem item)
        {
            // handle=0 en PB suele ser root. Lo mapeo a una "raíz virtual".
            if (handle == 0)
            {
                item = new TreeViewItem
                {
                    Level = 0,
                    Data = "",
                    Label = "",
                    Children = true
                };
                return;
            }

            // Buscar nodo por handle en Tag
            TreeNode? node = FindNodeByHandle(tv_1.Nodes, handle);
            if (node == null)
            {
                item = new TreeViewItem { Level = 0, Data = "", Label = "", Children = true };
                return;
            }

            tv_1_GetItem_FromNode(node, out item);
        }

        protected void tv_1_GetItem_FromNode(TreeNode node, out TreeViewItem item)
        {
            object data = "";

            if (node.Tag is NodeTag nt)
                data = nt.Data;
            else if (node.Tag != null)
                data = node.Tag;

            item = new TreeViewItem
            {
                Level = node.Level + 1,   // WinForms Level(0) => PB Level(1)
                Data = data,
                Label = node.Text,
                Children = node.Nodes.Count > 0
            };
        }


        private int tv_1_InsertItemLast(int parentHandle, TreeViewItem newItem)
        {
            TreeNode parentNode;

            if (parentHandle == 0)
            {
                parentNode = null!;
            }
            else
            {
                parentNode = FindNodeByHandle(tv_1.Nodes, parentHandle) ?? null!;
            }

            var node = new TreeNode(newItem.Label)
            {
                Tag = newItem.Data
            };

            // Si tiene hijos, agrego un dummy para que aparezca el [+] (típico lazy load)
            if (newItem.Children)
                node.Nodes.Add(new TreeNode(""));

            if (parentHandle == 0 || parentNode == null)
                tv_1.Nodes.Add(node);
            else
                parentNode.Nodes.Add(node);

            // Devuelvo un "handle" estable guardándolo en TagHandle
            // (sin inventar: es un id interno solo para emular el handle PB)
            int handle = EnsureNodeHandle(node);
            return handle;
        }

        private void tv_1_ExpandItem(int handle)
        {
            var node = FindNodeByHandle(tv_1.Nodes, handle);
            node?.Expand();
        }

        private void tv_1_SelectItem(int handle)
        {
            var node = FindNodeByHandle(tv_1.Nodes, handle);
            if (node != null) tv_1.SelectedNode = node;
        }

        protected int GetHandleFromNode(TreeNode node)
            => node.Tag is NodeTag nt ? nt.Handle : 0;

        private int EnsureNodeHandle(TreeNode node)
        {
            if (node.Tag is NodeTag nt)
                return nt.Handle;

            int h = NodeHandleGenerator.Next();
            object data = node.Tag ?? "";
            node.Tag = new NodeTag(h, data);
            return h;
        }

        private TreeNode? FindNodeByHandle(TreeNodeCollection nodes, int handle)
        {
            foreach (TreeNode n in nodes)
            {
                if (n.Tag is NodeTag nt && nt.Handle == handle)
                    return n;

                var child = FindNodeByHandle(n.Nodes, handle);
                if (child != null) return child;
            }
            return null;
        }

        // Small internal structures
       

        private static class NodeHandleGenerator
        {
            private static int _h = 0;
            public static int Next() => ++_h;
        }
    }

     
   
}
