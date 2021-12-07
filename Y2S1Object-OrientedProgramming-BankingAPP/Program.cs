//Student ID 23952 Itamar Junior
using System;
namespace Y2S1ObjectOrientedProgrammingBankingAPP
{
    class MainClass
    {
        public static void Main()
        {
           
            models.Vanilla.top();
            Console.WriteLine("Identifie yourself\n" +
                "(1)Employer\n" +
                "(2)Customer\n" +
                "   Type your option:");
            int userOption = Int32.Parse(Console.ReadLine());
            models.Login.validatorSystem(userOption);
        }
    }
}
