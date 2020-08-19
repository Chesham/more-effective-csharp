using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Item46;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class item46
    {
        [TestMethod(), Ignore]
        public void ExpressionAPI測試()
        {
            var item46 = new Item46.Class1();
            int expected = 10;
            var r = item46.CallInterface(s => DoWork(10));
            Assert.AreEqual(expected, r);
        }

        public int DoWork(int value)
        {
            return value + 10;

        }

    }
}