using System.Threading;

class Program
{
    static void Main()
    {
        Timer obj = new Timer();
        
        TimerDelegate timer = new TimerDelegate(obj.TimerMethod);
        while (true)
        {
            Thread.Sleep(1000);
            timer(0);
        }
    }
}
