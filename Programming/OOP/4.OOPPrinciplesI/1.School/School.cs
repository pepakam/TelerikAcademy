using System.Collections;
using System.Collections.Generic;
using System.Text;

public class School : IEnumerable
{
    private readonly SortedSet<Class> classes = new SortedSet<Class>();

    public School(string name)
    {
        this.Name = name;
    }

    public string Name { get; private set; }

    public School AddClass(params Class[] classes)
    {
        foreach (var _class in classes)
        {
            this.classes.Add(_class);
        }
        return this;
    }

    public void Add(Class _class)
    {
        this.AddClass(_class);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.classes.GetEnumerator();
    }

    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        info.AppendLine("School: " + this.Name);
        info.AppendLine(this.classes.ToString<Class>());

        return info.ToString();
    }
}
