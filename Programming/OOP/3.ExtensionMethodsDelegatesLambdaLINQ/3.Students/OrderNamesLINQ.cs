using System;
using System.Linq;

partial class OrderNamesLINQ
{
    private Student[] presortedClass;

    public OrderNamesLINQ(Student[] myClass)
    {
        this.PresortedClass = myClass;
    }

    public Student[] PresortedClass
    {
        set
        {
            this.presortedClass = value;
        }
    }

    public void ShowSortedClass()
    {
        var sort =
            from student in this.presortedClass
            orderby student.FirstName descending,
                student.LastName descending
            select student;

        foreach (Student student in sort)
        {
            Console.WriteLine(  "{0} {1}", student.FirstName, student.LastName);
        }

    }

}
