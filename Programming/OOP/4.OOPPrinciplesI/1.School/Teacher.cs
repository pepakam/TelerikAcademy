using System.Collections.Generic;
using System.Text;

public class Teacher : Human, ICommentable
{
    private readonly SortedSet<Discipline> disciplines = new SortedSet<Discipline>();

    public Teacher(string firstName, string lastName)
        : base(firstName, lastName)
    {

    }
    public List<string> Comments { get; set; }

    public Teacher AddDiscipline(params Discipline[] disciplines)
    {
        foreach (var discipline in disciplines)
        {
            this.disciplines.Add(discipline);
        }
        return this;
    }

    public void AddComment(string comment)
    {
        this.Comments.Add(comment);
    }

    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        info.AppendLine(base.ToString());

        info.AppendLine(this.disciplines.ToString<Discipline>());

        return info.ToString();
    }
}
