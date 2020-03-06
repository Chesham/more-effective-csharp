using Microsoft.VisualStudio.TestTools.UnitTesting;
using item03;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Immutable;
using System.Linq;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class Item03
    {
        [TestMethod()]
        public void TestItem03()
        {
            var ph = new string[10];
            var target = new item03.Item03("Paigekuo",25,"Kaohsiung",ph);
            var expect = 25;
            var actual = target.Age;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void TestArrayValue()
        {
            var ph = new string[10];
            ph[0] = "09XX-XXX-XXX";
            var target = new item03.Item03("Paigekuo", 25, "Kaohsiung", ph);
            ph[0] = "09OOO-OOO-OOO";
            var expect = "09XX-XXX-XXX";
            var actual = target.Phones2.First();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void TestArrayRefrernce()
        {
            var ph = new string[10];
            ph[0] = "09XX-XXX-XXX";
            var target = new item03.Item03("Paigekuo", 25, "Kaohsiung", ph);
            ph[0] = "09OOO-OOO-OOO";
            var expect = "09XX-XXX-XXX";
            var actual = target.Phones.First();
            Assert.AreNotEqual(expect, actual);
        }

    }
}