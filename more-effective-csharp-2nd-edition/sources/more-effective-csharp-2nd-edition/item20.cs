using item20;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace more_effective_csharp_2nd_edition
{
    [TestClass]
    public class item20
    {
        [TestMethod]
        public async Task WorkEngineTest()
        {
            var engine = new WorkEngine();
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
    }
}
