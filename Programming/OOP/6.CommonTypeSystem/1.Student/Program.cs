using System;

class Program
{
    static void Main()
    {
        Student firstStudent = new Student("Misho","Aleksandrov","Petrov","8345677890","София, ул.\"Nezabravka\" 21","0888123456","az@az.com",null,Specialties.Spec2,Universities.Uni3,Faculties.Fac2);
        Student secondStudent = new Student("Misho", "Aleksandrov", "Petrov", "8345677892"); //SSN differs from SSN of the firstStudent
        Student thirdStudent = new Student("Nasko", "Aleksandrov", "Petrov", "5600256921");
        Student clonedStudent = (Student) firstStudent.Clone();

        Console.WriteLine("------------------tests---------------------");
        Console.WriteLine( firstStudent.CompareTo(clonedStudent));
        Console.WriteLine(firstStudent.CompareTo(secondStudent));
        Console.WriteLine(firstStudent.Equals(thirdStudent));
        Console.WriteLine(firstStudent.Equals(clonedStudent));
        Console.WriteLine(firstStudent==clonedStudent);
        Console.WriteLine(firstStudent != clonedStudent);
        Console.WriteLine("------------------ first student---------------------");
        Console.WriteLine(firstStudent);
        Console.WriteLine("------------------ second student---------------------");
        Console.WriteLine(secondStudent);
        Console.WriteLine("------------------ third student---------------------");
        Console.WriteLine(thirdStudent);
        Console.WriteLine("------------------ cloned student---------------------");
        Console.WriteLine(clonedStudent);
    }
}
