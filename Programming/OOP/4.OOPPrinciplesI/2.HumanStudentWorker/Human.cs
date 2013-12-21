using System;
using System.Text;

public abstract class Human
{
    private const string SuffixIndentation = "  ";
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
        set { this.firstName = value; }
    }

   
    public string LastName
    {
        get { return this.lastName; }
        set { this.lastName = value; }
    }

    internal string ToString(string sufix)
    {
        StringBuilder info = new StringBuilder();

        info.AppendFormat("Name: {0} {1}", this.FirstName, this.LastName).AppendLine();       
        info.AppendLine(sufix).Replace(Environment.NewLine, Environment.NewLine + SuffixIndentation);
        return info.TrimEnd().ToString();
    }


}
