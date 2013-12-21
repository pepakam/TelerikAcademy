class DepositAcc : Account, IDepositable, IWithdrawable
{
    public DepositAcc(Customer customer, decimal balance, decimal interestRate)
        : base(customer, balance, interestRate)
    {
    }


    public Account Withdraw(decimal sum)
    {
         this.Balance -= sum;
          return this;
    }

    public override decimal CalculateInterest(int months)
    {
        if (this.Balance > 0 && this.Balance < 1000)
        {
            return 0;
        }
        else
        {
            return base.CalculateInterest(months);
        }

    }

    public override string ToString()
    {
        return base.ToString("Deposit Account");
    }
}
