using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using item31;
using System.Threading.Tasks;
using System.Threading;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class Item31
    {
        /*[TestMethod()]
        public async Task TestSomeMethodAsync()
        {
            var target = new item31.Item31();
            //var task = target.SomeMethodAsync();
            //var expect = "In SomeMethodAsync,before the await";
            //Assert.AreEqual(expect, target.msg);
            //task.Wait();
            //expect = "In SomeMethodAsync,after the await2";
            //Assert.AreEqual(expect, target.msg);
            var tids = await target.SomeMethodAsync();
            Assert.AreEqual(tids.Item1, tids.Item2);
        }*/

        [TestMethod()]
        public async Task TestAwareAsync()
        {
            var target = new item31.Item31();

            var StratThreadID = Thread.CurrentThread.ManagedThreadId;
            var AwareThreadID = await target.AwareAsync();
            var EndThreadID = Thread.CurrentThread.ManagedThreadId;
            Assert.AreEqual(StratThreadID, AwareThreadID);
            Assert.AreEqual(StratThreadID, EndThreadID);
        }
    }
}
