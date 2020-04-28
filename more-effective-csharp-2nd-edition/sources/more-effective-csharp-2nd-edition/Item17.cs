using Microsoft.VisualStudio.TestTools.UnitTesting;
using item17;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class Item17
    {
        [TestMethod()]
        public void TestGetValue()
        {
            var target = new item17.Item17();
            target.GetValue();
            var expect = 5;
            target.Datas.Add(0);
            var actual = target.Datas.Count;
            Assert.AreNotEqual(expect, actual);
        }

        [TestMethod()]
        public void TestGetInterface()
        {
            var target = new item17.Item17();
            var expect = 5;
            target.GetValue(); 
            var actual = target.DatasI.Count();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void TestGetWrappers()
        {
            var target = new item17.Item17();
            var expect = 5;
            target.GetValue();
            var actual = target.DatasW.Count;
            Assert.AreEqual(expect, actual);
        }
    }
}