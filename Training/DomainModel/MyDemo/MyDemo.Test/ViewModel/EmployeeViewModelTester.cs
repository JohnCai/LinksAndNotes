using System;
using Mavis.Framework.Test;
using Mavis.MVVM;
using MyDemo.Core.DataInterfaces;
using MyDemo.Test.Helper;
using MyDemo.ViewModel;
using NUnit.Framework;
using Rhino.Mocks;
using MyDemo.Core;

namespace MyDemo.Test.ViewModel
{
    [TestFixture]
    public class EmployeeViewModelTester
    {
        private EmployeeViewModel _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new EmployeeViewModel(CreateStubRepository());
        }

        private IEmployeeRepository CreateStubRepository()
        {
            IEmployeeRepository employeeRepositoryStub = MockRepository.GenerateStub<IEmployeeRepository>();

            employeeRepositoryStub.Expect(x => x.SaveOrUpdate(null)).IgnoreArguments().Return(CreateStubEmployee());

            return employeeRepositoryStub;
        }

        private Employee CreateStubEmployee()
        {
            Employee employee = new Employee
                                    {
                                        EmployeeCode = "1001",
                                        Name = "Jack"
                                    };
            EntityIdSetter.SetIdOf(employee, 1);

            return employee;
        }

        [Test]
        public void ShouldBeInViewOnlyModeByDefault()
        {
            _sut.ViewMode.ShouldEqual(ViewMode.ViewOnlyMode);
        }

        [Test]
        public void ShouldBeInAddModeAfterExecutingAddCommand()
        {
            _sut.AddCommand.Execute(null);

            _sut.ViewMode.ShouldEqual(ViewMode.AddMode);
        }

        [Test]
        public void ShouldBeInEditModeAfterExecutingEditCommand()
        {
            _sut.EditCommand.Execute(null);

            _sut.ViewMode.ShouldEqual(ViewMode.EditMode);
        }

        [Test]
        public void ShouldBeInViewOnlyModeAfterExecutingSaveCommand()
        {
            _sut.SaveCommand.Execute(null);

            _sut.ViewMode.ShouldEqual(ViewMode.ViewOnlyMode);
        }

        [Test]
        public void CanCreateEmployee()
        {
            _sut.AddCommand.Execute(null);

            _sut.CurrentEmployee.Name = "Jack";
            _sut.CurrentEmployee.EmployeeCode = "1001";

            _sut.SaveCommand.Execute(null);

            _sut.CurrentEmployee.ShouldNotBeNull();
            _sut.CurrentEmployee.Name.ShouldEqual("Jack");
            _sut.CurrentEmployee.EmployeeCode.ShouldEqual("1001");
            _sut.CurrentEmployee.ID.ShouldBeGreaterThan(0);
        }
    }
}
