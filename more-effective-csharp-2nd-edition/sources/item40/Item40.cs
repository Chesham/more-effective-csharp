using System;
using System.Threading;
using System.Threading.Tasks;

namespace item40
{
    public class Item40
    {
        int total = 0;
        object syncHandle = new object();

        public int TotalValue
        {
            get
            {
                lock (syncHandle)
                { return total; }
            }
        }

        public int AddTotal_Lock()
        {
            lock (syncHandle)
            {
                for (int i = 1; i <= 10; i++)
                {
                    total += i;

                    if (i == 1)
                    {
                        Thread t1 = new Thread(ChangeTotal);
                        t1.Start(100);
                    }
                }
            }
            Thread.Sleep(100);
            return total;
        }

        public int AddTotal_NoLock()
        {
            for (int i = 1; i <= 10; i++)
            {
                total += i;

                if (i == 1)
                {
                    Thread t1 = new Thread(ChangeTotal);
                    t1.Start(100);
                }
                Thread.Sleep(100);
            }
            return total;
        }

        public void ChangeTotal(object value)
        {
            lock (syncHandle)
            {
                total = (int)value;
            }
        }

        //------------------------------------------------

        int Value = 0;
        //int syncHandle2 = 1;

        public int GetValue
        {
            get
            {
                return Value;
            }
        }

        public int ChangeValue1()
        {
            Monitor.Enter(syncHandle);
            for (int i = 1; i <= 10; i++)
            {
                Value += i;

                if (i == 1)
                {
                    Thread t1 = new Thread(ChangeValue2);
                    t1.Start(100);
                }
            }
            Monitor.Exit(syncHandle);
            Thread.Sleep(100);
            return Value;
        }

        public void ChangeValue2(object value)
        {
            Monitor.Enter(syncHandle);
            Value = (int)value;
            Monitor.Exit(syncHandle);
        }
    }
}
