using DependencyInjectionConsole;
using FristDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionPractice.Controllers
{
    public class AccountController : Controller
    {
        private IEmailService _emailService { get; set; }
        private IDatabaseAccessService _databaseAccessService { get; set; }
        public AccountController(IEmailService emailService, IDatabaseAccessService databaseAccessService)
        {
            _emailService = emailService;
            _databaseAccessService = databaseAccessService;
        }
        
        public IActionResult AccountServices()
        {
            var accountManagementService = new AccountManagementService();
            accountManagementService.emailService = _emailService;
            accountManagementService.databaseAccessService = _databaseAccessService;
            return View(accountManagementService);
        }

        public IActionResult Test()
        {
            var model = new TestModel();
            return View(model);
        }
    }
}
