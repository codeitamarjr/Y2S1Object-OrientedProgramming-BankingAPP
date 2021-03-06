//23952 Itamar Junior
using System;
using System.IO;
namespace Y2S1ObjectOrientedProgrammingBankingAPP.models
{
    public class Customer
    {
        public static void System(String accountNumber)
        {
            Vanilla.top();
            Console.WriteLine("Customer Access Menu for " +accountNumber+
                "\n(1)Bank Statments" +
                "\n(2)Lodge" +
                "\n(3)Withdraw" +
                "\n(4)Transfer from Current to Savings" +
                "\n(5)Transfer from Savings to Current" +
                "\n(6)Transfer to another Customer" +
                "\n(0)Exit and go back to the Main Menu" +
                "\n   Type your option:");

            int userOption = Convert.ToInt32(Console.ReadLine());
            if (userOption == 1)
            {
                Vanilla.top();
                Operations.statement(accountNumber, "current");
                Operations.statement(accountNumber, "savings");
                Console.WriteLine("Press 0 to go back to the menu");
                int optionm = Convert.ToInt32(Console.ReadLine());
                if ( optionm == 0) System(accountNumber);
            }
            if (userOption == 2)
            {
                Vanilla.top();
                Console.WriteLine("What is the ammount you want to lodge?");
                double ammount = Convert.ToDouble(Console.ReadLine());
                Operations.Moviment(accountNumber, ammount, "Lodgement", "current");
                Console.WriteLine("Press 0 to go back to the menu");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 0) System(accountNumber);
            }
            if (userOption == 3)
            {
                Vanilla.top();
                Console.WriteLine("What is the ammount you want to withdraw?");
                double ammount = Convert.ToDouble(Console.ReadLine());
                if (ammount > Current.getCurrent(accountNumber))
                {
                    Console.WriteLine("Insuficient Account Balance");
                } else
                {
                    Operations.Moviment(accountNumber, -ammount, "Withdraw", "current");
                }
                Console.WriteLine("Press 0 to go back to the menu");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 0) System(accountNumber);
            }
            if (userOption == 4)
            {
                Vanilla.top();
                Console.WriteLine("What is the ammount you want to Transfer from your Current Account into your Savings Account?");
                double ammount = Convert.ToDouble(Console.ReadLine());
                if (ammount > Current.getCurrent(accountNumber))
                {
                    Console.WriteLine("Insuficiente Balance");
                }
                else
                {
                    Operations.Moviment(accountNumber, -ammount, "Transfer", "current");
                    Operations.Moviment(accountNumber, ammount, "Transfer", "savings");

                    //Withdraw.Operation(accountNumber, ammount, "Transfer", "current");
                    //Lodge.Operation(accountNumber, ammount, "Transfer", "savings");
                }
                Console.WriteLine("Press 0 to go back to the menu");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 0) System(accountNumber);
            }
            if (userOption == 5)
            {
                Vanilla.top();
                Console.WriteLine("What is the ammount you want to Transfer from your Savings Account into your Current Account?");
                double ammount = Convert.ToDouble(Console.ReadLine());
                if (ammount > Savings.getSavings(accountNumber))
                {
                    Console.WriteLine("Insuficient Balance");
                }
                else
                {
                    Operations.Moviment(accountNumber, -ammount, "Transfer", "savings");
                    Operations.Moviment(accountNumber, ammount, "Transfer", "current");
                    //Withdraw.Operation(accountNumber, ammount, "Transfer", "savings");
                    //Lodge.Operation(accountNumber, ammount, "Transfer", "current");
                }
                Console.WriteLine("Press 0 to go back to the menu");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 0) System(accountNumber);
            }
            if (userOption == 6)
            {
                Vanilla.top();
                Console.WriteLine("==================\nWelcome to the Transfer Panel");
                Console.WriteLine("What is the ammount you want transfer from your account " + accountNumber + "?");
                double ammount = Convert.ToDouble(Console.ReadLine());
                if (ammount > Current.getCurrent(accountNumber))
                {
                    Console.WriteLine("Insuficient Account Balance");
                    Console.WriteLine("Press 0 to go back to the menu");
                    int option = Convert.ToInt32(Console.ReadLine());
                    if (option == 0) System(accountNumber);
                }
                else
                {
                    Console.WriteLine("What is the account number you want to transfer to?");
                    String accountNumberTarget = Console.ReadLine();
                    Console.WriteLine("You are transfering " + ammount + " from " + accountNumber + " to " + accountNumberTarget + "\n" +
                        "Do you want to proceed?\n" +
                        "(1)Yes\n" +
                        "(2)No");
                    int option = Convert.ToInt16(Console.ReadLine());
                    if (option == 1)
                    {
                        Operations.Moviment(accountNumber, -ammount, "To " + accountNumberTarget, "current");
                        Operations.Moviment(accountNumberTarget, ammount, "From " + accountNumber, "current");
                        Console.WriteLine("Press 0 to go back to the menu");
                        option = Convert.ToInt32(Console.ReadLine());
                        if (option == 0) System(accountNumber);
                    }
                    if (option == 2) System(accountNumber);

                    Console.WriteLine("Press 0 to go back to the menu");
                    option = Convert.ToInt32(Console.ReadLine());
                    if (option == 0) System(accountNumber);
                }
            }
            if (userOption == 0)
            {
                Console.Clear();
                MainClass.Main();
            }
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
            //Check if the customer is already on the system before create it again
            //Mount the array with all the customers
            char[] delimit = { '\t', '\n' };
            string[] customersArray = File.ReadAllText("customers.txt").Split(delimit);
            for (int i = 0; i < customersArray.Length; i++)
            {
                if (customersArray[i].Contains(firstName))
                {
                    if (customersArray[i + 1].Contains(lastName))
                    {
                        if (customersArray[i - 1].Contains(newAccountNumber))
                        {
                            if (customersArray[i + 2].Contains(email))
                            {
                                Console.WriteLine("This Customer is already on the system!");
                                Console.WriteLine("Press 0 to go back to the menu");
                                int option = Convert.ToInt32(Console.ReadLine());
                                if (option == 0) Employee.System();
                            }
                        }
                    }
                }
            }




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
                //if the array contains "-" means is an accountNumber
                //for each account number it will print the balance of savings and current
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
            Vanilla.top();
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
                            Console.WriteLine("Accces guaranted for "+firstName);
                                System(accountNumber);
                            } Console.WriteLine("Wrong pin");
                        } Console.WriteLine("Wrong Account Number");
                    } 
                }  
            }
        }
    }
}
