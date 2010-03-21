using Mavis.Framework.Test;
using MyDemo.Core;
using NUnit.Framework;

namespace MyDemo.Test.Core
{
    [TestFixture]
    public class EmployeeTester
    {
        private Employee _employeeSut;

        [SetUp]
        public void SetUp()
        {
            _employeeSut = new Employee();
        }

        [Test]
        public void EmployeeIsInvalidWhenNameIsEmpty()
        {
            _employeeSut.Name.ShouldBeNullOrEmpty();
            _employeeSut.IsValid.ShouldBeFalse();
        }

        [Test]
        public void EmployeeIsInvalidWhenCodeIsEmpty()
        {
            _employeeSut.EmployeeCode.ShouldBeNullOrEmpty();
            _employeeSut.IsValid.ShouldBeFalse();
        }

        [Test]
        public void EmployeeIsValidWhenItHasCodeAndName()
        {
            _employeeSut.Name = "Jack";
            _employeeSut.EmployeeCode = "1001";

            _employeeSut.IsValid.ShouldBeTrue();
        }

        [Test]
        public void EmployeeIsSalariedByDefault()
        {
            _employeeSut.EmployeeType = EmployeeType.Salaried;
        }

        [Test]
        public void CanChangeEmployeeType()
        {
            _employeeSut.EmployeeType = EmployeeType.Hourly;
            _employeeSut.EmployeeType.ShouldEqual(EmployeeType.Hourly);
        }

        [Test]
        public void PaySystemShouldBeNullForANewEmployee()
        {
            _employeeSut.PaySystem.ShouldBeNull();
        }
    }
}