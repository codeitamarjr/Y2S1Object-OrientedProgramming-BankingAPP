//23952
using System;
using System.IO;
namespace Y2S1ObjectOrientedProgrammingBankingAPP.models
{
    public class Customer
    {
        public static void System(String accountNumber)
        {
            Console.WriteLine("As a Customer you can:" +
                "\n(1)Retrieve the Transaction History" +
                "\n(2)Lodge" +
                "\n(3)Withdraw" +
                "\n(4)Transfer from Current to Savings" +
                "\n(5)Transfer from Savings to Current" +
                "\n(0)Exit and go back to the Main Menu");

            int userOption = Convert.ToInt32(Console.ReadLine());
            if (userOption == 1)
            {
                Current.history(accountNumber);
                Savings.history(accountNumber);
                System(accountNumber);
            }
            if (userOption == 2)
            {
                Console.WriteLine("What is the ammount you want to lodge?");
                double ammount = Convert.ToDouble(Console.ReadLine());
                Lodge.Operation(accountNumber, ammount, "Lodgement", "current");
                System(accountNumber);
            }
            if (userOption == 3)
            {
                Console.WriteLine("What is the ammount you want to withdraw?");
                double ammount = Convert.ToDouble(Console.ReadLine());
                if (ammount > Current.getCurrent(accountNumber))
                {
                    Console.WriteLine("Insuficient Account Balance");
                } else
                {
                    Withdraw.Operation(accountNumber, ammount, "Withdraw", "current");
                }
                System(accountNumber);
            }
            if (userOption == 4)
            {
                Console.WriteLine("What is the ammount you want to Transfer from your Current Account into your Savings Account?");
                double ammount = Convert.ToDouble(Console.ReadLine());
                if (ammount > Current.getCurrent(accountNumber))
                {
                    Console.WriteLine("Insuficiente Balance");
                }
                else
                {
                    Withdraw.Operation(accountNumber, ammount, "Transfer", "current");
                    Lodge.Operation(accountNumber, ammount, "Transfer", "savings");
                }
                System(accountNumber);
            }
            if (userOption == 5)
            {
                Console.WriteLine("What is the ammount you want to Transfer from your Savings Account into your Current Account?");
                double ammount = Convert.ToDouble(Console.ReadLine());
                if (ammount > Savings.getSavings(accountNumber))
                {
                    Console.WriteLine("Insuficient Balance");
                }
                else
                {

                    Withdraw.Operation(accountNumber, ammount, "Transf:C>S", "savings");
                    Lodge.Operation(accountNumber, ammount, "Transf:C>S", "current");
                }
                System(accountNumber);

            }

            if (userOption == 0)
            {
                MainClass.Main();
            }
            //1.To login, a customer must enter their name, account code AND a pin number for their account
            //2.A customer can retrieve the transaction history for their specified account.
            //3.They can add and subtract money to either their savings account or current account.
            //4.They cannot have negative balances
        }
        public static void createCustomer(String accountNumber, String firstName, String lastName, String email)
        {
            StreamWriter sw = new StreamWriter("customers.txt");
            sw.WriteLine(accountNumber + "\t" + firstName + "\t" + lastName + "\t" + email);
            Console.WriteLine("Customers file was created and account added to the customers file");
            sw.Close();
        }

