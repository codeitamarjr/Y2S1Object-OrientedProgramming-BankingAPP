using System;
using System.IO;
using System.Text;
namespace Y2S1ObjectOrientedProgrammingBankingAPP.models
{
    public class Employee
    {
        public static void System()
        {
            Console.WriteLine("==================\nAs a bank employee you can:\n(1)Create and\n(2)Delete customers.");
            int userOption = Convert.ToInt32(Console.ReadLine());
            if (userOption == 1)
            {
                Create();
            }
            if (userOption == 2)
             {
                Delete();
            }

        }

        private static void Create()
        //1.As a bank employee you can create and delete customers.
        //2.Each new customer gets a savings account and a current account. 
        {
            Console.WriteLine("==================\nWelcome to the Create Panel");
            Console.WriteLine("Please imput the first name of the customer:");
            String firstName = Console.ReadLine();
            Console.WriteLine("Input the last name of the customer:");
            String lastName = Console.ReadLine();
           
            int leghtName = firstName.Length + lastName.Length;
            int numberFirstName = char.ToUpper(firstName[0]) - 64;
            int numberLastName = char.ToUpper(lastName[0]) - 64;

            String accountNumber = firstName[0] + ""+ lastName[0] + "-" + leghtName + "-"+ numberFirstName + "-" +numberLastName ;
            Console.WriteLine("The bank account of "+ firstName + " " + lastName + " is " + accountNumber);
            CreateFiles(accountNumber);
        }

        private static void CreateFiles(String accountNumber)
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("customers.txt"))
                {
                    string line;
                    // Go through all the lines of the TXT cuscomers file, until the end of the file
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Check if the accountNumber is already on customer txt file
                        if (line == accountNumber)
                        {
                            //If it's already on the customers file nothing will happen
                            Console.WriteLine("This account already exists!");
                            System();

                        }
                        else
                        //If it's not on the customer file, the StreamWriter will create files savings, current and add to the customers.txt
                        {
                            //Open the file
                            Savings.createSavings(accountNumber);
                            Current.createCurrent(accountNumber);
                            Customer.createCustomer(accountNumber);
                            System();
                        }
                    }
                }
                
            }

            catch (Exception e)
            {
                // Let the user know what went wrong, for example if it's the first access to the system
                Console.WriteLine("The file could not be read/found:");
                Console.WriteLine(e.Message);

                Savings.createSavings(accountNumber);
                Current.createCurrent(accountNumber);
                Customer.createCustomer(accountNumber);
                System();
            }
        }



        private static void Delete()
        //3.You can only delete customers who have zero balances. 
        {
            Console.WriteLine("==================\nWelcome to the Delete Panel");
            Console.WriteLine("What is the account code that you wish to delete?");
            String accountNumber = Console.ReadLine();

            using (StreamReader sr = new StreamReader("customers.txt"))
            {
                string line;
                // Go theough all the lines of the TXT cuscomers file, until the end of the file
                while ((line = sr.ReadLine()) != null)
                {
                    //Check if the account is on customer txt file
                    if (line == accountNumber)
                    {
                        Console.WriteLine("Are you sure you want to delete the account " + accountNumber + "?\n(1)Yes\n(2)No");
                        int accountDeleteOption = Convert.ToInt32(Console.ReadLine());

                        if (accountDeleteOption == 1)
                        {

                            Console.WriteLine("The balance of the savings account for this customer is " + Savings.getSavings(accountNumber));
                            Console.WriteLine("The balance of the current account for this customer is " + Current.getCurrent(accountNumber));
                            if (Savings.getSavings(accountNumber) > 0 | Current.getCurrent(accountNumber) > 0)
                            {
                                Console.WriteLine("The balance is "+ ( Savings.getSavings(accountNumber) + Current.getCurrent(accountNumber)  )+ " , make a withdraw to drop it to 0");
                                System();
                            }
                            else {
                                Console.WriteLine("Press 1 to confirm or 2 to cancel:");
                                int userOption = Convert.ToInt32(Console.ReadLine());

                                if (userOption == 1)
                                {


                                    //string tempFile = Path.GetTempFileName();
                                    using (var sreader = new StreamReader("customers.txt"))
                                    using (var swriter = new StreamWriter("customers-temp.txt"))
                                    {
                                        string lines;
                                        while ((lines = sreader.ReadLine()) != null)
                                        {
                                            if (lines != accountNumber)
                                                swriter.WriteLine(lines);
                                        }
                                    }
                                    File.Delete("customers.txt");
                                    File.Move("customers-temp.txt", "customers.txt");
                                    File.Delete(accountNumber+"-savings.txt");
                                    File.Delete(accountNumber + "-current.txt");
                                    Console.WriteLine("The account number was deleted from the Customer DB, savings account and current account also deleted.");
                                    System();
                                }
                                else
                                {
                                    System();
                                }

                            }

                        }
                        else {
                            System();
                        }

                    } else
                    {
                        Console.WriteLine("This account it not on the system\nCheck the account number and try again");
                        Delete();  
                    }
                }

                }

                }
        //4.You can create transactions(lodge, deposit) for each customer. You should be able to add and withdraw for a specified account.
        //5.To create a customer account you need first name, last name and email.
        //6.You should be able to show a complete list of customers including their balances in savings and current account.
        //7.There should be a menu item allowing you to list customers, their account numbers.
    }
}
