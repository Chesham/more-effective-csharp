using System;

namespace item15
{
    public class Item15
    {
    }


    public class GrandFather
    {
        public string print()
        {
            return "GrandFather";
        }
    }



    public class Father : GrandFather
    {
        public string print()
        {
            return "Father";
        }
    }

    public class Child : Father
    {
        public new string print()
        {
            return "Child";
        }
    }

    public class GrandMather
    {
        public virtual string print()
        {
            return "GrandMother";
        }
    }

    public class Mother : GrandMather
    {
        public override string print()
        {
            return "Mother";
        }
    }

    public class Child2 : Mother
    {
        public override string print()
        {
            return "Child";
        }
    }

}
