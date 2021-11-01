using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionConsole
{
    class SpecialDatabaseAccessService : IDatabaseAccessService
    {
        public string DeleteUser(string email)
        {
            return $"DeleteUser From SpecialDatabaseAccessService; Email:{email}";
        }

        public string SaveUserInDatabase(string email, string password)
        {
            return $"SaveUserInDatabase from SpecialDatabaseAccessService; Email:{email}";
        }

        public string FindSimilarLocationInDatabase()
        {
            return "FindSimilarLocationInDatabase from SpecialDatabaseAccessService";
        }
    }
}
