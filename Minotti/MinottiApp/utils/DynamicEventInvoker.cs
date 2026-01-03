using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinottiApp.utils
{
    public static class DynamicEventInvoker
    {
        public static void Trigger(object target, string eventName, params object?[] args)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (string.IsNullOrWhiteSpace(eventName)) return;

            InvokeBestMatch(target, eventName, args);
        }

        public static void Post(object target, string eventName, params object?[] args)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (string.IsNullOrWhiteSpace(eventName)) return;

            // Si es un Control/Form, posteamos en el hilo UI.
            if (target is Control c && !c.IsDisposed)
            {
                try
                {
                    c.BeginInvoke(new Action(() => InvokeBestMatch(target, eventName, args)));
                    return;
                }
                catch
                {
                    // si falla BeginInvoke, cae al invoke directo
                }
            }

            // Fallback: ejecución directa
            InvokeBestMatch(target, eventName, args);
        }

        private static void InvokeBestMatch(object target, string methodName, object?[] args)
        {
            var type = target.GetType();

            // En PB podés hacer TriggerEvent("Close") sobre ventana:
            // preferimos métodos públicos/protegidos/privados de instancia.
            const BindingFlags flags =
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            // 1) Buscar match exacto por nombre y cantidad de parámetros
            var candidates = type.GetMethods(flags)
                .Where(m => string.Equals(m.Name, methodName, StringComparison.OrdinalIgnoreCase))
                .ToArray();

            if (candidates.Length == 0)
                throw new MissingMethodException(type.FullName, methodName);

            // 2) Elegir el mejor overload por cantidad y compatibilidad
            MethodInfo? best = null;

            foreach (var m in candidates)
            {
                var ps = m.GetParameters();
                if (ps.Length != args.Length) continue;

                bool ok = true;
                for (int i = 0; i < ps.Length; i++)
                {
                    var pType = ps[i].ParameterType;
                    var a = args[i];

                    if (a == null)
                    {
                        // null solo es válido para referencia o nullable
                        if (pType.IsValueType && Nullable.GetUnderlyingType(pType) == null)
                        {
                            ok = false;
                            break;
                        }
                    }
                    else
                    {
                        if (!pType.IsAssignableFrom(a.GetType()))
                        {
                            ok = false;
                            break;
                        }
                    }
                }

                if (ok)
                {
                    best = m;
                    break;
                }
            }

            // 3) Si no hubo match por tipo, intentar por cantidad y convertir básicos (string->int, etc.)
            if (best == null)
            {
                best = candidates.FirstOrDefault(m => m.GetParameters().Length == args.Length);
            }

            if (best == null)
                throw new MissingMethodException(type.FullName, methodName);

            var finalArgs = CoerceArgs(best.GetParameters(), args);
            var result = best.Invoke(target, finalArgs);

            // Si el handler devuelve Task, no lo bloqueamos (similar a PB trigger sin esperar)
            if (result is Task)
            {
                // fire-and-forget
            }
        }

        private static object?[] CoerceArgs(ParameterInfo[] ps, object?[] args)
        {
            if (ps.Length == 0) return Array.Empty<object?>();

            var finalArgs = new object?[args.Length];

            for (int i = 0; i < args.Length; i++)
            {
                var pType = ps[i].ParameterType;
                var a = args[i];

                if (a == null)
                {
                    finalArgs[i] = null;
                    continue;
                }

                if (pType.IsAssignableFrom(a.GetType()))
                {
                    finalArgs[i] = a;
                    continue;
                }

                try
                {
                    // Conversión simple (string->int, etc.)
                    finalArgs[i] = Convert.ChangeType(a, Nullable.GetUnderlyingType(pType) ?? pType);
                }
                catch
                {
                    // Si no se puede convertir, pasamos tal cual (y que reviente como en PB si corresponde)
                    finalArgs[i] = a;
                }
            }

            return finalArgs;
        }


        /// <summary>
        /// Emula PB TriggerEvent(obj, "evento").
        /// Busca un método instance con ese nombre (ignora mayúsc/minúsc) y lo invoca.
        /// Retorna:
        ///  - si devuelve int: ese int
        ///  - si devuelve void: 1
        ///  - si no existe o falla: -1
        /// </summary>
        public static int TriggerEvent(object? target, string eventName, params object?[] args)
        {
            if (target == null) return -1;
            if (string.IsNullOrWhiteSpace(eventName)) return -1;

            var t = target.GetType();

            // Busca método por nombre (case-insensitive)
            var mi = t.GetMethod(
                eventName,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.IgnoreCase);

            if (mi == null) return -1;

            try
            {
                object? ret = mi.Invoke(target, args);

                if (mi.ReturnType == typeof(void))
                    return 1;

                if (ret is int i)
                    return i;

                // Si devolviera algo distinto, PB no lo usa: devolvemos 1 si no es null, sino -1
                return ret != null ? 1 : -1;
            }
            catch
            {
                return -1;
            }
        }
    }
}
