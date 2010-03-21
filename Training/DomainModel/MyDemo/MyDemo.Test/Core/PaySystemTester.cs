using Mavis.Framework.Test;
using MyDemo.Core;
using NUnit.Framework;

namespace MyDemo.Test.Core
{
    [TestFixture]
    public class PaySystemTester
    {
        private PaySystem _paySystemSut;
   
        [SetUp]
        public void SetUp()
        {
            _paySystemSut = new PaySystem();

            _paySystemSut.PaySystemCode.ShouldBeNullOrEmpty();
            _paySystemSut.Name.ShouldBeNullOrEmpty();
            
        }

        [Test]
        public void PaySystemWithoutCodeOrNameIsInvalid()
        {
            _paySystemSut.IsValid.ShouldBeFalse();

            _paySystemSut.Name = "PaySystem1";
            _paySystemSut.PaySystemCode = "1";

            _paySystemSut.IsValid.ShouldBeTrue();
        }
    }
}