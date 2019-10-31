using System;
using Bank.Services;

namespace BankService
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("john", "clifford");
            Console.WriteLine(customer.GetFullName());
        }
    }
}
