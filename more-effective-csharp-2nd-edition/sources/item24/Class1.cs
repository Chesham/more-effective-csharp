using System;

namespace item24
{
    public class Class1
    {
    }

    public class BaseType : ICloneable
    {
        private string label = "class naame";
        private int[] values = new int[10];

        public object Clone()
        {
            BaseType rVal = new BaseType();
            rVal.label = label;
            for(int i = 0; i < values.Length; i++)
            {
                rVal.values[i] = values[i];
            }
            return rVal;
        }
    }

    public class Derived : BaseType, ICloneable
    {
        private double[] dValues = new double[10];
    }

    //----------------------------------------------------------

    public class BaseType2
    {
        private string label;
        private int[] values;

        protected BaseType2()
        {
            label = "class naame";
            values = new int[10];
        }

        protected BaseType2(BaseType2 right)
        {
            label = right.label;
            values = right.values.Clone() as int[];
        }
    }

    public sealed class Derived2 : BaseType2, ICloneable
    {
        private double[] dValues = new double[10];

        public Derived2()
        {
            dValues = new double[10];
        }
        private Derived2(Derived2 right) :
            base(right)
        {
            dValues = right.dValues.Clone() as double[];
        }
        public object Clone()
        {
            Derived2 rVal = new Derived2(this);
            return rVal;
        }
    }
}
