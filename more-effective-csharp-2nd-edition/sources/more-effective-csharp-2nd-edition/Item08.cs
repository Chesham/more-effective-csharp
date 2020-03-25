using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using item08;

namespace more_effective_csharp_2nd_edition
{
    [TestClass]
    public class Item08
    {
        [TestMethod]
        public void Test01()
        {
            CTest a = new CTest();
            var aPoint = new { x = 5, y = 67 };
            var bPoint = a.Transfrom(aPoint, (p) => new { x = p.x * 2, y = p.y * 2 });

            Assert.AreSame(aPoint.GetType(), bPoint.GetType());
            Assert.AreEqual(aPoint.x * 2, bPoint.x);
        }

        [TestMethod]
        public void Test02()
        {
            CTest2 c = new CTest2();
            List<int> _list = new List<int>{ 10, 20, 30 };
            var a = c.Find(_list, 20);
            (int FindValue, int FindIndex) b = c.Find(_list, 30);

            Assert.AreEqual(a.index, 1);
            Assert.AreEqual(b.FindIndex, 2);
        }
    }
}
