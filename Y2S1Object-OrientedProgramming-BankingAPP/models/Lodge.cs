//23952
using System;
using System.IO;
namespace Y2S1ObjectOrientedProgrammingBankingAPP.models
{
    public class Lodge
    {
        public static void Operation(String accountNumber, double ammount, String operation, String sourceAccount)
        {
            String today = DateTime.Now.ToString("dd/MM/yyyy");
            string[] accounttArray = File.ReadAllText(accountNumber + "-" + sourceAccount + ".txt").Split('\t');
            double balanceAccount = Double.Parse(accounttArray[accounttArray.Length - 1]);
            double newBalanceSavingsAccount = balanceAccount + ammount;
            Console.WriteLine("The Balance of " + sourceAccount + " Account is " + balanceAccount);
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
            Console.WriteLine("The ammount " + ammount + " was added to the " + sourceAccount + " Account with success!" +
                "\nThe new " + sourceAccount + " Account Balance is " + newBalanceSavingsAccount);
        }
    }
}
