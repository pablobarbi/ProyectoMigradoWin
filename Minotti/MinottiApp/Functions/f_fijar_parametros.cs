using Minotti;
using System;

namespace Minotti.Functions
{
    public static class f_fijar_parametros
    {
        // s_arg[0] equivale a s_arg[1] en PB
        // parametros[0] equivale a parametros[1] en PB
        public static void ffijar_parametros(string[] s_arg, ref string[] parametros)
        {
            if (s_arg == null) return;
            if (parametros == null) return;

            if (s_arg.Length == 1)
            {
                if (string.Equals(s_arg[0], "ua", StringComparison.OrdinalIgnoreCase))
                {
                    // PB: guo_app.ds_valor_inicial.GetItemString(1, 'unidad_academica')
                    parametros[0] = guo_app.ds_valor_inicial.GetItemString(1, "unidad_academica");
                }
            }
        }

        public static string[] ffijar_parametros(string[] s_arg)
        {
            if (s_arg == null)
                return Array.Empty<string>();

            // En PB normalmente se inicializa con la cantidad de args
            string[] parametros = new string[s_arg.Length];

            // Reutiliza la implementación existente
            ffijar_parametros(s_arg, ref parametros);

            return parametros;
        }

    }
}
