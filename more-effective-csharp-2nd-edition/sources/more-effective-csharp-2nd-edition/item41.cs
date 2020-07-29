using item41;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace more_effective_csharp_2nd_edition
{
    [TestClass]
    public class item41
    {
        [TestMethod]
        public void 引發死鎖()
        {
            var target = new ShouldNotLockThis();
            var lockAquired = true;
            target.foo(() =>
            {
                Task.Run(() =>
                {
                    lockAquired = target.update();
                }).Wait();
            });
            Assert.IsFalse(lockAquired);
        }

        [TestMethod]
        public void 縮小縮定範圍避免死鎖()
        {
            var target = new ShouldLockLikeThis();
            var lockAquired = false;
            target.foo(() =>
            {
                Task.Run(() =>
                {
                    lockAquired = target.update();
                }).Wait();
            });
            Assert.IsTrue(lockAquired);
        }
    }
}
