using System;
using System.Collections.Generic;

namespace item08
{
    public class CTest
    {
        public T Transfrom<T>(T element, Func<T, T> transformFunc)
        {
            return transformFunc(element);
        }
    }

    public class CTest2
    {
        public (T sought,int index) Find<T>(IEnumerable<T> enumerable,T value) //以tuple作為回傳值
        {
            int index = 0;
            foreach(T element in enumerable)
            {
                if(element.Equals(value))
                {
                    return (value, index);
                }
                index++;
            }
            return (default(T), -1);
        }
    }
}
