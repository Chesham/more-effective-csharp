using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using item15;
using System.Linq;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class item15
    {

        [TestMethod()]
        public void Test01()
        {
            GrandFather child = new Child();
            Assert.AreNotEqual("Child", child.print());
            Assert.AreEqual("GrandFather", child.print());

            GrandMather child2 = new Child2();
            Assert.AreEqual("Child", child2.print());


        }



    }
}
