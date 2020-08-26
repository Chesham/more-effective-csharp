using System;
using System.Collections.Generic;
using System.Text;
using item47;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class Item47
    {
        [TestMethod()]
        public void Add()
        {
            int answer = item47.Class1.Add(5, 4);
            Assert.AreEqual(9, answer);
        }
    }
}
