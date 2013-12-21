using System;
using System.Linq;

partial class FilterByName
{
    private Student[] prefilteredClass;

    public FilterByName(Student[] myClass)
    {
        this.prefilteredClass = myClass;
    }
    
    public Student[] PrefilteredClass
    {

        set
        {
            this.prefilteredClass = value;
        }
    }

    public void ShowFilteredClass()
    {
        var filteredClass =
            from student in this.prefilteredClass
            where student.FirstName.CompareTo(student.LastName) == -1
            select student;

        foreach (var student in filteredClass)
        {
            Console.WriteLine(  "{0} {1}", student.FirstName, student.LastName);
        }
    }
    
}
