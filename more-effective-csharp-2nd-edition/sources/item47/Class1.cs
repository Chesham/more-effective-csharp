using System;
using Microsoft.CSharp.RuntimeBinder;

namespace item47
{
    public class Class1
    {
        private static dynamic DynamicAdd(dynamic left, dynamic right)
        {
            return left + right;
        }

        public static T1 Add<T1 , T2>(T1 left, T2 right)
        {
            dynamic result = DynamicAdd(left, right);
            return (T1)result;
        }
    }
}
