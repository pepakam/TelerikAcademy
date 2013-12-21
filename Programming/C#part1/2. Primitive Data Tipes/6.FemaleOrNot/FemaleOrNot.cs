//Declare a boolean variable called isFemale and assign an appropriate value corresponding to your gender.
using System;

class FemaleOrNot
{
    static void Main()
    {
        string myGender = "Female";
        bool isFemale;
        if (myGender == "Female")
        {
            isFemale = true;
        }
        else
        {
            isFemale = false;
        }
        Console.WriteLine("My genter is female -> {0}", isFemale);
    }
}
