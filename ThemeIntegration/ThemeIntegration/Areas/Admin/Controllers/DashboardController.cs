using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThemeIntegration.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Form()
        {
            return View();
        }
    }
}
