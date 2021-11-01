using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionConsole
{
    class SpecialDatabaseAccessService : IDatabaseAccessService
    {
        public void DeleteUser(string email)
        {
            Console.WriteLine("DeleteUser From SpecialDatabaseAccessService");
        }

        public void SaveUserInDatabase(string email, string password)
        {
            Console.WriteLine("SaveUserInDatabase from SpecialDatabaseAccessService");
        }

        public void FindSimilarLocationInDatabase()
        {
            
        }
    }
}
