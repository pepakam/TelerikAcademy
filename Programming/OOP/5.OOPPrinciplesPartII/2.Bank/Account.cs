using System.Text;

class Account : IDepositable
{
    public Customer Customer { get; protected set; }
    public decimal Balance { get; protected set; }
    public decimal InterestRate { get; protected set; }

    public Account(Customer customer, decimal balance, decimal interestRate)
    {
        this.Customer = customer;
        this.Balance = balance;
        this.InterestRate = interestRate;
    }

    public virtual decimal CalculateInterest(int months)
    {
        if (months == 0) { return 0; }
        else
        {
            return months * this.InterestRate * this.Balance;
        }
    }

    public Account Deposit(decimal sum)
    {
        this.Balance += sum;
        return this;
    }



    public string ToString(string type)
    {
        StringBuilder info = new StringBuilder();
        info.AppendLine("Type: " + type);
        info.AppendLine("Customer: " + this.Customer);
        info.AppendLine("Balance: " + this.Balance);
        info.AppendLine("Interest rate: " + this.InterestRate);
        return info.ToString();
    }
}
