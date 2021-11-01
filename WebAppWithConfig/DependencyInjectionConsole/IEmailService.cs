using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionConsole
{
    public interface IEmailService
    {
        public void LoginErrorMessage(string email,string errorType);
        public void SendConfirmationEmailToUser(string email);
    }
}
