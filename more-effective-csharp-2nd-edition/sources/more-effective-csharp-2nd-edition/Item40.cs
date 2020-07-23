using System;
using System.Collections.Generic;
using System.Text;
using item40;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class Item40
    {
        [TestMethod()]
        public void NoLock()
        {
            item40.Item40 a = new item40.Item40();
            Assert.AreEqual(0, a.TotalValue);
            a.AddTotal_NoLock();
            Assert.AreNotEqual(55, a.TotalValue);
        }

        [TestMethod()]
        public void Lock()
        {
            item40.Item40 a = new item40.Item40();
            Assert.AreEqual(0, a.TotalValue);
            a.AddTotal_Lock();
            Assert.AreEqual(100, a.TotalValue);
        }

        [TestMethod()]
        public void MonitorLock()
        {
            item40.Item40 a = new item40.Item40();
            Assert.AreEqual(0, a.GetValue);
            a.ChangeValue1();
            Assert.AreEqual(100, a.GetValue);
        }
    }
}
