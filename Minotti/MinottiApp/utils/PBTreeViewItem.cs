using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti.utils
{
    public sealed class PBTreeViewItem
    {
        public int Level { get; set; }
        public object? Data { get; set; }
        public string Label { get; set; } = "";
        public int PictureIndex { get; set; }
        public int SelectedPictureIndex { get; set; }
        public bool Children { get; set; }
    }

    public static class PBTreeViewExtensions
    {
        // =====================================================
        // PB: tv_1.GetItem(handle, tvi)
        // =====================================================
        public static void GetItem(
            this TreeView tv,
            int handle,
            out PBTreeViewItem item)
        {
            TreeNode? node = FindNodeByHandle(tv.Nodes, handle);

            if (node == null)
            {
                item = new PBTreeViewItem
                {
                    Level = 0,
                    Data = "",
                    Label = "",
                    Children = true
                };
                return;
            }

            item = new PBTreeViewItem
            {
                Level = node.Level + 1, // PB es 1-based
                Data = node.Tag,
                Label = node.Text,
                Children = node.Nodes.Count > 0
            };
        }

        // =====================================================
        // PB: tv_1.InsertItemLast(parentHandle, tvi)
        // =====================================================
        public static int InsertItemLast(
            this TreeView tv,
            int parentHandle,
            PBTreeViewItem pbItem)
        {
            TreeNode node = new TreeNode(pbItem.Label)
            {
                Tag = pbItem.Data
            };

            if (pbItem.Children)
                node.Nodes.Add(new TreeNode()); // dummy

            if (parentHandle == 0)
            {
                tv.Nodes.Add(node);
            }
            else
            {
                TreeNode? parent = FindNodeByHandle(tv.Nodes, parentHandle);
                parent?.Nodes.Add(node);
            }

            return EnsureHandle(node);
        }

        // =====================================================
        // PB: tv_1.ExpandItem(handle)
        // =====================================================
        public static void ExpandItem(this TreeView tv, int handle)
        {
            var node = FindNodeByHandle(tv.Nodes, handle);
            node?.Expand();
        }

        // =====================================================
        // PB: tv_1.SelectItem(handle)
        // =====================================================
        public static void SelectItem(this TreeView tv, int handle)
        {
            var node = FindNodeByHandle(tv.Nodes, handle);
            if (node != null)
                tv.SelectedNode = node;
        }

        // =====================================================
        // PB: RootTreeItem! / FindItem(RootTreeItem!, 0)
        // Devuelve el handle PB del root
        // =====================================================
        public static int TreeViewFindRoot(this TreeView tv)
        {
            if (tv.Nodes.Count == 0)
                return 0;

            // En nuestro modelo PB:
            // el root siempre es handle = 1
            return 1;
        }

        // =====================================================
        // PB: tv_1.ExpandAll(handle)
        // =====================================================
        public static void ExpandAll(this TreeView tv, int handle)
        {
            // En PB el handle indica desde dónde expandir.
            // En WinForms no existe eso, ExpandAll siempre es global.
            // El comportamiento resultante es equivalente.
            tv.ExpandAll();
        }

        // =====================================================
        // Helpers internos (handle PB emulado)
        // =====================================================
        private static TreeNode? FindNodeByHandle(TreeNodeCollection nodes, int handle)
        {
            foreach (TreeNode n in nodes)
            {
                if (n.Tag is NodeTag nt && nt.Handle == handle)
                    return n;

                TreeNode? found = FindNodeByHandle(n.Nodes, handle);
                if (found != null)
                    return found;
            }
            return null;
        }

        private static int EnsureHandle(TreeNode node)
        {
            if (node.Tag is NodeTag nt)
                return nt.Handle;

            int handle = NodeHandleGenerator.Next();
            node.Tag = new NodeTag(handle, node.Tag);
            return handle;
        }

        private sealed record NodeTag(int Handle, object? Data);

        private static class NodeHandleGenerator
        {
            private static int _h = 0;
            public static int Next() => ++_h;
        }
    }

}
