﻿using System;
using System.IO;
using System.Text;
namespace Y2S1ObjectOrientedProgrammingBankingAPP.models
{
    public class Current
    {
        
        public static double getCurrent(String accountNumber)
        {
            StreamReader sr = new StreamReader(accountNumber + "-current.txt");
            //add all values of current in an Array splitted by tab
            string[] currentArray = File.ReadAllText(accountNumber + "-current.txt").Split('\t');
            //get the last value of the savingsArray which is the balance of this saving account
            int lastItem = currentArray.Length - 1;
            //Parse the String to a Double and return it
            return Double.Parse(currentArray[lastItem]);
        }
        public static void createCurrent(String accountNumber)
        {
            String today = DateTime.Now.ToString("dd/MM/yyyy");
            StreamWriter sw = new StreamWriter(accountNumber + "-current.txt", true, Encoding.ASCII);
            sw.WriteLine(today + "\tStart\t" + 0 + "\t" + 0);
            Console.WriteLine("The Current Account has been created with success!");
            sw.Close();
        }
        public static void history(String accountNumber)
        {
            Console.WriteLine("Current History");
            Console.WriteLine("Date\t\tDesc\tAmount\tBalance");
            using (StreamReader sr = new StreamReader(accountNumber + "-current.txt"))
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

     
    }
}
