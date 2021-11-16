//23952
using System;
using System.IO;
namespace Y2S1ObjectOrientedProgrammingBankingAPP.models
{
    public class Withdraw
    {
        public static void Operation(String accountNumber, double ammount, String operation, String sourceAccount)
        {
            String today = DateTime.Now.ToString("dd/MM/yyyy");
            string[] accountArray = File.ReadAllText(accountNumber + "-"+ sourceAccount +".txt").Split('\t');
            double balanceAccount = Double.Parse(accountArray[accountArray.Length -1]);

            if ( ammount > balanceAccount)
            {
                Console.WriteLine("Insuficient Balance: "+balanceAccount);
            } else
            {
             //Get the firt letter of the account Uper Case
             string accountUpperCase = char.ToUpper(sourceAccount[0]) + (sourceAccount.Substring(1));

            double newBalanceSavingsAccount = balanceAccount - ammount;
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
            Console.WriteLine("The ammount " + ammount + " was withdraw from the " + accountUpperCase + " Account with success!" +
                "\nThe new " + accountUpperCase + " Account Balance is " + newBalanceSavingsAccount);
            }
        }
    }
}
