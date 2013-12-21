using System;

public class Human : IComparable<Human>
{
    private string firstName;
    private string lastName;
    

    public Human()
    {
            
    }
    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        
    }   

    public string FirstName
    {
        get { return this.firstName; }
       private set { this.firstName = value; }
    }

    public string LastName
    {
        get { return this.lastName; }
       private set { this.lastName = value; }
    }

    public int CompareTo(Human other)
    {
        return this.FirstName.CompareTo(other.FirstName);
    }
    public override string ToString()
    {
        return String.Format("{0} {1}", this.FirstName, this.LastName);
    }
}
