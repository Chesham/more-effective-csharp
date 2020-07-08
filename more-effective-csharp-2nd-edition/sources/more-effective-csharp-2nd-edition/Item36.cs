using Microsoft.VisualStudio.TestTools.UnitTesting;
using item36;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class Item36
    {
        [TestMethod()]
        public void TestHideException()
        {
            var target = new item36.Item36();
            target.hideException();
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void TestShowException()
        {
            var target = new item36.Item36();
            Assert.ThrowsException<AggregateException>(() => target.showException());
        }

        [TestMethod()]
        public void TestLINQException()
        {
            var nums = from n in Enumerable.Range(0, 300)
                       where n < 150
                       select 100 / (n % 10);

            Assert.ThrowsException<DivideByZeroException>(() =>
            {
                foreach (var item in nums)
                    Console.WriteLine(item);
            });
        }

        [TestMethod()]
        public void TestPLINQException()
        {
            Assert.ThrowsException<AggregateException>(() =>
            {
                var nums = from n in ParallelEnumerable.Range(0, 300)
                           where n < 150
                           select 100 / (n % 10);

                foreach (var item in nums)
                    Console.WriteLine(item);
            });
        }
    }
}