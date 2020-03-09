using System;

namespace item04
{
    public struct EmployeebyStruct
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        public EmployeebyStruct(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }
    }

    public class EmployeebyClass
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        public EmployeebyClass(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }
    }
}
