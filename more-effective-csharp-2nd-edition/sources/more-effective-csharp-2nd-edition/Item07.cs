using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using item07;

namespace more_effective_csharp_2nd_edition
{
	[TestClass]
	public class Item07
	{
		[TestMethod]
		public void Test01()
		{
			Tuples01 a = new Tuples01();
			var aPoint = new { x = 5, y = 67 };
			var aPoint2 = new {  y = 67, x = 5 };

			var anotherPoint = a.Transfrom(aPoint, (p) => new { x = p.x * 2, y = p.y * 2 });
			//var anotherPoint2 = a.Transfrom(aPoint3, (p) => (Rise: p.Rise * 2, Run: p.Run * 2));

			Assert.AreEqual(aPoint.x * 2, anotherPoint.x);
			//Assert.AreEqual(aPoint3.Rise * 2, anotherPoint2.Rise);
			Assert.AreNotSame(aPoint.GetType(), aPoint2.GetType());

		}

		[TestMethod]
		public void Test02()
		{
			(int Rise, int Run) aPoint = (5, 67);
			(int Rise1, int Run1) aPoint2 = (5, 67);
			var aPoint3 = (5, 67);

			Assert.AreSame(aPoint.GetType(), aPoint2.GetType());
			Assert.AreSame(aPoint.GetType(), aPoint3.GetType());
		}

		[TestMethod]
		public void Test03()
		{
			Tuples01 a = new Tuples01();
			var aPoint = new { x = 5, y = 67 };
			var bPoint = a.Transfrom(aPoint, (p) => new { x = p.x * 2, y = p.y * 2 });

			Assert.AreSame(aPoint.GetType(), bPoint.GetType());
			Assert.AreEqual(aPoint.x * 2, bPoint.x);
		}
	}
}
