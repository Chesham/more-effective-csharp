using System;
using System.Collections.Generic;

namespace item35
{
    public static class Item35
    {
        public static bool SomeTest(this int inputValue)
        {
            return inputValue % 10 == 0;
        }

        public static int SomeProjection(this int intput)
        {
            return intput/10;
        }
    }
}
