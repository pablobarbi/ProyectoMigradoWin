using Minotti;
using Minotti.utils;
using Minotti.Views.Basicos;
using Minotti.Views.Basicos.Models;
using Minotti.Views.Pbl.Views;
using System;
using System.Linq;
using System.Windows.Forms;
using Message = Minotti.utils.Message;

namespace MinottiApp.utils
{
    public enum PBOpenMode
    {
        Original = 0
    }


    public static class MessagePB
    {
        // Equivalente PB: Message.PowerObjectParm
        public static object? PowerObjectParm { get; set; }

        // Equivalente PB: Message.StringParm
        public static string? StringParm { get; set; }
    }



    public static class OpenSheetWithParmPB
    {
        /// <summary>
        /// Emula PB: OpenSheetWithParm(wAux, parm, objeto, mdi, menuFlag, Original!)
        /// - objeto: Type del Form a abrir (en PB es at_operacion.uof_GetObjeto(nivel))
        /// - mdi: Form MDI (guo_app.uof_Getmdi())
        /// - menuFlag: lo recibimos pero no lo asumimos (lo ignoramos como stub)
        /// </summary>
        public static int OpenSheetWithParm(
            object? wAux,
            object? parm,
            Type objeto,
            Form? mdi,
            object? menuColgar,
            PBOpenMode mode)
        {
            try
            {
                // PB: Message.PowerObjectParm = parm
                MessagePB.PowerObjectParm = parm;

                // Validaciones
                if (objeto == null)
                    return -1;

                if (!typeof(Form).IsAssignableFrom(objeto))
                    return -1;

                // Instanciar la ventana
                var frm = (Form?)Activator.CreateInstance(objeto);
                if (frm == null)
                    return -1;

                // Asignar MDI Parent (PB OpenSheet)
                if (mdi != null)
                {
                    frm.MdiParent = mdi;
                }

                // Mostrar el formulario
                frm.Show();

                // 🔴 AVISO CLAVE: mostrar MDI Client cuando se abre un sheet
                if (mdi is w_principal wp)
                {
                    wp.ShowMdiClient();
                }

                return 1;
            }
            catch (Exception ex)
            {
                MessageBoxPB.MessageBox(
                    "Error",
                    ex.Message,
                    MessageBoxIcon.Error,
                    MessageBoxButtons.OK);

                return -1;
            }
        }


        public static int OpenSheetWithParm(
            object? wAux,
            object? parm,
            string objeto,
            Form? mdi,
            object? menuColgar,
            PBOpenMode mode)
        {
            if (string.IsNullOrWhiteSpace(objeto))
                return -1;

            // 1) Resolver Type por nombre (busca en todos los assemblies cargados)
            Type? t = ResolveTypeByName(objeto);

            // 2) Fallback por namespace típico del proyecto
            if (t == null && !objeto.Contains("."))
                t = ResolveTypeByName("Minotti.Views." + objeto)
                    ?? ResolveTypeByName("Minotti." + objeto);

            if (t == null)
                return -1;

            // Reusar implementación principal
            return OpenSheetWithParm(wAux, parm, t, mdi, menuColgar, mode);
        }

        /// <summary>
        /// PB: OpenSheet(objeto, mdi, pos, Original!)
        /// </summary>
        public static int OpenSheet(
            Type objeto,
            Form? mdi,
            int pos,
            PBOpenMode mode)
        {
            // PB OpenSheet NO pasa parámetros
            return OpenSheetWithParm(
                null,          // wAux
                null,          // parm
                objeto,
                mdi,
                null,          // menuColgar
                mode
            );
        }


        private static Type? ResolveTypeByName(string typeName)
        {
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type? t = asm.GetType(typeName, throwOnError: false, ignoreCase: true);
                if (t != null) return t;

                try
                {
                    t = asm.GetTypes().FirstOrDefault(x =>
                        string.Equals(x.Name, typeName, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(x.FullName, typeName, StringComparison.OrdinalIgnoreCase));

                    if (t != null) return t;
                }
                catch
                {
                    // Algunos assemblies pueden fallar en GetTypes()
                }
            }

            return null;
        }


        public static int OpenSheetWithParm<TForm>(
            TForm form,
            object parametro,
            string titulo,
            Form mdiParent,
            int colgar,
            PBOpenMode modo
        ) where TForm : Form
        {
            // Seteo de parámetros PB-like
            if (form is w_operacion wop && parametro is cat_operacion op)
                wop.at_op = op;
            else if (form is IFormularioConOperacion conOp && parametro is cat_operacion op2)
                conOp.Operacion = op2;

            form.MdiParent = mdiParent;
            form.Text = titulo;

            form.Show();

            // 🔴 AVISO CLAVE: mostrar MDI Client
            if (mdiParent is w_principal wp)
            {
                wp.ShowMdiClient();
            }

            return 1;
        }
    }



    public static class PBWindow
    {
        /// <summary>
        /// Emula PB: OpenWithParm(w_ventana, parametro)
        /// - objeto: typeof(Form) de la ventana a abrir
        /// - parm: parámetro que se guardará en Message.PowerObjectParm
        /// 
        /// La ventana luego lee 'Message.PowerObjectParm' en su ue_iniciar(), constructor o evento Load.
        /// </summary>
        public static int OpenWithParm(Type objeto, object? parm)
        {
            try
            {
                // 1) PB: Se carga el parámetro global
                Message.PowerObjectParm = parm;

                // 2) Validaciones típicas PB → C#
                if (objeto == null)
                    return -1;

                if (!typeof(Form).IsAssignableFrom(objeto))
                    return -1;

                // 3) Crear instancia de la ventana
                Form? frm = (Form?)Activator.CreateInstance(objeto);
                if (frm == null)
                    return -1;

                // 4) Obtener el MDI si corresponde (equivale a OpenSheet en PB si existe)
                Form? mdi = uo_app.Instance?.uof_getmdi();
                if (mdi != null && mdi.IsMdiContainer)
                {
                    frm.MdiParent = mdi;
                }

                // 5) Mostrar
                frm.Show();

                // PB retorna 1 al abrir OK
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en OpenWithParm: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }



    }

}
