namespace Minotti.utils
{
    public interface IPowerObject
    {
        int TriggerEvent(string eventName, params object?[] args)
             => ((Control)this).TriggerEvent(eventName, args);

        void PostEvent(string eventName, params object?[] args)
            => ((Control)this).PostEvent(eventName, args);
    }
}
