# Exam - Digital Solutions Developer

The Bank Account Using Object-Oriented Principles, simulate a basic current account.

### A bank account have the following functionality

* Open Account
* Close Account 
* Display Balance
* Deposit Funds
* Withdraw Funds
* Apply agreed overdraft (Where an account is allowed to go into a pre-arranged negative balance) 

### Getting Started

1.) I used [dotnet CLI](https://dotnet.microsoft.com/download) for Mac for creating the solution and the projects. **BankService** is the main production or implementation code and **BankService.Tests** is the test code to test the implementation code if it meets the expected behaviour base on the requirements.

2.) The **BankService.Tests** uses [NUnit](https://nunit.org/) as it's testing tool

### Running the Projects

1.) Navigate to the project directory after cloning the project:

`cd BankApplicationRecreated`

2.) Navigate to the solution directory and run this command below to test all the expected behaviour:

`dotnet test`

3.) If you want to see a specific output you can edit the **Program.cs** file in *BankService* Project:

`cd BankService`

and run

`dotnet run`

> Note:
> You're able to tweak some tests (for example, changing the inputs to analyse the outcome of said changes) without touching the implementation code.

### Author

This documentation is prepared by [John Clifford de Vera](https://github.com/jayzyaj).