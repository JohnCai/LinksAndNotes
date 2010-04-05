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

        private string _name;
        public virtual string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private string _employeeCode;
        public virtual string EmployeeCode
        {
            get { return _employeeCode; }
            set
            {
                _employeeCode = value;
                NotifyPropertyChanged("EmployeeCode");
            }
        }

        public virtual EmployeeType EmployeeType { get; set; }

        public virtual PaySystem PaySystem { get; set; }
    }

    public enum EmployeeType
    {
        Salaried,
        Hourly
    }
}
