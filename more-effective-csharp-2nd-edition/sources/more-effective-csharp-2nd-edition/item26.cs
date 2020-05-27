using item26;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;

namespace more_effective_csharp_2nd_edition
{
    [TestClass]
    public class item26
    {

        [TestMethod]
        public void 例外延遲發生的迭代方法()
        {
            var target = Generator.DelayedException(Enumerable.Range(0, 10), -8);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                foreach (var i in target)
                {
                }
            });
        }

        [TestMethod]
        public void 可檢查的例外盡早發生的迭代方法()
        {
            Assert.ThrowsException<ArgumentException>(() => Generator.Generate(Enumerable.Range(0, 10), -8));
        }

        [TestMethod]
        public void 例外延遲發生的異步方法()
        {
            var target = Worker.LoadMessage(string.Empty);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                try
                {
                    return target.Result;
                }
                catch (AggregateException ae)
                {
                    ExceptionDispatchInfo.Throw(ae.Flatten().InnerException);
                    return null;
                }
            });
        }

        [TestMethod]
        public void 可檢查的例外盡早發生的異步方法()
        {
            Assert.ThrowsException<ArgumentException>(() => Worker.LoadMessageWithLocalFunction(string.Empty));
        }
    }
}
