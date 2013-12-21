//A marketing firm wants to keep record of its employees. Each record would have the following characteristics – first name, family name, age, gender (m or f), ID number, unique employee number (27560000 to 27569999). Declare the variables needed to keep the information for a single employee using appropriate data types and descriptive names.

using System;

class EmployeeInfo
{
    static void Main()
    {
        string firstName = "John";
        string familyName = "Smith";
        byte age = 35;
        char gender = 'M';
        ushort idNumber = 1224;
        uint uniqueEmployeeNumber = 27569999U;
        Console.WriteLine("Name: {0} {1}\nAge: {2}\nGender: {3}\nID number: {4}\nUnique Employee Number: {5}", firstName, familyName, age, gender, idNumber, uniqueEmployeeNumber);
    }
}
