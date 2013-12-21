using System;
using System.Collections.Generic;
using System.Text;

public class Class : ICommentable, IComparable<Class>
{
    private readonly SortedSet<Teacher> teachers = new SortedSet<Teacher>();
    private  readonly SortedSet<Student> students = new SortedSet<Student>();
    private string uniqueTextId;

    public Class(string Id)
    {
        this.UniqueTextId = Id;
    }


    public string UniqueTextId
    {
        get { return this.uniqueTextId; }
        set { this.uniqueTextId = value; }
    }

    public List<string> Comments { get; set; }

    public Class AddTeacher(params Teacher[] teachers)
    {
        foreach (Teacher teacher in teachers)
            this.teachers.Add(teacher);

        return this;
    }

    public Class AddStudent(params Student[] students)
    {
        foreach (Student student in students)
            this.students.Add(student);

        return this;
    }

    public void AddComment(string comment)
    {
        this.Comments.Add(comment);
    }

    public int CompareTo(Class other)
    {
        return this.UniqueTextId.CompareTo(other.UniqueTextId);
    }
   
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine("Class name: " + this.UniqueTextId);
        
            info.AppendLine("Teachers: ");
            info.AppendLine(this.teachers.ToString<Teacher>());

            info.AppendLine("Students: ");
            info.AppendLine(this.students.ToString<Student>());

            return info.ToString();
        }
    
}
