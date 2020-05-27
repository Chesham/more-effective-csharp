using item25;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace more_effective_csharp_2nd_edition
{
    [TestClass]
    public class item25
    {
        [TestMethod]
        public void FillArrayTest()
        {
            var storage = new B[10];
            B.FillArray(storage, () => B.Factory());
            Assert.IsTrue(storage.All(i => i is B));
            B.FillArray(storage, () => D1.Factory());
            Assert.IsTrue(storage.All(i => i is D1));
            B.FillArray(storage, () => D2.Factory());
            Assert.IsTrue(storage.All(i => i is D2));
        }

        [TestMethod]
        public void FillArrayMismatchTest()
        {
            B[] storage = new D1[10];
            Assert.ThrowsException<ArrayTypeMismatchException>(() => B.FillArray(storage, () => B.Factory()));
            // 書上說三個都會例外，但實際上型別相符就不會發生例外
            B.FillArray(storage, () => D1.Factory());
            Assert.IsTrue(storage.All(i => i is D1));
            Assert.ThrowsException<ArrayTypeMismatchException>(() => B.FillArray(storage, () => D2.Factory()));
        }

        [TestMethod]
        public void CS1503()
        {
            B[] storage = new D1[10];
            // CS1503 error
            //B.Contravariance(storage);
            B.Contravariance(storage.Cast<D1>().ToArray());
        }

        [TestMethod]
        public void WriteOutputArrayTest()
        {
            B.WriteOutputArray(new[] { "one", "two" });
            // CS7036
            //B.WriteOutputArray();
            B.WriteOutputArray(new object[] { });
        }

        [TestMethod]
        public void WriteOutputParamsTest()
        {
            B.WriteOutputParams("one", "two");
            B.WriteOutputParams();
        }
    }
}
