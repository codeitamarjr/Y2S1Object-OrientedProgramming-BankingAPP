//Student ID 23952 Itamar Junior
using System;
namespace Y2S1ObjectOrientedProgrammingBankingAPP
{
    class MainClass
    {
        public static void Main()
        {
            Console.WriteLine("***********************************\n" +
                "Welcome to Banking System" +
                "\n***********************************");

            Console.WriteLine("Identifie yourself\n(1)Employer\n(2)Customer\nType your option:");
            int userOption = Convert.ToInt32(Console.ReadLine());
            models.Login.validatorSystem(userOption);
        }
    }
}
