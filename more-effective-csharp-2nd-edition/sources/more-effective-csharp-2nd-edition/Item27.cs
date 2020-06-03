using Microsoft.VisualStudio.TestTools.UnitTesting;
using item27;
using System;
using System.Collections.Generic;
using System.Text;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class Item27
    {
        [TestMethod()]
        public void TestSomeMethodAsync()
        {
            var target = new item27.Item27();
            var task = target.SomeMethodAsync();
            var expect = "In SomeMethodAsync,before the await";
            Assert.AreEqual(expect, target.msg);
            task.Wait();
            expect = "In SomeMethodAsync,after the await";
            Assert.AreEqual(expect, target.msg);
        }
    }
}