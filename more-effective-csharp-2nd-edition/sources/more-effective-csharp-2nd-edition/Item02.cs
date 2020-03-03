using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace more_effective_csharp_2nd_edition
{
    [TestClass]
    public class Item02
    {
        [TestMethod]
        public void TestSerializedInMemory()
        {
            var expect = new item02.Item02 { Name = "Hello" };
            var serializer = new BinaryFormatter();
            var serialized = default(byte[]);
            using (var stream = new MemoryStream())
            {
                serializer.Serialize(stream, expect);
                serialized = stream.ToArray();
            }
            var actual = default(item02.Item02);
            using (var stream = new MemoryStream())
            {
                stream.Write(serialized, 0, serialized.Length);
                stream.Seek(0, SeekOrigin.Begin);
                actual = (item02.Item02)serializer.Deserialize(stream);
            }
            Assert.AreEqual(expect, actual);
        }
    }
}
