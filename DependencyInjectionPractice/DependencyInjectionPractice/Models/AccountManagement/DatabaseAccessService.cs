using DependencyInjectionPractice.Models.AccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionConsole
{
    class DatabaseAccessService : IDatabaseAccessService
    {
        private IDriverService _driverService;
        public DatabaseAccessService(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public string DeleteUser(string email)
        {
            return $"DelteUser from DatabaseAccessService;Email={email}";
        }

        public string SaveUserInDatabase(string email, string password)
        {
            return $"SaveUserInDatabase from DatabaseAccessService; Email={email} + DriverClass = {_driverService.run()}";
        }

    }
}
