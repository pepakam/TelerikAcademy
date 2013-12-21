using System;

class LoanAcc : Account,IDepositable
{
    public LoanAcc(Customer customer, decimal balance, decimal interestRate)
        : base(customer, balance, interestRate)
    {
    }

    //public Account Deposit(decimal sum)
    //{
    //     this.Balance += sum;
    //    return this;

    //}

    public override decimal CalculateInterest(int months)
    {
        if (this.Customer is IndividualCustomer)
        {
            return base.CalculateInterest(Math.Max(months - 3 , 0));
        }
        else
        {
            return base.CalculateInterest(Math.Max(months - 2, 0));
        }
    }

    public override string ToString()
    {
        return base.ToString("Loan Account");
    }
}
