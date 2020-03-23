using System;

namespace item07
{
    public class Tuples01
    {
        static void Main(string[] args)
        {
        }

        public T Transfrom<T>(T element, Func<T, T> transformFunc)
        {
            return transformFunc(element);
        }
    }
}
