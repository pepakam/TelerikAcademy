using System;

class Program
{
    static void Main()
    {
        Person[] persons =
        {
            new Person("Иван Петров"), 
            new Person("Лили Иванова", 74), 
            new Person("Силвия Руменова", 23),
            new Person("Петър Григоров"),
            new Person("Росена Миленова", 35)
        };

        foreach (var person in persons)
        {
            Console.WriteLine(person);
        }    

    }
}
