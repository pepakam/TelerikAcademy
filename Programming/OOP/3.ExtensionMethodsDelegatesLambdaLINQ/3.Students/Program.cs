using System;

class Program
{
    static void Main()
    {
        Student[] myClass =
        {
            new Student("Mariq", "Ivanova", 17),
            new Student("Nikolet", "Parvanov", 18),
            new Student("Georgi", "Jordanov", 25),
            new Student("Jordan", "Georgiev", 35),
            new Student("Methody", "Qnakiev", 45),
            new Student("Liusi", "Petkova", 50),
            new Student("Kiril", "Ilarionov", 61),
        };
        FilterByName filterByName = new FilterByName(myClass);
        FilterByAge filterByAge = new FilterByAge(myClass);
        OrderNamesLambda orderNamesLambda = new OrderNamesLambda(myClass);
        OrderNamesLINQ orderNamesLinq = new OrderNamesLINQ(myClass);

        Console.WriteLine("-----------------Filter by Name--------------------------");
        filterByName.ShowFilteredClass();

        Console.WriteLine("\n-----------------Filter by Age--------------------------");
        filterByAge.ShowFilteredClass();

        Console.WriteLine("\n-----------------Order with Lambda--------------------------");
        orderNamesLambda.ShowSordedClass();

        Console.WriteLine("\n-----------------Order with LINQ--------------------------");
        orderNamesLinq.ShowSortedClass();
        
    }
}
