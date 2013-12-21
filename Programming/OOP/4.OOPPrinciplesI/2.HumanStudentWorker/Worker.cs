using System.Text;

public class Worker : Human
{
    private const int DefaultWorkDaysPerWeek = 5;
    public decimal WeekSalary { get; private set; }
    public double WorkHoursPerDay { get; private set; }
    public int WorkDaysPerWeek { get; private set; }

    public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay, int workDaysPerWeek = DefaultWorkDaysPerWeek)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
        this.WorkDaysPerWeek = workDaysPerWeek;
    }

    public decimal MoneyPerHour()
    {
        return this.WeekSalary / ((decimal)this.WorkHoursPerDay * this.WorkDaysPerWeek);
    }

    public override string ToString()
    {
       StringBuilder info = new StringBuilder();
        info.AppendLine("Week salary: " + this.WeekSalary);
        info.AppendLine("Work hours per day: " + this.WorkHoursPerDay);
        info.AppendFormat("Money per hour: ${0:0.00}", this.MoneyPerHour());

        return base.ToString(info.ToString());
    }
}
