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
			var aPoint = new { x = 5, y = 67 };
			var aPoint2 = new {  y = 67, x = 5 };

			Assert.AreNotSame(aPoint.GetType(), aPoint2.GetType());
		}

		[TestMethod]
		public void Test02()
		{
			CTest a = new CTest();
			var aPoint2 = (x : 5, y : 67);
			var aPoint3 = (50, 6);
		
			Assert.AreSame(a.aPoint.GetType(), aPoint2.GetType());
			Assert.AreSame(a.aPoint.GetType(), aPoint3.GetType());
			Assert.AreEqual(a.aPoint.Run, aPoint2.y);
			Assert.AreNotEqual(a.aPoint.Run, aPoint3.Item2);
		}
	}
}
