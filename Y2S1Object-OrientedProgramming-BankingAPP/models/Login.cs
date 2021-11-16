//23952
using System;
namespace Y2S1ObjectOrientedProgrammingBankingAPP.models
{
    public class Login
    {
        public static void validatorSystem(int userOption)
        {
            if (userOption == 1) {
                loginEmployee();
            } else
            {
                loginCustomer();
            }
        }
        private static void loginEmployee()
        {
            Console.WriteLine("Enter the employee password to acces the System");
            String password = Console.ReadLine();
            if (password == "A1234")
            {
                Console.WriteLine("Welcome to the Employee System");
                Employee.System();
            }
            else
            {
                Console.WriteLine("The password is wrong, access denied.");
                MainClass.Main();
            }
        }
        private static void loginCustomer()
        {
            Console.WriteLine("Welcome to the Customer System Access\n" +
                    "To access your Bank Account, please imput your first name:");
            String firstName = Console.ReadLine();
            Console.WriteLine("Input your surname:");
            String lastName = Console.ReadLine();
            Console.WriteLine("What is your account nunber?");
            String accountNumber = Console.ReadLine();
            Console.WriteLine("What is your PIN?");
            String PIN = Console.ReadLine();
            Customer.accessCustomer(firstName,lastName,accountNumber,PIN);
            loginCustomer();
        }
    }
}
