//Student ID 23952 Itamar Junior
using System;

namespace Y2S1ObjectOrientedProgrammingBankingAPP
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Banking TriploXXX System");

            Console.WriteLine("Are you a: \n1-Employee or an \n2-Customer? \nType your option:");

            int userOption = Convert.ToInt32(Console.ReadLine());

            models.Login.validatorSystem(userOption);

        }
    }
}
