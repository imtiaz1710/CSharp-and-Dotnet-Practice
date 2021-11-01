using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionPractice.Models.AccountManagement
{
    public class DriverService : IDriverService
    {
        public string run()
        {
            return "Run() from DriverService";
        }
    }
}
