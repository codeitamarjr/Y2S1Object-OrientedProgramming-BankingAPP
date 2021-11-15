using System;
using System.IO;
using System.Text;
namespace Y2S1ObjectOrientedProgrammingBankingAPP.models
{
    public class Customer
    {
        public static void System()
        {

//1.To login, a customer must enter their name, account code AND a pin number for their account
//2.A customer can retrieve the transaction history for their specified account.
//3.They can add and subtract money to either their savings account or current account.
//4.They cannot have negative balances
        }
        public static void createCustomer(String accountNumber)
        {
            StreamWriter sw = new StreamWriter("customers.txt");
            sw.WriteLine(accountNumber);
            Console.WriteLine("Account added to the customers database");
            sw.Close();
        }
    }
}
