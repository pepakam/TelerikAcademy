using System;

public abstract class Customer
{
    public string Name { get; private set; }

    public Customer(string name)
    {
        this.Name = name;
    }

    public override string ToString()
    {
        return String.Format("{0}", this.Name) ;
    }
}
