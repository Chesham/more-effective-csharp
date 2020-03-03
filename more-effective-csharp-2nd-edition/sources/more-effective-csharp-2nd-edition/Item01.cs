using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace more_effective_csharp_2nd_edition
{
    [TestClass]
    public class Item01
    {
        [TestMethod]
        public void TestFirstName()
        {
            var target = item01.Item01.Create("Chesham", "Chou");
            var expect = "Chesham";
            var actual = target.firstName;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestLastName()
        {
            var target = item01.Item01.Create("Chesham", "Chou");
            var expect = "Chou";
            var actual = target.lastName;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestName()
        {
            var target = item01.Item01.Create("Chesham", "Chou");
            var expect = "Chesham, Chou";
            var actual = target.Name;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestTimeout()
        {
            var target = item01.Item01.Create("Chesham", "Chou");
            var expect = TimeSpan.FromSeconds(5);
            var actual = target.Timeout;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestTimeoutOverriding()
        {
            var target = item01.Item01.Create("Chesham", "Chou", TimeSpan.FromMinutes(5));
            var expect = TimeSpan.FromMinutes(5);
            var actual = target.Timeout;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestMemberIndexer()
        {
            var expect = item01.Item01.Create("Chesham Jr.", "Chou");
            var target = item01.Item01.Create("Chesham", "Chou", null, expect);
            var actual = target[0];
            Assert.AreEqual(expect, actual);
        }
    }
}
