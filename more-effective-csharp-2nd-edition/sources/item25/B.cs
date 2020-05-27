using System;
using System.Diagnostics;

namespace item25
{
    public class B
    {
        public static B Factory() => new B();

        public virtual void WriteType() => WriteLine(nameof(B));

        public static void FillArray(B[] arr, Func<B> generator)
        {
            for (var i = 0; i < arr.Length; ++i)
                arr[i] = generator();
        }

        public static void Contravariance(D1[] arr)
        {
            for (var i = 0; i < arr.Length; ++i)
                arr[i] = new D1();
        }

        public static void WriteOutputArray(object[] objs)
        {
        }
        
        public static void WriteOutputParams(params object[] objs)
        {
        }

        protected void WriteLine(string msg) => Debug.WriteLine(msg);
    }
}
