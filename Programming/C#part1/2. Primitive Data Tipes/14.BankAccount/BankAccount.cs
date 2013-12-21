//A bank account has a holder name (first name, middle name and last name), available amount of money (balance), bank name, IBAN, BIC code and 3 credit card numbers associated with the account. Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names.

using System;

class BankAccount
{
    static void Main()
    {
        //-----HOLDER------

        string firstName = "Иван";
        string middleName = "Георгиев";
        string lastName = "Иванов";
        string holderName = firstName + " " + middleName + " " + lastName;

        //-----BALANCE------

        decimal balance = 32400.47m;
        //-----BANK INFO------
        string bankName = "ПРОКРЕДИТ БАНК";

        //-----IBAN------

        string countryCode = "BG";
        byte controlNumber = 37;
        string identificationOfBank = "PRCB";
        ushort identificationOfBau = 9230;
        byte accountType = 10;
        int account = 2680078;
        string strAccount = account.ToString().PadLeft(8, '0');
        //string strAccount = string.Format("{0:00000000}", account);
        object IBAN = countryCode + controlNumber.ToString() +
            identificationOfBank + identificationOfBau.ToString() +
            accountType.ToString() + strAccount;

        //-----BIC------

        string locationCodeOfBic = "SF";
        string BIC = identificationOfBank + countryCode + locationCodeOfBic;

        //-----CREDIT CARDS------

        string creditCardType1 = "Visa";
        string creditCardType2 = "American Express";
        string creditCardType3 = "Mastercard";
        ulong CardNumber1 = 123456789012345U;
        ulong CardNumber2 = 123456789012345U;
        ulong CardNumber3 = 123456789012345U;
        string creditCardNumber1 = CreditCardFormat(creditCardType1, CardNumber1);
        string creditCardNumber2 = CreditCardFormat(creditCardType2, CardNumber2);
        string creditCardNumber3 = CreditCardFormat(creditCardType3, CardNumber3);

        //-----WRITE INFO------

        Console.WriteLine("Holder name: " + holderName);
        Console.WriteLine("Balance: {0:C}", balance);
        Console.WriteLine("Bank: " + bankName);
        Console.WriteLine("IBAN: " + IBAN);
        Console.WriteLine("BIC: " + BIC);
        Console.WriteLine("Credit Card Number: " + creditCardNumber1);
        Console.WriteLine("Credit Card Number: " + creditCardNumber2);
        Console.WriteLine("Credit Card Number: " + creditCardNumber3);
    }

    //-----Credit Card Format------

    private static string CreditCardFormat(string cardType, ulong cardNumber)
    {
        string creditCardNumber = "";

        switch (cardType)
        {
            case "Visa":
                creditCardNumber = string.Format("{0:4000 0000 0000 0000}", cardNumber);
                break;
            case "American Express":
                creditCardNumber = string.Format("{0:3000 0000000 00000}", cardNumber);
                break;
            case "Mastercard":
                creditCardNumber = string.Format("{0:5000 0000 0000 0000}", cardNumber);
                break;
            default:
                creditCardNumber = string.Format("{0:4000 0000 0000 0000}", cardNumber);
                break;
        }
        return creditCardNumber;
    }
}