using MinottiApp.utils;

namespace Minotti.utils
{

    public static class PowerObjectExtensions
    {
        public static int TriggerEvent(
            this IPowerObject po,
            string eventName,
            params object?[] args)
        {
            return DynamicEventInvoker.TriggerEvent(
                (Control)po,
                eventName,
                args
            );
        }

        public static void PostEvent(
            this IPowerObject po,
            string eventName,
            params object?[] args)
        {
            DynamicEventInvoker.Post(
                (Control)po,
                eventName,
                args
            );
        }
    }

}
