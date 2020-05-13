using item22;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace more_effective_csharp_2nd_edition
{
    [TestClass]
    public class item22
    {
        [TestMethod]
        public void Test1()
        {
            Vector vector = new Vector();
            for (int i = 0; i < 10; i++)
            {
                vector.Add(i);
            }
            Assert.AreEqual(10+10, vector.Count());
        }

        [TestMethod]
        public void Test2()
        {
            Vector vector = new Vector();
            var list = Enumerable.Range(0, 10).Select(s => s * 1.0).ToList();
            vector.Add(list);
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(i, vector[i]);
            }
            Assert.AreEqual(10, vector.Count());
        }

        [TestMethod]
        public void Test3()
        {
            Vector vector = new Vector();
            int nScale = 1;
            Assert.AreEqual(nScale.GetType().ToString(), vector.Scale(nScale));

            double dScale = 1;
            Assert.AreEqual(dScale.GetType().ToString(), vector.Scale(dScale));

            float fScale = 1;
            Assert.AreEqual(fScale.GetType().ToString(), vector.Scale(fScale));

            short Scale = 1;
            Assert.AreEqual(Scale.GetType().ToString(), vector.Scale(Scale));

        }

        [TestMethod]
        public void Test4()
        {
            Vector vector = new Vector();
            double dScale = 1;
            Assert.AreEqual(dScale.GetType().ToString(), vector.ScaleV2(dScale));

            float fScale = 1;
            Assert.AreEqual(fScale.GetType().ToString(), vector.ScaleV2(fScale));

            short Scale = 1;
            Assert.AreNotEqual(Scale.GetType().ToString(), vector.ScaleV2(Scale));
            Assert.AreEqual(typeof(float).ToString(), vector.ScaleV2(Scale));

            int nScale = 1;
            Assert.AreEqual(typeof(float).ToString(), vector.ScaleV2(nScale));

        }

        [TestMethod]
        public void Test5()
        {
            MyPoint point = new MyPoint();
            {
                double dXScale = 1, dYScale = 1;
                Assert.AreEqual($"X:{typeof(double)},Y:{typeof(double)}", point.Scale(dXScale, dYScale));
            }

            {
                int nXScale = 1, nYScale = 1;
                Assert.AreEqual($"X:{typeof(int)},Y:{typeof(int)}", point.Scale(nXScale, nYScale));
            }

            {
                int nXScale = 1;
                float fYScale = 1;
                Assert.AreEqual($"X:{typeof(double)},Y:{typeof(double)}", point.Scale(nXScale, fYScale));
            }

        }

        [TestMethod]
        public void Test6()
        {
            MyPoint3D point = new MyPoint3D();
            double dXScale = 1;
            Assert.AreEqual($"{typeof(double)}", point.Scale(dXScale));
            Assert.AreNotEqual($"{typeof(int)}", point.Scale(1));
            Assert.AreEqual($"{typeof(int)}", ((MyPoint)point).Scale(1));

        }

        [TestMethod]
        public void Test7()
        {
            Util u = new Util();
            Assert.AreEqual(3, u.Max(1, 3));
            Assert.AreEqual(5.3, u.Max(5.3, 12.7f));
            Assert.AreEqual(12.7f, u.Max(5, 12.7f));

        }
    }
}
