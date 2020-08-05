using System;
using System.Collections.Generic;

namespace item44
{
    public class MyType
    {
        public String StringMember { get; set; }

        public static implicit operator String(MyType aString) => aString.StringMember;
        public static implicit operator MyType(String aString) => new MyType { StringMember = aString };
    }
    public static class Item44
    {
        public static IEnumerable<TResult> Convert<TResult>(this System.Collections.IEnumerable sequence)
        {
            foreach (object item in sequence)
            {
                dynamic coercion = (dynamic)item;
                yield return (TResult)coercion;
            }
        }
    }
}
