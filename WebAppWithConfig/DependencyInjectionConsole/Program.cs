using System;

namespace DependencyInjectionConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var accountManagementService = new AccountManagementService(new EmailService(), new SpecialDatabaseAccessService());
            accountManagementService.CreateUserAccount("abc@gmail.com","13455");
        }
    }
}
