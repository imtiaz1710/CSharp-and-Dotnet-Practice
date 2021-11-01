using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionConsole
{
    public interface IEmailService
    {
        public string LoginErrorMessage(string email,string errorType);
        public string SendConfirmationEmailToUser(string email);
    }
}
