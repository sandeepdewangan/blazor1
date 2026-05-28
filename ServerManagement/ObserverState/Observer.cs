namespace ServerManagement.ObserverState
{
    public class Observer
    {
        protected Action? _listeners;

        public void AddStateChangeListener(Action? listeners)
        {
            if (listeners is not null)
            {
                _listeners = _listeners + listeners;
            }
        }

        public void RemoveStateChangeListener(Action? listeners)
        {
            if (listeners is not null)
            {
                _listeners = _listeners - listeners;
            }
        }

        public void BroadcastStateChange()
        {
            _listeners?.Invoke();
        }

    }
}
