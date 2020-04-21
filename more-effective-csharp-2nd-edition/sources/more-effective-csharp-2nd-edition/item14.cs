using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using item14;
using System.Linq;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class item14
    {
        [TestMethod()]
        public void Test01()
        {
            var warmDays = from item in new WeatherDataStream("Ann Arbor")
                           where item.Temperature > 80
                           select item;

            Assert.AreEqual(true, true);
        }

        [TestMethod()]
        public void Test02()
        {
            Employee _Employee;
            //_Employee.Name = "aa";


            Assert.AreEqual(true, true);
        }
    }
}
