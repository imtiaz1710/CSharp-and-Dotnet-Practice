using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionConsole
{
    public class EmailService : IEmailService
    {
        public string LoginErrorMessage(string email, string errorType)
        {
            return "LoginErrorMessage from EmailService";
        }


        public string SendConfirmationEmailToUser(string email)
        {
            return "sendConfirmationEmailToUser from EmailService";
        }
    }
}
