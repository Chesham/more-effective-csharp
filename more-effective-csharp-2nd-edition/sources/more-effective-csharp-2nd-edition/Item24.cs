using System;
using System.Collections.Generic;
using System.Text;
using item24;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace more_effective_csharp_2nd_edition
{
    [TestClass]
    public class item24
    {
        [TestMethod]
        public void Test1()
        {
            Derived d = new Derived();
            Derived d2 = d.Clone() as Derived;
            Assert.AreEqual(null, d2);
        }

        [TestMethod]
        public void Test2()
        {
            Derived2 d = new Derived2();
            Derived2 d2 = d.Clone() as Derived2;
            Assert.AreNotEqual(null, d2);
        }
    }
}
