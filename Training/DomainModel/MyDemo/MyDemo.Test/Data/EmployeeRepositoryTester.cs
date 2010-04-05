using System;
using Mavis.Framework.Test;
using MyDemo.Data.Repositories;
using NUnit.Framework;
using MyDemo.Core.DataInterfaces;
using MyDemo.Core;

namespace MyDemo.Test.Data
{
    [TestFixture]
    public class EmployeeRepositoryTester: DataTestBase
    {
        [Test]
        public void CanGetAll()
        {
            var allEmployees = _employeeRepositorySut.GetAll();

            allEmployees.Count.ShouldEqual(2);
        }

        [Test]
        public void CanGetOne()
        {
            var employee = _employeeRepositorySut.Get(2);

            employee.EmployeeCode.ShouldEqual("1002");
            employee.Name.ShouldEqual("John");
        }

        protected override void LoadTestData()
        {
            CreatePersistedEmployee("1001", "Jack");
            CreatePersistedEmployee("1002", "John");
            FlushAndClearSession();
        }

        private void CreatePersistedEmployee(string code, string name)
        {
            Employee employee = new Employee {EmployeeCode = code, Name = name};
            _employeeRepositorySut.SaveOrUpdate(employee);
        }

        private IEmployeeRepository _employeeRepositorySut = new EmployeeRepository();
    }
}