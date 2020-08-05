using Microsoft.VisualStudio.TestTools.UnitTesting;
using item43;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class Item43
    {
        [TestMethod()]
        public void TestAdd()
        {
            dynamic answer = item43.Item43.Add(5, 5);
            Assert.AreEqual(10, answer);
            answer = item43.Item43.Add(5.5, 7.3);
            Assert.AreEqual(12.8, answer);
            answer = item43.Item43.Add(5, 12.3);
            Assert.AreEqual(17.3, answer);
            answer = item43.Item43.Add("Here is ", "a label");
            Assert.AreEqual("Here is a label", answer);
            answer = item43.Item43.Add(DateTime.Now, TimeSpan.FromDays(1));
            Assert.AreEqual(DateTime.Now.AddDays(1).Date, ((DateTime)answer).Date);
            Assert.AreEqual(DateTime.Now.AddDays(1).ToString(), System.Convert.ToString(answer));
        }

        [TestMethod()]
        public void TestAddT()
        {
            var lambdaAnswer = item43.Item43.AddT(5, 5, (a, b) => a + b);
            Assert.AreEqual(10, lambdaAnswer);
            var lambdaAnswer2 = item43.Item43.AddT(5.5, 7.3, (a, b) => a + b);
            Assert.AreEqual(12.8, lambdaAnswer2);
            var lambdaAnswer3 = item43.Item43.AddT(5, 12.3, (a, b) => a + b);
            Assert.AreEqual(17.3, lambdaAnswer3);
            var lambdaAnswer4 = item43.Item43.AddT("Here is ", "a label", (a, b) => a + b);
            Assert.AreEqual("Here is a label", lambdaAnswer4);
            var now = DateTime.Now;
            var tomorrow = item43.Item43.AddT(now, TimeSpan.FromDays(1), (a, b) => a.Add(b));
            Assert.AreEqual(now.AddDays(1), tomorrow);
            var finalLabel = item43.Item43.AddT("something", 3, (a, b) => a + b.ToString());
            Assert.AreEqual("something3", finalLabel);
        }

        [TestMethod()]
        public void TestAddExpression()
        {
            var sum = item43.Item43.AddExpression(5, 7);
            Assert.AreEqual(12, sum);
            /*var now = DateTime.Now;
            var tomorrow = item43.Item43.AddExpression(now, TimeSpan.FromDays(1));
            Assert.AreEqual(now.AddDays(1), tomorrow);*/
        }

        [TestMethod()]
        public void TestAddExpression2()
        {
            var now = DateTime.Now;
            var tomorrow = item43.Item43.AddExpression2<DateTime, TimeSpan, DateTime>(now, TimeSpan.FromDays(1));
            Assert.AreEqual(now.AddDays(1), tomorrow);
            //throw in  Expression.Add
            Assert.ThrowsException<InvalidOperationException>(() => item43.Item43.AddExpression2<double, int, double>(5.3, 12));
            Assert.ThrowsException<InvalidOperationException>(() => item43.Item43.AddExpression2<string, int,string>("Hi", 12));
            
            foreach (var i in Enumerable.Range(0, 300))
                tomorrow = item43.Item43.AddExpression2<DateTime, TimeSpan, DateTime>(now, TimeSpan.FromDays(1));
        }

        [TestMethod()]
        public void TestBinaryOperatorAdd()
        {
            var sum = item43.BinaryOperator<int, int, int>.Add(5, 7);
            Assert.AreEqual(12, sum);
            Assert.ThrowsException<InvalidOperationException>(() => item43.BinaryOperator<int, double, double>.Add(5, 12.3));
        }

        [TestMethod()]
        public void TestAddExpressionWithConversion()
        {
            var sum = item43.BinaryOperator<int, int, int>.AddExpressionWithConversion(5, 7);
            Assert.AreEqual(12, sum);
            var sum2 = item43.BinaryOperator<int, double, double>.AddExpressionWithConversion(5, 12.3);
            Assert.AreEqual(17.3, sum2);

            var now = DateTime.Now;
            Assert.ThrowsException<InvalidOperationException>(
                () => item43.BinaryOperator<DateTime, TimeSpan, DateTime>.AddExpressionWithConversion(now, TimeSpan.FromDays(1)));
        }
    }
}