using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using item21;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace more_effective_csharp_2nd_edition
{
    [TestClass]
    public class item21
    {
        [TestMethod]
        public async Task WorkEngineTest()
        {
            var engine = new WorkEngineDerived();
            var isEventCalled = false;
            var e = new EventHandler<WorkEventArgs>((sender, args) =>
            {
                isEventCalled = true;
                if (args.step == 0)
                {
                    Assert.AreEqual(false, args.isCancelled);
                    args.Cancel();
                }
                // 因為第一個通知就設定取消，所以永遠不該有 0 以外的 step
                Assert.AreEqual(0, args.step);
            });
            engine.onProgress += e;
            await engine.Start();
            engine.onProgress -= e;
            Assert.IsFalse(isEventCalled);
        }

        [TestMethod]
        public async Task WorkEngineTest2()
        {
            var engine = new WorkEngineDerived2();
            var isEventCalled = false;
            var e = new EventHandler<WorkEventArgs>((sender, args) =>
            {
                isEventCalled = true;
                if (args.step == 0)
                {
                    Assert.AreEqual(false, args.isCancelled);
                    args.Cancel();
                }
                // 因為第一個通知就設定取消，所以永遠不該有 0 以外的 step
                Assert.AreEqual(0, args.step);
            });
            engine.onProgress += e;
            await engine.Start();
            engine.onProgress -= e;
            Assert.IsTrue(isEventCalled);
        }

        [TestMethod]
        public async Task WorkEngineTest3()
        {
            var engine = new WorkEngineDerivedV2();
            var isEventCalled = false;
            var e = new EventHandler<WorkEventArgs>((sender, args) =>
            {
                isEventCalled = true;
                if (args.step == 0)
                {
                    Assert.AreEqual(false, args.isCancelled);
                    args.Cancel();
                }
                // 因為第一個通知就設定取消，所以永遠不該有 0 以外的 step
                Assert.AreEqual(0, args.step);
            });
            engine.OnProgress += e;
            await engine.Start();
            engine.OnProgress -= e;
            Assert.IsTrue(isEventCalled);
        }
    }
}
