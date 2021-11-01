using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionConsole
{
    public class AccountManagementService
    {

        private IEmailService _emailService { get; set; }
        public IDatabaseAccessService _databaseAccessService { get; set; }
        public AccountManagementService(IEmailService emailService,IDatabaseAccessService databaseAccessService)
        {
            _emailService = emailService;
            _databaseAccessService = databaseAccessService;
        }

        public void CreateUserAccount(string email,string password)
        {

            if(!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                try
                {
                    _databaseAccessService.SaveUserInDatabase(email, password);
                    _emailService.SendConfirmationEmailToUser(email);
                }
                catch (Exception)
                {
                    _databaseAccessService.DeleteUser(email);
                    _emailService.LoginErrorMessage(email,"Ivalid formate. Can't Create Account. Check your email or password");
                }
            }

        }
    }
}
