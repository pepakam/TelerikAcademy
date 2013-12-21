﻿public class Student : Human
{
    private int grade;

    public Student(string firstName, string lastName) : base(firstName,lastName)
    {
            
    }

    public Student(string firstName, string lastName, int grade)
        : base(firstName, lastName)
    {
        this.Grade = grade;
    }

    public int Grade
    {
        get { return this.grade; }
        set { this.grade = value; }
    }

    public override string ToString()
    {
        return base.ToString("Grade: " + this.Grade);
    }
}
