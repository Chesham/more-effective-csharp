using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using item38;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class item38
    {
        [TestMethod()]
        public void TestBackgroundWorkerGetResult()
        {
            var e = new EventHandler<DoWorkEventArgs>((sender, args) =>
            {
                Assert.AreEqual(55, args.Result);
            });
            WorkEngine engine = new WorkEngine();
            engine.handler += e;
            engine.Start(10);
        }
        [TestMethod()]
        public void TestBackgroundWorkerCancel()
        {
            var e = new EventHandler<DoWorkEventArgs>((sender, args) =>
            {
                Assert.IsTrue(args.Cancel);
                Assert.AreEqual(-999, args.Result);
            });
            WorkEngine engine = new WorkEngine();
            engine.handler += e;
            engine.Start(10);
            engine.Cancel();

        }
    }
}
