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

            WeatherData.PrintCollection(warmDays);

            foreach (var o in warmDays)
            {
                Assert.IsTrue(o.WindSpeed <= 70);
            }
        }        
    }
}
