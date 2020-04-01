using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace more_effective_csharp_2nd_edition
{
    [TestClass]
    public class Item09
    {
        [TestMethod]
        public void 實值型別物件識別測試()
        {
            var expect = new item09.ValueEquality();
            var actual = new item09.ValueEquality();
            Assert.IsFalse(ReferenceEquals(expect, actual));
        }

        [TestMethod]
        public void 參考型別物件識別測試()
        {
            var expect = new item09.ReferenceEquality();
            var actual = new item09.ReferenceEquality();
            Assert.IsFalse(ReferenceEquals(expect, actual));
        }

        [TestMethod]
        public void 參考物件相等性測試()
        {
            var id = new object();
            var left = new item09.ReferenceEquality { Id = id };
            var right = new item09.ReferenceEquality { Id = id };
            var other = new item09.ReferenceEquality { Id = id };
            // reflexive
            Assert.AreEqual(left, left);
            Assert.IsTrue(left.Equals(left));
            Assert.IsTrue(left == left);
            Assert.AreEqual(right, right);
            Assert.IsTrue(right.Equals(right));
            Assert.IsTrue(right == right);
            // symmetric
            Assert.AreEqual(left, right);
            Assert.IsTrue(left.Equals(right));
            Assert.IsFalse(left == right);
            Assert.AreEqual(right, left);
            Assert.IsTrue(right.Equals(left));
            Assert.IsFalse(right == left);
            // transitive
            Assert.AreEqual(right, other);
            Assert.IsTrue(right.Equals(other));
            Assert.IsFalse(right == other);
            Assert.AreEqual(left, other);
            Assert.IsTrue(left.Equals(other));
            Assert.IsFalse(left == other);
        }

        [TestMethod]
        public void 參考物件空無相等性測試()
        {
            var left = new item09.ReferenceEquality { Id = new object() };
            var right = default(item09.ReferenceEquality);
            Assert.AreNotEqual(left, right);
            Assert.IsFalse(left.Equals(right));
            Assert.AreNotEqual(right, left);
        }

        [TestMethod]
        public void 實值物件相等性測試()
        {
            var id = new object();
            var left = new item09.ValueEquality { Id = id };
            var right = new item09.ValueEquality { Id = id };
            var other = new item09.ValueEquality { Id = id };
            var differ = new item09.ValueEquality { Id = id, Name = new object() };
            // reflexive
            Assert.AreEqual(left, left);
            Assert.IsTrue(left.Equals(left));
            Assert.AreEqual(right, right);
            Assert.IsTrue(right.Equals(right));
            // symmetric
            Assert.AreEqual(left, right);
            Assert.IsTrue(left.Equals(right));
            Assert.AreEqual(right, left);
            Assert.IsTrue(right.Equals(left));
            // transitive
            Assert.AreEqual(right, other);
            Assert.IsTrue(right.Equals(other));
            Assert.AreEqual(left, other);
            Assert.IsTrue(left.Equals(other));

            Assert.AreNotEqual(left, differ);
            Assert.IsFalse(left.Equals(differ));
        }
    }
}
