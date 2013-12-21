using System;

class MortgageAcc : Account, IDepositable
{
    public MortgageAcc(Customer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
    {
    }

    //public Account Deposit(decimal sum)
    //{
    //     this.Balance += sum;
    //    return this;

    //}

    public override decimal CalculateInterest(int months)
    {
        if (this.Customer is CompanyCustomer)
        {
            return base.CalculateInterest(Math.Min(months, 12))/2+base.CalculateInterest(Math.Max(months-12,0));
        }
        else
        {
            return base.CalculateInterest(Math.Max((months - 6),0));
        }       
    }

    public override string ToString()
    {
        return base.ToString("Mortgage Account");
    }
}
