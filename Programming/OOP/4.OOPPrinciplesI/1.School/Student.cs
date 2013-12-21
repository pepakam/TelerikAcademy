using System.Collections.Generic;

public class Student : Human, ICommentable
{
    private byte uniqueClassNumber;
    /*
    public Student(string firstName, string lastName, byte uniqueClassNumber) : base (firstName, lastName)
    {
        this.UniqueClassNumber = uniqueClassNumber;
    }
    */
    public Student(string firstName, string lastName)
        : base(firstName, lastName)
    {

    }

    public byte UniqueClassNumber
    {
        get { return this.uniqueClassNumber; }
        private set { this.uniqueClassNumber = value; }
    }

    public List<string> Comments { get; set; }

    public void AddComment(string comment)
    {
        this.Comments.Add(comment);
    }
}
