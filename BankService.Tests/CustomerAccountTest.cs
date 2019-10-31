using NUnit.Framework;
using Bank.Services;

namespace Bank.UnitTests.Services
{
    [TestFixture]
    public class CustomerAccountTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Should_Match_CustomerFullName()
        {
            Customer customer = new Customer("john", "clifford");
            Assert.AreEqual("John Clifford", customer.GetFullName());
        }
    }
}