namespace ServerManagement.ObserverState
{
    public class RaipurOnlineServerStore : Observer
    {
        // What we want to observe?
        private int _numOfServerOnline;

        public int GetNumberOfServerOnline()
        {
            return _numOfServerOnline;
        }

        public void SetNumberOfServerOnline(int num)
        {
            _numOfServerOnline = num;
            base.BroadcastStateChange();
        }
    }
}
