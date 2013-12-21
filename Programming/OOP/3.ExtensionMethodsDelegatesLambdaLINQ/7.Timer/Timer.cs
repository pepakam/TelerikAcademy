using System;


public delegate void TimerDelegate(int start);
public class Timer
{
    public int Numbers { get; set; }
    public void TimerMethod(int start)
    {
        Console.WriteLine(this.Numbers);
        this.Numbers++;
    }
}
