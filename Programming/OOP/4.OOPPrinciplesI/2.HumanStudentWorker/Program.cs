using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student("Иван", "Георгиев", 8),
            new Student("Петко", "Леонов", 6),
            new Student("Гергана", "Райкова", 5),
            new Student("Лили", "Иванова", 12),
            new Student("Жоро", "Георгиев", 7),
            new Student("Мирослав", "Асенов", 9),
            new Student("Ачо", "Методиев", 10),
            new Student("Ани", "Радославова", 11),
            new Student("Ненко", "Ненков", 20),
            new Student("Петко", "Студенов", 32)
        };

        List<Worker> workers = new List<Worker>()
        {
            new Worker("Людмила", "Каменова", 15.5m, 6.5d),
            new Worker("Мила", "Георгиева", 80m, 4d),
            new Worker("Петко", "Каменов", 70m, 8),
            new Worker("Таня", "Ванкова", 120m, 8, 4),
            new Worker("Женя", "Димитрова", 150m, 8),
            new Worker("Анастасия", "Петрова", 75m, 5.5),
            new Worker("Мартин", "Борисов", 65.6m, 6),
            new Worker("Гергана", "Димитрова", 25m,8),
            new Worker("Радослав", "Методиев", 34.25m, 10),
            new Worker("Генади", "Николов", 70m, 9)
        };
        Console.WriteLine("--------------Students, sorted by grade-----------------------");
        var sortedStudents =
            from s in students
            orderby s.Grade
            select s;
        sortedStudents.Print();

        Console.WriteLine("---------Workers, sorted by money per hour in descending order------------");
        var sortedWorkers =
             from w in workers
             orderby w.MoneyPerHour() descending 
             select w;
        sortedWorkers.Print();

        Console.WriteLine("---------Students and workers, sorted by first name and last name---------");

       List<Human> humans = new List<Human>();
        humans.AddRange(students);
        humans.AddRange(workers);

         var sortedHumans =
             from h in humans
             orderby h.FirstName, h.LastName 
             select h;

         //  variant 2

        //var sortedHumans =
        //    humans.OrderBy(h => h.FirstName)
        //        .ThenBy(h => h.LastName);
        
        sortedHumans.Print();

    }


}
