using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionConsole
{
    public class AccountManagementService
    {

        public IEmailService emailService { get; set; }
        public IDatabaseAccessService databaseAccessService { get; set; }
        
    }
}
