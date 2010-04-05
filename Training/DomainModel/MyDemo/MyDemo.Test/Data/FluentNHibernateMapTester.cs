using FluentNHibernate.Testing;
using NUnit.Framework;
using MyDemo.Core;

namespace MyDemo.Test.Data
{
    [TestFixture]
    public class FluentNHibernateMapTester: DataTestBase
    {
        [Test]
        public void CanCorrectlyMapEmployee()
        {
            new PersistenceSpecification<Employee>(Session)
                .CheckProperty(c => c.ID, 1)
                .CheckProperty(c => c.Name, "Jack")
                .CheckProperty(c => c.EmployeeCode, "1001")
                .CheckProperty(c => c.EmployeeType, EmployeeType.Hourly)
                .CheckReference(c => c.PaySystem, new PaySystem())
                .VerifyTheMappings();
        }

        [Test]
        public void CanCorrectlyMapPaySystem()
        {
            new PersistenceSpecification<PaySystem>(Session)
                .CheckProperty(p => p.ID, 1)
                .CheckProperty(p => p.Name, "PaySystem1")
                .CheckProperty(p => p.PaySystemCode, "1")
                .VerifyTheMappings();
        }
    }
}