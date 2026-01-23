using MinottiApp.utils;

namespace Minotti.utils
{
    public static class ControlExtensions
    {
        public static int TriggerEvent(
            this Control control,
            string eventName,
            params object?[] args)
        {
            return DynamicEventInvoker.TriggerEvent(control, eventName, args);
        }

        public static void PostEvent(
            this Control control,
            string eventName,
            params object?[] args)
        {
            DynamicEventInvoker.Post(control, eventName, args);
        }

        public static int TriggerEventInt(
        this Control control,
        string eventName,
        params object?[] args)
        {
            return DynamicEventInvoker.TriggerEvent(control, eventName, args);
        }
    }

}
