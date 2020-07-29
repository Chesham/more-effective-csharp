using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace item41
{
    public class ShouldLockLikeThis
    {
        private object mtx;

        private object getSyncObject()
        {
            Interlocked.CompareExchange(ref mtx, new object(), null);
            return mtx;
        }
        public void foo(Action waitOutsideReady)
        {
            lock (getSyncObject())
            {
            }
            waitOutsideReady();
        }

        public bool update()
        {
            var locked = Monitor.TryEnter(getSyncObject());
            if (!locked)
                return locked;
            try
            {
                return locked;
            }
            finally
            {
                if (locked)
                    Monitor.Exit(getSyncObject());
            }
        }
    }
}
