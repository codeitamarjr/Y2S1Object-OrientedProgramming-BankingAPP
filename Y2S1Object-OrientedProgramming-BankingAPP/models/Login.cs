using System;
namespace Y2S1ObjectOrientedProgrammingBankingAPP.models
{
    public class Login
    {
        public static void validatorSystem(int userOption)
        {
            
            if (userOption == 1){
                Console.WriteLine("Welcome to the Employee System");
                models.Employee.System();
            } else
            {
                Console.WriteLine("Welcome to the Customer System");
                models.Customer.System();
            }

          
        }
    }
}
