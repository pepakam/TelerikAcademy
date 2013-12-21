using System;
using System.Collections.Generic;

public class Discipline : ICommentable, IComparable<Discipline>
{
    private string name;
    private byte nuberOfLectures;
    private byte numberOfExersices;

    public Discipline(string name, byte numberOfLectures=0, byte numberOfExersices=0)
    {
        this.Name = name;
        this.NuberOfLectures = numberOfLectures;
        this.NumberOfExersices = numberOfExersices;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }  

    public byte NuberOfLectures
    {
        get { return this.nuberOfLectures; }
        set { this.nuberOfLectures = value; }
    }   

    public byte NumberOfExersices
    {
        get { return this.numberOfExersices; }
        set { this.numberOfExersices = value; }
    }

    public List<string> Comments { get; set; }

    public void AddComment(string comment)
    {
        this.Comments.Add(comment);
    }

    public int CompareTo(Discipline other)
    {
        return this.Name.CompareTo(other.Name);
    }

    public override string ToString()
    {
        return String.Format("Topic: {0}; Number of Lectures: {1}; Number of Exercises: {2}",
            this.Name, this.NuberOfLectures, this.NumberOfExersices);
    }

}
