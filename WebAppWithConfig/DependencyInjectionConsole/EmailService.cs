using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionConsole
{
    public class EmailService : IEmailService
    {
        public void LoginErrorMessage(string email, string errorType)
        {
            Console.WriteLine("LoginErrorMessage from EmailService");
        }


        public void SendConfirmationEmailToUser(string email)
        {
            Console.WriteLine("sendConfirmationEmailToUser from EmailService");
        }
    }
}
