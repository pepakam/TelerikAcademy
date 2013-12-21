using System;

class Program
{
    static void TestInterest(Account account, int months)
    {
        for (int i = 1; i <= months; i++)
        {
            Console.WriteLine(account.CalculateInterest(i));
            Console.WriteLine();
        }
    }
    static void Main()
    {
        Console.WriteLine(
            new Bank("Raifaisen Bank").AddAccount(
                new DepositAcc(new CompanyCustomer("Nova Era Ltd"), 150M, .07M).Withdraw(50M).Deposit(200M)
                ,
                new MortgageAcc(new IndividualCustomer("Plamen Petrov"), 0M, .1M).
                Deposit(200M),
                new LoanAcc(new IndividualCustomer("Nikola Димитров"), 1000M, .12M).
                Deposit(50M)));

        Console.WriteLine("Calculate Loan account interest (company customer): ");
        TestInterest(new LoanAcc(
            new CompanyCustomer("Nova Era Ltd"), 100M, .1M
        ),12);

        Console.WriteLine("Calculate Loan account interest (individual customer): ");
        TestInterest(new LoanAcc(
            new IndividualCustomer("Liudmila"), 100M, .1M
        ), 12);

        Console.WriteLine("Calculate Mortgage Account account interest (individual customer): ");
        TestInterest(new MortgageAcc(
            new IndividualCustomer("Petrova"), 100M, .1M
        ), 18);

        Console.WriteLine("Calculate Mortgage Account account interest (company customer): ");
        TestInterest(new MortgageAcc(
            new CompanyCustomer("Nova Era Ltd"), 100M, .1M
        ), 16);

        Console.WriteLine("Calculate Deposit Account account interest (balance<1000): ");
        TestInterest(new DepositAcc(
            new IndividualCustomer("Naidenov"), 100M, .1M
        ), 6);

        Console.WriteLine("Calculate Deposit Account account interest (balance=1000): ");
        TestInterest(new DepositAcc(
            new IndividualCustomer("Naidenov"), 1000M, .1M
        ), 6);

    }

}
