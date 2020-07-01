using item34;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace more_effective_csharp_2nd_edition
{
    [TestClass]
    public class item34
    {
        [TestMethod]
        public async Task 測試非同步取得快取結果()
        {
            var target = new Coo();
            var r = await target.getCache();
            Assert.AreEqual(0, r);
        }

        [TestMethod]
        public async Task 測試緊湊迴圈使用緩衝擴充取得非同步快取結果()
        {
            var target = new Coo();
            for (var i = 0; i < 1000; ++i)
            {
                var r = await target.getCache();
                Assert.AreEqual(0, r);
            }
        }

        [TestMethod]
        public async Task 測試緊湊迴圈取得非同步快取結果()
        {
            var target = new Coo();
            for (var i = 0; i < 1000; ++i)
            {
                var r = await target.getCacheTask();
                Assert.AreEqual(0, r);
            }
        }

        [TestMethod]
        public async Task 快取逾時前會直接取用快取不重新評估()
        {
            var target = new Coo { cacheTimeout = TimeSpan.FromSeconds(1), randomRange = (50, 50) };
            var r = await target.getCache();
            Assert.AreEqual(50, r);
            target.randomRange = (0, 0);
            r = await target.getCache();
            Assert.AreEqual(50, r);
            target.getNow = () => DateTime.Now + TimeSpan.FromSeconds(2);
            r = await target.getCache();
            Assert.AreEqual(0, r);
        }
    }
}
