using Microsoft.VisualStudio.TestTools.UnitTesting;
using item28;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class Item28
    {
        [TestMethod, Ignore]
        public void TestFireAndForget()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Console.WriteLine("GetException");
            };
            var timeout = TimeSpan.FromMilliseconds(10);
            item28.Item28.FireAndForget(timeout);
            Task.Delay(timeout * 2).Wait();
            Assert.Fail("should not happen");
        }

        [TestMethod, Ignore]
        public void TestReturnTask()
        {
            var timeout = TimeSpan.FromMilliseconds(10);
            Assert.ThrowsException<AggregateException>(() => item28.Item28.ReturnTask(timeout).Wait());
        }

        [TestMethod, Ignore]
        public void TestOnEvent()
        {
            var target = new item28.TaskEvent();
            target.OnShapeChanged(new EventArgs());
        }

        [TestMethod, Ignore]
        public void TestOnEventStop()
        {
            var target = new item28.TaskEventStop();
            target.OnShapeChanged(new EventArgs());
        }
    }
}