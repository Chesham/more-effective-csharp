using Microsoft.VisualStudio.TestTools.UnitTesting;
using item05;

namespace more_effective_csharp_2nd_edition
{
    [TestClass]
    public class Item05
    {
        [TestMethod]
        public void TestDefaultisNull()
        {
            LogMessage logger = new LogMessage();
            Assert.IsNull(logger.Message);           
        }

        [TestMethod]
        public void TestDefaultisNotNull()
        {
            LogMessageV2 logger = new LogMessageV2();
            Assert.IsNotNull(logger.Message);
        }

        [TestMethod]
        public void TestNotAssignDefault()
        {
            Obs o = new Obs();
            Assert.AreEqual(Planet.None, o.whichPlanet);
            Assert.AreEqual(0, o.magnitude);
        }

        [TestMethod]
        public void TestAssginDefault()
        {
            ObsV2 o = new ObsV2(Planet.Earth, 10);
            Assert.AreEqual(Planet.Earth, o.whichPlanet);
            Assert.AreEqual(10, o.magnitude);
        }
    }
}
