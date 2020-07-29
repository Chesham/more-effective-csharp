using System;
using System.Threading;

namespace item41
{
    public class ShouldNotLockThis
    {
        public void foo(Action waitOutsideReady)
        {
            lock (this)
            {
                waitOutsideReady();
            }
        }

        public bool update()
        {
            var locked = Monitor.TryEnter(this);
            if (!locked)
                return locked;
            try
            {
                return locked;
            }
            finally
            {
                if (locked)
                    Monitor.Exit(this);
            }
        }
    }
}
