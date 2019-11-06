using Bank.Services;
using NUnit.Framework;


namespace Bank.UnitTests.Services
{
    [TestFixture]
    public class BankAccountWithdrawalTransactionTest
    {
        private Customer _customer;

        [SetUp]
        public void Setup()
        {
            this._customer = new Customer("Chae", "Young");
            this._customer.SetContactNumber("+639399399027");
            this._customer.SetEmail("deverajaycee17@gmail.com");
            this._customer.OpenBankAccount("savings", "Paseo De Roxas", 10000.00m);
        }

        [Test]
        public void Should_Not_Allow_Customer_ToWithdraw_LessThan_MinimumRequired_Amount()
        {
            Assert.That(() => this._customer.WithdrawToAccount("1234", 99.99m), Throws.Exception);
        }

        [Test]
        public void Should_Not_Allow_Customer_ToWithdraw_Amount_That_Is_Not_Divisble_ByHundreds()
        {
            Assert.That(() => this._customer.WithdrawToAccount("1234", 100.99m), Throws.Exception);
            Assert.That(() => this._customer.WithdrawToAccount("1234", 100.01m), Throws.Exception);
        }

        [Test]
        public void Should_Not_Allow_Customer_ToWithdraw_If_Pin_IsIncorrect()
        {
            Assert.That(() => this._customer.WithdrawToAccount("2332", 400.00m), Throws.Exception);
        }

        [Test]
        public void Should_Not_Allow_Customer_ToWithdraw_MoreThanRemainingBalance()
        {
            Assert.That(() => this._customer.WithdrawToAccount("1234", 10000.01m), Throws.Exception);
        }

        [Test]
        public void Should_Match_WithdrawAmount()
        {
            Assert.That(this._customer.WithdrawToAccount("1234", 1500.00m), Is.EqualTo("1500.00"));
        }
    }
}