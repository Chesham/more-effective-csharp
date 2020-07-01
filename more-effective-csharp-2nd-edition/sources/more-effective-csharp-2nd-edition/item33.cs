using item33;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace more_effective_csharp_2nd_edition
{
    [TestClass]
    public class item33
    {
        class ProgressReporter : IProgress<(int, string)>
        {
            public event EventHandler<(int, string)> onProgress;

            public void Report((int, string) value)
            {
                onProgress?.Invoke(this, value);
            }
        }

        [TestMethod]
        public async Task 僅執行工作()
        {
            var target = new Coo();
            await target.foo();
        }

        [TestMethod]
        public async Task 不取消直接走完()
        {
            var progresses = new List<(int, string)>();
            var reporter = new ProgressReporter();
            reporter.onProgress += (sender, args) =>
            {
                progresses.Add(args);
            };
            var target = new Coo();
            await target.foo(reporter);
            Assert.AreEqual(6, progresses.Count);
            Assert.IsTrue(Enumerable.Range(0, 6).Select(i => i * 20).SequenceEqual(progresses.Select(i => i.Item1)));
        }

        [TestMethod]
        public async Task 取消不走完()
        {
            var progresses = new List<(int, string)>();
            var timeout = TimeSpan.FromMilliseconds(50);
            using (var cts = new CancellationTokenSource(timeout))
            {
                var reporter = new ProgressReporter();
                reporter.onProgress += (sender, args) =>
                {
                    progresses.Add(args);
                };
                var target = new Coo { randomBoundaries = ((int)timeout.TotalMilliseconds, (int)timeout.TotalMilliseconds) };
                try
                {
                    await target.foo(cts.Token, reporter);
                }
                catch (OperationCanceledException ce)
                {
                    Logger.LogMessage("{0}\n{1}", ce.Message, ce.StackTrace);
                }
            }
            Assert.AreNotEqual(6, progresses.Count);
            Assert.IsTrue(Enumerable.Range(0, progresses.Count).Select(i => i * 20).SequenceEqual(progresses.Select(i => i.Item1)));
        }

        [TestMethod]
        public async Task 取消且不回報()
        {
            var timeout = TimeSpan.FromMilliseconds(50);
            var caughtException = default(OperationCanceledException);
            using (var cts = new CancellationTokenSource(timeout))
            {
                var target = new Coo { randomBoundaries = ((int)timeout.TotalMilliseconds, (int)timeout.TotalMilliseconds) };
                try
                {
                    await target.foo(cts.Token);
                }
                catch (OperationCanceledException ce)
                {
                    Logger.LogMessage("{0}\n{1}", ce.Message, ce.StackTrace);
                    caughtException = ce;
                }
            }
            Assert.IsNotNull(caughtException);
        }
    }
}
