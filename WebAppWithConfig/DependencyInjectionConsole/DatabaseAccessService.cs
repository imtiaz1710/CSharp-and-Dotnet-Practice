using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionConsole
{
    class DatabaseAccessService : IDatabaseAccessService
    {
        public void DeleteUser(string email)
        {
            Console.WriteLine("DelteUser from DatabaseAccessService");
        }

        public void SaveUserInDatabase(string email, string password)
        {
            Console.WriteLine("SaveUserInDatabase from DatabaseAccessService");
        }
    }
}
