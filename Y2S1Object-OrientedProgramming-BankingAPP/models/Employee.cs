//23952
using System;
using System.IO;
namespace Y2S1ObjectOrientedProgrammingBankingAPP.models
{
    public class Employee
    {
        public static void System()
        {
            Console.WriteLine("==================\nAs a bank employee you can:" +
                "\n(1)Create Customers" +
                "\n(2)Delete customers" +
                "\n(3)Lodge Current Account" +
                "\n(4)Withdraw Current Account" +
                "\n(5)List Customers Personal DATA" +
                "\n(6)List Customers Balances" +
                "\n(7)Account Statements" +
                "\n(0)Go back to the Main Menu");
            int userOption = Convert.ToInt32(Console.ReadLine());
            if (userOption == 1)
            {
                Create();
            }
            if (userOption == 2)
            {
                Delete();
            }
            if (userOption == 3)
            {
                Console.WriteLine("==================\nWelcome to the Lodge Panel");
                Console.WriteLine("What is the account number you want to lodge?");
                String accountNumber = Console.ReadLine();
                Console.WriteLine("What is the ammount you want to lodge?");
                double ammount = Convert.ToDouble(Console.ReadLine());
                Operations.Operation(accountNumber,ammount,"Lodgement","current");
                System();
            }
            if (userOption == 4)
            {
                Console.WriteLine("==================\nWelcome to the Withdraw Panel");
                Console.WriteLine("What is the account number you want to withdraw?");
                String accountNumber = Console.ReadLine();
                Console.WriteLine("What is the ammount you want to withdraw?");
                double ammount = Convert.ToDouble(Console.ReadLine());
                if ( ammount > Current.getCurrent(accountNumber))
                {
                    Console.WriteLine("Insuficiente Account Balance");
                } else
                {
                    Operations.Operation(accountNumber, -ammount, "Withdraw", "current");
                }
                System();
            }
            if (userOption == 5)
            {
                Console.WriteLine("==================\nWelcome to the Customers List Data");
                Customer.listCustomers();
                System();
            }
            if (userOption == 6)
            {
                Console.WriteLine("==================\nWelcome to the Customers List Balance");
                Customer.listCustomersBalances();
                System();
            }
            if (userOption == 6)
            {
                Console.WriteLine("==================\nWelcome to the Bank Statements");
                Console.WriteLine("What is the account number you want to see?");
                String accountNumber = Console.ReadLine();
                Console.WriteLine("Choose an option:" +
                    "\n(1)Current Account" +
                    "\n(2)Savings Account");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 1) Operations.statement(accountNumber, "current");
                if (option == 2) Operations.statement(accountNumber, "savings");
                System();
            }

            if (userOption == 0)
            {
                MainClass.Main();
            }

        }

        private static void Create()
        {
            //5.To create a customer account you need first name, last name and email.
            Console.WriteLine("==================\nWelcome to the Create Panel");
            Console.WriteLine("Please imput the first name of the customer:");
            String firstName = Console.ReadLine();
            Console.WriteLine("Input the last name of the customer:");
            String lastName = Console.ReadLine();
            Console.WriteLine("Input the e-mail of the customer:");
            String email = Console.ReadLine();

            int leghtName = firstName.Length + lastName.Length;
            int numberFirstName = char.ToUpper(firstName[0]) - 64;
            int numberLastName = char.ToUpper(lastName[0]) - 64;


            //The formula to create the account number:
            String accountNumber = firstName[0] + "" + lastName[0] + "-" + leghtName + "-" + numberFirstName + "-" + numberLastName;
            Console.WriteLine("The bank account of " + firstName + " " + lastName + " is " + accountNumber);
            CreateFiles(accountNumber,firstName,lastName,email);
        }

        private static void CreateFiles(String accountNumber, String firstName, String lastName,String  email)
        {
            if (File.Exists("customers.txt"))
            {
                Customer.updateCustomer(accountNumber, firstName, lastName, email);
                Savings.createSavings(accountNumber);
                Current.createCurrent(accountNumber);
                System();
            }
            else
            {
                Console.WriteLine("The customers file does not exists");
                Savings.createSavings(accountNumber);
                Current.createCurrent(accountNumber);
                Customer.createCustomer(accountNumber, firstName, lastName, email);
                System();
            }
        }

        private static void Delete()
        {
            Console.WriteLine("==================\nWelcome to the Delete Panel");
            Console.WriteLine("What is the account code that you wish to delete?");
            String accountNumber = Console.ReadLine();
            Customer.deleteCustomer(accountNumber);
            System();
        }
    }
}
