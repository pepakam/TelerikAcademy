//A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number. Write a program that reads the information about a company and its manager and prints them on the console.

using System;

class CompanyInfo
{
    static void Main()
    {
        //Company info
        Console.Write("Enter company name: ");
        string CompanyName = Console.ReadLine();

        Console.Write("Enter address: ");
        string adress = Console.ReadLine();

        Console.Write("Enter phone number: ");
        int phone = int.Parse(Console.ReadLine());

        Console.Write("Enter Fax number: ");
        int fax = int.Parse(Console.ReadLine());

        Console.Write("Enter web site: ");
        string web = Console.ReadLine();

        //Menager info
        Console.Write("Enter Menager's first name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter Menager's last name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter age: ");
        byte age = byte.Parse(Console.ReadLine());

        Console.Write("Enter Menager's phone number: ");
        int MenagerPhone = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("       Company info\n");
        Console.WriteLine("{0,-15} {1, -15}", "Company:", CompanyName);
        Console.WriteLine("{0,-15} {1, -15}", "Address:", adress);
        Console.WriteLine("{0,-15} {1, -15}", "Phone:", phone);
        Console.WriteLine("{0,-15} {1, -15}", "Fax:", fax);
        Console.WriteLine("{0,-15} {1, -15}", "Web site:", web);
        Console.WriteLine();
        Console.WriteLine("       Menager\n");
        Console.WriteLine("{0,-15} {1, -15}", "Menager:", firstName + " " + lastName);
        Console.WriteLine("{0,-15} {1, -15}", "Age:", age);
        Console.WriteLine("{0,-15} {1, -15}", "Phone:", MenagerPhone);
    }
}

