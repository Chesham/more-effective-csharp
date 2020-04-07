using Microsoft.VisualStudio.TestTools.UnitTesting;
using item12;
using System;
using System.Collections.Generic;
using System.Text;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class Item12
    {
        [TestMethod()]
        public void TestSetName()
        {
            var target = new item12.Item12();
            var expect = "Kuo Paige";
            var actual = target.SetName(firstName: "Kuo", lastName: "Paige");
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void TestSetName2()
        {
            var target = new item12.Item12();
            var expect = "Lin Paige";
            var actual = target.SetName("Paige");
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void TestSetName3()
        {
            var target = new item12.Item12();
            var expect = "Kuo Paige";
            var actual = target.SetName("Paige", "Kuo");
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void Testcompute()
        {
            var target = new item12.Item12();
            var expect = 51;
            var actual = target.compute(1);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void Testcompute2()
        {
            var target = new item12.Item12();
            var expect = 7;
            var actual = target.compute(1,2,3);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void Testcompute3()
        {
            var target = new item12.Item12();
            var expect = 11;
            var actual = target.compute(1,three:2);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void Testcompute4()
        {
            var target = new item12.Item12();
            var expect = 21;
            var actual = target.compute(1,2);
            Assert.AreEqual(expect, actual);
        }
    }
}