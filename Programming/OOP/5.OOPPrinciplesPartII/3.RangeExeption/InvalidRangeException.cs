using System;

public class InvalidRangeException<T> :Exception
{
    private const string exceptonMessage = "Out of the range!";
    private T start;
    private T end;

    public T Start
    {
        get { return this.start; }
        set { this.start = value; }
    } 

    public T End
    {
        get { return this.end; }
        set { this.end = value; }
    }

    public InvalidRangeException(T start, T end, Exception innerExseption =null): base(exceptonMessage, innerExseption)
    {
        this.Start = start;
        this.End = end;
    }
}
