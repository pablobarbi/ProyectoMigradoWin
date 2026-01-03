using System;
using System.Linq;
using System.Windows.Forms;

namespace Minotti.Views.Menues.Controls
{
    /// <summary>
    /// Migración de PowerBuilder: w_menu_arbol_lista.srw
    /// Hereda de w_menu_arbol y agrega lista, enlaces y botones.
    /// </summary>
    public partial class w_menu_arbol_lista : w_menu_arbol
    {
        public w_menu_arbol_lista()
        {
            InitializeComponent();
            RehostBaseTreeView();
        }

        /// <summary>
        /// Ubica el TreeView heredado "tv_1" dentro del split container (Panel1).
        /// No accede al campo privado: lo busca por Name en la jerarquía.
        /// </summary>
        private void RehostBaseTreeView()
        {
            Control? tv = FindControlRecursive(this, "tv_1");
            if (tv != null)
            {
                tv.Parent?.Controls.Remove(tv);
                tv.Dock = DockStyle.Fill;
                this.sc_main.Panel1.Controls.Add(tv);
            }
        }

        private static Control? FindControlRecursive(Control root, string name)
        {
            foreach (Control c in root.Controls)
            {
                if (string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase))
                    return c;
                var nested = FindControlRecursive(c, name);
                if (nested != null) return nested;
            }
            return null;
        }

        // Hook mínimos de botones (mantener nombres)
        private void pb_agregar_Click(object? sender, EventArgs e) { /* agregar */ }
        private void pb_borrar_Click(object? sender, EventArgs e)  { /* borrar  */ }
        private void pb_confirmar_Click(object? sender, EventArgs e){ /* confirmar*/ }
        private void pb_imprimir_Click(object? sender, EventArgs e){ /* imprimir */ }
    }
}
