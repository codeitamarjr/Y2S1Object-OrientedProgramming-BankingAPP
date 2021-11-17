﻿using System;
using System.IO;
namespace Y2S1ObjectOrientedProgrammingBankingAPP.models
{
    public class Operations
    {
        public static void Operation(String accountNumber, double ammount, String operation, String sourceAccount)
        {
            //this code will update an account and log the transactions as below:
            //accountNumber, ammount(Positive to add, negative to remove), operation(NAME on the Statement/Log), sourceAccount(current or savings)
            //To add 100 to savings pass 100 to ammount and savings on sourceAccount
            //To remove 100 from current pass -100 to amount and current on sourceAccount
            String today = DateTime.Now.ToString("dd/MM/yyyy");
            string[] accountArray = File.ReadAllText(accountNumber + "-" + sourceAccount + ".txt").Split('\t');
            double balanceAccount = Double.Parse(accountArray[accountArray.Length - 1]);
            double newBalanceSavingsAccount;

            newBalanceSavingsAccount = balanceAccount + ammount;
            //Get the firt letter of the account Uper Case
            string accountUpperCase = char.ToUpper(sourceAccount[0]) + (sourceAccount.Substring(1));

            Console.WriteLine("The Balance of " + accountUpperCase + " Account is " + balanceAccount);
            //read savings and create a new savings temp;
            using (var sreader = new StreamReader(accountNumber + "-" + sourceAccount + ".txt"))
            using (var swriter = new StreamWriter(accountNumber + "-" + sourceAccount + "-temp.txt"))
            //copy lines from savings to savings-temp
            {
                string lines;
                while ((lines = sreader.ReadLine()) != null)
                {
                    swriter.WriteLine(lines);
                }
            }
            //Add the new line with Lodge
            using (StreamWriter sw = File.AppendText(accountNumber + "-" + sourceAccount + "-temp.txt"))
            {
                sw.WriteLine(today + "\t" + operation + "\t" + ammount + "\t" + newBalanceSavingsAccount);
            }
            //Delete the old file and rename removing temp from the file
            File.Delete(accountNumber + "-" + sourceAccount + ".txt");
            File.Move(accountNumber + "-" + sourceAccount + "-temp.txt", accountNumber + "-" + sourceAccount + ".txt");
            Console.WriteLine("The ammount " + ammount + " was " + operation + " from the " + accountUpperCase + " Account with success!" +
                "\nThe new " + accountUpperCase + " Account Balance is " + newBalanceSavingsAccount);
        }

        public static void statement(String accountNumber, String accountSource)
        {
            //This file will print the bank statement based on the accountNumber and accountSource(savings or current)
            Console.WriteLine(char.ToUpper(accountSource[0]) + (accountSource.Substring(1)) + " Statement");
            Console.WriteLine("Date\t\tDesc\t\tAmount\tBalance");
            using (StreamReader sr = new StreamReader(accountNumber + "-" + accountSource + ".txt"))
            {
                string line;
                // Read and print each line from the file until the end of the file is reached. 
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}