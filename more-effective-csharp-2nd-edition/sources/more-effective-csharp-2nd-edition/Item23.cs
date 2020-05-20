using System;
using System.Collections.Generic;
using System.Text;
using item23;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace more_effective_csharp_2nd_edition
{
    [TestClass]
    public class item23
    {
        [TestMethod]
        public void Test1()
        {
            GeneratedStuff a = new GeneratedStuff();

            Assert.AreEqual(0, a.storage);
            a.UpdateValue(10);
            Assert.AreEqual(10, a.storage);
            a.UpdateValue(-5);
            Assert.AreEqual(10, a.storage);
        }
    }
}
