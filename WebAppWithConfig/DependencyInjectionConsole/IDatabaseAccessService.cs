using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionConsole
{
    public interface IDatabaseAccessService
    {
        public void SaveUserInDatabase(string email, string password);
        public void DeleteUser(string email);
    }
}
