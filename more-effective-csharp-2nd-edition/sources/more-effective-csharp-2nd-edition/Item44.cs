using Microsoft.VisualStudio.TestTools.UnitTesting;
using item44;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class Item44
    {
        readonly IEnumerable<String> s = Enumerable.Range(0, 10).Select(i => "String" + i);
        [TestMethod()]
        public void TestMyType1()
        {
            var answer = s.Cast<MyType>();
            Assert.ThrowsException<InvalidCastException>(() =>
            {
                foreach (var v in answer)
                {
                    Assert.AreEqual("MyType", v.GetType().Name);
                }
            });
        }

        [TestMethod()]
        public void TestMyType2()
        {
            var answer = from MyType v in s select v;
            Assert.ThrowsException<InvalidCastException>(() =>
            {
                foreach (var v in answer)
                {
                    Assert.AreEqual("MyType", v.GetType().Name);
                }
            });
        }

        [TestMethod()]
        public void TestMyType3()
        {
            var answer = from v in s select (MyType)v;
            foreach (var v in answer)
            {
                Assert.AreEqual("MyType", v.GetType().Name);
            }
        }

        [TestMethod()]
        public void TestMyType4()
        {
            var answer = s.Select(n => new MyType { StringMember = n });
            foreach (var v in answer)
            {
                Assert.AreEqual("MyType", v.GetType().Name);
            }
        }

        [TestMethod()]
        public void TestMyType5()
        {
            var answer = from v in s select new MyType { StringMember = v };
            foreach (var v in answer)
            {
                Assert.AreEqual("MyType", v.GetType().Name);
            }
        }

        [TestMethod()]
        public void TestMyType6()
        {
            var answer = s.Convert<MyType>();
            foreach (var v in answer)
            {
                Assert.AreEqual("MyType", v.GetType().Name);
            }
        }
    }
}