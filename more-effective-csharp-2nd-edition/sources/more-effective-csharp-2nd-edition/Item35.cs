using Microsoft.VisualStudio.TestTools.UnitTesting;
using item35;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class Item35
    {
        readonly int[] expect = Enumerable.Range(0, 30).ToArray();

        [TestMethod()]
        public void 停止並進行()
        {
            var stopAndGoArray = (from n in ParallelEnumerable.Range(0, 300)
                                  where n.SomeTest()
                                  select n.SomeProjection()).ToArray();
            Assert.AreEqual(expect.Length, stopAndGoArray.Length);
            Assert.AreEqual(expect.Except(stopAndGoArray).Count(), 0);
            Assert.AreEqual(expect.Skip(20).Take(20).Except(stopAndGoArray.Skip(20).Take(20)).Count(), 0);
        }

        [TestMethod()]
        public void 反向列舉()
        {
            var numsParallel = from n in ParallelEnumerable.Range(0, 300)
                               where n.SomeTest()
                               select n.SomeProjection();

            var actual = new List<int>();
            object o = new object();
            foreach (var item in numsParallel)
            {
                lock (o)
                {
                    actual.Add(item);
                }
            }
            Assert.AreEqual(expect.Length, actual.Count);
            Assert.AreEqual(expect.Except(actual).Count(), 0);
            Assert.AreNotEqual(expect.Skip(20).Take(20).Except(actual.Skip(20).Take(20)).Count(), 0);
        }

        [TestMethod()]
        public void 反向列舉2()
        {
            var numsParallel = from n in ParallelEnumerable.Range(0, 300)
                               where n.SomeTest()
                               select n.SomeProjection();

            var actual = new List<int>();
            var o = new object();
            numsParallel.ForAll(item =>
            {
                lock (o)
                {
                    actual.Add(item);
                }
            });
            Assert.AreEqual(expect.Length, actual.Count());
            Assert.AreEqual(expect.Except(actual).Count(), 0);
            Assert.AreNotEqual(expect.Skip(20).Take(20).Except(actual.Skip(20).Take(20)).Count(), 0);
        }

        [TestMethod()]
        public void PLINQ序列式演算法()
        {
            var numsParallel = (from n in ParallelEnumerable.Range(0, 300)
                                where n.SomeTest()
                                select n.SomeProjection()).Skip(20).Take(20);

            var actual = new List<int>();
            var o = new object();
            numsParallel.ForAll(item =>
            {
                lock (o)
                {
                    actual.Add(item);
                }
            });
            foreach (var a in actual)
            {
                Console.WriteLine(a);
            }
            Assert.AreEqual(expect.Skip(20).Take(20).Count(), actual.Count);
            Assert.AreEqual(expect.Skip(20).Take(20).Except(actual).Count(), 0);//[20-29]
        }

    }
}