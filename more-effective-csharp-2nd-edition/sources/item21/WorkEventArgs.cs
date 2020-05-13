using System;

namespace item21
{
    public class WorkEventArgs : EventArgs
    {
        public Exception exception { get; set; }

        public int step { get; internal set; }

        public bool isCancelled { get; internal set; } = false;

        public void Cancel()
        {
            isCancelled = true;
        }
    }
}
