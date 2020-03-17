using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using item06;

namespace more_effective_csharp_2nd_edition
{
    [TestClass]
    public class Item06
    {
        [TestMethod]
        public void TestDefault()
        {
            MyPoint p = new MyPoint();
            Assert.AreEqual(0, p.X);
            Assert.AreEqual(0, p.Y);
            Assert.AreEqual(0, p.Distance);
        }

        [TestMethod]
        public void TestDistance()
        {
            MyPoint p = new MyPoint();
            p.X = 3;
            p.Y = 4;
            Assert.AreEqual(3, p.X);
            Assert.AreEqual(4, p.Y);
            Assert.AreEqual(5, p.Distance);
        }

        [TestMethod]
        public void TestV2Distance()
        {
            MyPointV2 p = new MyPointV2();
            p.X = 3;
            p.Y = 4;
            Assert.AreEqual(3, p.X);
            Assert.AreEqual(4, p.Y);
            Assert.AreEqual(5, p.Distance);
            Assert.AreEqual(5, p.Distance);

        }
    }
}
