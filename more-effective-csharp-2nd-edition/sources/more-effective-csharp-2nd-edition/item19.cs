using item19;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace more_effective_csharp_2nd_edition
{
    [TestClass]
    public class item19
    {
        [TestMethod]
        public void AnimalFooTest()
        {
            var obj = new Animal();
            var expect = "Animal.Foo";
            var actual = obj.Foo(new Apple());
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TigerFooAppleTest()
        {
            var obj = new Tiger();
            var expect = "Tiger.Foo";
            var actual = obj.Foo(new Apple());
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TigerFooFruitTest()
        {
            var obj = new Tiger();
            var expect = "Tiger.Foo";
            var actual = obj.Foo(new Fruit());
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void UpcastAnimalFooTest()
        {
            Animal obj = new Tiger();
            var expect = "Animal.Foo";
            var actual = obj.Foo(new Apple());
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void CastingFooTest()
        {
            var obj = new Tiger();
            var expect = "Animal.Foo";
            var actual = ((Animal)obj).Foo(new Apple());
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TigerBarTest()
        {
            var obj = new Tiger();
            var expect = "Tiger.Bar";
            var actual = obj.Bar(new Apple());
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TigerBazTest()
        {
            var obj = new Tiger();
            // C# 4.0 later
            var expect = "Tiger.Baz";
            var actual = obj.Baz(Enumerable.Repeat(new Apple(), 2));
            Assert.AreEqual(expect, actual);
        }
    }
}
