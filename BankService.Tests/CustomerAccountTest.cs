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

        [Test]
        public void Should_Validate_InvalidCustomerEmail()
        {
            Assert.That(() => this._customer.SetEmail("deverajaycee17.com"), Throws.Exception);
        }

        [Test]
        public void Should_Match_CustomerContactNumber()
        {
            this._customer.SetContactNumber("09399399027");
            Assert.AreEqual("09399399027", this._customer.GetContactNumber());

            this._customer.SetContactNumber("+639399399027");
            Assert.AreEqual("+639399399027", this._customer.GetContactNumber());
        }

        [Test]
        public void Should_Validate_InvalidCustomerContactNumber()
        {
            Assert.That(() => this._customer.SetContactNumber("+87000"), Throws.Exception);
        }
    }
}