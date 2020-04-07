using Microsoft.VisualStudio.TestTools.UnitTesting;
using item11;
using System;
using System.Collections.Generic;
using System.Text;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class Item11
    {
        [TestMethod()]
        public void TestComputeArea()
        {
            var target = new Circle(3, 0, 5.0f);
            var expect = 5.0f * 5.0f * Math.PI;
            var actual = ComputeShape.ComputeArea(target);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void TestFlatten()
        {
            var target = new Circle(3, 0, 5.0f);
            var expectX = 5 / 2;
            var expectY = 5 * 2;
            ComputeShape.Flatten(target);
            //ComputeShape.Flatten((myEllipse)target);

            var actual = target.radius;
            Assert.AreNotEqual(expectX, actual);
            Assert.AreNotEqual(expectY, actual);
            Assert.AreEqual(5.0f, target.radius);
        }
        [TestMethod()]
        public void TestFlatten2()
        {
            var c = new Circle(3, 0, 5.0f);
            var target = new myEllipse(c);
            var expectX = 5.0 / 2;
            var expectY = 5.0 * 2;
            ComputeShape.Flatten(target);

            var actual = target;
            Assert.AreEqual(expectX, actual.RadiusX);
            Assert.AreEqual(expectY, actual.RadiusY);
        }
    }
}