using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using item04;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class Item04
    {
        [TestMethod()]
        public void TestStructType()
        {
            List<EmployeebyStruct> Employees = new List<EmployeebyStruct>();
            EmployeebyStruct e = new EmployeebyStruct("CEO", 50000);
            Employees.Add(e);

            var current = Employees.Find(ee => ee.Name == "CEO");
            int Bonus = 10000;
            current.Salary += Bonus;

            var expect = 50000;
            var actual = Employees.Find(ee => ee.Name == "CEO").Salary;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void TestClassType()
        {
            List<EmployeebyClass> Employees = new List<EmployeebyClass>();
            EmployeebyClass e = new EmployeebyClass("CEO", 50000);
            Employees.Add(e);

            var current = Employees.Find(ee => ee.Name == "CEO");
            int Bonus = 10000;
            current.Salary += Bonus;

            var expect = 60000;
            var actual = Employees.Find(ee => ee.Name == "CEO").Salary; 
            Assert.AreEqual(expect, actual);
        }
    }
}
