
using Minotti.Data;
using Minotti.Repositories;
using Minotti.Structures;
using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Models;
using System;
using System.Windows.Forms;

namespace Minotti.Views.Capitulos.Controls
{
    public partial class w_migracion_capitulos2 : w_operacion
    {
        // PB: st_nivel s_nvl[]
        protected st_nivel[] s_nvl;

        // PB: integer nivel_actual
        protected int nivel_actual;

        // PB: DataStore dw_param
        protected datastore? dw_param;

        // PB: boolean ultimo_nivel = TRUE
        protected bool ultimo_nivel = true;

        public w_migracion_capitulos2()
        {
            InitializeComponent();
        }

        // =====================================================
        // PB: event ue_leer_parametros
        // =====================================================
        public override void ue_leer_parametros()
        {
            base.ue_leer_parametros();

            int niveles = 4;
            s_nvl = new st_nivel[niveles + 1]; // PB indexado desde 1

            // ===== NIVEL 1 =====
            s_nvl[1] = new st_nivel();
            s_nvl[1].dw = new datastore();
            s_nvl[1].titulo = "Capitulos";
            s_nvl[1].dw.DataObject = "dk_capitulos_treeview";
            s_nvl[1].dw.SetTransObject(SQLCA.Instance);
            s_nvl[1].activo = 1;
            s_nvl[1].dw.Retrieve();

            // ===== NIVEL 2 =====
            s_nvl[2] = new st_nivel();
            s_nvl[2].dw = new datastore();
            s_nvl[2].titulo = "Capitulos";
            s_nvl[2].dw.DataObject = "dk_capitulaciones_treeview";
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
        // PB: event ue_iniciar
        // =====================================================
        public override void ue_iniciar()
        {
            base.ue_iniciar();
            ue_cargar_nivel(0);
        }

        // =====================================================
        // PB: event ue_cargar_nivel(integer incremento)
        // =====================================================
        protected void ue_cargar_nivel(int incremento)
        {
            Cursor = Cursors.WaitCursor;

            TreeNode? nodoActual = null;
            int nivelNodo = 0;

            if (incremento > 0 && incremento - 1 < tv_1.Nodes.Count)
            {
                nodoActual = tv_1.Nodes[incremento - 1];
                nivelNodo = nodoActual.Level + 1;
            }

            if (nivelNodo >= s_nvl.Length - 1)
            {
                Cursor = Cursors.Default;
                return;
            }

            int nuevoNivel = nivelNodo + 1;
            datastore dw = s_nvl[nuevoNivel].dw;

            if (nuevoNivel > 1 && nodoActual != null)
            {
                string colFiltro = dw.Describe("#3.Name");
                dw.SetFilter($"{colFiltro} = '{nodoActual.Tag}'");
                dw.Filter();
            }

            int cantidad = dw.RowCount();

            for (int i = 1; i <= cantidad; i++)
            {
                string data = "";

                if (nuevoNivel == s_nvl.Length - 1)
                {
                    data = dw.GetItemString(i, "modulo") + " - ";
                }

                data += dw.GetItemString(i, dw.Describe("#1.Name"));
                string label = dw.GetItemString(i, dw.Describe("#2.Name"));

                TreeNode nuevoNodo = new TreeNode(label)
                {
                    Tag = data
                };

                if (nodoActual == null)
                    tv_1.Nodes.Add(nuevoNodo);
                else
                    nodoActual.Nodes.Add(nuevoNodo);
            }

            Cursor = Cursors.Default;
        }

        // =====================================================
        // PB: close
        // =====================================================
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (s_nvl != null)
            {
                for (int i = 1; i < s_nvl.Length; i++)
                {
                    s_nvl[i]?.dw?.Destroy();
                }
            }

            dw_param?.Destroy();
        }

        private void Tv_1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            if (node == null) return;

            // En PB se usaba ItemData / Object
            // Acá usamos Tag
            if (node.Tag is not uo_capitulos cap)
                return;

            // Flag PB típico: evitar recargar hijos
            if (cap.Cargado)
                return;

            // Recupera hijos según nivel
            // (esto viene directo del SRW)
            uo_ds ds_hijos = new uo_ds();
            ds_hijos.SetTransObject(SQLCA.Instance);

            switch (cap.Nivel)
            {
                case 1: // Capítulo → Rúbricas
                    ds_hijos.DataObject = "dk_rubricas_treeview";
                    ds_hijos.uof_retrieve(cap.capitulo_id);
                    break;

                case 2: // Rúbrica → Subrúbricas
                    ds_hijos.DataObject = "dk_subrubricas_treeview";
                    ds_hijos.uof_retrieve(cap.capitulo_id, cap.rubrica_id);
                    break;

                default:
                    return;
            }

            // Inserta nodos hijos
            for (int i = 1; i <= ds_hijos.RowCount(); i++)
            {
                string texto = ds_hijos.GetItemString(i, "descripcion");
                long id = ds_hijos.GetItemLong(i, "id");

                var hijo = new uo_capitulos
                {
                    capitulo_id = cap.capitulo_id,
                    rubrica_id = cap.Nivel == 1 ? id : cap.rubrica_id,
                    subrubrica_id = cap.Nivel == 2 ? id : 0,
                    Nivel = cap.Nivel + 1,
                    Cargado = false
                };

                TreeNode childNode = new TreeNode(texto)
                {
                    Tag = hijo
                };

                // Placeholder PB: para que aparezca el "+"
                childNode.Nodes.Add("...");
                node.Nodes.Add(childNode);
            }

            // Marca como cargado (clave)
            cap.Cargado = true;
        }

    }
}
