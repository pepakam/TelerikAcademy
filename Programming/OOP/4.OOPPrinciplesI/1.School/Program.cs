using System;


class Program
{
    static void Main()
    {

        Console.WriteLine(new School("Music school")
            {
                new Class("Инструментален").AddStudent(
                new Student("Боряна","Иванова"),
                new Student("Мартин","Георгиев")
                ).AddTeacher(
                new Teacher("Пламен","Димитров").AddDiscipline(new Discipline("Цигулка",1,3)),
                new Teacher("Жанет","Кирицова").AddDiscipline(new Discipline("Пиано",10,2),new Discipline("Клавирен съпровод",3,2))),

                new Class("Теоретичен").AddStudent(
                new Student("Миглена","Стефанова"),
                new Student("Стефан","Димитров")
                ).AddTeacher(
                new Teacher("Пламен","Желязков").AddDiscipline(new Discipline("Хармония",1,3)),
                new Teacher("Лиляна","Ангелова").AddDiscipline(new Discipline("Солвеж",25,5),new Discipline("История на музиката")))
            }
        );
    }
}
