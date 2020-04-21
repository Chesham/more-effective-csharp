using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using item13;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class Item13
    {
        [TestMethod()]
        public void Test01()
        {
            var target = new PhoneValidator();

            Assert.AreEqual(true, target.ValidareNumber("0965478956"));
        }

        [TestMethod()]
        public void Test02()
        {
            var target = new PhoneValidator();

            Assert.AreEqual(false, target.ValidareNumber("530965478956"));
        }

        [TestMethod()]
        public void Test03()
        {
            var target = new PhoneValidator();
            var target2 = target.CreatValidator(PhoneTypes.TW);
            Assert.AreEqual(true, target2.ValidareNumber("0965478956"));
        }

        [TestMethod()]
        public void Test04()
        {
            var target = new PhoneValidator();
            var target2 = target.CreatValidator(PhoneTypes.US);

            Assert.AreEqual(true, target2.ValidareNumber("530965478956"));
        }
    }
}
