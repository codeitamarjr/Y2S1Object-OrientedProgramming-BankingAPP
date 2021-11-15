using System;
using System.IO;
using System.Text;
namespace Y2S1ObjectOrientedProgrammingBankingAPP.models
{
    public class Savings
    {
        public Savings()
        {
        }

        public static double getSavings(String accountNumber)
        {
            StreamReader sr = new StreamReader(accountNumber + "-savings.txt");
            //add all values of savings in an Array splitted by tab
            string[] savingsArray = File.ReadAllText(accountNumber + "-savings.txt").Split('\t');
            //get the last value of the savingsArray which is the balance of this saving account
            int lastItem = savingsArray.Length-1;
            //Parse the String to a Double and return it
            return Double.Parse(savingsArray[lastItem]) ;
        }

    }
}