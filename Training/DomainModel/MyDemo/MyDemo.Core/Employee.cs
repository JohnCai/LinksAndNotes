using System;
using Mavis.Core;

namespace MyDemo.Core
{
    public class Employee: Entity
    {
        public Employee()
        {
            EmployeeType = EmployeeType.Salaried;
            AddRule(new SimpleRule("Name", "Name should not be empty!", () => string.IsNullOrEmpty(Name)));
            AddRule(new SimpleRule("EmployeeCode", "EmployeeCode should not be empty!", () => string.IsNullOrEmpty(EmployeeCode)));
        }

        public string Name { get; set; }

        public string EmployeeCode { get; set; }

        public EmployeeType EmployeeType { get; set; }

        public PaySystem PaySystem { get; set; }
    }

    public enum EmployeeType
    {
        Salaried,
        Hourly
    }
}
