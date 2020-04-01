using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace more_effective_csharp_2nd_edition
{
    [TestClass]
    public class Item10
    {
        [TestMethod]
        public void 參考型別基本規則測試()
        {
            var left = new item10.ReferenceType();
            var right = new item10.ReferenceType();
            Assert.AreEqual(left, right);
            Assert.IsTrue(left.Equals(right));
            Assert.AreEqual(right, left);
            Assert.IsTrue(right.Equals(left));
            Assert.AreEqual(left.GetHashCode(), right.GetHashCode());

            var id = new object();
            left = new item10.ReferenceType { Id = id };
            right = new item10.ReferenceType { Id = id };
            Assert.AreEqual(left, right);
            Assert.IsTrue(left.Equals(right));
            Assert.AreEqual(right, left);
            Assert.IsTrue(right.Equals(left));
            Assert.AreEqual(left.GetHashCode(), right.GetHashCode());
        }

        [TestMethod]
        public void 實值型別基本規則測試()
        {
            var left = new item10.ValueType();
            var right = new item10.ValueType();
            Assert.AreEqual(left, right);
            Assert.IsTrue(left.Equals(right));
            Assert.AreEqual(right, left);
            Assert.IsTrue(right.Equals(left));
            Assert.AreEqual(left.GetHashCode(), right.GetHashCode());

            var id = new object();
            left = new item10.ValueType { Id = id };
            right = new item10.ValueType { Id = id };
            Assert.AreEqual(left, right);
            Assert.IsTrue(left.Equals(right));
            Assert.AreEqual(right, left);
            Assert.IsTrue(right.Equals(left));
            Assert.AreEqual(left.GetHashCode(), right.GetHashCode());
        }

        [TestMethod]
        public void 參考型別違反規則2將毀損雜湊容器()
        {
            var target = new item10.ReferenceType { Id = new object() };
            var set = new HashSet<item10.ReferenceType> { target };
            // 容器內含有對象物件
            Assert.IsTrue(set.Contains(target));
            // 取出容器內含物件與對象物件相等
            var actual = set.First();
            Assert.AreEqual(target, actual);
            Assert.AreEqual(actual, target);
            Assert.IsTrue(target.Equals(actual));
            Assert.IsTrue(actual.Equals(target));
            // 改變對象物件雜湊值
            target.Id = new object();
            // 容器表明不再持有該物件
            Assert.IsFalse(set.Contains(target));
            Assert.IsFalse(set.Contains(actual));
            // 容器已遺失(或者稱為洩漏, leak)該物件
            Assert.AreEqual(1, set.Count());
        }

        [TestMethod]
        public void 實質型別違反規則2不會毀損雜湊容器()
        {
            var target = new item10.ValueType { Id = new object() };
            var set = new HashSet<item10.ValueType> { target };
            // 容器內含有對象物件
            Assert.IsTrue(set.Contains(target));
            // 取出容器內含物件與對象物件相等
            var actual = set.First();
            Assert.AreEqual(target, actual);
            Assert.AreEqual(actual, target);
            Assert.IsTrue(target.Equals(actual));
            Assert.IsTrue(actual.Equals(target));
            // 改變對象物件雜湊值
            target.Id = new object();
            // 容器表明不再持有該物件，注意第二個驗證與參考型別行為不同
            Assert.IsFalse(set.Contains(target));
            Assert.IsTrue(set.Contains(actual));
            // 容器實際上沒有遺失該物件，因為你還是可以用 actual 搜尋到它 (就可以刪除)
            Assert.AreEqual(1, set.Count());
        }
    }
}
