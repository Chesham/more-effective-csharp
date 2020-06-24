using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using item32;
using System.Threading.Tasks;
using System.Threading;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class Item32
    {
        [TestMethod()]
        public async Task TestReadStockTicker()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            var target = new item32.Item32();
            var SymbolList = await target.ReadStockTicker(numbers);
            Assert.AreEqual(numbers.Count, SymbolList.Count);

            for(int i = 0; i < numbers.Count; i++)
            {
                Assert.AreEqual(numbers[i], SymbolList[i]);
            }
        }

        [TestMethod()]
        public async Task TestReadStockTicker2()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            var target = new item32.Item32();
            var SymbolList = await target.ReadStockTicker2(numbers);
            Assert.AreEqual(numbers.Count, SymbolList.Count);

            for (int i = 0; i < numbers.Count; i++)
            {
                Assert.AreEqual(numbers[i], SymbolList[i]);
            }
        }

        [TestMethod()]
        public async Task TestReadStockTicker3()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            var target = new item32.Item32();
            var FirstSymbol = await target.ReadStockTicker3(numbers);

            Assert.AreEqual(numbers[4], FirstSymbol);

        }

        [TestMethod()]
        public async Task TestReadStockTicker4()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            var target = new item32.Item32();
            var SymbolList = await target.ReadStockTicker4(numbers);

            Assert.AreEqual(numbers.Count, SymbolList.Count);

            bool IsSame = true;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] != SymbolList[i])
                    IsSame = false;
            }
            Assert.IsTrue(IsSame);
        }

        [TestMethod()]
        public async Task TestReadStockTicker5()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            var target = new item32.Item32();
            var SymbolList = await target.ReadStockTicker5(numbers);

            Assert.AreEqual(numbers.Count, SymbolList.Count);

            bool IsSame = true;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] != SymbolList[i])
                    IsSame = false;
            }
            Assert.IsFalse(IsSame);
        }

        [TestMethod()]
        public async Task TestReadStockTicker6()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
           
            var SymbolList = await taskcompletionsource.ReadStockTicker(numbers);

            Assert.AreEqual(numbers.Count, SymbolList.Count);

            bool IsSame = true;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] != SymbolList[i])
                    IsSame = false;
            }
            Assert.IsFalse(IsSame);
        }
    }
}
