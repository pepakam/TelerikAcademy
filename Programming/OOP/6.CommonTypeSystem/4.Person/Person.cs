using System.Text;

class Person
{
    private string name;
    private int? age;

    public Person(string name, int? age=null)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int? Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendFormat("Name: {0,-20}", this.Name);

        if (this.Age != null)
        {
            sb.Append(" | Age: " + this.Age);
        }
        else
        {
            sb.Append(" | Age: - ");
        }
        return sb.ToString();
    }
}