//23952 Itamar Junior
using System;
namespace Y2S1ObjectOrientedProgrammingBankingAPP.models
{
    public class Login
    {
        public static void validatorSystem(int userOption)
        {
            switch (userOption)
            {
                case 1:
                    loginEmployee();
                    break;
                case 2:
                    loginCustomer();
                    break;
            }
        }
        private static void loginEmployee()
        {
            Vanilla.top();
            Console.WriteLine("Enter the employee password to acces the System");
            String password = Console.ReadLine();
            if (password == "A1234")
            {
                Vanilla.top();
                Console.WriteLine("Welcome to the Employee System");
                Employee.System();
            }
            else
            {
                Vanilla.top();
                Console.WriteLine("The password is wrong, access denied.");
                MainClass.Main();
            }
        }
        private static void loginCustomer()
        {
            
            Vanilla.top();
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
