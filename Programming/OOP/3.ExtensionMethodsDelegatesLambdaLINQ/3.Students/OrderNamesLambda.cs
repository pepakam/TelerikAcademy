using System;
using System.Linq;

class OrderNamesLambda
{
    private Student[] presortedClass;

    public OrderNamesLambda(Student[] myClass)
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

    public void ShowSordedClass()
    {
        var sortedClass = this.presortedClass.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);

        foreach (Student student in sortedClass)
        {
            Console.WriteLine(  "{0} {1}", student.FirstName, student.LastName);
        }
    }
}