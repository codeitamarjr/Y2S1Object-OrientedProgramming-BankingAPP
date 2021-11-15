﻿using System;
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
        public static void createSavings(String accountNumber)
        {
            StreamWriter sw = new StreamWriter(accountNumber + "-savings.txt", true, Encoding.ASCII);
            String today = DateTime.Now.ToString("dd/MM/yyyy");
            sw.WriteLine(today + "\tStart\t" + 0 + "\t" + 0);
            Console.WriteLine("The Savings Account has been created with success!");
            sw.Close();
        }
    }
}