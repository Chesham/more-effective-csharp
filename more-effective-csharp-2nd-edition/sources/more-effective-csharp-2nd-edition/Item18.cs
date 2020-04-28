using Microsoft.VisualStudio.TestTools.UnitTesting;
using item18;
using System;
using System.Collections.Generic;
using System.Text;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class Item18
    {
        [TestMethod()]
        public void TestOverride()
        {
            var target = new Circle();
            target.Update(10);
            var expect = target.Area;
            var actual = 3.14 * 10 * 10 * 2;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void TestAddEventHandler()
        {
            var target = new Rectangle();
            target.ShapeChanged += target.OnShapeChanged2;
            target.Update(10, 10);
            var expect = target.Area;
            var actual = 10*10*3;
            Assert.AreEqual(expect, actual);
        }
    }
}