        public static void updateCustomer(string newAccountNumber, String firstName, String lastName, String email)
        {
            //read customer and create a new customers temp
            using (var sreader = new StreamReader("customers.txt"))
            using (var swriter = new StreamWriter("customers-temp.txt"))
            //copy lines from customers to cusmtomers-temp
            {
                string lines;
                while ((lines = sreader.ReadLine()) != null)
                {
                    if (lines != newAccountNumber)
                    {
                        swriter.WriteLine(lines);
                    }
                }
            }
            //write the new account at the customers-temp file
            using (StreamWriter sw = File.AppendText("customers-temp.txt"))
            {
                sw.WriteLine(newAccountNumber + "\t" + firstName + "\t" + lastName + "\t" + email);
            }
            //After all data was copy from customers to customers-temp, delete the old file
            //and rename removing temp from the file
            File.Delete("customers.txt");
            File.Move("customers-temp.txt", "customers.txt");
            Console.WriteLine("The account number was add to the Customer File/DB with success!");
        }
        public static void deleteCustomer(String accountNumber)
        {
            if (Savings.getSavings(accountNumber) > 0 | Current.getCurrent(accountNumber) > 0)
            {
                Console.WriteLine("The balance is " + (Savings.getSavings(accountNumber) + " Savings and " + Current.getCurrent(accountNumber)) + " on Current Account , make a withdraw to drop it to 0");
            }
            else
            {
                Console.WriteLine("Press 1 to confirm or 2 to cancel:");
                int userOption = Convert.ToInt32(Console.ReadLine());
                if (userOption == 1)
                {
                    //read customer and create a new customers-temp
                    using (var sreader = new StreamReader("customers.txt"))
                    using (var swriter = new StreamWriter("customers-temp.txt"))
                    //copy lines from customers to string lines
                    {
                       
                        string lines;
                        while ((lines = sreader.ReadLine()) != null)
                        {
                            //If the line is does not contain the account number
                            //copy the line to the customers-temp.txt
                            if (!lines.Contains(accountNumber))
                            {
                                swriter.WriteLine(lines);
                            }
                        }
                    }
                    //After all data was copy from customers to customers-temp(Skiping the
                    //account to delete), delete the old file customers file and
                    //rename removing temp from the new file(Also delete savings and current of this accountNumber)
                    File.Delete("customers.txt");
                    File.Delete(accountNumber + "-savings.txt");
                    File.Delete(accountNumber + "-current.txt");
                    File.Move("customers-temp.txt", "customers.txt");
                    Console.WriteLine("The account number "+ accountNumber + " was deleted from the Customer DB, savings account and current account also deleted.");
                }
                if (userOption == 2)
                    Console.WriteLine("Operation cancelled.");
            }
        }
        public static void listCustomers()
        {
            Console.WriteLine("Account\t\tName\tSurname\tEmail");
            using (StreamReader sr = new StreamReader("customers.txt"))
            {
                string line;
                // Read and display lines from the file until 
                // the end of the file is reached. 
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        public static void listCustomersBalances()
        {
            //add all values of customers in an Array splitted by tab or newline
            char[] delimit = {'\t' ,'\n'};
            string[] customersArray = File.ReadAllText("customers.txt").Split(delimit);
            Console.WriteLine("Account\t\tName\tCurrent\tSavings");
            for (int i = 0; i < customersArray.Length; i++)
            {
                if (customersArray[i].Contains("-"))
                {
                    Console.WriteLine(customersArray[i]+"\t"+ customersArray[i+1] +
                        "\t"+ Current.getCurrent(customersArray[i]) +
                        "\t"+ Savings.getSavings(customersArray[i]));
                }
            }
        }
        public static void accessCustomer(String firstName, String lastName, String accountNumber, String PIN)
        {
            char[] delimit = { '\t', '\n' };
            string[] customersArray = File.ReadAllText("customers.txt").Split(delimit);

            int numberFirstName = char.ToUpper(firstName[0]) - 64;
            int numberLastName = char.ToUpper(lastName[0]) - 64;
            String password = numberFirstName +""+ numberLastName;
            for (int i = 0; i < customersArray.Length; i++)
            {
                if (customersArray[i].Contains(firstName))
                {
                    if (customersArray[i + 1].Contains(lastName))
                    {
                        if (customersArray[i - 1].Contains(accountNumber))
                        {
                            if ( password == PIN)
                            {
                            Console.WriteLine("Accces guaranted");
                                System(accountNumber);
                            }
                        }
                    }
                } 
            }
        }
    }
}
