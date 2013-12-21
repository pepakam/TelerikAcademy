using System;
using System.Linq;

partial class FilterByAge
{
    private Student[] prefilteredClass;

    public FilterByAge(Student[] myClass)
    {
        this.PrefilteredClass = myClass;
    }

    public Student[] PrefilteredClass
    {
        get
        {
            return this.prefilteredClass;
        }
        set
        {
            this.prefilteredClass = value;
        }
    }

    public void ShowFilteredClass()
    {
        var filtered =
            from student in this.prefilteredClass
            where student.Age >= 18 && student.Age <= 24
            select student;

        foreach (Student student in filtered)
        {
            Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Age);
        }

    }
}
