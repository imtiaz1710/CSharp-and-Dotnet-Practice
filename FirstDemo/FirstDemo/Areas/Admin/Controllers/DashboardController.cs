using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "ViewPermission")]
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
