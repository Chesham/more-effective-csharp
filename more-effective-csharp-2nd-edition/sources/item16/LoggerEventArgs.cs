using System;

namespace item16
{
    public class LoggerEventArgs : EventArgs
    {
        public Exception exception { get; set; }

        public string msg { get; internal set; }

        public bool isCancelled { get; internal set; } = false;

        public void Cancel()
        {
            isCancelled = true;
        }
    }
}
