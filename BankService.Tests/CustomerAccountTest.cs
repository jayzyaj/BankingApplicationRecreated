using NUnit.Framework;
using Bank.Services;

namespace Bank.UnitTests.Services
{
    [TestFixture]
    public class CustomerAccountTest
    {
        private Customer _customer;
        [SetUp]
        public void Setup()
        {
            this._customer = new Customer("john", "clifford");
        }

        [Test]
        public void Should_Match_CustomerFullName()
        {
            // Customer customer = new Customer("john", "clifford");
            Assert.AreEqual("John Clifford", this._customer.GetFullName());
        }

        [Test]
        public void Should_Match_CustomerEmail()
        {
            this._customer.SetEmail("deverajaycee17@gmail.com");
            Assert.AreEqual("deverajaycee17@gmail.com", this._customer.GetEmail());
        }
    }
}