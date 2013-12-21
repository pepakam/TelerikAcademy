using System;
using System.Linq;

public class GSMTest
{
    static void Main()
    {
        // GSMTest
        GSM[] test = new GSM[3];
        Display testDisplay = new Display(5, 65000);
        Battery testBattery = new Battery(BatteryType.LiIon, 15, 20);

        GSM firstPhone = new GSM("StarII", "Samsung", 120, "Pesho", testBattery, testDisplay);
        test[0] = firstPhone;

        Display test2Display = new Display(3, 250);
        Battery test2Battery = new Battery(BatteryType.NiCd, 10, 12);
        GSM secondPhone = new GSM("Desire 300", "HTC", 300, "Ivan", test2Battery, test2Display);
        test[1] = secondPhone;

        Display test3Display = new Display(7, 255000);
        Battery test3Battery = new Battery(BatteryType.NiMH, 5, 6);
        GSM thirdPhone = new GSM("Lumbia 625", "Nokia", 650, "Kalina", test3Battery, test3Display);
        test[2] = thirdPhone;

        for (int i = 0; i < test.Length; i++)
        {
            Console.WriteLine(test[i]);
        }

        Console.WriteLine(GSM.Iphone.Model);
        Console.WriteLine(GSM.Iphone.Manufacturer);
        Console.WriteLine(firstPhone.Battery.BatteryModel);
        Console.WriteLine(new string('-',70));
        Console.WriteLine("GSM CALL Histiry Test");
        Console.WriteLine(new string('-', 70));

        //GSM Call History Test
        GSM myPhone = new GSM("IPhone4S", "Apple", 450, "Lili", testBattery, testDisplay);

        myPhone.AddCall(DateTime.Now, "0888665533", 55);
        myPhone.AddCall(DateTime.Now, "0888345678", 512);
        myPhone.AddCall(DateTime.Now, "0888123456", 238);
        myPhone.AddCall(DateTime.Now, "0888987654", 5);
        myPhone.AddCall(DateTime.Now, "0888244668", 105);
        myPhone.AddCall(DateTime.Now, "0888133557", 89);
        myPhone.AddCall(DateTime.Now, "0888435465", 72);
        myPhone.DisplayCallHistory();
        Console.WriteLine(myPhone.CalcPrice(0.37));
        myPhone.RemoveCallByDuration(105);
        myPhone.DisplayCallHistory();
        Console.WriteLine(myPhone.CalcPrice(0.37));
        myPhone.ClearHistory();
        myPhone.DisplayCallHistory();






    }
}
